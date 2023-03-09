using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pro_Screw_Market
{
    public partial class LoadingScreen : Form
    {
        public LoadingScreen()
        {
            InitializeComponent();
        }

        private int loadingbatValue;

        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            LoadingBarTimer.Start();
        }
        
        private void LoadingBarTimer_Tick(object sender, EventArgs e)
        {

            loadingbatValue += 1;

            lblLoadingProcess.Text = loadingbatValue.ToString() + "%Mischa";

            LoadingProgressBar.Value = loadingbatValue;

           if(loadingbatValue >= LoadingProgressBar.Maximum)
            {
                LoadingBarTimer.Stop();  //Stop Timer bei Value = 100

                // Finisch loading show main menu screen
                MainMenueScreen mainMenueScreen = new MainMenueScreen();
                mainMenueScreen.Show();

                this.Hide();  // Schliess das Loadingscreen


            }
        }

    }
}
 