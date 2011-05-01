using System.ComponentModel.Design;
using AdvancedWizardControl.Wizard;
using AdvancedWizardControl.WizardPages;

namespace AdvancedWizardControl.Strategies
{
    public abstract class WizardStrategy
    {
        public abstract void Loading();
        public abstract void SetButtonStates();
        public abstract void Cancel();
        public abstract void Help();
        public abstract void Finish();
        public abstract void Next(ISelectionService selection);
        public abstract void Back(ISelectionService selection);
        public abstract void GoToPage(int pageIndex);
        public abstract void GoToPage(AdvancedWizardPage page);

        public static WizardStrategy CreateWizard(bool DesignMode, AdvancedWizard wizard)
        {
            if(DesignMode)
                return new DesignTimeWizardStrategy(wizard);

            return new RuntimeWizardStrategy(wizard);
        }
    }
}