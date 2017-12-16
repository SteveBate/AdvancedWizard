using System;
using AdvancedWizardControl.WizardPages;

namespace AdvancedWizardControl.EventArguments
{
    public class WizardPageChangedEventArgs : EventArgs
    {
        public WizardPageChangedEventArgs(AdvancedWizardPage page, int pageIndex)
        {
            Page = page;
            PageIndex = pageIndex;
        }

        public AdvancedWizardPage Page { get; set; }

        public int PageIndex { get; }
    }
}