namespace ExpressionBinder;

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
        this.numericUpDown1.DataBindings.Add("Value", obj, "Decimal", true);
        this.checkBox1.DataBindings.Add("Checked", obj, "Bool", true);
    }
 
    private void button1_Click(object sender, EventArgs e)
    {
        MessageBox.Show(obj.Field);
        MessageBox.Show(obj.Field2);
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
    }
 
    private void button5_Click(object sender, EventArgs e)
    {
        MessageBox.Show(obj.Bool.ToString());
    }
 
    private void button6_Click(object sender, EventArgs e)
    {
        obj.Bool = !obj.Bool;
    }
}