using System.ComponentModel.Design;
using AdvancedWizardControl.Enums;
using AdvancedWizardControl.EventArguments;
using AdvancedWizardControl.Wizard;
using AdvancedWizardControl.WizardPages;

namespace AdvancedWizardControl.Strategies
{
    public class RuntimeWizardStrategy : WizardStrategy
    {
        #region constructor
        
        public RuntimeWizardStrategy(AdvancedWizard wizard)
        {
            _wizard = wizard;
        } 

        #endregion

        #region public

        public override void Loading()
        {
            if (_wizard.HasPages())
            {
                GoToPage(0);
            }
        }

        public override void SetButtonStates()
        {
            if (_wizard.OnLastPage() && _wizard.HasOnePage())
            {
                _wizard.BackButtonEnabled = false;
                _wizard.NextButtonEnabled = false;
                return;
            }

            if (_wizard.OnLastPage() && _wizard.HasExplicitFinishButton())
            {
                _wizard.BackButtonEnabled = true;
                _wizard.NextButtonEnabled = false;
                return;
            }

            if (_wizard.OnLastPage())
            {
                _wizard.BackButtonEnabled = true;
                _wizard.FinishButtonEnabled = true;
                _wizard.SetButtonText("btnNext", _wizard.FinishButtonText);
                return;
            }

            if (_wizard.OnFirstPage())
            {
                _wizard.BackButtonEnabled = false;
                _wizard.NextButtonEnabled = _wizard.WizardPages.Count > 1; //_wizard._nextButtonEnabledState;
                _wizard.SetButtonText("btnNext", _wizard.ReadNextText());
                return;
            }

            if (_wizard.OnAMiddlePage())
            {
                _wizard.BackButtonEnabled = true;
                _wizard.NextButtonEnabled = _wizard.NextButtonEnabledState;
                _wizard.SetButtonText("btnNext", _wizard.ReadNextText());
                return;
            }
        }

        public override void Cancel()
        {
            if (_wizard.CancelEventAssigned())
                _wizard.FireCancelEvent();
        }

        public override void Help()
        {
            if (_wizard.HelpEventAssigned())
                _wizard.FireHelpEvent();
        }

        public override void Finish()
        {
            if (_wizard.FinishEventAssigned())
                _wizard.FireFinishEvent();
        }

        public override void Back(ISelectionService selection)
        {
            MoveToPreviousPage();
            SetButtonStates();
        }

        public override void Next(ISelectionService selection)
        {
            if (Finishing()) return;

            WizardEventArgs args;

            if (UserAllowsMoveToProceed(Direction.Forward, out args) && _wizard.MoreThanOnePageExists())
            {
                MoveToNextPage(args);
                SetButtonStates();
            }
        }

        public override void GoToPage(int pageIndex)
        {
            int index = _wizard.IndexOfCurrentPage();
            _wizard.SelectWizardPage(pageIndex);
            _wizard.StoreIndexOfCurrentPage(index);

            _wizard.CurrentPage.FirePageShowEvent();

            if (_wizard.PageChangedEventAssigned())
                _wizard.FirePageChanged(_wizard.IndexOfCurrentPage());
        }

        public override void GoToPage(AdvancedWizardPage page)
        {
            int index = _wizard.IndexOfCurrentPage();
            _wizard.SelectWizardPage(page);
            _wizard.StoreIndexOfCurrentPage(index);
            SetButtonStates();

            page.FirePageShowEvent();

            if (_wizard.PageChangedEventAssigned())
                _wizard.FirePageChanged(_wizard.IndexOfCurrentPage());
        }

        #endregion **** public members ****

        #region private

        private readonly AdvancedWizard _wizard;

        private bool UserAllowsMoveToProceed(Direction direction, out WizardEventArgs eventArgs)
        {
            WizardEventArgs args = direction == Direction.Forward ? AttemptMoveToNextPage() : AttemptMoveToPreviousPage();

            eventArgs = args;

            return args.AllowPageChange;
        }

        private void MoveToPreviousPage()
        {
            _wizard.SelectWizardPage(_wizard.ReadIndexOfPreviousPage());

            _wizard.NextButtonEnabledState = true;
            int pageIndex = _wizard.IndexOfCurrentPage();

            _wizard.WizardPages[pageIndex].FirePageShowEvent();

            if (_wizard.PageChangedEventAssigned())
                _wizard.FirePageChanged(pageIndex);
        }

        private void MoveToNextPage(WizardEventArgs args)
        {
            if (CanMoveToNextPage(args))
            {
                _wizard.SelectWizardPage(args.NextPageIndex);
                _wizard.StoreIndexOfCurrentPage(args.CurrentPageIndex);

                _wizard.WizardPages[args.NextPageIndex].FirePageShowEvent();

                if (_wizard.PageChangedEventAssigned())
                    _wizard.FirePageChanged(args.NextPageIndex);

                if (args.NextPageIndex == _wizard.WizardPages.Count - 1)
                    if (_wizard.LastPageEventAssigned())
                        _wizard.FireLastPage();
            }
        }

        private bool CanMoveToNextPage(WizardEventArgs args)
        {
            return args.NextPageIndex < _wizard.WizardPages.Count;
        }

        private WizardEventArgs AttemptMoveToPreviousPage()
        {
            WizardEventArgs ev = FireBackEvent() ?? new WizardEventArgs(_wizard.IndexOfCurrentPage());

            return ev;
        }

        private WizardEventArgs AttemptMoveToNextPage()
        {
            WizardEventArgs ev = FireNextEvent() ?? new WizardEventArgs(_wizard.IndexOfCurrentPage());

            return ev;
        }

        private WizardEventArgs FireBackEvent()
        {
            int currentTabIndex = _wizard.IndexOfCurrentPage();
            WizardEventArgs ev = null;

            if (_wizard.BackEventAssigned())
            {
                ev = _wizard.FireBackEvent(currentTabIndex);
                int newTabIndex;
                bool allowPageToChange;
                _wizard.CheckForUserChangesToEventParameters(ev, out allowPageToChange, out newTabIndex);
            }

            return ev;
        }

        private WizardEventArgs FireNextEvent()
        {
            int currentTabIndex = _wizard.IndexOfCurrentPage();
            WizardEventArgs ev = null;

            // may neede to go to a user specified page
            if (_wizard.NextEventAssigned())
            {
                ev = _wizard.FireNextEvent(currentTabIndex);
                bool allowPageToChange;
                int newTabIndex;
                _wizard.CheckForUserChangesToEventParameters(ev, out allowPageToChange, out newTabIndex);
            }

            return ev;
        }

        private bool Finishing()
        {
            bool result = false;

            if (_wizard.OnLastPage() && !_wizard.HasExplicitFinishButton())
            {
                if (_wizard.FinishEventAssigned())
                    _wizard.FireFinishEvent(); // pass on System.EventArgs

                result = true;
            }

            return result;
        }

        #endregion
    }
}