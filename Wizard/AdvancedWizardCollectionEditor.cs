using System;
using System.ComponentModel.Design;
using AdvancedWizardControl.WizardPages;

namespace AdvancedWizardControl.Wizard
{
    /// <summary>
    /// WizardCollectionEditor:
    /// 
    /// Enables WizardPages to be added to our control through the propertygrid;
    /// 
    /// Assigned to the AdvancedWizard WizardPages property through the 
    /// [Editor(typeof(WizardCollectionEditor), typeof(UITypeEditor))] attribute;
    /// </summary>
    public class AdvancedWizardCollectionEditor : CollectionEditor
    {
        public AdvancedWizardCollectionEditor(Type wizardPage)
            : base(wizardPage)
        {
        }

        protected override Type[] CreateNewItemTypes()
        {
            return new[] {typeof (AdvancedWizardPage)};
        }
    }
}