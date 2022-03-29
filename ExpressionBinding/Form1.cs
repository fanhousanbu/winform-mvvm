using System;
using System.Windows.Forms;

namespace ExpressionBinding
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Entity obj = new Entity();

        private void Form1_Load(object sender, EventArgs e)
        {
            this.textBox1.DataBindings.Add("Text", obj, "Field");

            this.numericUpDown1.Bind(obj, () => numericUpDown1.Value, () => obj.Decimal);
            this.checkBox1.DataBindings.Add("Checked", obj, "Bool", true);

            // another demo
            textBox2.Bind(person, () => textBox2.Text, () => person.GivenNames);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(obj.Field);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            obj.Field = DateTime.Now.ToString("HH:mm:ss,fff");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(obj.Decimal.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            obj.Decimal += 1;
            obj.Field = obj.Decimal.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(obj.Bool.ToString());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            obj.Bool = !obj.Bool;
        }

        Person person = new Person();

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show(person.GivenNames);
        }
    }
}
