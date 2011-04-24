using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using AdvancedWizardControl.WizardPages;

namespace AdvancedWizardControl.Wizard
{
    /// <summary>
    /// WizardPageDesigner: 
    /// 
    /// Allows drag-drop operations to be performed on our pages;
    /// 
    /// Stops a user from selecting pages and being able to drag them out of the
    /// Wizard control;
    /// 
    /// Assigned to a WizardPage through the [Designer(typeof(WizardPageDesigner))]
    /// attribute;
    /// </summary>
    internal class AdvancedWizardPageDesigner : ParentControlDesigner
    {
        #region public

        public override SelectionRules SelectionRules
        {
            get { return DoNotAllowPageToBeManipulatedByMouse(); }
        }

        public override void Initialize(IComponent c)
        {
            base.Initialize(c);
            GetReferenceToWizardPage();
            InitializeWizardPage();
            InitializeDesigner();
        }

        private SelectionRules DoNotAllowPageToBeManipulatedByMouse()
        {
            return base.SelectionRules & SelectionRules.None;
        }

        #endregion

        #region protected

        protected override void OnDragDrop(DragEventArgs de)
        {
            de.Effect = DragDropEffects.Move;
            base.OnDragDrop(de);
        }

        #endregion

        #region private

        private AdvancedWizardPage _page;

        private void InitializeDesigner()
        {
            DrawGrid = true;
            EnableDragDrop(true);
        }

        private void InitializeWizardPage()
        {
            _page.AllowDrop = false;
        }

        private void GetReferenceToWizardPage()
        {
            _page = (Control as AdvancedWizardPage);
        }

        #endregion
    }
}