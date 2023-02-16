using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S7.Net;

namespace TiaportalHaberlesme
{
    public partial class Form1 : Form
    {
        Plc plcim;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBaglantiKur_Click(object sender, EventArgs e)
        {
            plcim = new Plc(CpuType.S71200, "192.168.0.5", 0, 1);
            plcim.Open();
            timer1.Start();
            if (plcim.IsConnected)
            {
                lblBaglantidurum.Text = "Plc'ye Baglantı Başarılı";
                lblBaglantidurum.ForeColor = Color.Green;
                btnBaglantiKur.BackColor = Color.Green;
                btnBaglantiKur.Text = "PLC'ye Baglantı Kuruldu";
                btnBaglantiKes.BackColor = Color.WhiteSmoke;
                btnBaglantiKes.Text = "Baglantı Kesildi";
               


            }
            

        }

        private void btnBaglantiKes_Click(object sender, EventArgs e)
        {
            plcim.Close();
            lblBaglantidurum.Text = "Plc Baglantı Kesildi";
            lblBaglantidurum.ForeColor = Color.Red;
            btnBaglantiKes.BackColor = Color.Red;
            btnBaglantiKur.Text = "Baglantı Kur";
            btnBaglantiKur.BackColor = Color.WhiteSmoke;
            timer1.Stop();
        
        }
        

        private void btnVeri_al_Click(object sender, EventArgs e)
        {
            
            try
            {
                lblBaglantidurum.Text = "Baglantı Yok";

            }
            catch (Exception)
            {

                lblBaglantidurum.Text = "Baglantıyı Kontrol Kdiniz";
            }  
           
         

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            txbStart.Text = (plcim.Read("DB1.DBX0.0")).ToString();
            txbStop.Text = (plcim.Read("DB1.DBX0.1")).ToString();
            txbAcilstop.Text = (plcim.Read("DB1.DBX0.2")).ToString();
            txbIlerde.Text = (plcim.Read("DB1.DBX0.3")).ToString();
            txbGeride.Text = (plcim.Read("DB1.DBX0.4")).ToString();
            txbHome.Text = (plcim.Read("DB1.DBX0.5")).ToString();
            txbYSicaklik.Text = (plcim.Read("DB1.DBX0.6")).ToString();
            txbYBasinc.Text = (plcim.Read("DB1.DBX0.7")).ToString();
            txbQ0_0.Text = (plcim.Read("Q0.0")).ToString();
            txbQ0_1.Text = (plcim.Read("Q0.1")).ToString();
            txbQ0_2.Text = (plcim.Read("Q0.2")).ToString();
            txbQ0_3.Text = (plcim.Read("Q0.3")).ToString();
            txbQ0_4.Text = (plcim.Read("Q0.4")).ToString();
            txbQ0_5.Text = (plcim.Read("Q0.5")).ToString();
            txbQ0_6.Text = (plcim.Read("Q0.6")).ToString();
            txbQ0_7.Text = (plcim.Read("Q0.7")).ToString();

            txbHiz.Text = (plcim.Read(DataType.DataBlock, 1, 2, VarType.Int, 1)).ToString();
            txbEncoder.Text = (plcim.Read(DataType.DataBlock, 1, 4, VarType.Int, 1)).ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            plcim.Write("DB1.DBX6.0", true);
            plcim.Write("DB1.DBX6.1", true);
            plcim.Write("DB1.DBX6.2", true);
            plcim.Write("DB1.DBX6.3", true);
            plcim.Write("DB1.DBX6.4", true);
            plcim.Write("DB1.DBX6.5", true);
            plcim.Write("DB1.DBX6.6", true);
            plcim.Write("DB1.DBX6.7", true);
            btnQ0_0_False.BackColor = Color.Red;
            btnQ0_0_True.BackColor = Color.Green;
            txbCikis_1.Text = "Aktif";
            txbCikis_1.ForeColor = Color.Green;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          
            
                plcim.Write("DB1.DBX6.0", false);
                plcim.Write("DB1.DBX6.1", false);
                plcim.Write("DB1.DBX6.2", false);
                plcim.Write("DB1.DBX6.3", false);
                plcim.Write("DB1.DBX6.4", false);
                plcim.Write("DB1.DBX6.5", false);
                plcim.Write("DB1.DBX6.6", false);
                plcim.Write("DB1.DBX6.7", false);

            
          
        }

        private void btnQ0_0_True_Click(object sender, EventArgs e)
        {
           
                plcim.Write("DB1.DBX6.0", true);
                btnQ0_0_True.ForeColor = Color.Black;
                txbCikis_1.ForeColor = Color.Green;
                txbCikis_1.Text = "Aktif";
                btnQ0_0_False.ForeColor = Color.Black;
                btnQ0_0_True.BackColor = Color.Green;
                btnQ0_0_False.BackColor = Color.White;

            
           
        }

        private void btnQ0_0_False_Click(object sender, EventArgs e)
        {
           
            plcim.Write("DB1.DBX6.0", false);
            btnQ0_0_False.ForeColor = Color.Black;
            txbCikis_1.ForeColor = Color.Red;
            txbCikis_1.Text = "Pasif";
            btnQ0_0_True.ForeColor = Color.Black;
            btnQ0_0_False.BackColor = Color.Red;
            btnQ0_0_True.BackColor = Color.White;

        }

        private void btnQ0_1_True_Click(object sender, EventArgs e)
        {
          
            plcim.Write("DB1.DBX6.1", true);
            btnQ0_1_True.ForeColor = Color.Black;
            txbCikis_2.ForeColor = Color.Green;
            txbCikis_2.Text = "Aktif";
            btnQ0_1_False.ForeColor = Color.Black;
            btnQ0_1_True.BackColor = Color.Green;
            btnQ0_1_False.BackColor = Color.White;
        }

        private void btnQ0_1_False_Click(object sender, EventArgs e)
        {
            
            plcim.Write("DB1.DBX6.1", false);
            btnQ0_1_False.ForeColor = Color.Black;
            txbCikis_2.ForeColor = Color.Red;
            txbCikis_2.Text = "Pasif";
            btnQ0_1_True.ForeColor = Color.Black;
            btnQ0_1_False.BackColor = Color.Red;
            btnQ0_1_True.BackColor = Color.White;
        }

        private void btnQ0_2_True_Click(object sender, EventArgs e)
        {
            plcim.Write("DB1.DBX6.2", true);
            btnQ0_2_True.ForeColor = Color.Black;
            txbCikis_3.ForeColor = Color.Green;
            txbCikis_3.Text = "Aktif";
            btnQ0_2_False.ForeColor = Color.Black;
            btnQ0_2_True.BackColor = Color.Green;
            btnQ0_2_False.BackColor = Color.White;
        }

        private void btnQ0_2_False_Click(object sender, EventArgs e)
        {
            plcim.Write("DB1.DBX6.2", false);
            btnQ0_2_False.ForeColor = Color.Black;
            txbCikis_3.ForeColor = Color.Red;
            txbCikis_3.Text = "Pasif";
            btnQ0_2_True.ForeColor = Color.Black;
            btnQ0_2_False.BackColor = Color.Red;
            btnQ0_2_True.BackColor = Color.White;
        }

        private void btnQ0_3_True_Click(object sender, EventArgs e)
        {
            plcim.Write("DB1.DBX6.3", true);
            btnQ0_3_True.ForeColor = Color.Black;
            txbCikis_4.ForeColor = Color.Green;
            txbCikis_4.Text = "Aktif";
            btnQ0_3_False.ForeColor = Color.Black;
            btnQ0_3_True.BackColor = Color.Green;
            btnQ0_3_False.BackColor = Color.White;
        }

        private void btnQ0_3_False_Click(object sender, EventArgs e)
        {
            plcim.Write("DB1.DBX6.3", false);
            btnQ0_3_False.ForeColor = Color.Black;
            txbCikis_4.ForeColor = Color.Red;
            txbCikis_4.Text = "Pasif";
            btnQ0_3_True.ForeColor = Color.Black;
            btnQ0_3_False.BackColor = Color.Red;
            btnQ0_3_True.BackColor = Color.White;
        }

        private void btnQ0_4_True_Click(object sender, EventArgs e)
        {
            plcim.Write("DB1.DBX6.4", true);
            btnQ0_4_True.ForeColor = Color.Black;
            txbCikis_5.ForeColor = Color.Green;
            txbCikis_5.Text = "Aktif";
            btnQ0_4_False.ForeColor = Color.Black;
            btnQ0_4_True.BackColor = Color.Green;
            btnQ0_4_False.BackColor = Color.White;
        }

        private void btnQ0_4_False_Click(object sender, EventArgs e)
        {
            plcim.Write("DB1.DBX6.4", false);
            btnQ0_4_False.ForeColor = Color.Black;
            txbCikis_5.ForeColor = Color.Red;
            txbCikis_5.Text = "Pasif";
            btnQ0_4_True.ForeColor = Color.Black;
            btnQ0_4_False.BackColor = Color.Red;
            btnQ0_4_True.BackColor = Color.White;
        }

        private void btnQ0_5_True_Click(object sender, EventArgs e)
        {
            plcim.Write("DB1.DBX6.5", true);
            btnQ0_5_True.ForeColor = Color.Black;
            txbCikis_6.ForeColor = Color.Green;
            txbCikis_6.Text = "Aktif";
            btnQ0_5_False.ForeColor = Color.Black;
            btnQ0_5_True.BackColor = Color.Green;
            btnQ0_5_False.BackColor = Color.White;
        }

        private void btnQ0_5_False_Click(object sender, EventArgs e)
        {
            plcim.Write("DB1.DBX6.5", false);
            btnQ0_5_False.ForeColor = Color.Black;
            txbCikis_6.ForeColor = Color.Red;
            txbCikis_6.Text = "Pasif";
            btnQ0_5_True.ForeColor = Color.Black;
            btnQ0_5_False.BackColor = Color.Red;
            btnQ0_5_True.BackColor = Color.White;
        }

        private void btnQ0_6_True_Click(object sender, EventArgs e)
        {
            plcim.Write("DB1.DBX6.6", true);
            btnQ0_6_True.ForeColor = Color.Black;
            txbCikis_7.ForeColor = Color.Green;
            txbCikis_7.Text = "Aktif";
            btnQ0_6_False.ForeColor = Color.Black;
            btnQ0_6_True.BackColor = Color.Green;
            btnQ0_6_False.BackColor = Color.White;
        }

        private void btnQ0_6_False_Click(object sender, EventArgs e)
        {
            plcim.Write("DB1.DBX6.6", false);
            btnQ0_6_False.ForeColor = Color.Black;
            txbCikis_7.ForeColor = Color.Red;
            txbCikis_7.Text = "Pasif";
            btnQ0_6_True.ForeColor = Color.Black;
            btnQ0_6_False.BackColor = Color.Red;
            btnQ0_6_True.BackColor = Color.White;
        }

        private void btnQ0_7_True_Click(object sender, EventArgs e)
        {
            plcim.Write("DB1.DBX6.7", true);
            btnQ0_7_True.ForeColor = Color.Black;
            txbCikis_8.ForeColor = Color.Green;
            txbCikis_8.Text = "Aktif";
            btnQ0_7_False.ForeColor = Color.Black;
            btnQ0_7_True.BackColor = Color.Green;
            btnQ0_7_False.BackColor = Color.White;
        }

        private void btnQ0_7_False_Click(object sender, EventArgs e)
        {
            plcim.Write("DB1.DBX6.7", false);
            btnQ0_7_False.ForeColor = Color.Black;
            txbCikis_8.ForeColor = Color.Red;
            txbCikis_8.Text = "Pasif";
            btnQ0_7_True.ForeColor = Color.Black;
            btnQ0_7_False.BackColor = Color.Red;
            btnQ0_7_True.BackColor = Color.White;
        }

      
    }
}
