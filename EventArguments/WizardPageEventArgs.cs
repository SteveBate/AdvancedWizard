using System;
using AdvancedWizardControl.WizardPages;

namespace AdvancedWizardControl.EventArguments
{
    public class WizardPageEventArgs : EventArgs
    {
        public WizardPageEventArgs(AdvancedWizardPage page)
        {
            Page = page;
        }

        public AdvancedWizardPage Page { get; }
    }
}