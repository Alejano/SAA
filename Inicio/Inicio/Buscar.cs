﻿using System;
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
        string[] DatosAuto = new string[99];

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
            ID_A = textBox1.Text;

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
                    textBox4.Text = DatosAuto[15];
                    textBox5.Text = DatosAuto[11];
                    textBox6.Text = DatosAuto[39];
                   
                }
            }
        }
    }
}
