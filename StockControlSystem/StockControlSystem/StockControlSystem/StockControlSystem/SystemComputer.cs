using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace StockControlSystem
{
    public delegate void loadEntityEventHandler(string[] entity);
    public partial class SystemComputer : Form
    {
        Control control;

        public SystemComputer()
        {
            InitializeComponent();
            control = new Control();
        }

        private void loadFile(string nameFilter, int numberOfEntriesInLine, loadEntityEventHandler load)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = nameFilter;
            openFileDialog.InitialDirectory = Application.StartupPath;
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string s;
                string[] properties = new string[numberOfEntriesInLine];
                char spliter = '&';

                try
                {
                    using (TextReader trs = new StreamReader(openFileDialog.FileName))
                    {
                        while (((s = trs.ReadLine()) != null) && s!= "")
                        {          
                            properties = s.Split(spliter);
                            load(properties);
                        }
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("Exception is caught (LoadFile)");
                }           
            }
        }

        private void btnLoadSuppliers_Click(object sender, EventArgs e)
        {
            loadFile("Suppliers|*.txt", 4, control.loadSupplier);         
        }

        private void btnLoadStock_Click(object sender, EventArgs e)
        {
            loadFile("StockItems|*.txt", 7, control.loadStock);
            Till till = new Till();
            till.Show();
        }

        private void btnListAllSuppliers_Click(object sender, EventArgs e)
        {
            ListDialog ld = new ListDialog();
            ld.Show();
        }

        private void btnListAllStock_Click(object sender, EventArgs e)
        {

        }

        private void btnListScarceStock_Click(object sender, EventArgs e)
        {

        }

        private void btnOrder_Click(object sender, EventArgs e)
        {

        }

        private void btnListOutstandingOrders_Click(object sender, EventArgs e)
        {

        }

        private void btnRestock_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }
    }
}
