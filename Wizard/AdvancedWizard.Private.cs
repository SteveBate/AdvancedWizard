using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using AdvancedWizardControl.Enums;
using AdvancedWizardControl.Strategies;
using AdvancedWizardControl.WizardPages;

namespace AdvancedWizardControl.Wizard
{
    public partial class AdvancedWizard
    {
        private void InitializeComponent()
        {
            _pnlButtons = new Panel();
            _btnHelp = new Button();
            _btnCancel = new Button();
            _btnBack = new Button();
            _btnNext = new Button();
            _btnFinish = new Button();
            _pnlButtons.SuspendLayout();
            SuspendLayout();
            // 
            // pnlButtons
            // 
            _pnlButtons.BackColor = SystemColors.Control;
            _pnlButtons.Controls.Add(_btnHelp);
            _pnlButtons.Controls.Add(_btnCancel);
            _pnlButtons.Controls.Add(_btnBack);
            _pnlButtons.Controls.Add(_btnNext);
            _pnlButtons.Controls.Add(_btnFinish);
            _pnlButtons.Dock = DockStyle.Bottom;
            _pnlButtons.Location = new Point(0, 256);
            _pnlButtons.Name = "_pnlButtons";
            _pnlButtons.Size = new Size(440, 40);
            _pnlButtons.TabIndex = 0;
            // 
            // btnHelp
            // 
            _btnHelp.Location = new Point(8, 8);
            _btnHelp.Name = "_btnHelp";
            _btnHelp.TabIndex = 9;
            _btnHelp.TabStop = false;
            _btnHelp.Text = "&Help";
            _btnHelp.Click += BtnHelpClick;
            // 
            // btnCancel
            // 
            _btnCancel.Anchor = (((AnchorStyles.Top | AnchorStyles.Right)));
            _btnCancel.Location = new Point(120, 8);
            _btnCancel.Name = "_btnCancel";
            _btnCancel.TabIndex = 8;
            _btnCancel.TabStop = false;
            _btnCancel.Text = "&Cancel";
            _btnCancel.Click += BtnCancelClick;
            // 
            // btnBack
            // 
            _btnBack.Anchor = (((AnchorStyles.Top | AnchorStyles.Right)));
            _btnBack.Location = new Point(200, 8);
            _btnBack.Name = "_btnBack";
            _btnBack.TabIndex = 7;
            _btnBack.TabStop = false;
            _btnBack.Text = "< Back";
            _btnBack.Click += BtnBackClick;
            // 
            // btnNext
            // 
            _btnNext.Anchor = (((AnchorStyles.Top | AnchorStyles.Right)));
            _btnNext.Location = new Point(280, 8);
            _btnNext.Name = "_btnNext";
            _btnNext.TabIndex = 6;
            _btnNext.TabStop = false;
            _btnNext.Text = "Next >";
            _btnNext.Click += BtnNextClick;
            // 
            // btnFinish
            // 
            _btnFinish.Anchor = (((AnchorStyles.Top | AnchorStyles.Right)));
            _btnFinish.Location = new Point(360, 8);
            _btnFinish.Name = "_btnFinish";
            _btnFinish.TabIndex = 5;
            _btnFinish.TabStop = false;
            _btnFinish.Text = "&Finish";
            _btnFinish.Click += BtnFinishClick;
            // 
            // AdvancedWizard
            // 
            Controls.Add(_pnlButtons);
            Name = "AdvancedWizard";
            Size = new Size(440, 296);
            _pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void AllowKeyPressesToNavigateWizard() => Application.AddMessageFilter(this);

        private void SetButtonLocationsForOfficeLayout()
        {
            _btnHelp.Left = _pnlButtons.Width - _btnHelp.Width - 12;
            _btnCancel.Left = _btnHelp.Left - _btnCancel.Width - 5;
            _btnFinish.Left = _btnCancel.Left - _btnFinish.Width - 5;
            _btnNext.Left = _finishButton ? _btnFinish.Left - _btnNext.Width - 5 : _btnFinish.Left;
            _btnBack.Left = _btnNext.Left - _btnBack.Width;
        }

        private void SetTabOrderForOfficeLayout()
        {
            // set the tab orders
            _btnHelp.TabIndex = 4;
            _btnCancel.TabIndex = 3;
            _btnBack.TabIndex = 0;
            _btnNext.TabIndex = 1;
            _btnFinish.TabIndex = 2;
        }

        private void ChangeOfficeLayout(bool hasFinishButton)
        {
            if (hasFinishButton)
            {
                _btnFinish.Visible = true;
                _btnCancel.Left = _btnHelp.Visible ? _btnHelp.Left - _btnCancel.Width - 5 : _btnHelp.Left;
                _btnNext.Left = _btnFinish.Left - _btnFinish.Width - 5;
                _btnBack.Left = _btnNext.Left - _btnNext.Width;
                _btnNext.Text = _nextButtonText;
            }
            else
            {
                _btnFinish.Visible = false;
                _btnCancel.Left = _btnHelp.Visible ? _btnHelp.Left - _btnCancel.Width - 5 : _btnHelp.Left;
                _btnNext.Left = _btnFinish.Left;
                _btnBack.Left = _btnNext.Left - _btnNext.Width;
                _btnNext.Text = IndexOfCurrentPage() == WizardPages.Count - 1 ? _finishButtonText: _nextButtonText;
            }
        }

        private void SetButtonLocationsForDefaultLayout()
        {
            _btnFinish.Left = _pnlButtons.Width - _btnFinish.Width - 12;
            _btnNext.Left = _btnFinish.Left - _btnNext.Width - 5;
            _btnBack.Left = _btnNext.Left - _btnBack.Width - 5;
            _btnCancel.Left = _btnBack.Left - _btnCancel.Width - 5;
            _btnHelp.Left = 12;
        }

        private void SetTabOrderForDefaultLayout()
        {
            // set the tab orders
            _btnHelp.TabIndex = 0;
            _btnCancel.TabIndex = 1;
            _btnBack.TabIndex = 2;
            _btnNext.TabIndex = 3;
            _btnFinish.TabIndex = 4;
        }

        private void ChangeDefaultLayout(bool hasFinishButton)
        {
            if (hasFinishButton)
            {
                _btnFinish.Visible = true;
                _btnNext.Left = _btnFinish.Left - _btnFinish.Width - 5;
                _btnBack.Left = _btnNext.Left - _btnNext.Width;
                _btnCancel.Left = _btnBack.Left - _btnBack.Width - 5;
                _btnNext.Text = _nextButtonText;
            }
            else
            {
                _btnFinish.Visible = false;
                _btnNext.Left = _btnFinish.Left;
                _btnBack.Left = _btnNext.Left - _btnNext.Width;
                _btnCancel.Left = _btnBack.Left - _btnBack.Width - 5;
                _btnNext.Text = IndexOfCurrentPage() == WizardPages.Count - 1 ? _finishButtonText : _nextButtonText;
            }
        }

        private void ShowAllButtons()
        {
            FinishButton = true;
            HelpButton = true;
            CancelButton = true;
        }

        private void ProcessTouchScreenValue(bool val)
        {
            _touchScreen = val;

            if (val)
            {
                _pnlButtons.Height = 60;

                _btnHelp.Height = 46;
                _btnCancel.Height = 46;
                _btnBack.Height = 46;
                _btnNext.Height = 46;
                _btnFinish.Height = 46;
            }
            else
            {
                _pnlButtons.Height = 40;
                _btnHelp.Height = 23;
                _btnCancel.Height = 23;
                _btnBack.Height = 23;
                _btnNext.Height = 23;
                _btnFinish.Height = 23;
            }

            _btnHelp.Top = 8;
            _btnCancel.Top = 8;
            _btnBack.Top = 8;
            _btnNext.Top = 8;
            _btnFinish.Top = 8;
        }

        private const int VkEscape = 27;
        private const int VkReturn = 13;
        private const int WmKeydown = 0x0100;

        private Button _btnBack;
        private Button _btnCancel;
        private Button _btnFinish;
        private Button _btnHelp;
        private Button _btnNext;
        private Panel _pnlButtons;

        private bool _finishButton = true;
        private bool _helpButton = true;
        private AdvancedWizardPage _lastPage;

        internal bool NextButtonEnabledState;
        private bool _pageSetAsFinishPage;
        private int _selectedPage;
        private ISelectionService _selectionService;
        private readonly WizardStrategy _wizardStrategy;

        private string _backButtonText = "< Back";
        private ButtonLayoutKind _buttonLayoutKind;
        private bool _buttonsVisible = true;
        private string _cancelButtonText = "&Cancel";
        private string _finishButtonText = "&Finish";
        private string _helpButtonText = "&Help";
        private string _nextButtonText = "Next >";
        private string _tempNextText = "Next >";
        private bool _touchScreen;
    }
}