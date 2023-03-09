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
        private int lastSelectedProductKey;

        public Produkte()
        {
            InitializeComponent();
            ShowProduct();
        }

        private void ShowProduct()
        {
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
            if(tbxProductName.Text == ""
                || tbxProductBrand.Text == ""
                || cbxProductCategorie.Text == ""
                || tbxProductPrice.Text == "")
                {
                MessageBox.Show("Bitte fülle alle Felder aus");
                return;
                }

            string productName = tbxProductName.Text;
            string productBrand = tbxProductBrand.Text;
            string productKategorie = cbxProductCategorie.Text;
            string productPrise = tbxProductPrice.Text;

            string query = string.Format("Insert into Product values('{0}', '{1}', '{2}', '{3}')", productName, productBrand, productKategorie, productPrise);
            ExecuteQuery(query);
            ClearAllField();
            ShowProduct();
        }

        private void btnProductEdit_Click(object sender, EventArgs e)
        {
            if (lastSelectedProductKey == 0)
            {
                MessageBox.Show("Bitte wähle zuerst ein rodukt aus");
                return;
            }

            string productName = tbxProductName.Text;
            string productBrand = tbxProductBrand.Text;
            string productKategorie = cbxProductCategorie.Text;
            string productPrise = tbxProductPrice.Text;


            string query = string.Format("update Product set Name = '{0}', Brand = '{1}', Kategorie = '{2}', Preis = '{3}' where Id={4}"
                , productName, productBrand, productKategorie, productPrise, lastSelectedProductKey);

            ExecuteQuery(query);
            ShowProduct();
        }

        private void btnProductClear_Click(object sender, EventArgs e)
        {
            ClearAllField();
        }

        private void btnProductDelete_Click(object sender, EventArgs e)
        {
            if(lastSelectedProductKey == 0)
            {
                MessageBox.Show("Bitte wähle zuerst ein rodukt aus");
                return;
            }
            string query = string.Format("delete from Product where Id={0};", lastSelectedProductKey);
            ExecuteQuery(query);
            ClearAllField();
            ShowProduct();
        }

        private void ExecuteQuery(string query)
        {
           
            databaseConnection.Open();      // Es musst immer eine Verbindung zur Databank aufbauen
            SqlCommand sqlCommand = new SqlCommand(query, databaseConnection);
            sqlCommand.ExecuteNonQuery();
            databaseConnection.Close();     // Nach den hinzufügen der neuen Daten muss immer die Verindung zu Datenbank geschlossen werden

        }   
            


            private void ClearAllField()        // Lösch alle Eingabefelder
        {
            tbxProductName.Text = "";
            tbxProductBrand.Text = "";
            tbxProductPrice.Text = "";
            cbxProductCategorie.Text = "";
            cbxProductCategorie.SelectedItem = null;
        }

        private void ProductsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxProductName.Text = ProductsDGV.SelectedRows[0].Cells[1].Value.ToString();
            tbxProductBrand.Text = ProductsDGV.SelectedRows[0].Cells[2].Value.ToString();
            cbxProductCategorie.Text = ProductsDGV.SelectedRows[0].Cells[3].Value.ToString();
            tbxProductPrice.Text = ProductsDGV.SelectedRows[0].Cells[4].Value.ToString();

            lastSelectedProductKey = (int)ProductsDGV.SelectedRows[0].Cells[0].Value;

        }
    }
}
