using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HimChistka
{
    public partial class Form1 : Form
    {
        Bouquet bouquet = new Bouquet();
        public Form1()
        {
            InitializeComponent();
        }

        public void btnClickThis_Click(object sender, EventArgs e)
        {
            try
            {
            var flower = new Flower(textBox2.Text, Int32.Parse(textBox4.Text));
            flower.Price = Int32.Parse(textBox4.Text);
            bouquet.AddFlower(flower);
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            label5.Text = "";
            }
            catch (Exception)
            {
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                label5.Text = "не корректный ввод";
            }
            
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (bouquet.FlowerCount == 0)
            {
                lblHelloWorld.Text = "букет пуст";
            }
            else
            {
                string bouquetState = bouquet.State;
                lblHelloWorld.Text = ($"Базовая стоимость букета: {bouquet.BasePrice} \nРеальная стоимость букета: {bouquet.RealPrice} \nСостояние букета: {bouquetState}\nКоличество цветов в букете: {bouquet.FlowerCount}\nКоличество увядших цветов в букете: {bouquet.WitheredFlowerCount}");

            }
        }

            private void Form1_Load(object sender, EventArgs e)
            {
            }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if ((bouquet.FlowerCount <= Int32.Parse(textBox1.Text)) || (Int32.Parse(textBox1.Text) < 0))
                {
                    label5.Text = "цветок под этим индексом не существует";
                    textBox1.Text = "";
                }
                else
                {
                    bouquet.RemoveFlower(Int32.Parse(textBox1.Text));
                    textBox1.Text = "";
                    label5.Text = "";
                }
                
            }
            catch (Exception)
            {
                label5.Text = "не корректный ввод";
                textBox1.Text = "";
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
    }