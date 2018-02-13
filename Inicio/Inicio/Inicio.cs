using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Inicio
{
    public partial class Inicio : Form
    {
        public static string usu = "";
        bool u = false;
        bool c = false;
        public static string UsuarioI = "";
        

        public Inicio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text != "" && textBox2.Text != "")
            {



                foreach (DataGridViewRow Row in dataGridView1.Rows)
                {

                    String strFila = Row.Index.ToString();
                    string Valor = Convert.ToString(Row.Cells["Usuario"].Value);
                    string Valor2 = Convert.ToString(Row.Cells["Contraseña"].Value);
                    string Valor3 = Convert.ToString(Row.Cells["Nivel"].Value);

                    if (Valor == this.textBox1.Text)
                    {
                        u = true;
                        usu = Valor;
                        if (Valor2 == this.textBox2.Text)
                        {
                            c = true;


                            if (Valor3 == "1")
                            {
                                UsuarioI = Valor3;
                                inicioAdm Adm = new inicioAdm();
                                Adm.Show(this);
                                this.Hide();
                                usu = Valor;
                                textBox1.Clear();
                                textBox2.Clear();


                            }
                            else
                            {
                                if (Valor3 == "2")
                                {
                                    UsuarioI = Valor3;
                                    inicioAdm Adm = new inicioAdm();
                                    Adm.Show(this);
                                    this.Hide();
                                    usu = Valor;
                                   
                                    textBox1.Clear();
                                    textBox2.Clear();
                                }
                                else {
                                    if (Valor3 == "3")
                                    {
                                        Oficina of = new Oficina();
                                        of.Show(this);
                                        this.Hide();

                                        usu = Valor;
                                       
                                        textBox1.Clear();
                                        textBox2.Clear();
                                    };
                                }

                            }
                        }
                        else
                        {
                            MessageBox.Show("Usuario o Contraseña incorrectos");
                        }
                    }
                }
                if (u == false) { MessageBox.Show("Usuario o Contraseña incorrectos"); }

            }
            else
            {
                if (textBox1.Text == "" && textBox2.Text == "") { MessageBox.Show("Necesita ingresar los datos"); }
                else
                {
                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("Necesita ingresar su nombre de Usuario");
                    }
                    else
                    {
                        MessageBox.Show("Necesita ingresar su contraseña");
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            dataGridView1.Hide();

            conectar();

        }

        void conectar()
        {
            MongoClient client = new MongoClient("mongodb://Directivo:zaqxsw123@ds123410.mlab.com:23410/saa");
            var db = client.GetDatabase("saa");
            var usuarios = db.GetCollection<BsonDocument>("Admin");

            if (usuarios == null)
            {

                MessageBox.Show("Conccion no exitosa, verifique su internet");
                Close();
            }
            else
            {

                usuarios.AsQueryable<BsonDocument>().ToList().ForEach(song =>

         dataGridView1.Rows.Add(Convert.ToString(song["Usuario"]), Convert.ToString(song["Contraseña"]), Convert.ToString(song["Nivel"]))
        );
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Oficina of = new Oficina();
            of.Show(this);
            this.Hide();

            //Chicas para cerrar secion y regresar a este formulario ocupen esto...
            //this.Owner.Show();
            //this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Buscar bus = new Buscar();
            bus.Show();
        }
    }
}
