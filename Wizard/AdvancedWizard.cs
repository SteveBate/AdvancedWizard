using System;
using System.ComponentModel;
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
        #region constructor

        public AdvancedWizard()
        {
            InitializeComponent();
            _pages = new AdvancedWizardPageCollection();
            _wizardStrategy = DesignMode ? WizardStrategy.CreateDesignTimeWizard(this) : WizardStrategy.CreateRuntimeTimeWizard(this);
            FlatStyle = FlatStyle.Standard;
        }

        #endregion

        #region protected

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GetSelectionService();
            _pnlButtons.SendToBack();
            _tempNextText = NextButtonText;
            _wizardStrategy.Loading();
            AllowKeyPressesToNavigateWizard();
        }

        #endregion
        
        #region internal

        internal void SetButtonStates()
        {
            _wizardStrategy.SetButtonStates();
        }

        internal void StoreIndexOfCurrentPage(int index)
        {
            (_pages[_selectedPage]).PreviousPage = index;
        }

        internal int ReadIndexOfPreviousPage()
        {
            return (_pages[_selectedPage]).PreviousPage;
        }

        internal bool HasExplicitFinishButton()
        {
            return _finishButton;
        }

        internal bool HasPages()
        {
            return _pages.Count > 0;
        }

        internal int IndexOfCurrentPage()
        {
            return _selectedPage;
        }

        internal int IndexOfNextPage()
        {
            return _selectedPage + 1;
        }

        internal bool HasOnePage()
        {
            return _pages.Count == 1;
        }

        internal bool MoreThanOnePageExists()
        {
            return _pages.Count > 1;
        }

        internal bool OnFirstPage()
        {
            return _selectedPage == 0;
        }

        internal bool OnLastPage()
        {
            return _selectedPage == _pages.Count - 1 || (_lastPage == CurrentPage && CurrentPageIsFinishPage);
        }

        internal bool OnAMiddlePage()
        {
            return !OnFirstPage() && !OnLastPage();
        }

        internal string ReadNextText()
        {
            return _tempNextText;
        }

        internal void SelectFirstPage()
        {
            _selectedPage = 0;
            AdvancedWizardPage page = _pages[_selectedPage];
            page.BringToFront();
            SetButtonStates();
        }

        internal void SelectWizardPage(int index)
        {
            if (index < 0 || index > _pages.Count)
                return;

            _selectedPage = index;
            AdvancedWizardPage page = _pages[index];
            page.BringToFront();
            SetButtonStates();
        }

        internal void SelectWizardPage(AdvancedWizardPage page)
        {
            if (_pages.Contains(page))
            {
                _selectedPage = _pages.IndexOf(page);
                page.BringToFront();
                SetButtonStates();
            }
        }

        internal void SelectPreviousPage()
        {
            if (_selectedPage > 0)
            {
                _selectedPage--;
                AdvancedWizardPage page = _pages[_selectedPage];
                page.BringToFront();
                SetButtonStates();
            }
        }

        internal void SelectNextPage()
        {
            if (_selectedPage < _pages.Count - 1)
            {
                _selectedPage++;
                AdvancedWizardPage page = _pages[_selectedPage];
                page.BringToFront();
                SetButtonStates();
            }
        }

        internal void SetButtonText(Button b, string text)
        {
            b.Text = text;
        }

        internal void SetButtonText(string buttonName, string text)
        {
            foreach (Control c in _pnlButtons.Controls)
            {
                if (c.Name == buttonName)
                    c.Text = text;
            }
        }

        internal bool WizardHasNoPages()
        {
            return _pages.Count == 0;
        }

        /// <summary>
        /// Check for design-time mouse clicks so that wizard pages can be navigated 
        /// at design-time. This method is called from our WizardDesigner through
        /// the overridden GetHitTest method.
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        internal bool UserClickedAButtonAtDesignTime(Point point)
        {
            Control c = GetChildAtPoint(point);

            if (c != null && c.Name == "_pnlButtons")
            {
                Control b = c.GetChildAtPoint(c.PointToClient(Cursor.Position));
                if (b != null)
                    return WizardButtonWasClicked(b);

                return false;
            }
            return false;
        }

        internal bool WizardButtonWasClicked(Control b)
        {
            if (b is Button)
                return true;
            return false;
        }

        internal bool PageChangedEventAssigned()
        {
            return PageChanged != null;
        }

        internal void FirePageChanged(int index)
        {
            var ev = new WizardPageChangedEventArgs(_pages[index], index);
            PageChanged(this, ev);
        }

        internal bool LastPageEventAssigned()
        {
            return LastPage != null;
        }

        internal void FireLastPage()
        {
            LastPage(this, EventArgs.Empty);
        }

        internal bool NextEventAssigned()
        {
            return Next != null;
        }

        internal WizardEventArgs FireNextEvent(int currentTabIndex)
        {
            var ev = new WizardEventArgs(currentTabIndex);
            Next(this, ev);
            return ev;
        }

        internal bool BackEventAssigned()
        {
            return Back != null;
        }

        internal WizardEventArgs FireBackEvent(int currentTabIndex)
        {
            var ev = new WizardEventArgs(currentTabIndex);
            Back(this, ev);
            return ev;
        }

        internal bool FinishEventAssigned()
        {
            return Finish != null;
        }

        internal void FireFinishEvent()
        {
            Finish(this, EventArgs.Empty);
        }

        internal bool HelpEventAssigned()
        {
            return Help != null;
        }

        internal void FireHelpEvent()
        {
            Help(this, EventArgs.Empty);
        }

        internal bool CancelEventAssigned()
        {
            return Cancel != null;
        }

        internal void FireCancelEvent()
        {
            Cancel(this, EventArgs.Empty);
        }

        internal void CheckForUserChangesToEventParameters(WizardEventArgs ev, out bool allowPageToChange, out int newTabIndex)
        {
            allowPageToChange = ev.AllowPageChange;
            newTabIndex = ev.NextPageIndex;
        }

        #endregion

        #region public

        [Category("_wizardStrategy")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Description("Add pages to the wizard.")]
        [Editor(typeof (AdvancedWizardCollectionEditor), typeof (UITypeEditor))]
        public AdvancedWizardPageCollection WizardPages
        {
            get { return _pages; }
        }


        [Browsable(false)]
        public AdvancedWizardPage CurrentPage
        {
            get { return _pages[_selectedPage]; }
        }


        [Category("_wizardStrategy")]
        [Description("Allows user to control the wizard through the Escape and Enter keys.")]
        public bool ProcessKeys
        {
            get { return _processKeys; }
            set { _processKeys = value; }
        }


        [Category("Behavior")]
        [Browsable(true)]
        [Description("Set the style of all the wizard buttons.")]
        public FlatStyle FlatStyle
        {
            get { return _btnCancel.FlatStyle; }
            set
            {
                _btnCancel.FlatStyle = value;
                _btnBack.FlatStyle = value;
                _btnNext.FlatStyle = value;
                _btnFinish.FlatStyle = value;
                _btnHelp.FlatStyle = value;
            }
        }


        [Category("_wizardStrategy")]
        [Description("Alters the layout of the buttons.")]
        [RefreshProperties(RefreshProperties.Repaint)]
        public ButtonLayoutKind ButtonLayout
        {
            get { return _buttonLayoutKind; }
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
                            ShowHelpAndFinishButtons();
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
                            ShowHelpAndFinishButtons();
                        }
                        finally
                        {
                            _pnlButtons.ResumeLayout();
                        }
                        break;
                }
            }
        }

        [Category("_wizardStrategy")]
        [Browsable(true)]
        [Description("Show or hide the butons. You can still access the pages programmatically if you hide them.")]
        public bool ButtonsVisible
        {
            get { return _buttonsVisible; }
            set
            {
                _buttonsVisible = value;
                ProcessButtonVisibleValue(value);
            }
        }

        [Category("_wizardStrategy")]
        [Browsable(true)]
        [Description("Increase the button size for easier use on a touchscreen")]
        public bool TouchScreen
        {
            get { return _touchScreen; }
            set
            {
                _touchScreen = value;
                ProcessTouchScreenValue(value);
            }
        }

        /// <summary>
        /// This property determines the layout of navigation buttons.
        /// True means an explicit Finish button is present whereas False
        /// means the Next button wil become a Finish button on the last
        /// page of the wizard.
        /// </summary>
        [Category("_wizardStrategy")]
        [Description("Allows a choice of a dedicated button to complete the wizard steps or to use the Next button.")]
        public bool FinishButton
        {
            get { return _finishButton; }
            set
            {
                _finishButton = value;

                if (_buttonLayoutKind == ButtonLayoutKind.Default)
                    ChangeDefaultLayout(_finishButton);
                else
                    ChangeOfficeLayout(_finishButton);
            }
        }


        [Category("_wizardStrategy")]
        [Description("Allows a choice of a dedicated button to complete the wizard steps or to use the Next button.")]
        public bool HelpButton
        {
            get { return _helpButton; }
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
                                _btnHelp.Left = (_pnlButtons.Width - _btnHelp.Width) - 12;
                                _btnHelp.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
                                _btnCancel.Left = (_btnHelp.Left - _btnCancel.Width - 5);
                                _btnFinish.Left = (_btnCancel.Left - _btnFinish.Width) - 5;
                                if (_btnFinish.Visible)
                                    _btnNext.Left = (_btnFinish.Left - _btnFinish.Width - 5);
                                else
                                    _btnNext.Left = _btnFinish.Left;
                                _btnBack.Left = (_btnNext.Left - _btnNext.Width);
                                break;

                            case false:
                                _btnHelp.Visible = false;
                                _btnHelp.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
                                _btnCancel.Left = (_pnlButtons.Width - _btnCancel.Width) - 12;
                                _btnFinish.Left = (_btnCancel.Left - _btnFinish.Width) - 5;
                                if (_btnFinish.Visible)
                                    _btnNext.Left = (_btnFinish.Left - _btnNext.Width) - 5;
                                else
                                    _btnNext.Left = _btnFinish.Left;
                                _btnBack.Left = (_btnNext.Left - _btnBack.Width);
                                break;
                        }
                        break;
                }
            }
        }


        [Category("WizardText")]
        [Description("Customise the text of the Cancel button.")]
        [Localizable(true)]
        public string HelpButtonText
        {
            get { return _btnHelp.Text; }
            set
            {
                _helpButtonText = value;
                _btnHelp.Text = value;
            }
        }


        [Category("WizardText")]
        [Description("Customise the text of the Cancel button.")]
        [Localizable(true)]
        public string CancelButtonText
        {
            get { return _btnCancel.Text; }
            set
            {
                _cancelButtonText = value;
                _btnCancel.Text = value;
            }
        }


        [Category("WizardText")]
        [Description("Customise the text of the Finish button.")]
        [Localizable(true)]
        public string FinishButtonText
        {
            get { return _btnFinish.Text; }
            set
            {
                _finishButtonText = value;
                _btnFinish.Text = value;
            }
        }


        [Category("WizardText")]
        [Description("Customise the text of the Back button.")]
        [Localizable(true)]
        public string BackButtonText
        {
            get { return _btnBack.Text; }
            set
            {
                _backButtonText = value;
                _btnBack.Text = value;
            }
        }


        [Category("WizardText")]
        [Description("Customise the text of the Next button.")]
        [Localizable(true)]
        public string NextButtonText
        {
            get { return _btnNext.Text; }
            set
            {
                _tempNextText = _nextButtonText;
                _nextButtonText = value;
                _btnNext.Text = value;
            }
        }


        [Category("_wizardStrategy")]
        [Description("Indicates whether the control is enabled.")]
        [Localizable(true)]
        [Browsable(false)]
        public bool BackButtonEnabled
        {
            get { return _btnBack.Enabled; }
            set
            {
                _btnBack.Enabled = value;
                _btnBack.Invalidate();
            }
        }


        [Category("_wizardStrategy")]
        [Description("Indicates whether the control is enabled.")]
        [Localizable(true)]
        [Browsable(false)]
        public bool NextButtonEnabled
        {
            get { return NextButtonEnabledState; }
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
        [Category("_wizardStrategy")]
        [Description("Indicates whether the control is enabled.")]
        [Localizable(true)]
        [Browsable(false)]
        public bool FinishButtonEnabled
        {
            get
            {
                switch (_finishButton)
                {
                    case true:
                        return _btnFinish.Enabled;

                    default:
                        return _btnNext.Enabled;
                }
            }
            set
            {
                switch (_finishButton)
                {
                    case true:
                        _btnFinish.Enabled = value;
                        //finishButtonEnabledState = value;
                        break;

                    case false:
                        _btnNext.Enabled = value;
                        NextButtonEnabledState = value;
                        break;
                }
            }
        }

        [Browsable(false)]
        public bool CurrentPageIsFinishPage
        {
            get { return _pageSetAsFinishPage && _lastPage == CurrentPage; }
            set
            {
                if (value)
                {
                    _pageSetAsFinishPage = true;
                    _lastPage = CurrentPage;
                    if (HasExplicitFinishButton())
                        NextButtonEnabled = false;
                    else
                        _btnNext.Text = FinishButtonText;
                }
                else
                {
                    _pageSetAsFinishPage = false;
                    _lastPage = null;
                    if (HasExplicitFinishButton())
                        NextButtonEnabled = true;
                    else
                        _btnNext.Text = _tempNextText;
                }
            }
        }

        public void GoToPage(int pageIndex)
        {
            _wizardStrategy.GoToPage(pageIndex);
        }

        public void GoToPage(AdvancedWizardPage page)
        {
            _wizardStrategy.GoToPage(page);
        }

        public void ClickNext()
        {
            _wizardStrategy.Next(_selectionService);
        }

        public void ClickBack()
        {
            _wizardStrategy.Back(_selectionService);
        }

        public void ClickFinish()
        {
            _wizardStrategy.Finish();
        }

        public void ClickCancel()
        {
            _wizardStrategy.Cancel();
        }

        public void ClickHelp()
        {
            _wizardStrategy.Help();
        }

        #endregion

        #region internal event handlers

        internal void BtnNextClick(object sender, EventArgs e)
        {
            _wizardStrategy.Next(_selectionService);
        }

        internal void BtnBackClick(object sender, EventArgs e)
        {
            _wizardStrategy.Back(_selectionService);
        }

        internal void BtnFinishClick(object sender, EventArgs e)
        {
            _wizardStrategy.Finish();
        }

        internal void BtnCancelClick(object sender, EventArgs e)
        {
            _wizardStrategy.Cancel();
        }

        internal void BtnHelpClick(object sender, EventArgs e)
        {
            _wizardStrategy.Help();
        }

        #endregion

        #region events

        [Category("WizardAction")]
        [Description("Fires when the Cancel button is clicked.")]
        public event EventHandler Cancel = delegate { };

        [Category("WizardAction")]
        [Description("Fires when the Next button is clicked.")]
        public event EventHandler<WizardEventArgs> Next = delegate { };

        [Category("WizardAction")]
        [Description("Fires when the Back button is clicked.")]
        public event EventHandler Back = delegate { };

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

        #endregion

        #region IMessageFilter Members

        public bool PreFilterMessage(ref Message msg)
        {
            switch (msg.Msg)
            {
                case WmKeydown:
                    if (!DesignMode && _processKeys)
                    {
                        switch ((int) msg.WParam)
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

        #endregion
    }
}