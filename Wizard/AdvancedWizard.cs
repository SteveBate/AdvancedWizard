using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using AdvancedWizardControl.Enums;
using AdvancedWizardControl.EventArguments;
using AdvancedWizardControl.Strategies;
using AdvancedWizardControl.WizardPages;

namespace AdvancedWizardControl.Wizard
{
    /// <summary>
    /// AdvancedWizard is a wizard control for the .Net platform
    /// </summary>
    [DefaultProperty("Pages")]
    [DefaultEvent("Finish")]
    [ToolboxBitmap(typeof (Bitmap))]
    [Designer(typeof (AdvancedWizardDesigner))]
    public partial class AdvancedWizard : UserControl, IMessageFilter
    {
        public AdvancedWizard()
        {
            InitializeComponent();
            FlatStyle = FlatStyle.Standard;
            WizardPages = new AdvancedWizardPageCollection();
            _wizardStrategy = WizardStrategy.CreateWizard(DesignMode, this);
        }

        /// <summary>
        /// IMessageFilter implementation
        /// </summary>
        public bool PreFilterMessage(ref Message msg)
        {
            switch (msg.Msg)
            {
                case WmKeydown:
                    if (!DesignMode && ProcessKeys)
                    {
                        switch ((int)msg.WParam)
                        {
                            case VkEscape:
                                _wizardStrategy.Cancel();
                                break;

                            case VkReturn:
                                if (OnLastPage())
                                    _wizardStrategy.Finish();
                                else if (NextButtonEnabled)
                                    _wizardStrategy.Next(null);
                                break;
                        }
                    }
                    break;
            }
            return false;
        }

        [Category("WizardAction")]
        [Description("Fires when the Cancel button is clicked.")]
        public event EventHandler Cancel = delegate { };

        [Category("WizardAction")]
        [Description("Fires when the Next button is clicked.")]
        public event EventHandler<WizardEventArgs> Next = delegate { };

        [Category("WizardAction")]
        [Description("Fires when the Back button is clicked.")]
        public event EventHandler<WizardEventArgs> Back = delegate { };

        [Category("WizardAction")]
        [Description("Fires when the Finish button is clicked.")]
        public event EventHandler Finish = delegate { };

        [Category("WizardAction")]
        [Description("Fires when the Help button is clicked.")]
        public event EventHandler Help = delegate { };

        [Category("WizardAction")]
        [Description("Fires when the page changes.")]
        public event EventHandler<WizardPageChangedEventArgs> PageChanged = delegate { };

        [Category("WizardAction")]
        [Description("Fires when the last page is reached.")]
        public event EventHandler LastPage = delegate { };

        [Category("Wizard")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Description("Add pages to the wizard.")]
        [Editor(typeof(AdvancedWizardCollectionEditor), typeof(UITypeEditor))]
        public AdvancedWizardPageCollection WizardPages { get; }

        [Browsable(false)]
        public AdvancedWizardPage CurrentPage => WizardPages[_selectedPage];

        [Category("Wizard")]
        [Description("Allows user to control the wizard through the Escape and Enter keys.")]
        public bool ProcessKeys { get; set; }

        [Category("Behavior")]
        [Browsable(true)]
        [Description("Set the style of all the wizard buttons.")]
        public FlatStyle FlatStyle
        {
            get => _btnCancel.FlatStyle;
            set
            {
                _btnCancel.FlatStyle = value;
                _btnBack.FlatStyle = value;
                _btnNext.FlatStyle = value;
                _btnFinish.FlatStyle = value;
                _btnHelp.FlatStyle = value;
            }
        }

        [Category("Wizard")]
        [Description("Alters the layout of the buttons.")]
        [RefreshProperties(RefreshProperties.Repaint)]
        public ButtonLayoutKind ButtonLayout
        {
            get => _buttonLayoutKind;
            set
            {
                _buttonLayoutKind = value;
                switch (value)
                {
                    case ButtonLayoutKind.Default:
                        _pnlButtons.SuspendLayout();
                        try
                        {
                            SetButtonLocationsForDefaultLayout();
                            SetTabOrderForDefaultLayout();
                            ShowAllButtons();
                        }
                        finally
                        {
                            _pnlButtons.ResumeLayout();
                        }
                        break;

                    case ButtonLayoutKind.Office97:
                        _pnlButtons.SuspendLayout();
                        try
                        {
                            SetButtonLocationsForOfficeLayout();
                            SetTabOrderForOfficeLayout();
                            ShowAllButtons();
                        }
                        finally
                        {
                            _pnlButtons.ResumeLayout();
                        }
                        break;
                }
            }
        }

        [Category("Wizard")]
        [Browsable(true)]
        [Description("Show or hide the butons. You can still access the pages programmatically if you hide them.")]
        public bool ButtonsVisible
        {
            get => _buttonsVisible;
            set => _pnlButtons.Visible = _buttonsVisible = value;
        }

        [Description("Shows or hides the Cancel button")]
        [Category("Wizard")]
        public bool CancelButton
        {
            get => _btnCancel.Visible;
            set => _btnCancel.Visible = value;
        }

        [Category("Wizard")]
        [Browsable(true)]
        [Description("Increase the button size for easier use on a touchscreen")]
        public bool TouchScreen
        {
            get => _touchScreen;
            set => ProcessTouchScreenValue(value);
        }

        /// <summary>
        /// This property determines the layout of navigation buttons.
        /// True means an explicit Finish button is present whereas False
        /// means the Next button wil become a Finish button on the last
        /// page of the wizard.
        /// </summary>
        [Category("Wizard")]
        [Description("Allows a choice of a dedicated button to complete the wizard steps or to use the Next button.")]
        public bool FinishButton
        {
            get => _finishButton;
            set
            {
                _finishButton = value;

                if (_buttonLayoutKind == ButtonLayoutKind.Default)
                    ChangeDefaultLayout(_finishButton);
                else
                    ChangeOfficeLayout(_finishButton);
            }
        }

        [Category("Wizard")]
        [Description("Allows a choice of a dedicated button to complete the wizard steps or to use the Next button.")]
        public bool HelpButton
        {
            get => _helpButton;
            set
            {
                _helpButton = value;
                switch (_buttonLayoutKind)
                {
                    case ButtonLayoutKind.Default:
                        switch (_helpButton)
                        {
                            case true:
                                _btnHelp.Visible = true;
                                _btnHelp.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
                                break;

                            case false:
                                _btnHelp.Visible = false;
                                _btnHelp.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
                                break;
                        }
                        break;

                    case ButtonLayoutKind.Office97:
                        switch (_helpButton)
                        {
                            case true:
                                _btnHelp.Visible = true;
                                _btnHelp.Left = _pnlButtons.Width - _btnHelp.Width - 12;
                                _btnHelp.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                                _btnCancel.Left = _btnHelp.Left - _btnCancel.Width - 5;
                                _btnFinish.Left = _btnCancel.Left - _btnFinish.Width - 5;
                                _btnNext.Left = _btnFinish.Visible ? _btnFinish.Left - _btnFinish.Width - 5 : _btnFinish.Left;
                                _btnBack.Left = _btnNext.Left - _btnNext.Width;
                                break;

                            case false:
                                _btnHelp.Visible = false;
                                _btnHelp.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                                _btnCancel.Left = _pnlButtons.Width - _btnCancel.Width - 12;
                                _btnFinish.Left = _btnCancel.Left - _btnFinish.Width - 5;
                                _btnNext.Left = _btnFinish.Visible ? _btnFinish.Left - _btnNext.Width - 5 : _btnFinish.Left;
                                _btnBack.Left = _btnNext.Left - _btnBack.Width;
                                break;
                        }
                        break;
                }
            }
        }

        [Category("Wizard")]
        [Description("Customise the text of the Cancel button.")]
        [Localizable(true)]
        public string HelpButtonText
        {
            get => _btnHelp.Text;
            set
            {
                _helpButtonText = value;
                _btnHelp.Text = value;
            }
        }

        [Category("Wizard")]
        [Description("Customise the text of the Cancel button.")]
        [Localizable(true)]
        public string CancelButtonText
        {
            get => _btnCancel.Text;
            set
            {
                _cancelButtonText = value;
                _btnCancel.Text = value;
            }
        }

        [Category("Wizard")]
        [Description("Customise the text of the Finish button.")]
        [Localizable(true)]
        public string FinishButtonText
        {
            get => _btnFinish.Text;
            set
            {
                _finishButtonText = value;
                _btnFinish.Text = value;
            }
        }

        [Category("Wizard")]
        [Description("Customise the text of the Back button.")]
        [Localizable(true)]
        public string BackButtonText
        {
            get => _btnBack.Text;
            set
            {
                _backButtonText = value;
                _btnBack.Text = value;
            }
        }

        [Category("Wizard")]
        [Description("Customise the text of the Next button.")]
        [Localizable(true)]
        public string NextButtonText
        {
            get => _btnNext.Text;
            set
            {
                _tempNextText = _nextButtonText;
                _nextButtonText = value;
                _btnNext.Text = value;
            }
        }

        [Category("Wizard")]
        [Description("Indicates whether the control is enabled.")]
        [Localizable(true)]
        [Browsable(false)]
        public bool BackButtonEnabled
        {
            get => _btnBack.Enabled;
            set
            {
                _btnBack.Enabled = value;
                _btnBack.Invalidate();
            }
        }

        [Category("Wizard")]
        [Description("Indicates whether the control is enabled.")]
        [Localizable(true)]
        [Browsable(false)]
        public bool NextButtonEnabled
        {
            get => NextButtonEnabledState;
            set
            {
                NextButtonEnabledState = value;
                _btnNext.Enabled = NextButtonEnabledState;
                _btnNext.Invalidate();
            }
        }

        // When FinishButton is set to false the NextButton "becomes" the Finish button
        // To enable or disable this button you had to call NextButtonEnabled even though
        // to the application developer it looked like the actual finish button. Therefore,
        // it makes more sense to call FinishButtonEnabled. This changed works with the
        // appropriate button depending on the value of the FinishButton property
        [Category("Wizard")]
        [Description("Indicates whether the control is enabled.")]
        [Localizable(true)]
        [Browsable(false)]
        public bool FinishButtonEnabled
        {
            get { return _finishButton ? _btnFinish.Enabled : _btnNext.Enabled; }
            set
            {
                if (_finishButton)
                {
                    _btnFinish.Enabled = value;
                }
                else if (_finishButton == false)
                {
                    _btnNext.Enabled = value;
                    NextButtonEnabledState = value;
                }
            }
        }

        [Browsable(false)]
        public bool CurrentPageIsFinishPage
        {
            get => _pageSetAsFinishPage && _lastPage == CurrentPage;
            set
            {
                _pageSetAsFinishPage = value;
                _lastPage = value ? CurrentPage : null;
                if (HasExplicitFinishButton())
                    NextButtonEnabled = !value;
                else
                    _btnNext.Text = value ? FinishButtonText : _tempNextText;
            }
        }

        public void GoToPage(int pageIndex) => _wizardStrategy.GoToPage(pageIndex);

        public void GoToPage(AdvancedWizardPage page) => _wizardStrategy.GoToPage(page);

        public void ClickNext() => _wizardStrategy.Next(_selectionService);

        public void ClickBack() => _wizardStrategy.Back(_selectionService);

        public void ClickFinish() => _wizardStrategy.Finish();

        public void ClickCancel() => _wizardStrategy.Cancel();

        public void ClickHelp() => _wizardStrategy.Help();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _selectionService = (ISelectionService)GetService(typeof(ISelectionService));
            _pnlButtons.SendToBack();
            _tempNextText = NextButtonText;
            _wizardStrategy.Loading();
            AllowKeyPressesToNavigateWizard();
        }
    }
}