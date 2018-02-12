using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inicio
{
    public partial class inicioAdm : Form
    {
    
        public inicioAdm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdmAutos aa = new AdmAutos(); ;
            aa.Show(this);
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sucursales suc = new Sucursales();
            suc.Show(this);
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void inicioAdm_Load(object sender, EventArgs e)
        {
            if (Inicio.UsuarioI == "1") { }
            if (Inicio.UsuarioI == "2") { button3.Hide(); button4.Hide(); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdmUsuarios admu=new AdmUsuarios();
            admu.Show(this);
            this.Hide();
        }
    }
}
