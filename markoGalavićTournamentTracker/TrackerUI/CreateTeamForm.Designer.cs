namespace TrackerUI
{
    partial class CreateTeamForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.entryFeeLabel = new System.Windows.Forms.Label();
            this.teamNameValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.selectTeamMemberDropDown = new System.Windows.Forms.ComboBox();
            this.addMemberButton = new System.Windows.Forms.Button();
            this.teamMembersListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.removeSelectedMembersButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.memberFirstNametextBox = new System.Windows.Forms.TextBox();
            this.memberLastNameTextBox = new System.Windows.Forms.TextBox();
            this.memberEmailTextBox = new System.Windows.Forms.TextBox();
            this.memberPhoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.createMemberButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.createTeamButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // entryFeeLabel
            // 
            this.entryFeeLabel.AutoSize = true;
            this.entryFeeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.entryFeeLabel.Location = new System.Drawing.Point(50, 170);
            this.entryFeeLabel.Name = "entryFeeLabel";
            this.entryFeeLabel.Size = new System.Drawing.Size(192, 24);
            this.entryFeeLabel.TabIndex = 9;
            this.entryFeeLabel.Text = "Select Team Member";
            // 
            // teamNameValue
            // 
            this.teamNameValue.Location = new System.Drawing.Point(54, 125);
            this.teamNameValue.Multiline = true;
            this.teamNameValue.Name = "teamNameValue";
            this.teamNameValue.Size = new System.Drawing.Size(250, 25);
            this.teamNameValue.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(50, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Team Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(39, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 29);
            this.label1.TabIndex = 6;
            this.label1.Text = "Create Team";
            // 
            // selectTeamMemberDropDown
            // 
            this.selectTeamMemberDropDown.FormattingEnabled = true;
            this.selectTeamMemberDropDown.Location = new System.Drawing.Point(54, 197);
            this.selectTeamMemberDropDown.Name = "selectTeamMemberDropDown";
            this.selectTeamMemberDropDown.Size = new System.Drawing.Size(250, 21);
            this.selectTeamMemberDropDown.TabIndex = 10;
            // 
            // addMemberButton
            // 
            this.addMemberButton.Location = new System.Drawing.Point(106, 224);
            this.addMemberButton.Name = "addMemberButton";
            this.addMemberButton.Size = new System.Drawing.Size(155, 40);
            this.addMemberButton.TabIndex = 15;
            this.addMemberButton.Text = "Add Member";
            this.addMemberButton.UseVisualStyleBackColor = true;
            this.addMemberButton.Click += new System.EventHandler(this.addMemberButton_Click);
            // 
            // teamMembersListBox
            // 
            this.teamMembersListBox.FormattingEnabled = true;
            this.teamMembersListBox.Location = new System.Drawing.Point(530, 125);
            this.teamMembersListBox.Name = "teamMembersListBox";
            this.teamMembersListBox.Size = new System.Drawing.Size(294, 290);
            this.teamMembersListBox.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(526, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 24);
            this.label3.TabIndex = 18;
            this.label3.Text = "Team Member";
            // 
            // removeSelectedMembersButton
            // 
            this.removeSelectedMembersButton.Location = new System.Drawing.Point(889, 149);
            this.removeSelectedMembersButton.Name = "removeSelectedMembersButton";
            this.removeSelectedMembersButton.Size = new System.Drawing.Size(155, 45);
            this.removeSelectedMembersButton.TabIndex = 23;
            this.removeSelectedMembersButton.Text = "Remove Selected";
            this.removeSelectedMembersButton.UseVisualStyleBackColor = true;
            this.removeSelectedMembersButton.Click += new System.EventHandler(this.removeSelectedMembersButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(50, 341);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 24);
            this.label4.TabIndex = 24;
            this.label4.Text = "Add New Member";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(61, 439);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 24);
            this.label5.TabIndex = 25;
            this.label5.Text = "Email";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(61, 463);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 24);
            this.label6.TabIndex = 26;
            this.label6.Text = "Phone Number";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(61, 415);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 24);
            this.label7.TabIndex = 27;
            this.label7.Text = "Last Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(61, 391);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 24);
            this.label8.TabIndex = 28;
            this.label8.Text = "First Name";
            // 
            // memberFirstNametextBox
            // 
            this.memberFirstNametextBox.Location = new System.Drawing.Point(207, 390);
            this.memberFirstNametextBox.Multiline = true;
            this.memberFirstNametextBox.Name = "memberFirstNametextBox";
            this.memberFirstNametextBox.Size = new System.Drawing.Size(250, 25);
            this.memberFirstNametextBox.TabIndex = 30;
            // 
            // memberLastNameTextBox
            // 
            this.memberLastNameTextBox.Location = new System.Drawing.Point(207, 414);
            this.memberLastNameTextBox.Multiline = true;
            this.memberLastNameTextBox.Name = "memberLastNameTextBox";
            this.memberLastNameTextBox.Size = new System.Drawing.Size(250, 25);
            this.memberLastNameTextBox.TabIndex = 31;
            // 
            // memberEmailTextBox
            // 
            this.memberEmailTextBox.Location = new System.Drawing.Point(207, 438);
            this.memberEmailTextBox.Multiline = true;
            this.memberEmailTextBox.Name = "memberEmailTextBox";
            this.memberEmailTextBox.Size = new System.Drawing.Size(250, 25);
            this.memberEmailTextBox.TabIndex = 32;
            // 
            // memberPhoneNumberTextBox
            // 
            this.memberPhoneNumberTextBox.Location = new System.Drawing.Point(207, 462);
            this.memberPhoneNumberTextBox.Multiline = true;
            this.memberPhoneNumberTextBox.Name = "memberPhoneNumberTextBox";
            this.memberPhoneNumberTextBox.Size = new System.Drawing.Size(250, 25);
            this.memberPhoneNumberTextBox.TabIndex = 33;
            // 
            // createMemberButton
            // 
            this.createMemberButton.Location = new System.Drawing.Point(149, 516);
            this.createMemberButton.Name = "createMemberButton";
            this.createMemberButton.Size = new System.Drawing.Size(155, 40);
            this.createMemberButton.TabIndex = 34;
            this.createMemberButton.Text = "Create Member";
            this.createMemberButton.UseVisualStyleBackColor = true;
            this.createMemberButton.Click += new System.EventHandler(this.createMemberButton_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // createTeamButton
            // 
            this.createTeamButton.Location = new System.Drawing.Point(506, 574);
            this.createTeamButton.Name = "createTeamButton";
            this.createTeamButton.Size = new System.Drawing.Size(155, 40);
            this.createTeamButton.TabIndex = 35;
            this.createTeamButton.Text = "Create Member";
            this.createTeamButton.UseVisualStyleBackColor = true;
            this.createTeamButton.Click += new System.EventHandler(this.createTeamButton_Click);
            // 
            // CreateTeamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 686);
            this.Controls.Add(this.createTeamButton);
            this.Controls.Add(this.createMemberButton);
            this.Controls.Add(this.memberPhoneNumberTextBox);
            this.Controls.Add(this.memberEmailTextBox);
            this.Controls.Add(this.memberLastNameTextBox);
            this.Controls.Add(this.memberFirstNametextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.removeSelectedMembersButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.teamMembersListBox);
            this.Controls.Add(this.addMemberButton);
            this.Controls.Add(this.selectTeamMemberDropDown);
            this.Controls.Add(this.entryFeeLabel);
            this.Controls.Add(this.teamNameValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CreateTeamForm";
            this.Text = "CreateTeamForm";
            this.Load += new System.EventHandler(this.CreateTeamForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label entryFeeLabel;
        private System.Windows.Forms.TextBox teamNameValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox selectTeamMemberDropDown;
        private System.Windows.Forms.Button addMemberButton;
        private System.Windows.Forms.ListBox teamMembersListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button removeSelectedMembersButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox memberFirstNametextBox;
        private System.Windows.Forms.TextBox memberLastNameTextBox;
        private System.Windows.Forms.TextBox memberEmailTextBox;
        private System.Windows.Forms.TextBox memberPhoneNumberTextBox;
        private System.Windows.Forms.Button createMemberButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button createTeamButton;
    }
}