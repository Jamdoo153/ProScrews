using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pro_Screw_Market
{
    public partial class Produkte : Form

    {
        private SqlConnection databaseConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Walke\Documents\ProScrewsMarket.mdf;Integrated Security = True; Connect Timeout = 30");
        

        public Produkte()
        {
            InitializeComponent();

            //Start
            databaseConnection.Open();

            string query = "select * from Product";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, databaseConnection);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            ProductsDGV.DataSource = dataSet.Tables[0];

            ProductsDGV.Columns[0].Visible = false;

            databaseConnection.Close();
        }

        private void btnProducrtSave_Click(object sender, EventArgs e)
        {

        }

        private void btnProductEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnProductClear_Click(object sender, EventArgs e)
        {

        }

        private void btnProductDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
