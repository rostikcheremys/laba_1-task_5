using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Program
{
    public partial class Form1 : Form
    {
        private List<Action<Form>> _actions;

        public Form1()
        {
            InitializeComponent();
            Commands();
        }

        private void Commands()
        {
            _actions =
            [
                form => form.Opacity = form.Opacity == 1.0 ? 0.5 : 1.0,
                form => form.BackColor = form.BackColor == Color.Blue ? SystemColors.Control : Color.Blue,
                form => MessageBox.Show("Hello World!"),
                form => MessageBox.Show("I'm a Super Mega Button!")
            ];
        }

        private void TransparencyButton_Click(object sender, EventArgs e) => _actions[0](this);

        private void ColorButton_Click(object sender, EventArgs e) => _actions[1](this);

        private void HelloWorldButton_Click(object sender, EventArgs e) => _actions[2](this);

        private void btnSetOfActions_Click(object sender, EventArgs e) => _actions[3](this);

        private void IsSelectedCheckBox1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                _actions[3] += _actions[0];
            }
            else
            {
                _actions[3] -= _actions[0];
            }
        }
        
        private void IsSelectedCheckBox2(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                _actions[3] += _actions[1];
            }
            else
            {
                _actions[3] -= _actions[1];
            }
        }

        private void IsSelectedCheckBox3(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                _actions[3] += _actions[2];
            }
            else
            {
                _actions[3] -= _actions[2];
            }
        }
    }
}
