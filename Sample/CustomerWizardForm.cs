using System;
using System.Windows.Forms;
using AdvancedWizardControl.Enums;
using AdvancedWizardControl.EventArguments;

namespace Sample
{
    public partial class CustomerWizardForm : Form
    {
        public CustomerWizardForm()
        {
            InitializeComponent();
            advancedWizard1.FlatStyle = FlatStyle.Standard;
            advancedWizard1.NextButtonEnabled = true;
        }

        private void WhenPage2IsShown(object sender, WizardPageEventArgs e)
        {
            MessageBox.Show(@"Showing page 2");
        }

        private void WhenUserClicksNext(object sender, WizardEventArgs e)
        {
            if (e.CurrentPageIndex != 1) return;

            errorProvider1.SetError(txtFirstName, string.IsNullOrEmpty(txtFirstName.Text) ? txtFirstName.Tag.ToString() : string.Empty);
            errorProvider1.SetError(txtSurname, string.IsNullOrEmpty(txtSurname.Text) ? txtSurname.Tag.ToString() : string.Empty);
            e.AllowPageChange = !string.IsNullOrEmpty(txtFirstName.Text) && !string.IsNullOrEmpty(txtSurname.Text);
        }

        private void WhenUserClicksBack(object sender, WizardEventArgs e)
        {
            if (e.CurrentPageIndex == 2)
            {
                var answer = MessageBox.Show(@"Go back. Are you sure?", @"Close DataPort", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                e.AllowPageChange = answer != DialogResult.Cancel;
            }
        }

        private void WhenOnLastPage(object sender, EventArgs e)
        {
            MessageBox.Show(@"last page!");
        }

        private void WhenUserClicksFinish(object sender, EventArgs e)
        {
            MessageBox.Show(@"You clicked Finish");
        }

        private void WhenUserClicksCancel(object sender, EventArgs e)
        {
            MessageBox.Show(@"You clicked Cancel");
        }

        private void WhenUserClicksHelp(object sender, EventArgs e)
        {
            MessageBox.Show(@"You clicked Help");
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            var ctl = (Control) sender;
            errorProvider1.SetError(ctl, string.IsNullOrEmpty(ctl.Text) ? ctl.Tag.ToString() : string.Empty);
        }

        private void OnHelpCheckChange(object sender, EventArgs e)
        {
            advancedWizard1.HelpButton = chkHelp.Checked;
        }

        private void OnCancelCheckChange(object sender, EventArgs e)
        {
            advancedWizard1.CancelButton = chkCancel.Checked;
        }

        private void OnFinishCheckChange(object sender, EventArgs e)
        {
            advancedWizard1.FinishButton = chkFinish.Checked;
        }

        private void OnDefaultCheckChange(object sender, EventArgs e)
        {
            advancedWizard1.ButtonLayout = ButtonLayoutKind.Default;
            chkCancel.Checked = chkHelp.Checked = chkFinish.Checked = true;
        }

        private void OnOfficeCheckChange(object sender, EventArgs e)
        {
            advancedWizard1.ButtonLayout = ButtonLayoutKind.Office97;
            chkCancel.Checked = chkHelp.Checked = chkFinish.Checked = true;
        }
    }
}