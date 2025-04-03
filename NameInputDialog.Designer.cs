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
            nameTextBox.Location = new Point( 159, 17 );
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size( 361, 33 );
            nameTextBox.TabIndex = 9;
            // 
            // nameExtLabel
            // 
            nameExtLabel.AutoSize = true;
            nameExtLabel.Font = new Font( "Outfit", 20F );
            nameExtLabel.ForeColor = Color.Indigo;
            nameExtLabel.Location = new Point( 526, 17 );
            nameExtLabel.Name = "nameExtLabel";
            nameExtLabel.Size = new Size( 55, 34 );
            nameExtLabel.TabIndex = 10;
            nameExtLabel.Text = ".txt";
            // 
            // nameConfirmButton
            // 
            nameConfirmButton.Font = new Font( "Outfit SemiBold", 15F );
            nameConfirmButton.Location = new Point( 159, 60 );
            nameConfirmButton.Name = "nameConfirmButton";
            nameConfirmButton.Size = new Size( 361, 33 );
            nameConfirmButton.TabIndex = 13;
            nameConfirmButton.Text = "Confirm";
            nameConfirmButton.UseVisualStyleBackColor = true;
            // 
            // NameInputDialog
            // 
            AcceptButton = nameConfirmButton;
            AutoScaleDimensions = new SizeF( 7F, 15F );
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size( 593, 105 );
            ControlBox = false;
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
            StartPosition = FormStartPosition.CenterScreen;
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
    }
}