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
    public partial class AdmUsuarios : Form
    {
        int limp = 0;
        string[] DatosAdm = new string[99];
        string IDB = "";
        static int ID_adm = 0;
        public AdmUsuarios()
        {
            InitializeComponent();
        }


        private void agregarNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limp = 1;
            Limpiar();
            //MessageBox.Show("se agregara uno nuevo");
            groupBox1.Show();
            Obtenerid();


        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limp = 2;
            Limpiar();
            // MessageBox.Show("se actualizara uno ");
            groupBox2.Show();
        }

        void Limpiar()
        {
            if (limp == 1) { groupBox2.Hide(); groupBox3.Hide(); groupBox4.Hide();groupBox8.Hide(); groupBox9.Hide(); }
            if (limp == 2) { groupBox1.Hide(); groupBox3.Hide(); groupBox4.Hide();  groupBox8.Hide(); groupBox9.Hide(); }
            if (limp == 3) { groupBox1.Hide(); groupBox2.Hide(); groupBox4.Hide();  groupBox8.Hide(); groupBox9.Hide(); }
            if (limp == 4) { groupBox1.Hide(); groupBox2.Hide(); groupBox3.Hide();groupBox8.Hide(); }
            if (limp == 5) { groupBox1.Hide(); groupBox2.Hide(); groupBox3.Hide(); groupBox4.Hide();  groupBox8.Hide(); }
            if (limp == 6) { groupBox1.Hide(); groupBox2.Hide(); groupBox3.Hide(); groupBox4.Hide(); groupBox9.Hide(); }
            if (limp == 9) { groupBox1.Hide(); groupBox2.Hide(); groupBox3.Hide(); groupBox4.Hide(); groupBox8.Hide(); groupBox6.Hide(); }
        }

        private void Agregar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        void Agregar_Admin()
        {
            bool verificacion = false;



            // MessageBox.Show("creando Administrador");
            BsonDocument Admin = new BsonDocument
                  {//informacion del alumno
                    {"Id_Adm",textBox1.Text},
                    {"Usuario",textBox2.Text },
                    {"Contraseña",textBox3.Text },
                    {"Nivel",comboBox1.Text }


                  };
            BsonDocument DatosAdmin = Admin;
            int longitud = textBox7.Text.Length;
            if (textBox4.Text == textBox3.Text)
            {
                longitud = textBox3.Text.Length;
                if (longitud >= 6)
                {



                    foreach (DataGridViewRow Row in dataGridView1.Rows)
                    {

                        String strFila = Row.Index.ToString();
                        string Valor = Convert.ToString(Row.Cells["Usuario"].Value);

                        if (Valor == this.textBox2.Text)
                        {
                            verificacion = true;
                        }

                    }
                    if (verificacion == true)
                    {
                        MessageBox.Show("Usuario ya existe");
                    }
                    else
                    {
                        MongoClient client = new MongoClient("mongodb://Directivo:zaqxsw123@ds123410.mlab.com:23410/saa");
                        var db = client.GetDatabase("saa");
                        var usuarios = db.GetCollection<BsonDocument>("Admin");

                        usuarios.InsertOne(DatosAdmin);
                      
                        //MessageBox.Show("Administrador creado");
                        limpiarDatos();
                        Actualizar();
                    }
                }
                else { MessageBox.Show("La contraseña debe tener minimo 6 caracteres"); }
            }
            else { MessageBox.Show("Contraseña no coincide"); }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Agregar_Admin();
            Obtenerid();
        }

        void Obtenerid()
        {
            MongoClient client = new MongoClient("mongodb://Directivo:zaqxsw123@ds123410.mlab.com:23410/saa");
            var db = client.GetDatabase("saa");
            var usuarios = db.GetCollection<BsonDocument>("Admin");

            usuarios.AsQueryable<BsonDocument>().ToList().ForEach(song =>
          ID_adm = Convert.ToInt32(song["Id_Adm"])
           );

            ID_adm = ID_adm + 1;
            textBox1.Text = Convert.ToString(ID_adm);

        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        void limpiarDatos()
        {
            button2.Hide();
            button5.Hide();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();


        }


        void Actualizar()
        {

            dataGridView1.Rows.Clear();

            MongoClient client = new MongoClient("mongodb://Directivo:zaqxsw123@ds123410.mlab.com:23410/saa");
            var db = client.GetDatabase("saa");
            var usuarios = db.GetCollection<BsonDocument>("Admin");

            usuarios.AsQueryable<BsonDocument>().ToList().ForEach(song =>
            dataGridView1.Rows.Add(Convert.ToString(song["Id_Adm"]), Convert.ToString(song["Usuario"]), Convert.ToString(song["Nivel"]))
            );
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void porIDToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            limp = 4;
            Limpiar();
            //MessageBox.Show("Buscar por ID");
            groupBox6.Show();
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {

                e.Handled = true;
                return;
            }
        }


        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {

                e.Handled = true;
                return;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {

                e.Handled = true;
                return;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {

                e.Handled = true;
                return;
            }
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        public static int adm = 0;
      

     

       

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void buscarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void AdmUsuarios_Load(object sender, EventArgs e)
        {
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            groupBox4.Hide();
            groupBox6.Hide();
            groupBox9.Hide();
            groupBox8.Show();
            button2.Hide();
            button5.Hide();
            //label19.Text = IniciarSesion.usu;
            //progressBar1.Hide();



            MongoClient client = new MongoClient("mongodb://Directivo:zaqxsw123@ds123410.mlab.com:23410/saa");
            var db = client.GetDatabase("saa");
            var usuarios = db.GetCollection<BsonDocument>("Admin");

            usuarios.AsQueryable<BsonDocument>().ToList().ForEach(song =>
            dataGridView1.Rows.Add(Convert.ToString(song["Id_Adm"]), Convert.ToString(song["Usuario"]), Convert.ToString(song["Nivel"]))
            );
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {

                String strFila = Row.Index.ToString();
                string Valor = Convert.ToString(Row.Cells["Usuario"].Value);

                if (Valor == this.textBox16.Text)
                {
                    dataGridView1.Rows[Convert.ToInt32(strFila)].DefaultCellStyle.BackColor = Color.Red;
                }
                else { dataGridView1.Rows[Convert.ToInt32(strFila)].DefaultCellStyle.BackColor = Color.White; }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            IDB = textBox9.Text;


            MongoClient client = new MongoClient("mongodb://Directivo:zaqxsw123@ds123410.mlab.com:23410/saa");
            var db = client.GetDatabase("saa");
            var usuarios = db.GetCollection<BsonDocument>("Admin");


            var filter_id = Builders<BsonDocument>.Filter.Eq("Id_Adm", IDB);
            var entity = usuarios.Find(filter_id).FirstOrDefault();

            if (entity == null)
            {
                MessageBox.Show("Id no existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                groupBox4.Show();

                String DtAdmjson = entity.ToString();
                char[] separador = { '"', '"' };
                DatosAdm = DtAdmjson.Split(separador);

                // dataGridView1.Rows.Add(DatosAdm[7], DatosAdm[11], DatosAdm[19]);

                textBox5.Text = DatosAdm[11];
                //textBox6.Text = DatosAdm[19];
                comboBox2.Text= DatosAdm[19];

                button2.Show();
            }
        }

        private void porIDToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            limp = 4;
            Limpiar();
            //MessageBox.Show("Buscar por ID");
            groupBox6.Show();
        }

        private void porNombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limp = 9;
            Limpiar();
            //MessageBox.Show("Buscar por ID");
            groupBox9.Show();
        }

        private void porIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limp = 3;
            Limpiar();
            //  MessageBox.Show("se eliminara por id");
            groupBox3.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            button5.Show();

            IDB = textBox10.Text;


            MongoClient client = new MongoClient("mongodb://Directivo:zaqxsw123@ds123410.mlab.com:23410/saa");
            var db = client.GetDatabase("saa");
            var usuarios = db.GetCollection<BsonDocument>("Admin");


            var filter_id = Builders<BsonDocument>.Filter.Eq("Id_Adm", IDB);
            var entity = usuarios.Find(filter_id).FirstOrDefault();

            if (entity == null)
            {
                MessageBox.Show("ID no existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                groupBox4.Show();

                String DtAdmjson = entity.ToString();
                char[] separador = { '"', '"' };
                DatosAdm = DtAdmjson.Split(separador);


                textBox11.Text = DatosAdm[7];
                textBox12.Text = DatosAdm[11];
                textBox13.Text = DatosAdm[19];

                button2.Show();
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que desea Eliminar?", "Eliminar",
       MessageBoxButtons.YesNo, MessageBoxIcon.Question)
       == DialogResult.Yes)
            {
                IDB = textBox10.Text;
                MongoClient client = new MongoClient("mongodb://Directivo:zaqxsw123@ds123410.mlab.com:23410/saa");
                var db = client.GetDatabase("saa");
                var usuarios = db.GetCollection<BsonDocument>("Admin");

                usuarios.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("Id_Adm", IDB));
              
                Actualizar();
                limpiarDatos();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

      /*  private void textBox15_TextChanged_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {

                String strFila = Row.Index.ToString();
                string Valor = Convert.ToString(Row.Cells["Usuario"].Value);

                if (Valor == this.textBox15.Text)
                {
                    dataGridView1.Rows[Convert.ToInt32(strFila)].DefaultCellStyle.BackColor = Color.Red;
                }
                else { dataGridView1.Rows[Convert.ToInt32(strFila)].DefaultCellStyle.BackColor = Color.White; }
            }
        }
        */
        private void button2_Click_1(object sender, EventArgs e)
        {
            int longitud = 0;
            if (MessageBox.Show("Confirme para actualizar", "actualizando",
       MessageBoxButtons.YesNo, MessageBoxIcon.Question)
       == DialogResult.Yes)
            {


                if (textBox7.Text == textBox8.Text)
                {
                    longitud = textBox7.Text.Length;
                    if (longitud >= 6)
                    {
                        MongoClient client = new MongoClient("mongodb://Directivo:zaqxsw123@ds123410.mlab.com:23410/saa");
                        var db = client.GetDatabase("saa");
                        var usuarios = db.GetCollection<BsonDocument>("Admin");

                        usuarios.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("Id_Adm", IDB));



                        BsonDocument Admin = new BsonDocument
                  {//informacion del alumno
                    {"Id_Adm",IDB},
                    {"Usuario",textBox5.Text },
                    {"Contraseña",textBox8.Text },
                    {"Nivel",comboBox2.Text }


                  };

                        BsonDocument DatosAdmin = Admin;



                        usuarios.InsertOne(DatosAdmin);

                    
                        MessageBox.Show("Administrador actualizado");
                        limpiarDatos();
                        Actualizar();
                        groupBox4.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Debe tener mas de 6 caracteres");
                    }
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinsiden");
                }

            }
        }

        private void textBox14_TextChanged_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {

                String strFila = Row.Index.ToString();
                string Valor = Convert.ToString(Row.Cells["Id_Adm"].Value);

                if (Valor == this.textBox14.Text)
                {
                    dataGridView1.Rows[Convert.ToInt32(strFila)].DefaultCellStyle.BackColor = Color.Red;
                }
                else { dataGridView1.Rows[Convert.ToInt32(strFila)].DefaultCellStyle.BackColor = Color.White; }
            }
        }

        private void escritorioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limp = 6;
            Limpiar();
            //MessageBox.Show("se agregara uno nuevo");
            groupBox8.Show();
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
