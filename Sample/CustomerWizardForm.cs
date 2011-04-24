using System;
using System.Windows.Forms;
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
            advancedWizard1.LastPage += advancedWizard1_LastPage;
        }

        private void advancedWizard1_LastPage(object sender, EventArgs e)
        {
            MessageBox.Show("last page!");
        }

        private void advancedWizard1_Next(object sender, WizardEventArgs e)
        {
        }

        private void advancedWizard1_Finish(object sender, EventArgs e)
        {
        }

        private void wizardPage1_PageShow(object sender, WizardPageEventArgs e)
        {
            MessageBox.Show("PageShow");
        }
    }
}