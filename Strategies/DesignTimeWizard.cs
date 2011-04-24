using System.ComponentModel.Design;
using AdvancedWizardControl.Wizard;
using AdvancedWizardControl.WizardPages;

namespace AdvancedWizardControl.Strategies
{
    public class DesignTimeWizardStrategy : WizardStrategy
    {
        #region constructor
        
        public DesignTimeWizardStrategy(AdvancedWizard wizard)
        {
            _wizard = wizard;
        } 

        #endregion

        #region public

        public override void Loading()
        {
            if (_wizard.HasPages())
                _wizard.SelectFirstPage();
        }

        public override void SetButtonStates()
        {
            if (!_wizard.HasPages() || _wizard.HasOnePage())
            {
                _wizard.BackButtonEnabled = false;
                _wizard.NextButtonEnabled = false;
                return;
            }

            if (_wizard.OnFirstPage() && _wizard.MoreThanOnePageExists())
            {
                _wizard.BackButtonEnabled = false;
                _wizard.NextButtonEnabled = true;
                _wizard.SetButtonText("btnNext", _wizard.ReadNextText());
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
                _wizard.NextButtonEnabled = false;
                _wizard.SetButtonText("btnNext", _wizard.ReadNextText());
            }

            if (_wizard.OnAMiddlePage())
            {
                _wizard.BackButtonEnabled = true;
                _wizard.NextButtonEnabled = true;
            }
        }

        public override void Cancel()
        {
            // stub - not required at design time
        }

        public override void Help()
        {
            // stub - not required at design time
        }

        public override void Finish()
        {
            // stub - not required at design time
        }

        public override void Back(ISelectionService selection)
        {
            _wizard.SelectPreviousPage();
            SetButtonStates();
            SelectPageInProperyGrid(selection);
        }

        public override void Next(ISelectionService selection)
        {
            _wizard.SelectNextPage();
            SetButtonStates();
            SelectPageInProperyGrid(selection);
        }

        public override void GoToPage(int pageIndex)
        {
            // stub - not required at design time
        }

        public override void GoToPage(AdvancedWizardPage page)
        {
            // stub - not required at design time
        }

        #endregion

        #region private

        private readonly AdvancedWizard _wizard;

        private void SelectPageInProperyGrid(ISelectionService selection)
        {
            selection.SetSelectedComponents(new object[] {_wizard.CurrentPage}, SelectionTypes.MouseDown);
        }

        #endregion
    }
}