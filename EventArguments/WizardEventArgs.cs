using System;
using AdvancedWizardControl.Enums;

namespace AdvancedWizardControl.EventArguments
{
    /// <summary>
    /// Add AllowPageChange property to allow user to determine whether or not 
    /// the application user can proceed
    /// </summary>
    public class WizardEventArgs : EventArgs
    {
        public WizardEventArgs(int currentPageIndex, Direction direction = Direction.Forward)
        {
            CurrentPageIndex = currentPageIndex;
            NextPageIndex = direction == Direction.Forward ? currentPageIndex + 1 : currentPageIndex - 1;
            AllowPageChange = true;
        }

        public bool AllowPageChange { get; set; }
        public int CurrentPageIndex { get; }
        public int NextPageIndex { get; set; }
    }
}