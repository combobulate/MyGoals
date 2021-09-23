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
