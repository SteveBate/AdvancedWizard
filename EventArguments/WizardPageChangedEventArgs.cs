using System;
using AdvancedWizardControl.WizardPages;

namespace AdvancedWizardControl.EventArguments
{
    public class WizardPageChangedEventArgs : EventArgs
    {
        public WizardPageChangedEventArgs(AdvancedWizardPage page, int pageIndex)
        {
            Page = page;
            _pageIndex = pageIndex;
        }

        private AdvancedWizardPage _page;
        public AdvancedWizardPage Page
        {
            get { return _page; }
            set { _page = value; }
        }

        private readonly int _pageIndex;
        public int PageIndex
        {
            get { return _pageIndex; }
        }
    }
}