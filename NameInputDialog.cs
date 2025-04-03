using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DownloadYoutube
{
    public partial class NameInputDialog : Form
    {
        public string InputText { get; private set; } = string.Empty;

        public NameInputDialog()
        {
            InitializeComponent();
        }

        public NameInputDialog( string defaultName, string extension )
        {
            InitializeComponent();
            nameTextBox.Text = defaultName;
            nameExtLabel.Text = "." + extension;
        }

        private void NameInputDialog_Paint( object sender, PaintEventArgs e )
        {
            // Define the color and width of the border
            Color borderColor = Color.Blue; // Choose your desired color
            int borderWidth = 2; // Set the border width

            // Create a pen to draw the border
            using( Pen pen = new Pen( borderColor, borderWidth ) )
            {
                // Draw the border
                e.Graphics.DrawRectangle( pen, new Rectangle( 0, 0, ClientSize.Width - 1, ClientSize.Height - 1 ) );
            }
        }

        private void nameConfirmButton_Click( object sender, EventArgs e )
        {
            DialogResult = DialogResult.OK;
            InputText = nameTextBox.Text + nameExtLabel.Text;
            Close();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= 0x20000; // CS_DROPSHADOW
                return cp;
            }
        }
    }
}
