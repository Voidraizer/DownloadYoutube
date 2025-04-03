using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Windows.Forms;
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace DownloadYoutube
{
    public partial class FormParent : Form
    {
        private Form overlayForm = new();

        public FormParent()
        {
            InitializeComponent();
            InitializeOverlayForm();
            AcceptButton = step5GoButton;
        }

        private void InitializeOverlayForm()
        {
            overlayForm = new Form
            {
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.Manual,
                ShowInTaskbar = false,
                BackColor = Color.Black,
                Opacity = 0.3, // Adjust for desired fade effect
                Size = ClientSize,
                Location = Location
            };
        }

        private void step1YoutubeLink_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            // Set the link as visited
            step1YoutubeLink.LinkVisited = true;

            // Open the link in the default web browser
            System.Diagnostics.Process.Start( new ProcessStartInfo
            {
                FileName = "https://www.youtube.com",
                UseShellExecute = true
            } );
        }

        private void mediaTypeAudioOnly_CheckedChanged( object sender, EventArgs e )
        {
            if( mediaTypeAudioOnly.Checked )
            {
                mediaTypeAudioVideo.Checked = false;
                mediaTypeVideoOnly.Checked = false;
            }
        }

        private void mediaTypeAudioVideo_CheckedChanged( object sender, EventArgs e )
        {
            if( mediaTypeAudioVideo.Checked )
            {
                mediaTypeAudioOnly.Checked = false;
                mediaTypeVideoOnly.Checked = false;
            }
        }

        private void mediaTypeVideoOnly_CheckedChanged( object sender, EventArgs e )
        {
            if( mediaTypeAudioVideo.Checked )
            {
                mediaTypeAudioOnly.Checked = false;
                mediaTypeAudioVideo.Checked = false;
            }
        }

        private async void step4GoButton_Click( object sender, EventArgs e )
        {
            string url = step2UrlBox.Text;
            bool failed = false;

            if( string.IsNullOrWhiteSpace( url ) )
            {
                MessageBox.Show( $"Make sure you submit a www.youtube.com URL\n'{url}' is invalid", "URL doesn't look right", MessageBoxButtons.OK, MessageBoxIcon.Error );
                failed = true;
            }
            else if( url.Contains( ' ' ) || url.Contains( '\t' ) || url.Contains( '\n' ) )
            {
                MessageBox.Show( $"URL contains whitespace\n'{url}' is invalid", "URL doesn't look right", MessageBoxButtons.OK, MessageBoxIcon.Error );
                failed = true;
            }
            else if( !url.StartsWith( "www.youtube.com" ) && !url.StartsWith( "http://www.youtube.com" ) && !url.StartsWith( "https://www.youtube.com" ) && !url.StartsWith( "youtube.com" ) )
            {
                MessageBox.Show( $"Doesn't appear to be a youtube link\n'{url}' is invalid", "URL doesn't look right", MessageBoxButtons.OK, MessageBoxIcon.Error );
                failed = true;
            }

            if( failed )
            {
                return;
            }

            try
            {
                YoutubeClient youtube = new YoutubeClient();
                VideoId videoId = VideoId.Parse( url );
                Video video = await youtube.Videos.GetAsync( videoId );
                Debug.Print( $"Video ID: {videoId}" );

                // get the video title and if it contains "Official Music Video" or "Music Video", remove that from the string
                string title = video.Title;
                if( title.Contains( "Official Music Video" ) )
                {
                    title = title.Replace( "Official Music Video", "" );
                }
                else if( title.Contains( "Music Video" ) )
                {
                    title = title.Replace( "Music Video", "" );
                }

                Debug.Print( $"Video Title: {video.Title}" );

                var streamManifest = await youtube.Videos.Streams.GetManifestAsync( videoId );
                Debug.Print( $"Stream Manifest: {streamManifest}" );

                Debug.Print( $"{streamManifest.Streams.Count} streams available" );

                IStreamInfo? streamInfo = null;

                if( mediaTypeAudioOnly.Checked )
                {
                    streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();
                }
                else if( mediaTypeAudioVideo.Checked )
                {
                    streamInfo = streamManifest.GetMuxedStreams().GetWithHighestBitrate();
                }
                else if( mediaTypeVideoOnly.Checked )
                {
                    streamInfo = streamManifest.GetVideoOnlyStreams().GetWithHighestBitrate();
                }
                else
                {
                    Debug.Print( "Unknown Media Type" );
                }

                if( streamInfo == null )
                {
                    Debug.Print( "Stream Info is null" );
                    return;
                }
                Debug.Print( $"Stream Info: {streamInfo.Container.Name}" );

                string extension = streamInfo.Container.Name;
                Debug.Print( $"Extension: {extension}" );

                overlayForm.Owner = this;
                overlayForm.Size = ClientSize;
                overlayForm.Location = PointToScreen( Point.Empty );
                overlayForm.Show();

                string outputFilePath = string.Empty;

                using( NameInputDialog nameInputDialog = new NameInputDialog( title, extension ) )
                {
                    if( nameInputDialog.ShowDialog( this ) == DialogResult.OK )
                    {
                        outputFilePath = Path.Combine( step4DirTextBox.Text, nameInputDialog.InputText );
                        Debug.Print( $"File Name = {nameInputDialog.InputText}" );
                    }
                }

                overlayForm.Hide();

                if( string.IsNullOrWhiteSpace( outputFilePath ) )
                {
                    MessageBox.Show( $"Output file path is empty\n'{outputFilePath}' is invalid", "Output file path doesn't look right", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    return;
                }

                Debug.Print( $"Output File Path: {outputFilePath}" );

                YoutubeDownloader downloader = new YoutubeDownloader();

                IProgress<double> progress = new Progress<double>( percent =>
                {
                    Debug.Print( $"Download Progress: {percent}%" );
                    // Update the progress bar or any other UI element here
                } );

                await downloader.DownloadFile( streamInfo, outputFilePath, progress );
            }
            catch( Exception ex )
            {
                Debug.Print( $"Error: {ex.Message}" );
                // statusLabel.Text = $"Error: {ex.Message}";
            }
        }

        private void step4DirSelectButton_Click( object sender, EventArgs e )
        {
            // use folderBrowserDialog and open a folder browser dialog to select the output file path
            using( FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog() )
            {
                folderBrowserDialog.Description = "Select the output folder";
                folderBrowserDialog.ShowNewFolderButton = true;
                folderBrowserDialog.InitialDirectory = Environment.GetFolderPath( Environment.SpecialFolder.DesktopDirectory );

                if( folderBrowserDialog.ShowDialog() == DialogResult.OK )
                {
                    // Put the chosen location in the textbox
                    step4DirTextBox.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        protected override void OnMove( EventArgs e )
        {
            base.OnMove( e );
            if( overlayForm != null )
            {
                overlayForm.Location = Location;
            }
        }

        protected override void OnResize( EventArgs e )
        {
            base.OnResize( e );
            if( overlayForm != null )
            {
                overlayForm.Size = ClientSize;
            }
        }
    }
}
