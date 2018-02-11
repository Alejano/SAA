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
        


        public Sucursales()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Enter))
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
                    {"Id_Suc", ID_Sucursal},
                    {"NombreS",textBox1.Text }
                    
                  };
            BsonDocument Datossucursal = sucursal;

            BsonDocument gerente = new BsonDocument
                  {//informacion del alumno
                    {"Id_Gerente",ID_Gerente},
                    {"Id_Suc", ID_Sucursal},
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
            int max = 0;
            menu = 2;           
            Actualizar2();
            max = dataGridView2.Rows.GetLastRow(0);
            numericUpDown1.Maximum = max;

            MessageBox.Show(Convert.ToString(max));
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

        }
    }
}
