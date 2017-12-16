using System.Windows.Forms;
using System;
using AdvancedWizardControl.Enums;
using AdvancedWizardControl.EventArguments;
using AdvancedWizardControl.WizardPages;

namespace Sample
{
    partial class CustomerWizardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerWizardForm));
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.advancedWizard1 = new AdvancedWizardControl.Wizard.AdvancedWizard();
            this.wizardPageTitle = new AdvancedWizardControl.WizardPages.AdvancedWizardPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkFinish = new System.Windows.Forms.CheckBox();
            this.chkCancel = new System.Windows.Forms.CheckBox();
            this.chkHelp = new System.Windows.Forms.CheckBox();
            this.rbtnOffice = new System.Windows.Forms.RadioButton();
            this.rbtnDefault = new System.Windows.Forms.RadioButton();
            this.wizardPage1 = new AdvancedWizardControl.WizardPages.AdvancedWizardPage();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInitial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.wizardPage2 = new AdvancedWizardControl.WizardPages.AdvancedWizardPage();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.wizardPage3 = new AdvancedWizardControl.WizardPages.AdvancedWizardPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.advancedWizard1.SuspendLayout();
            this.wizardPageTitle.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.wizardPage1.SuspendLayout();
            this.wizardPage2.SuspendLayout();
            this.wizardPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // advancedWizard1
            // 
            this.advancedWizard1.BackButtonEnabled = false;
            this.advancedWizard1.BackButtonText = "< Back";
            this.advancedWizard1.ButtonLayout = AdvancedWizardControl.Enums.ButtonLayoutKind.Default;
            this.advancedWizard1.ButtonsVisible = true;
            this.advancedWizard1.CancelButton = true;
            this.advancedWizard1.CancelButtonText = "&Cancel";
            this.advancedWizard1.Controls.Add(this.wizardPageTitle);
            this.advancedWizard1.Controls.Add(this.wizardPage1);
            this.advancedWizard1.Controls.Add(this.wizardPage2);
            this.advancedWizard1.Controls.Add(this.wizardPage3);
            this.advancedWizard1.CurrentPageIsFinishPage = false;
            this.advancedWizard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedWizard1.FinishButton = true;
            this.advancedWizard1.FinishButtonEnabled = true;
            this.advancedWizard1.FinishButtonText = "&Finish";
            this.advancedWizard1.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.advancedWizard1.HelpButton = true;
            this.advancedWizard1.HelpButtonText = "&Help";
            this.advancedWizard1.Location = new System.Drawing.Point(0, 0);
            this.advancedWizard1.Name = "advancedWizard1";
            this.advancedWizard1.NextButtonEnabled = true;
            this.advancedWizard1.NextButtonText = "&Next";
            this.advancedWizard1.ProcessKeys = false;
            this.advancedWizard1.Size = new System.Drawing.Size(724, 480);
            this.advancedWizard1.TabIndex = 0;
            this.advancedWizard1.TouchScreen = false;
            this.advancedWizard1.WizardPages.Add(this.wizardPageTitle);
            this.advancedWizard1.WizardPages.Add(this.wizardPage1);
            this.advancedWizard1.WizardPages.Add(this.wizardPage2);
            this.advancedWizard1.WizardPages.Add(this.wizardPage3);
            this.advancedWizard1.Cancel += new System.EventHandler(this.WhenUserClicksCancel);
            this.advancedWizard1.Next += new System.EventHandler<AdvancedWizardControl.EventArguments.WizardEventArgs>(this.WhenUserClicksNext);
            this.advancedWizard1.Back += new System.EventHandler<AdvancedWizardControl.EventArguments.WizardEventArgs>(this.WhenUserClicksBack);
            this.advancedWizard1.Finish += new System.EventHandler(this.WhenUserClicksFinish);
            this.advancedWizard1.Help += new System.EventHandler(this.WhenUserClicksHelp);
            this.advancedWizard1.LastPage += new System.EventHandler(this.WhenOnLastPage);
            // 
            // wizardPageTitle
            // 
            this.wizardPageTitle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.wizardPageTitle.Controls.Add(this.groupBox2);
            this.wizardPageTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPageTitle.Header = true;
            this.wizardPageTitle.HeaderBackgroundColor = System.Drawing.Color.White;
            this.wizardPageTitle.HeaderFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.wizardPageTitle.HeaderImage = ((System.Drawing.Image)(resources.GetObject("wizardPageTitle.HeaderImage")));
            this.wizardPageTitle.HeaderImageVisible = true;
            this.wizardPageTitle.HeaderTitle = "Welcome to Advanced Wizard";
            this.wizardPageTitle.Location = new System.Drawing.Point(0, 0);
            this.wizardPageTitle.Name = "wizardPageTitle";
            this.wizardPageTitle.PreviousPage = 0;
            this.wizardPageTitle.Size = new System.Drawing.Size(724, 440);
            this.wizardPageTitle.SubTitle = "Your page description goes here";
            this.wizardPageTitle.SubTitleFont = new System.Drawing.Font("Tahoma", 8F);
            this.wizardPageTitle.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkFinish);
            this.groupBox2.Controls.Add(this.chkCancel);
            this.groupBox2.Controls.Add(this.chkHelp);
            this.groupBox2.Controls.Add(this.rbtnOffice);
            this.groupBox2.Controls.Add(this.rbtnDefault);
            this.groupBox2.Location = new System.Drawing.Point(112, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(499, 242);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // chkFinish
            // 
            this.chkFinish.AutoSize = true;
            this.chkFinish.Checked = true;
            this.chkFinish.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFinish.Location = new System.Drawing.Point(93, 158);
            this.chkFinish.Name = "chkFinish";
            this.chkFinish.Size = new System.Drawing.Size(88, 17);
            this.chkFinish.TabIndex = 4;
            this.chkFinish.Text = "Finish Button";
            this.chkFinish.UseVisualStyleBackColor = true;
            this.chkFinish.CheckedChanged += new System.EventHandler(this.OnFinishCheckChange);
            // 
            // chkCancel
            // 
            this.chkCancel.AutoSize = true;
            this.chkCancel.Checked = true;
            this.chkCancel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCancel.Location = new System.Drawing.Point(93, 135);
            this.chkCancel.Name = "chkCancel";
            this.chkCancel.Size = new System.Drawing.Size(93, 17);
            this.chkCancel.TabIndex = 3;
            this.chkCancel.Text = "Cancel Button";
            this.chkCancel.UseVisualStyleBackColor = true;
            this.chkCancel.CheckedChanged += new System.EventHandler(this.OnCancelCheckChange);
            // 
            // chkHelp
            // 
            this.chkHelp.AutoSize = true;
            this.chkHelp.Checked = true;
            this.chkHelp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHelp.Location = new System.Drawing.Point(93, 112);
            this.chkHelp.Name = "chkHelp";
            this.chkHelp.Size = new System.Drawing.Size(82, 17);
            this.chkHelp.TabIndex = 2;
            this.chkHelp.Text = "Help Button";
            this.chkHelp.UseVisualStyleBackColor = true;
            this.chkHelp.CheckedChanged += new System.EventHandler(this.OnHelpCheckChange);
            // 
            // rbtnOffice
            // 
            this.rbtnOffice.AutoSize = true;
            this.rbtnOffice.Location = new System.Drawing.Point(74, 78);
            this.rbtnOffice.Name = "rbtnOffice";
            this.rbtnOffice.Size = new System.Drawing.Size(105, 17);
            this.rbtnOffice.TabIndex = 1;
            this.rbtnOffice.Text = "Office 97 Layout";
            this.rbtnOffice.UseVisualStyleBackColor = true;
            this.rbtnOffice.CheckedChanged += new System.EventHandler(this.OnOfficeCheckChange);
            // 
            // rbtnDefault
            // 
            this.rbtnDefault.AutoSize = true;
            this.rbtnDefault.Checked = true;
            this.rbtnDefault.Location = new System.Drawing.Point(74, 55);
            this.rbtnDefault.Name = "rbtnDefault";
            this.rbtnDefault.Size = new System.Drawing.Size(96, 17);
            this.rbtnDefault.TabIndex = 0;
            this.rbtnDefault.TabStop = true;
            this.rbtnDefault.Text = "Default Layout";
            this.rbtnDefault.UseVisualStyleBackColor = true;
            this.rbtnDefault.CheckedChanged += new System.EventHandler(this.OnDefaultCheckChange);
            // 
            // wizardPage1
            // 
            this.wizardPage1.BackColor = System.Drawing.SystemColors.Control;
            this.wizardPage1.Controls.Add(this.txtSurname);
            this.wizardPage1.Controls.Add(this.label3);
            this.wizardPage1.Controls.Add(this.txtInitial);
            this.wizardPage1.Controls.Add(this.label2);
            this.wizardPage1.Controls.Add(this.txtFirstName);
            this.wizardPage1.Controls.Add(this.label1);
            this.wizardPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPage1.Header = true;
            this.wizardPage1.HeaderBackgroundColor = System.Drawing.Color.White;
            this.wizardPage1.HeaderFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.wizardPage1.HeaderImage = ((System.Drawing.Image)(resources.GetObject("wizardPage1.HeaderImage")));
            this.wizardPage1.HeaderImageVisible = true;
            this.wizardPage1.HeaderTitle = "New Customer Wizard";
            this.wizardPage1.Location = new System.Drawing.Point(0, 0);
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.PreviousPage = 0;
            this.wizardPage1.Size = new System.Drawing.Size(724, 440);
            this.wizardPage1.SubTitle = "Enter customer name details - All fields are required";
            this.wizardPage1.SubTitleFont = new System.Drawing.Font("Tahoma", 8F);
            this.wizardPage1.TabIndex = 1;
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(59, 247);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(244, 21);
            this.txtSurname.TabIndex = 6;
            this.txtSurname.Tag = "Last Name is required";
            this.txtSurname.TextChanged += new System.EventHandler(this.txtFirstName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Last Name:";
            // 
            // txtInitial
            // 
            this.txtInitial.Location = new System.Drawing.Point(59, 183);
            this.txtInitial.Name = "txtInitial";
            this.txtInitial.Size = new System.Drawing.Size(67, 21);
            this.txtInitial.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Initial:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(59, 125);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(244, 21);
            this.txtFirstName.TabIndex = 2;
            this.txtFirstName.Tag = "First Name is required";
            this.txtFirstName.TextChanged += new System.EventHandler(this.txtFirstName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "First Name:";
            // 
            // wizardPage2
            // 
            this.wizardPage2.BackColor = System.Drawing.SystemColors.Control;
            this.wizardPage2.Controls.Add(this.button1);
            this.wizardPage2.Controls.Add(this.textBox8);
            this.wizardPage2.Controls.Add(this.label8);
            this.wizardPage2.Controls.Add(this.textBox7);
            this.wizardPage2.Controls.Add(this.label7);
            this.wizardPage2.Controls.Add(this.textBox6);
            this.wizardPage2.Controls.Add(this.label6);
            this.wizardPage2.Controls.Add(this.textBox5);
            this.wizardPage2.Controls.Add(this.label5);
            this.wizardPage2.Controls.Add(this.textBox4);
            this.wizardPage2.Controls.Add(this.label4);
            this.wizardPage2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPage2.Header = true;
            this.wizardPage2.HeaderBackgroundColor = System.Drawing.Color.White;
            this.wizardPage2.HeaderFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.wizardPage2.HeaderImage = ((System.Drawing.Image)(resources.GetObject("wizardPage2.HeaderImage")));
            this.wizardPage2.HeaderImageVisible = true;
            this.wizardPage2.HeaderTitle = "New Customer Wizard";
            this.wizardPage2.Location = new System.Drawing.Point(0, 0);
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.PreviousPage = 1;
            this.wizardPage2.Size = new System.Drawing.Size(724, 440);
            this.wizardPage2.SubTitle = "Enter a house number and post code, then click Find";
            this.wizardPage2.SubTitleFont = new System.Drawing.Font("Tahoma", 8F);
            this.wizardPage2.TabIndex = 2;
            this.wizardPage2.PageShow += new System.EventHandler<AdvancedWizardControl.EventArguments.WizardPageEventArgs>(this.WhenPage2IsShown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(472, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Find";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(334, 125);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(119, 21);
            this.textBox8.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(331, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Post Code:";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(59, 308);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(244, 21);
            this.textBox7.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(56, 292);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Town:";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(59, 247);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(244, 21);
            this.textBox6.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(56, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Street 2:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(59, 183);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(244, 21);
            this.textBox5.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Street 1:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(59, 125);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(244, 21);
            this.textBox4.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "House Number:";
            // 
            // wizardPage3
            // 
            this.wizardPage3.BackColor = System.Drawing.SystemColors.Control;
            this.wizardPage3.Controls.Add(this.groupBox1);
            this.wizardPage3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPage3.Header = true;
            this.wizardPage3.HeaderBackgroundColor = System.Drawing.Color.White;
            this.wizardPage3.HeaderFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.wizardPage3.HeaderImage = ((System.Drawing.Image)(resources.GetObject("wizardPage3.HeaderImage")));
            this.wizardPage3.HeaderImageVisible = true;
            this.wizardPage3.HeaderTitle = "New Customer Wizard";
            this.wizardPage3.Location = new System.Drawing.Point(0, 0);
            this.wizardPage3.Name = "wizardPage3";
            this.wizardPage3.PreviousPage = 2;
            this.wizardPage3.Size = new System.Drawing.Size(724, 440);
            this.wizardPage3.SubTitle = "Check the details are correct then click Finish";
            this.wizardPage3.SubTitleFont = new System.Drawing.Font("Tahoma", 8F);
            this.wizardPage3.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(59, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(606, 277);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Summary";
            // 
            // CustomerWizardForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(724, 480);
            this.Controls.Add(this.advancedWizard1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerWizardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdvancedWizard Sample";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.advancedWizard1.ResumeLayout(false);
            this.wizardPageTitle.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.wizardPage1.ResumeLayout(false);
            this.wizardPage1.PerformLayout();
            this.wizardPage2.ResumeLayout(false);
            this.wizardPage2.PerformLayout();
            this.wizardPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AdvancedWizardControl.Wizard.AdvancedWizard advancedWizard1;
        private AdvancedWizardPage wizardPage1;
        private AdvancedWizardPage wizardPage2;
        private AdvancedWizardPage wizardPage3;
        private TextBox txtFirstName;
        private TextBox txtSurname;
        private Label label3;
        private TextBox txtInitial;
        private Label label2;
        private Label label1;
        private TextBox textBox8;
        private Label label8;
        private TextBox textBox7;
        private Label label7;
        private TextBox textBox6;
        private Label label6;
        private TextBox textBox5;
        private Label label5;
        private TextBox textBox4;
        private Label label4;
        private Button button1;
        private GroupBox groupBox1;
        private ErrorProvider errorProvider1;
        private AdvancedWizardPage wizardPageTitle;
        private GroupBox groupBox2;
        private CheckBox chkFinish;
        private CheckBox chkCancel;
        private CheckBox chkHelp;
        private RadioButton rbtnOffice;
        private RadioButton rbtnDefault;
    }
}