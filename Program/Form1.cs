using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Program
{
    public partial class Form1 : Form
    {
        private static List<Action<Form>> _actions;
        
        public Form1()
        {
            InitializeComponent();
            Delegates();
            Load += Form_CheckBox;
            CheckBox_Checked(this, EventArgs.Empty);
        }
        
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
        
        private void TransparencyButton_Click(object sender, EventArgs e) => _actions[0](this);
        
        private void ColorButton_Click(object sender, EventArgs e) => _actions[1](this);
        
        private void HelloWorldButton_Click(object sender, EventArgs e) => _actions[2](this);
        
        private void btnSetOfActions_Click(object sender, EventArgs e) => _actions[3](this);
        
        private void CheckBox_Checked(object sender, EventArgs e)
        {            
            if (checkBox1.Checked)
                button4.Click += TransparencyButton_Click;
            else
                button4.Click -= TransparencyButton_Click;

            if (checkBox2.Checked)
                button4.Click += ColorButton_Click;
            else
                button4.Click -= ColorButton_Click;

            if (checkBox3.Checked)
                button4.Click += HelloWorldButton_Click;
            else
                button4.Click -= HelloWorldButton_Click;
        }
        
        private void Form_CheckBox(object sender, EventArgs e)
        {            
            checkBox1.CheckedChanged += CheckBox_Checked;
            checkBox2.CheckedChanged += CheckBox_Checked;
            checkBox3.CheckedChanged += CheckBox_Checked;
        }
    }
}