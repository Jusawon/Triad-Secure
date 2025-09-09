using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triad_Secure
{
    public partial class AccessFrm : Form
    {
        public AccessFrm()
        {
            InitializeComponent();
        }

        private void AccessFrm_Load(object sender, EventArgs e)
        {
            AccountAccessViewer.View = View.Details;
            AccountAccessViewer.FullRowSelect = true;
            AccountAccessViewer.GridLines = true;

            AccountAccessViewer.Columns.Add("Account", 200);
            AccountAccessViewer.Columns.Add("Type", 100);
            AccountAccessViewer.Columns.Add("Read", 80);
            AccountAccessViewer.Columns.Add("Write", 80);
            AccountAccessViewer.Columns.Add("Full Control", 100);

            PopulateAccounts();

            SetBtn.Enabled = false;
        }

        private void AccountAccessViewer_MouseClick(object sender, MouseEventArgs e)
        {
            var hit = AccountAccessViewer.HitTest(e.Location);
            if (hit.SubItem != null && hit.Item != null)
            {
                int colIndex = hit.Item.SubItems.IndexOf(hit.SubItem);

                if (colIndex >= 2)
                {
                    hit.SubItem.Text = (hit.SubItem.Text == "[x]") ? "[ ]" : "[x]";
                }

                SetBtn.Enabled = AccountAccessViewer.Items
                    .Cast<ListViewItem>()
                    .Any(it => it.SubItems.Cast<ListViewItem.ListViewSubItem>()
                        .Skip(2)
                        .Any(sub => sub.Text == "[x]"));
            }
        }

        private void PopulateAccounts()
        {
            AccountAccessViewer.Items.Clear();

            using (var ctx = new PrincipalContext(ContextType.Machine))
            {
                // --- Users ---
                using (var userSearcher = new PrincipalSearcher(new UserPrincipal(ctx)))
                {
                    foreach (var result in userSearcher.FindAll())
                    {
                        var user = result as UserPrincipal;
                        if (user == null) continue;

                        var item = new ListViewItem(user.SamAccountName);
                        item.SubItems.Add("User");
                        item.SubItems.Add("[ ]"); // Read
                        item.SubItems.Add("[ ]"); // Write
                        item.SubItems.Add("[ ]"); // Full Control
                        AccountAccessViewer.Items.Add(item);
                    }
                }

                // --- Groups ---
                using (var groupSearcher = new PrincipalSearcher(new GroupPrincipal(ctx)))
                {
                    foreach (var result in groupSearcher.FindAll())
                    {
                        var group = result as GroupPrincipal;
                        if (group == null) continue;

                        var item = new ListViewItem(group.SamAccountName);
                        item.SubItems.Add("Group");
                        item.SubItems.Add("[ ]"); // Read
                        item.SubItems.Add("[ ]"); // Write
                        item.SubItems.Add("[ ]"); // Full Control
                        AccountAccessViewer.Items.Add(item);
                    }
                }
            }
        }

        private void SetBtn_Click(object sender, EventArgs e)
        {
            var selections = new List<(string Account, bool Read, bool Write, bool FullControl)>();

            foreach (ListViewItem item in AccountAccessViewer.Items)
            {
                selections.Add((
                    Account: item.Text,
                    Read: item.SubItems[2].Text == "[x]",
                    Write: item.SubItems[3].Text == "[x]",
                    FullControl: item.SubItems[4].Text == "[x]"
                ));
            }

            // Example: just debug print
            foreach (var sel in selections.Where(s => s.Read || s.Write || s.FullControl))
            {
                Debug.WriteLine($"{sel.Account}: Read={sel.Read}, Write={sel.Write}, FullControl={sel.FullControl}");
            }

            // Later: apply to file wrapper after encryption
        }
    }
}
