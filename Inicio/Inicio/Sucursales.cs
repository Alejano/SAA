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
    public partial class Sucursales : Form
    {
        string[] DatosAdm = new string[99];
        int menu = 0;
        int ID_Sucursal = 0;
        int ID_Gerente = 9999999;
        int ID_SucursalA = 0;
        string SN = "";


        public Sucursales()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button4.Show();
            button1.Hide();
            pictureBox2.Hide();
            menu = 1;
            Menus();
        }

        private void Sucursales_Load(object sender, EventArgs e)
        {
            
            Menus();
            Actualizar();


        }
        void Buscarid() {

            MongoClient client = new MongoClient("mongodb://Directivo:zaqxsw123@ds123410.mlab.com:23410/saa");
            var db = client.GetDatabase("saa");
            var idsS = db.GetCollection<BsonDocument>("Sucursal");

            idsS.AsQueryable<BsonDocument>().ToList().ForEach(song =>
            ID_Sucursal = Convert.ToInt32(song["Id_Suc"])

             );
            var idsG = db.GetCollection<BsonDocument>("Gerente");

            idsG.AsQueryable<BsonDocument>().ToList().ForEach(song =>
            ID_Gerente = Convert.ToInt32(song["Id_Gerente"])

             );
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Space))
            {

                e.Handled = true;
                return;
            }


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
         

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Space))
            {

                e.Handled = true;
                return;
            }
 
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarE( sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Buscarid();
            bool verificacion = false;

            ID_Sucursal++;
            ID_Gerente++;
            //MessageBox.Show(Convert.ToString(ID_Sucursal));
            //MessageBox.Show(Convert.ToString(ID_Gerente));

            // MessageBox.Show("creando Administrador");
            BsonDocument sucursal = new BsonDocument
                  {//informacion del alumno
                    {"Id_Suc", Convert.ToString(ID_Sucursal)},
                    {"NombreS",textBox1.Text }
                    
                  };
            BsonDocument Datossucursal = sucursal;

            BsonDocument gerente = new BsonDocument
                  {//informacion del alumno
                    {"Id_Gerente",Convert.ToString(ID_Gerente)},
                    {"Id_Suc",Convert.ToString(ID_Sucursal)},
                    {"NombreG",textBox2.Text },
                    {"APaterno",textBox3.Text },
                    {"AMaterno",textBox4.Text },
                    {"Usuario",textBox5.Text },
                    {"Contraseña",textBox6.Text },

                  };
            BsonDocument Datosgerentegerente = gerente;


            int longitud = textBox6.Text.Length;
            if (textBox7.Text == textBox6.Text)
            {
               
                if (longitud >= 6)
                {


 
                    foreach (DataGridViewRow Row in dataGridView1.Rows)
                    {

                        String strFila = Row.Index.ToString();
                        string Valor = Convert.ToString(Row.Cells["NombreS"].Value);

                        if (Valor == this.textBox1.Text)
                        {
                            verificacion = true;
                        }

                    }
                    
                    if (verificacion == true)
                    {
                        MessageBox.Show("La sucursal Ya existe");
                    }
                    else
                    {
                        
                        foreach (DataGridViewRow Row in dataGridView1.Rows)
                        {

                            String strFila = Row.Index.ToString();
                            string Valor = Convert.ToString(Row.Cells["Usuario"].Value);

                            if (Valor == this.textBox5.Text)
                            {
                                verificacion = true;
                            }

                        }
                    
                        if (verificacion == true)
                        {
                            MessageBox.Show("EL nombre de Usuario ya existe");
                        }
                        else
                        {
                              MongoClient client = new MongoClient("mongodb://Directivo:zaqxsw123@ds123410.mlab.com:23410/saa");
                              var db = client.GetDatabase("saa");
                              var usuarios = db.GetCollection<BsonDocument>("Sucursal");
                              

                              usuarios.InsertOne(Datossucursal);
                              var usuario = db.GetCollection<BsonDocument>("Gerente");

                              usuario.InsertOne(Datosgerentegerente);
                              
                           
                            limpiarDatos();
                            Actualizar();
                        }


                    }
                }
                else { MessageBox.Show("La contraseña debe tener minimo 6 caracteres"); }
            }
            else { MessageBox.Show("Contraseña no coincide"); }
        }

        void limpiarDatos() {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            numericUpDown1.Value = 0;
        }

        void Actualizar() {
            int i = 0;
            dataGridView1.Rows.Clear();
          
            MongoClient client = new MongoClient("mongodb://Directivo:zaqxsw123@ds123410.mlab.com:23410/saa");
            var db = client.GetDatabase("saa");
            var usuarios = db.GetCollection<BsonDocument>("Sucursal");

            usuarios.AsQueryable<BsonDocument>().ToList().ForEach(song =>
            dataGridView1.Rows.Add(Convert.ToString(song["NombreS"]))
            );           

            var usuario = db.GetCollection<BsonDocument>("Gerente");
           
            usuario.AsQueryable<BsonDocument>().ToList().ForEach(song =>
            dataGridView1.Rows[i++].Cells[1].Value = Convert.ToString(song["NombreG"])
            );
            i = 0;
            usuario.AsQueryable<BsonDocument>().ToList().ForEach(song =>
            dataGridView1.Rows[i++].Cells[2].Value = Convert.ToString(song["Usuario"])
            );

        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

       

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
           
        }

        void validarE(object sender, KeyPressEventArgs e) {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Enter))
            {

                e.Handled = true;
                return;
            }

           
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarE(sender, e);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
           
        }

        void Menus() {

            if (menu == 0) { groupBox1.Hide(); groupBox2.Hide(); dataGridView1.Show(); dataGridView2.Hide(); }
            if (menu == 1) { groupBox1.Show(); groupBox2.Hide(); dataGridView1.Show(); dataGridView2.Hide(); }
            if (menu == 2) { groupBox1.Hide(); groupBox2.Show();dataGridView1.Hide(); dataGridView2.Show(); }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Hide();
            button6.Show();    
            int max = 0;
            menu = 2;           
            Actualizar2();
            max = dataGridView2.Rows.GetLastRow(0);
            numericUpDown1.Maximum = max;

           // MessageBox.Show(Convert.ToString(max));
            if (max == 0) { MessageBox.Show("No ha agregado ningna sucursal");
            }
            else
            {               
                Menus();
            }



        }

        void Actualizar2() {
           
                int i = 0;
                dataGridView2.Rows.Clear();
                MongoClient client = new MongoClient("mongodb://Directivo:zaqxsw123@ds123410.mlab.com:23410/saa");
                var db = client.GetDatabase("saa");
                var usuarios = db.GetCollection<BsonDocument>("Sucursal");
              
                usuarios.AsQueryable<BsonDocument>().ToList().ForEach(song =>
                dataGridView2.Rows.Add(Convert.ToString(song["Id_Suc"]), Convert.ToString(song["NombreS"]))
                );
             
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int IDB=0;
            if (MessageBox.Show("Seguro que desea Eliminar?", "Eliminar",
       MessageBoxButtons.YesNo, MessageBoxIcon.Question)
       == DialogResult.Yes)
            {
                
                IDB = Convert.ToInt16(numericUpDown1.Value);
                MongoClient client = new MongoClient("mongodb://Directivo:zaqxsw123@ds123410.mlab.com:23410/saa");
                var db = client.GetDatabase("saa");
                var usuarios = db.GetCollection<BsonDocument>("Sucursal");

                usuarios.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("Id_Suc", IDB));

                var usuarios2 = db.GetCollection<BsonDocument>("Gerente");

                usuarios2.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("Id_Suc", IDB));

               
                Actualizar2();
                limpiarDatos();
            }
        }

        

        

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in dataGridView2.Rows)
            {

                String strFila = Row.Index.ToString();
                string Valor = Convert.ToString(Row.Cells[0].Value);
                //MessageBox.Show(Valor);
                if (Valor == Convert.ToString(numericUpDown1.Value)) {


                    foreach (DataGridViewRow Row2 in dataGridView2.Rows)
                    {

                        String strFila2 = Row2.Index.ToString();
                        string Valor2 = Convert.ToString(Row.Cells[1].Value);
                       // MessageBox.Show(Valor2);
                        if (Valor == Convert.ToString(numericUpDown1.Value))
                        {

                            textBox9.Text = Valor2;
                        }

                    }
                }
                
            }
          
        }

        private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            limpiarDatos();
            menu = 0;
            Actualizar();
            Menus();
        }
        public int turno = 0;
        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 0;
            textBox9.Clear();
            turno = 0;
            turnox();
        }
        int id_S = 0;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ID_SucursalA = Convert.ToInt16(numericUpDown1.Value);
            SN = textBox9.Text;

            id_S = Convert.ToInt16(numericUpDown1.Value);

            turno = 1;
            turnox();
            ActualizarT();

        }
        void turnox() {
            if (turno == 0)
            {
                numericUpDown1.Value = 0;
                textBox9.Clear();
                menu = 2;
                button6.Hide();
                pictureBox1.Show();
                int max = 0;
                menu = 2;
                Actualizar2();
                max = dataGridView2.Rows.GetLastRow(0);
                numericUpDown1.Maximum = max;

                //MessageBox.Show(Convert.ToString(max));
                if (max == 0)
                {
                    MessageBox.Show("No ha agregado ningna sucursal");
                }
                else
                {
                    Menus();
                }
            }
            if (turno == 1)
            {
                menu = 1;
                Menus();
                button1.Show();
                button4.Hide();
                button5.Hide();
                pictureBox2.Show();


            }
        }
        void ActualizarT()
        {
            //MessageBox.Show(Convert.ToString(ID_SucursalA));
            //MessageBox.Show(SN);
            MongoClient client = new MongoClient("mongodb://Directivo:zaqxsw123@ds123410.mlab.com:23410/saa");
            var db = client.GetDatabase("saa");
            var usuarios = db.GetCollection<BsonDocument>("Gerente");


            var filter_id = Builders<BsonDocument>.Filter.Eq("Id_Suc",Convert.ToString(ID_SucursalA));
            var entity = usuarios.Find(filter_id).FirstOrDefault();

            if (entity == null)
            {
                MessageBox.Show("Id no existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                turnox();
            }
            else
            {

                String DtAdmjson = entity.ToString();
                char[] separador = { '"', '"' };
                DatosAdm = DtAdmjson.Split(separador);

                // dataGridView1.Rows.Add(DatosAdm[7], DatosAdm[11], DatosAdm[19]);
                //MessageBox.Show(DatosAdm[7]);
                //MessageBox.Show( DatosAdm[11]);
                textBox1.Text =SN;
                textBox2.Text = DatosAdm[15];
                textBox3.Text = DatosAdm[19];
                textBox4.Text = DatosAdm[23];
                textBox5.Text = DatosAdm[27];

                //MessageBox.Show(DatosAdm[11]);
                //MessageBox.Show(DatosAdm[19]);


            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BsonDocument sucursal = new BsonDocument
                  {//informacion del alumno
                    {"Id_Suc", DatosAdm[11]},
                    {"NombreS",textBox1.Text}

                  };
            BsonDocument Datossucursal = sucursal;

            BsonDocument gerente = new BsonDocument
                  {//informacion del alumno
                    {"Id_Gerente",DatosAdm[7]},
                    {"Id_Suc", DatosAdm[11]},
                    {"NombreG",textBox2.Text },
                    {"APaterno", textBox3.Text },
                    {"AMaterno",textBox4.Text},
                    {"Usuario",textBox5.Text },
                    {"Contraseña",textBox6.Text },

                  };
            BsonDocument Datosgerentegerente = gerente;
            int longitud = textBox6.Text.Length;
            if (textBox7.Text == textBox6.Text)
            {

                if (longitud >= 6)
                {

                    if (MessageBox.Show("Seguro que desea Actulizar?", "Actulizar",
       MessageBoxButtons.YesNo, MessageBoxIcon.Question)
       == DialogResult.Yes)
                    {
                        MongoClient client = new MongoClient("mongodb://Directivo:zaqxsw123@ds123410.mlab.com:23410/saa");
                        var db = client.GetDatabase("saa");
                        var usuarios = db.GetCollection<BsonDocument>("Sucursal");
                        usuarios.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("Id_Suc", DatosAdm[11]));
                        usuarios.InsertOne(Datossucursal);

                        var usuarios2 = db.GetCollection<BsonDocument>("Gerente");
                        usuarios2.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("Id_Gerente", DatosAdm[7]));
                        usuarios2.InsertOne(Datosgerentegerente);

                        Actualizar();
                        Actualizar2();
                        turno = 0;
                        turnox();
                    }
                }

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            limpiarDatos();
            menu = 0;
            Actualizar();
            Menus();
        }
    }
}
