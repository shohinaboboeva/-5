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

            server = new Serever();

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

            Order newOrder = new Order { CustomerName = name };

            for (int i = 0; i < int.Parse(textBox1.Text); i++)
                newOrder.Add(new Chicken());

            for (int i = 0; i < int.Parse(textBox2.Text); i++)
                newOrder.Add(new Egg());

            if (comboBox1.SelectedItem.ToString() != "None")
            {
                string selectedDrink = comboBox1.SelectedItem.ToString();
                newOrder.Add(new Drink { Name = selectedDrink });
            }

            lock (tableRequests)
            {
                tableRequests.AddOrder(newOrder);
            }

            richTextBox1.AppendText($"Order received from {name}\n");
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText("Processing orders...\n");

            List<Order> currentOrders;
            lock (tableRequests)
            {
                currentOrders = tableRequests.OrderBy(o => o.CustomerName).ToList();
                tableRequests.Clear();
            }

          
            List<Task> cookingTasks = new List<Task>();
            foreach (var order in currentOrders)
            {
                cookingTasks.Add(cook.PrepareAllAsync(order.Items.ToList()));
            }

            await Task.WhenAll(cookingTasks);

            foreach (var order in currentOrders)
            {
                await Task.Delay(500);

                string summary = order.GetSummary();
                richTextBox1.AppendText($"Server delivered: {summary}\n");
            }

            richTextBox1.AppendText("All orders served!\n");
        }
    }
}
