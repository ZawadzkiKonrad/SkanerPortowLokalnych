using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skaner_portów_lokalnych
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Usuwanie przyciskow minimalizuj, maxymalizuj, zamknij:
            this.ControlBox = false;
        }
        //Funkcja "skanujporty":
        private void skanuj()
        {
            progressBar1.Value = 0;
            if (numericUpDown1.Value > numericUpDown2.Value)
            {
                MessageBox.Show("Błedny zakres portów.");
                return;
            }
            listBox1.Items.Add("Rozpoczęcie skanowania");
            for (int i = (int)numericUpDown1.Value; i <= (int)numericUpDown2.Value; i++)
            {
                progressBar1.Value++;
                this.Refresh();
                label1.Text = "Aktualnie skanowany port: " + i;
                try
                {
                    TcpListener serwer = new TcpListener(IPAddress.Loopback, i);
                    serwer.Start();
                    serwer.Stop();
                }
                catch
                {
                    listBox1.Items.Add("Port: " + i + " jest zajęty");
                }
            }
            progressBar1.Value = progressBar1.Maximum;
            listBox1.Items.Add("Koniec skanowania");
        }
        //Po kliknieciu na "START:"
        private void button1_Click(object sender, EventArgs e)
        {
            skanuj();
        }
        //Po kliknieciu na "wyjdz z programu":
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
