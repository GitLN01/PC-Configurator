using BusinessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class PC_Konfigurator : Form
    {
        private readonly PCBusiness pcBusiness;
        public PC_Konfigurator()
        {
            this.pcBusiness = new PCBusiness();
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        void refreshPC()
        {
            List<PC> p = this.pcBusiness.GetAllPC();
            dataGridView1.DataSource = p;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            refreshPC();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (tbGPU.Text != "" && tbCPU.Text != "" && tbRAM.Text != "" && tbMotherboard.Text != "" && tbStorage.Text != "" && tbCase.Text != "" && tbPSU.Text != "" && tbStorage.Text != "")
            {
                PC p = new PC();
                p.GPU = tbGPU.Text;
                p.CPU = tbCPU.Text;
                p.RAM = tbRAM.Text;
                p.Motherboard = tbMotherboard.Text;
                p.Storage = tbStorage.Text;
                p.Case = tbCase.Text;
                p.PSU = tbPSU.Text;
                p.Description = tbDescription.Text;

                this.pcBusiness.InsertPC(p);

                refreshPC();
                tbGPU.Text = "";
                tbCPU.Text = "";
                tbRAM.Text = "";
                tbMotherboard.Text = "";
                tbStorage.Text = "";
                tbCase.Text = "";
                tbPSU.Text = "";
                tbDescription.Text = "";
                MessageBox.Show("Racunar je dodat u bazu!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Popunite sva obavezna polja!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (tbGPU.Text != "" || tbCPU.Text != "" || tbRAM.Text != "" || tbMotherboard.Text != "" || tbStorage.Text != "" || tbCase.Text != "" || tbPSU.Text != "" || tbStorage.Text != "")
            {
                PC p = new PC();
                p.GPU = tbGPU.Text;
                p.CPU = tbCPU.Text;
                p.RAM = tbRAM.Text;
                p.Motherboard = tbMotherboard.Text;
                p.Storage = tbStorage.Text;
                p.Case = tbCase.Text;
                p.PSU = tbPSU.Text;
                p.Description = tbDescription.Text;
                p.Id = ID; 

                this.pcBusiness.UpdatePC(p);
                MessageBox.Show("Podaci o racunaru su ažurirani!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refreshPC();

                tbGPU.Text = "";
                tbCPU.Text = "";
                tbRAM.Text = "";
                tbMotherboard.Text = "";
                tbStorage.Text = "";
                tbCase.Text = "";
                tbPSU.Text = "";
                tbDescription.Text = "";
            }
            else
            {
                MessageBox.Show("Unesite barem jedan podatak za ažuriranje.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        int ID;
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
            PC p = new PC();
            p.Id = selectedId;
            if (this.pcBusiness.DeletePC(p))
            {
                refreshPC();
                tbGPU.Text = "";
                tbCPU.Text = "";
                tbRAM.Text = "";
                tbMotherboard.Text = "";
                tbStorage.Text = "";
                tbCase.Text = "";
                tbPSU.Text = "";
                tbDescription.Text = "";
                MessageBox.Show("Izabrani PC je uspešno obrisan iz baze!","Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Neuspešno brisanje!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                tbGPU.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value?.ToString();
                tbCPU.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value?.ToString();
                tbRAM.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value?.ToString();
                tbMotherboard.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value?.ToString();
                tbStorage.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value?.ToString();
                tbCase.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value?.ToString();
                tbPSU.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value?.ToString();
                tbDescription.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value?.ToString();
            }
        }
    }
}
