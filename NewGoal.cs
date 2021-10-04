using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGoals
{
    public partial class NewGoal : Form
    {
        string goalText = "";
        public NewGoal()
        {
            InitializeComponent();
            string goalText = "";
            this.inputText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
        }

        private void CheckKeys(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            // Behavior when pressing Enter key while in text field
            if (e.KeyChar == (char)13)
            {
                goalText = inputText.Text;
                this.Close();
            }
        }

        private void okay_Click(object sender, EventArgs e)
        {
            goalText = inputText.Text;
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string getGoalText()
        {
            return goalText;
        }
    }
}
