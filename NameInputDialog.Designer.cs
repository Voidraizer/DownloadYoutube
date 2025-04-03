namespace DownloadYoutube
{
    partial class NameInputDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            nameDescLabel = new Label();
            nameTextBox = new TextBox();
            nameExtLabel = new Label();
            nameConfirmButton = new Button();
            nameCancelButton = new Button();
            SuspendLayout();
            // 
            // nameDescLabel
            // 
            nameDescLabel.AutoSize = true;
            nameDescLabel.Font = new Font( "Outfit", 20F );
            nameDescLabel.ForeColor = Color.Indigo;
            nameDescLabel.Location = new Point( 12, 16 );
            nameDescLabel.Name = "nameDescLabel";
            nameDescLabel.Size = new Size( 141, 34 );
            nameDescLabel.TabIndex = 8;
            nameDescLabel.Text = "File Name:";
            // 
            // nameTextBox
            // 
            nameTextBox.Font = new Font( "Outfit", 15F );
            nameTextBox.Location = new Point( 159, 18 );
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size( 323, 33 );
            nameTextBox.TabIndex = 9;
            // 
            // nameExtLabel
            // 
            nameExtLabel.AutoSize = true;
            nameExtLabel.Font = new Font( "Outfit", 20F );
            nameExtLabel.ForeColor = Color.Indigo;
            nameExtLabel.Location = new Point( 488, 16 );
            nameExtLabel.Name = "nameExtLabel";
            nameExtLabel.Size = new Size( 55, 34 );
            nameExtLabel.TabIndex = 10;
            nameExtLabel.Text = ".txt";
            // 
            // nameConfirmButton
            // 
            nameConfirmButton.Font = new Font( "Outfit SemiBold", 15F );
            nameConfirmButton.Location = new Point( 254, 60 );
            nameConfirmButton.Name = "nameConfirmButton";
            nameConfirmButton.Size = new Size( 323, 33 );
            nameConfirmButton.TabIndex = 13;
            nameConfirmButton.Text = "Confirm (Enter)";
            nameConfirmButton.UseVisualStyleBackColor = true;
            nameConfirmButton.Click +=  nameConfirmButton_Click ;
            // 
            // nameCancelButton
            // 
            nameCancelButton.Font = new Font( "Outfit SemiBold", 15F );
            nameCancelButton.Location = new Point( 21, 60 );
            nameCancelButton.Name = "nameCancelButton";
            nameCancelButton.Size = new Size( 217, 33 );
            nameCancelButton.TabIndex = 14;
            nameCancelButton.Text = "Cancel (Escape)";
            nameCancelButton.UseVisualStyleBackColor = true;
            nameCancelButton.Click +=  nameCancelButton_Click ;
            // 
            // NameInputDialog
            // 
            AcceptButton = nameConfirmButton;
            AutoScaleDimensions = new SizeF( 7F, 15F );
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size( 600, 110 );
            ControlBox = false;
            Controls.Add( nameCancelButton );
            Controls.Add( nameConfirmButton );
            Controls.Add( nameExtLabel );
            Controls.Add( nameTextBox );
            Controls.Add( nameDescLabel );
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "NameInputDialog";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "NameInputDialog";
            TopMost = true;
            Paint +=  NameInputDialog_Paint ;
            ResumeLayout( false );
            PerformLayout();
        }

        #endregion

        private Label nameDescLabel;
        private TextBox nameTextBox;
        private Label nameExtLabel;
        private Button nameConfirmButton;
        private Button nameCancelButton;
    }
}