using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ValidationDemo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonExir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            if (isvalidated())
            {
                MessageBox.Show("New Record Added Succesfully", "Added Succesfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool isvalidated()
        {
            if (textBoxName.Text == string.Empty)
            {
                validate(textBoxName, "Name is Required");
                return false;
            }
            if (textBoxAge.Text == string.Empty)
            {
                validate(textBoxAge, "Age is required");
                return false;
            }
            else
            {
                int outage;
                if (!int.TryParse(textBoxAge.Text, out outage))
                {
                    validate(textBoxAge, "Age Should be integers");
                    return false;
                }

            }
            if (comboBox1.Text == string.Empty)
            {
                validate(comboBox1, "Qualification is Required");
                return false;
            }
            if (DateTime.Today.AddYears(-18) > dateTimePicker1.Value.Date)
            {
           
                validate(dateTimePicker1, "You should be over 18");
                return false;
            }
            return true;
        }
        private void validate(Control ctrl, string validationmessage)
        {
          
                errorProvider.SetError(ctrl, validationmessage);
                ctrl.BackColor = Color.LightPink;
                ctrl.Focus();
                MessageBox.Show(validationmessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Ctrl_Change(object sender, EventArgs e)
        {
            errorProvider.Clear();
            Control ctr = (Control)sender;
            ctr.BackColor = Color.White;
        }
    }
}
