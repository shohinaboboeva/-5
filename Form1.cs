using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Симулятор_простого_рестарана_5
{
    public partial class Form1 : Form
    {
        TableRequests tableRequests = new TableRequests();
        Cook cook = new Cook(2); 
        Serever server;
        public Form1()
        {
            InitializeComponent();

            server = new Serever(tableRequests);

            comboBox1.Items.AddRange(new string[]
            {
            "None", "Tea", "Fanta", "CocaCola", "Water"
            });
            comboBox1.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox3.Text;

            int eggs = int.Parse(textBox1.Text);
            int chicken = int.Parse(textBox2.Text);

            lock (tableRequests)
            {
                for (int i = 0; i < eggs; i++)
                    tableRequests.Add<Egg>(name);

                for (int i = 0; i < chicken; i++)
                    tableRequests.Add<Chicken>(name);

                if (comboBox1.SelectedItem.ToString() != "None")
                    tableRequests.Add<Drink>(name);
            }

            richTextBox1.AppendText($"Order received from {name}\n");
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText("Processing...\n");

            await server.SendAsync(cook, msg =>
            {
                Invoke(new Action(() =>
                {
                    richTextBox1.AppendText(msg + "\n");
                }));
            });

           
            foreach (var customer in tableRequests.Customers)
            {
                var items = tableRequests[customer];

                int drinks = items.Count(x => x is Drink);
                int eggs = items.Count(x => x is Egg);
                int chicken = items.Count(x => x is Chicken);

                richTextBox1.AppendText(
                    $"{customer} ordered {drinks} drink, {eggs} egg, {chicken} chicken\n");
            }
        }
    }
    
}
