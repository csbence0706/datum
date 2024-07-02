using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace datum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        private DateTime ma = DateTime.Now;
        private DateTime szulDatum;
        private DateTime valasztottDatum;
        private void Form1_Load(object sender, EventArgs e)
        {
            lblDatum.Text = ma.ToString("F");
            lblGratulacio.Text = "";
            valasztottDatum = dateTimePicker1.Value;
            ActiveControl = mskdTxtSzuldatum;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("hu-HU");
        }



        private void lblGratulacio_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            valasztottDatum = dateTimePicker1.Value;
            txtNapSorszam.Text = valasztottDatum.DayOfYear.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDatum.Text = DateTime.Now.ToString("F");
        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBezar_Click(object sender, EventArgs e)
        {
            DialogResult valasz = MessageBox.Show("Biztosan kilép?", "Megerősítés", MessageBoxButtons.YesNo);

            if (valasz == DialogResult.Yes) this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void mskdTxtSzuldatum_Leave_1(object sender, EventArgs e)
        {
            try
            {
                if (!mskdTxtSzuldatum.MaskCompleted) throw new FormatException();
                else
                {
                    szulDatum = DateTime.Parse(mskdTxtSzuldatum.Text);
                    if (szulDatum.Month == ma.Month && szulDatum.Day == ma.Day)
                    {
                        lblGratulacio.Text = "Isten éltessen!";
                    }
                    else
                    {
                        lblGratulacio.Text = "Boldog hétköznapot!";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hibás dátum", "Hiba");
                mskdTxtSzuldatum.Focus();

            }
        }

        private void mskdTxtSzuldatum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) mskdTxtSzuldatum_Leave_1(sender, e);
        }

        private void btnKiir_Click(object sender, EventArgs e)
        {
            txtEvSzam.Text = (ma.Year - szulDatum.Year).ToString();
            txtNap.Text = szulDatum.DayOfWeek.ToString();
            txtNapSorszam.Text = valasztottDatum.DayOfYear.ToString();
        }

        private void txtNapSzam_TextChanged(object sender, EventArgs e)
        {
            int hossz = txtNapSzam.Text.Length;
            if ((hossz >= 2 && txtNapSzam.Text.ElementAt(0) == '-') || (hossz >= 1 && txtNapSzam.Text.ElementAt(0) != '-'))
            {
                try
                {
                    int nap = int.Parse(txtNapSzam.Text);
                    txtKesobbiDatum.Text = valasztottDatum.AddDays(nap).ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("Nem számot írt", "Hiba");
                }
            }
        }

        private void btnTorol_Click(object sender, EventArgs e)
        {
            foreach (var item in this.Controls)
            {
                if (item is TextBox) ((TextBox)item).Clear();
            }
            lblGratulacio.Text = "";
            mskdTxtSzuldatum.Clear();
        }
    }
}