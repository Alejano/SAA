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
    public partial class AdmAutos : Form
    {
        string[] DatosAuto = new string[99];
        public static byte[] imagenb;
        public static byte imagenA;
        public static int ID_AUTO = 0;
        int menu = 0;
        public static Bitmap bm = null;
        public AdmAutos()
        {
            InitializeComponent();
        }
        void limpiar() {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox6.Clear();
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            
           
            Bitmap flag = new Bitmap(200, 100);
            Graphics flagGraphics = Graphics.FromImage(flag);
            int red = 0;
            int white = 11;
            while (white <= 100)
            {
                flagGraphics.FillRectangle(Brushes.White, 0, white, 200, 10);
                flagGraphics.FillRectangle(Brushes.White, 0, white, 200, 10);
                red += 20;
                white += 20;
            }
            pictureBox1.Image = flag;
        }
        void BuscarIDAuto()
        {

            MongoClient client = new MongoClient("mongodb://Directivo:zaqxsw123@ds123410.mlab.com:23410/saa");
            var db = client.GetDatabase("saa");
            var usuarios = db.GetCollection<BsonDocument>("Auto");


            usuarios.AsQueryable<BsonDocument>().ToList().ForEach(song =>
          ID_AUTO = Convert.ToInt32(song["Id_Auto"])
          );

           
          // MessageBox.Show(Convert.ToString(ID_AUTO));

        }
        void Menu() {
            if (menu == 0) { groupBox1.Hide(); /*groupBox2.Hide();*/ dataGridView1.Show();  }
            if (menu == 1) { groupBox1.Show(); /*groupBox2.Hide(); */ dataGridView1.Show(); numericUpDown5.Hide(); }
            if (menu == 2) { groupBox1.Show(); /*groupBox2.Show(); */ dataGridView1.Hide(); numericUpDown5.Show(); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string imagen = openFileDialog1.FileName;
                    pictureBox1.Image = Image.FromFile(imagen);
                    Convertir_Imagen(Image.FromFile(imagen));
                   
                       
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ID_AUTO = ID_AUTO + 1;
            BsonDocument Auto = new BsonDocument
                  {//informacion del Auto
                    {"Id_Auto",Convert.ToString(ID_AUTO)},
                    {"Id_Suc",Convert.ToString(numericUpDown3.Value)},
                    {"Marca",textBox1.Text },
                    {"Modelo",textBox2.Text },
                    {"Tipo",textBox5.Text },
                    {"N_Puertas",Convert.ToString(numericUpDown1.Value) },
                    {"N_Plazas",Convert.ToString(numericUpDown2.Value) },
                    {"C_Maletero",textBox3.Text },
                    {"E_min",Convert.ToString(numericUpDown4.Value) },
                    {"Foto",imagenb }
                  };
            BsonDocument DatosAuto = Auto;

            MongoClient client = new MongoClient("mongodb://Directivo:zaqxsw123@ds123410.mlab.com:23410/saa");
            var db = client.GetDatabase("saa");
            var usuarios = db.GetCollection<BsonDocument>("Auto");

            usuarios.InsertOne(DatosAuto);
            limpiar();
        }
      
        public static byte[] Convertir_Imagen(Image img)
        {
            string sTemp = Path.GetTempFileName();
            FileStream fs = new FileStream(sTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            img.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
            fs.Position = 0;

            int imgLength = Convert.ToInt32(fs.Length);
            byte[] bytes = new byte[imgLength];
            fs.Read(bytes, 0, imgLength);
            fs.Close();
            imagenb = bytes;
            return bytes;
        }
        

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in dataGridView2.Rows)
            {

                String strFila = Row.Index.ToString();
                string Valor = Convert.ToString(Row.Cells[0].Value);
                //MessageBox.Show(Valor);
                if (Valor == Convert.ToString(numericUpDown3.Value))
                {


                    foreach (DataGridViewRow Row2 in dataGridView2.Rows)
                    {

                        String strFila2 = Row2.Index.ToString();
                        string Valor2 = Convert.ToString(Row.Cells[1].Value);
                        // MessageBox.Show(Valor2);
                        if (Valor == Convert.ToString(numericUpDown3.Value))
                        {

                            textBox6.Text = Valor2;
                        }

                    }
                }

            }
        }

        private void AdmAutos_Load(object sender, EventArgs e)
        {
            menu = 0;
            Menu();
            Actualizar();
            dataGridView2.Hide();
            BuscarIDAuto();

        }
        void Actualizar()
        {
            int i = 0;
            dataGridView2.Rows.Clear();
            MongoClient client = new MongoClient("mongodb://Directivo:zaqxsw123@ds123410.mlab.com:23410/saa");
            var db = client.GetDatabase("saa");
            var usuarios = db.GetCollection<BsonDocument>("Sucursal");

            usuarios.AsQueryable<BsonDocument>().ToList().ForEach(song =>
            dataGridView2.Rows.Add(Convert.ToString(song["Id_Suc"]), Convert.ToString(song["NombreS"]))
            );

            dataGridView1.Rows.Clear();

            MongoClient client2 = new MongoClient("mongodb://Directivo:zaqxsw123@ds123410.mlab.com:23410/saa");
            var db2 = client.GetDatabase("saa");
            var usuarios2 = db.GetCollection<BsonDocument>("Auto");

            usuarios2.AsQueryable<BsonDocument>().ToList().ForEach(song =>
            dataGridView1.Rows.Add(Convert.ToString(song["Id_Auto"]), Convert.ToString(song["Modelo"]))
            );

        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuscarIDAuto();
            limpiar();
            button3.Hide();
            button4.Show();
            button6.Hide();
            int max = 0;
            menu = 1;
            Menu();
            max = dataGridView2.Rows.GetLastRow(0);
            numericUpDown3.Maximum = max;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void autosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            button4.Hide();
            button3.Show();
            button6.Hide();
            BuscarIDAuto();
           
            numericUpDown5.Maximum = ID_AUTO;
            menu = 2;
            Menu();
            

        }
        public string ID_A = "";
        public string ID_S = "";

        void BuscarAuto()
        {

            MongoClient client = new MongoClient("mongodb://Directivo:zaqxsw123@ds123410.mlab.com:23410/saa");
            var db = client.GetDatabase("saa");
            var usuarios = db.GetCollection<BsonDocument>("Auto");


            var filter_id = Builders<BsonDocument>.Filter.Eq("Id_Auto", Convert.ToString(numericUpDown5.Value));
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

                // dataGridView1.Rows.Add(DatosAuto[7], DatosAuto[11], DatosAuto[19]);
                
                //MessageBox.Show(DatosAuto[11]);
                ID_A = DatosAuto[7];
                ID_S = DatosAuto[11];
                numericUpDown3.Value = Convert.ToInt16(DatosAuto[11]);
                textBox1.Text = DatosAuto[15];
                textBox2.Text = DatosAuto[19];
                textBox5.Text = DatosAuto[23];
                numericUpDown1.Value = Convert.ToInt16(DatosAuto[27]);
                numericUpDown2.Value = Convert.ToInt16(DatosAuto[31]);
                textBox3.Text = DatosAuto[35];
                numericUpDown4.Value = Convert.ToInt16(DatosAuto[39]);
                buscarimg();
                pictureBox1.Image = bm;
            }
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            BuscarAuto();
           
        }

        void buscarimg()
        {


            MongoClient client = new MongoClient("mongodb://Directivo:zaqxsw123@ds123410.mlab.com:23410/saa");
            var db = client.GetDatabase("saa");
            var usuarios = db.GetCollection<BsonDocument>("Auto");


            var filter_id = Builders<BsonDocument>.Filter.Eq("Id_Auto", Convert.ToString(numericUpDown5.Value));
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

        private void button3_Click(object sender, EventArgs e)
        {
            int IDB = 0;
            if (MessageBox.Show("Seguro que desea Eliminar?", "Eliminar",
       MessageBoxButtons.YesNo, MessageBoxIcon.Question)
       == DialogResult.Yes)
            {

                IDB = Convert.ToInt16(numericUpDown1.Value);
                MongoClient client = new MongoClient("mongodb://Directivo:zaqxsw123@ds123410.mlab.com:23410/saa");
                var db = client.GetDatabase("saa");
                var usuarios = db.GetCollection<BsonDocument>("Auto");

                usuarios.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("Id_Auto", ID_A));

                limpiar();
            }
        }

        void eliminarA() {
            int IDB = 0;
            if (MessageBox.Show("¿Seguro que desea Actualizar?", "Eliminar",
       MessageBoxButtons.YesNo, MessageBoxIcon.Question)
       == DialogResult.Yes)
            {

                IDB = Convert.ToInt16(numericUpDown5.Value);
                MongoClient client = new MongoClient("mongodb://Directivo:zaqxsw123@ds123410.mlab.com:23410/saa");
                var db = client.GetDatabase("saa");
                var usuarios = db.GetCollection<BsonDocument>("Auto");

                usuarios.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("Id_Auto", ID_A));

               
            }

        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
            button4.Hide();
            button3.Hide();
            button6.Show();
            BuscarIDAuto();
            
            numericUpDown5.Maximum = ID_AUTO;
            menu = 2;
            Menu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            eliminarA();

            BsonDocument Auto = new BsonDocument
                  {//informacion del Auto
                    {"Id_Auto",Convert.ToString(ID_AUTO)},
                    {"Id_Suc",Convert.ToString(numericUpDown3.Value)},
                    {"Marca",textBox1.Text },
                    {"Modelo",textBox2.Text },
                    {"Tipo",textBox5.Text },
                    {"N_Puertas",Convert.ToString(numericUpDown1.Value) },
                    {"N_Plazas",Convert.ToString(numericUpDown2.Value) },
                    {"C_Maletero",textBox3.Text },
                    {"E_min",Convert.ToString(numericUpDown4.Value) },
                    {"Foto",imagenb }
                  };
            BsonDocument DatosAuto = Auto;

            MongoClient client = new MongoClient("mongodb://Directivo:zaqxsw123@ds123410.mlab.com:23410/saa");
            var db = client.GetDatabase("saa");
            var usuarios = db.GetCollection<BsonDocument>("Auto");

            usuarios.InsertOne(DatosAuto);
            limpiar();
            menu = 0;
            Menu();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
