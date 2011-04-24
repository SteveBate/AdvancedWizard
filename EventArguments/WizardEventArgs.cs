using System;

namespace AdvancedWizardControl.EventArguments
{
    /// <summary>
    /// Add AllowPageChange property to allow user to determine whether or not 
    /// the application user can proceed
    /// </summary>
    public class WizardEventArgs : EventArgs
    {
        public WizardEventArgs(int currentPageIndex)
        {
            CurrentPageIndex = currentPageIndex;
            NextPageIndex = currentPageIndex + 1; // defaults to the very next page after the current one
            AllowPageChange = true;
        }

        public bool AllowPageChange { get; set; }
        public int CurrentPageIndex { get; private set; }
        public int NextPageIndex { get; set; }
    }
}