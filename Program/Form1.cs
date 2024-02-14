using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Delegates();
        }
        
        private static List<Action<Form>> _actions;
        
        private void Delegates()
        {
            _actions =
            [
                form  => Opacity = Opacity == 1.0 ? 0.5 : 1.0,

                form => BackColor = BackColor == Color.Blue ? SystemColors.Control : Color.Blue,

                form => MessageBox.Show("Hello World!"),
                
                form => MessageBox.Show("I'm a Super Mega Button!"),
            ];
        }

        private void button1_Click(object sender, EventArgs e) => _actions[0](this);
        
        private void button2_Click(object sender, EventArgs e) => _actions[1](this);
        
        private void button3_Click(object sender, EventArgs e) => _actions[2](this);

        private void button4_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked) _actions[0](this);
            if (checkBox2.Checked) _actions[1](this);
            if (checkBox3.Checked) _actions[2](this);

            _actions[3](this);
        }
    }
}