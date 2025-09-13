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
        private List<(string Account, bool Read, bool Write, bool FullControl)> _selections
        = new List<(string, bool, bool, bool)>();
        public AccessFrm()
        {
            InitializeComponent();
        }

        public List<(string Account, bool Read, bool Write, bool FullControl)> GetSelections()
        {
            return _selections;
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

            SetBtn.Enabled = AccountAccessViewer.Items
                .Cast<ListViewItem>()
                .Any(it => it.SubItems.Cast<ListViewItem.ListViewSubItem>()
                    .Skip(2)
                    .Any(sub => sub.Text == "[x]"));
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

            string currentUser = WindowsIdentity.GetCurrent().Name;
            string currentSam = currentUser.Contains("\\")
                ? currentUser.Split('\\').Last() // extract SamAccountName if DOMAIN\User
                : currentUser;

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

                        // Default state: unchecked
                        item.SubItems.Add("[ ]"); // Read
                        item.SubItems.Add("[ ]"); // Write
                        item.SubItems.Add("[ ]"); // Full Control

                        if (user.SamAccountName.Equals(currentSam, StringComparison.OrdinalIgnoreCase))
                        {
                            item.SubItems[4].Text = "[x]";
                        }

                        AccountAccessViewer.Items.Add(item);
                    }
                }
            }

            // Ensure the "Set" button is enabled since one rule (current user) is guaranteed
            SetBtn.Enabled = true;
        }

        private void SetBtn_Click(object sender, EventArgs e)
        {
            _selections.Clear();

            foreach (ListViewItem item in AccountAccessViewer.Items)
            {
                _selections.Add((
                    Account: item.Text,
                    Read: item.SubItems[2].Text == "[x]",
                    Write: item.SubItems[3].Text == "[x]",
                    FullControl: item.SubItems[4].Text == "[x]"
                ));
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
