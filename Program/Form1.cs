using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Program
{
    public partial class Form1 : Form
    {
        private List<Action<Form>> _actions;
        private List<EventHandler> _checkBoxEventHandlers;

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
        
        private void btnSetOfActions_Click(object sender, EventArgs e)
        {
            _checkBoxEventHandlers =
            [
                (s, ev) => _actions[0](this),
                (s, ev) => _actions[1](this),
                (s, ev) => _actions[2](this)
            ];
            
            checkBox1.CheckedChanged += _checkBoxEventHandlers[0];
            checkBox2.CheckedChanged += _checkBoxEventHandlers[1];
            checkBox3.CheckedChanged += _checkBoxEventHandlers[2];
            
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            
            checkBox1.CheckedChanged -= _checkBoxEventHandlers[0];
            checkBox2.CheckedChanged -= _checkBoxEventHandlers[1];
            checkBox3.CheckedChanged -= _checkBoxEventHandlers[2];

            _actions[3](this);
        }
    }
}
