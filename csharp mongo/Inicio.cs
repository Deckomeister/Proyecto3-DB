using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;

namespace csharp_mongo
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int contador = 1;
            try
            {
                var dbClient = new MongoClient("mongodb://localhost:27017");
                IMongoDatabase db = dbClient.GetDatabase("sample_airbnb");
                var col = db.GetCollection<BsonDocument>("Customers");
                var Customer = new BsonDocument
                {
                {"_id", contador},
                {"Address",textBox2.Text},
                {"City",textBox3.Text},
                {"Country",textBox4.Text},
                {"District",textBox5.Text},
                {"Firstname",textBox6.Text},
                {"LastName",textBox7.Text},
                {"Status",comboBox1.Text}
                };
                col.InsertOneAsync(Customer);
                MessageBox.Show("Guardado con Exito");
                contador = contador + 1;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                comboBox1.Text = "";
            }
            catch (Exception error)
            {
                MessageBox.Show(error.StackTrace);
                contador = contador +  1;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var dbClient = new MongoClient("mongodb://127.0.0.1:27017");
            IMongoDatabase db = dbClient.GetDatabase("sample_airbnb");
            var col = db.GetCollection<BsonDocument>("Customers");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Or("_id", textBox8.Text) & builder.Or("FirstName", textBox8.Text) & builder.Or("Country" , textBox8.Text);
            var doc = col.Find(filter);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            { 
            var dbClient = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase db = dbClient.GetDatabase("sample_airbnb");
            var col = db.GetCollection<BsonDocument>("Customers");
            var Customer = new BsonDocument
                {
                {"Address",textBox2.Text},
                {"City",textBox3.Text},
                {"Country",textBox4.Text},
                {"District",textBox5.Text},
                {"Firstname",textBox6.Text},
                {"LastName",textBox7.Text},
                {"Status",comboBox1.Text}
                };
                var filter = Builders<BsonDocument>.Filter.Eq("_id", textBox1.Text);
                col.UpdateOneAsync(filter, Customer);
            MessageBox.Show("Ha sido modificado con Exito");
            }
            catch(Exception error)
            {
                MessageBox.Show(error.StackTrace);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try { 
            var dbClient = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase db = dbClient.GetDatabase("sample_airbnb");
            var col = db.GetCollection<BsonDocument>("Customers");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Or("_id", textBox8.Text) & builder.Or("FirstName", textBox8.Text);
            col.DeleteOneAsync(filter);
            MessageBox.Show("Ha sido eliminado con Exito");
            }
            catch(Exception error)
            {
                MessageBox.Show(error.StackTrace);
            }
        }
    }
}
