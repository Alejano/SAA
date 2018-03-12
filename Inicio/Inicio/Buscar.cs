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
using System.IO;

namespace Inicio
{
    public partial class Buscar : Form
    {
        string ID_A = "";
        string buscar = "";
        string[] DatosAuto = new string[99];
        public static byte[] imagenb;
        public static Bitmap bm = null;

        public Buscar()
        {
            InitializeComponent();
        }
        void mostrar()
        {
            dataGridView1.AutoGenerateColumns = true;

            MongoClient client = new MongoClient("mongodb://Directivo:zaqxsw123@ds123410.mlab.com:23410/saa");
            var db = client.GetDatabase("saa");
            var usuarios = db.GetCollection<BsonDocument>("Auto");

            usuarios.AsQueryable<BsonDocument>().ToList().ForEach(equis =>
            dataGridView1.Rows.Add(Convert.ToString(equis["Id_Auto"]), Convert.ToString(equis["Id_Suc"]), Convert.ToString(equis["Marca"]),
            Convert.ToString(equis["Modelo"]), Convert.ToString(equis["N_Plazas"]), Convert.ToString(equis["C_Maletero"]),
            Convert.ToString(equis["E_min"])));
        }

      /*  void buscarimg()
        {


            MongoClient client = new MongoClient("mongodb://Directivo:zaqxsw123@ds123410.mlab.com:23410/saa");
            var db = client.GetDatabase("saa");
            var usuarios = db.GetCollection<BsonDocument>("Auto");


            var filter_id = Builders<BsonDocument>.Filter.Eq("Id_Auto", ID_A);
            var ultimo7 = usuarios.Find<BsonDocument>(filter_id).FirstOrDefault();
            byte[] data = ultimo7["Foto"].AsBsonBinaryData.Bytes;
            imagenb = data;
            Convertir_Bytes_Imagen(imagenb);
            ultimo7.Clear();
        }
        

        void buscarimgmodelo()
        {
            ID_A = textBox12.Text;

            MongoClient client = new MongoClient("mongodb://Directivo:zaqxsw123@ds123410.mlab.com:23410/saa");
            var db = client.GetDatabase("saa");
            var usuarios = db.GetCollection<BsonDocument>("Auto");


            var filter_id = Builders<BsonDocument>.Filter.Eq("Modelo", ID_A);
            var ultimo7 = usuarios.Find<BsonDocument>(filter_id).FirstOrDefault();
            byte[] data = ultimo7["Foto"].AsBsonBinaryData.Bytes;
            imagenb = data;
            Convertir_Bytes_Imagen(imagenb);
            ultimo7.Clear();
        }


       /* void buscarimgmarca()
        {
            ID_A = textBox18.Text;

            MongoClient client = new MongoClient("mongodb://Directivo:zaqxsw123@ds123410.mlab.com:23410/saa");
            var db = client.GetDatabase("saa");
            var usuarios = db.GetCollection<BsonDocument>("Auto");


            var filter_id = Builders<BsonDocument>.Filter.Eq("Marca", ID_A);
            var ultimo7 = usuarios.Find<BsonDocument>(filter_id).FirstOrDefault();
            byte[] data = ultimo7["Foto"].AsBsonBinaryData.Bytes;
            imagenb = data;
            Convertir_Bytes_Imagen(imagenb);
            ultimo7.Clear();
        }
        public static Image Convertir_Bytes_Imagen(byte[] bytes)
        {
            if (bytes == null) return null;
            // MessageBox.Show("Convirtiendo byte a img :C");
            MemoryStream ms = new MemoryStream(bytes);

            try
            {
                bm = new Bitmap(ms);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return bm;

        }
        */

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Buscar_Load(object sender, EventArgs e)
        {
            tabControl1.Hide();
            mostrar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            button1.Hide();
            tabControl1.Show();



        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //jalas los datos de dataview

            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {

                String strFila = Row.Index.ToString();
                string Valor = Convert.ToString(Row.Cells[0].Value);
                //MessageBox.Show(Valor);
                if (Valor == Convert.ToString(textBox1.Text))

                {


                    foreach (DataGridViewRow Row2 in dataGridView1.Rows)
                    {

                        String strFila2 = Row2.Index.ToString();
                        string Valor2 = Convert.ToString(Row.Cells[1].Value);
                        // MessageBox.Show(Valor2);
                        if (Valor == Convert.ToString(textBox1.Text))
                        {

                            textBox2.Text = Valor2;
                        }

                    }
                }

                //termina jalara datos de dataview

                /*
                ID_A = textBox1.Text;
                int longitud = textBox1.Text.Length;

                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Ingrese matricula");
                }

                else
                {
                    MongoClient client = new MongoClient("mongodb://Directivo:zaqxsw123@ds123410.mlab.com:23410/saa");
                    var db = client.GetDatabase("saa");
                    var usuarios = db.GetCollection<BsonDocument>("Auto");

                    var filter_id = Builders<BsonDocument>.Filter.Eq("Id_Auto", ID_A);
                    var entity = usuarios.Find(filter_id).FirstOrDefault();


                    if (entity == null)
                    {
                        MessageBox.Show("Id no existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        String DtAdmjson = entity.ToString();
                        char[] separador = { '"', '"' };
                        DatosAuto = DtAdmjson.Split(separador);



                        textBox2.Text = DatosAuto[15];
                        textBox3.Text = DatosAuto[19];
                        //textBox4.Text = DatosAuto[15];
                        textBox5.Text = DatosAuto[11];
                        textBox6.Text = DatosAuto[39];
                        buscarimg();
                        pictureBox1.Image = bm;

                    }
                }
                */
            }
        }

    

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            ID_A = textBox12.Text;
            int longitud = textBox12.Text.Length;

            if (string.IsNullOrEmpty(textBox12.Text))
            {
                MessageBox.Show("Ingrese modelo");
            }

            else
            {
                MongoClient client = new MongoClient("mongodb://Directivo:zaqxsw123@ds123410.mlab.com:23410/saa");
                var db = client.GetDatabase("saa");
                var usuarios = db.GetCollection<BsonDocument>("Auto");

                var filter_id = Builders<BsonDocument>.Filter.Eq("Modelo", ID_A);
                var entity = usuarios.Find(filter_id).FirstOrDefault();


                if (entity == null)
                {
                    MessageBox.Show("Modelo no disponible", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    String DtAdmjson = entity.ToString();
                    char[] separador = { '"', '"' };
                    DatosAuto = DtAdmjson.Split(separador);


                    textBox11.Text = DatosAuto[11];
                    textBox10.Text = DatosAuto[15];
                    textBox9.Text = DatosAuto[19];
                    textBox8.Text = DatosAuto[11];
                    textBox7.Text = DatosAuto[39];
                    //buscarimgmodelo();
                    pictureBox2.Image = bm;

                }
            }
        }

        private void button3_KeyPress(object sender, KeyPressEventArgs e)
        {

            
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            ID_A = textBox18.Text;
            int longitud = textBox18.Text.Length;

            if (string.IsNullOrEmpty(textBox18.Text))
            {
                MessageBox.Show("Ingrese marca");
            }

            else
            {
                MongoClient client = new MongoClient("mongodb://Directivo:zaqxsw123@ds123410.mlab.com:23410/saa");
                var db = client.GetDatabase("saa");
                var usuarios = db.GetCollection<BsonDocument>("Auto");

                var filter_id = Builders<BsonDocument>.Filter.Eq("Marca", ID_A);
                var entity = usuarios.Find(filter_id).FirstOrDefault();


                if (entity == null)
                {
                    MessageBox.Show("Marca no disponible", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    String DtAdmjson = entity.ToString();
                    char[] separador = { '"', '"' };
                    DatosAuto = DtAdmjson.Split(separador);


                    textBox17.Text = DatosAuto[11];
                    textBox16.Text = DatosAuto[15];
                    textBox15.Text = DatosAuto[19];
                    textBox14.Text = DatosAuto[11];
                    textBox13.Text = DatosAuto[39];
                    //buscarimgmarca();
                    pictureBox3.Image = bm;

                }
            }

        }
    }
}