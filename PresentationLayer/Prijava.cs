using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class Prijava : Form
    {
        public Prijava()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string username = "user";
            string password = "pass";

            if (tbUsername.Text == username && tbPassword.Text == password)
            {
                var log = new PC_Konfigurator();
                log.Show();
                this.Hide();
            }

            else
            {
                if (tbUsername.Text != username)
                {
                    MessageBox.Show("Pogrešno korisničko ime. Molimo pokušajte ponovo.", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Pogrešna lozinka. Molimo pokušajte ponovo.", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
