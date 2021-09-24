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
    public partial class GoalsMainForm : Form
    {
        Classes.Goals myGoalsList = new Classes.Goals();
        
        public GoalsMainForm()
        {
            InitializeComponent();
            myGoalsList.AddGoal("Starter Set");
            myGoalsList.AddGoal("Starter Set 2");
            Classes.Goal goal = myGoalsList.SearchGoals("Starter Set");
            goal.AddChild("Test child 1");
            goal.AddChild("Test child 2");
            goal = myGoalsList.SearchGoals("Starter Set 2");
            goal.AddChild("Test child 3");
            goal.AddChild("Test child 4");
            
        }

        private void GoalsMainForm_Load(object sender, EventArgs e)
        {
            //treeViewPrintGoals(myGoalsList.MyGoals);
            foreach (Classes.Goal goal in myGoalsList.GetGoals())
            {
                TreeNode treeNode = new TreeNode(goal.GoalText);
                treeViewGoals.Nodes.Add(treeNode);
                if (goal.ChildGoals.Count != 0)
                    treeViewPrintGoals(treeNode, goal.ChildGoals);
            }
        }

        private void newGoal_Click(object sender, EventArgs e)
        {
            NewGoal newGoalForm = new NewGoal();
            newGoalForm.ShowDialog();
            if (newGoalForm.getGoalText() != "")
            {
                this.myGoalsList.AddGoal(newGoalForm.getGoalText());
                TreeNode treeNode = new TreeNode(newGoalForm.getGoalText());
                treeViewGoals.Nodes.Add(treeNode);
            }
        }

        private void treeViewGoals_OnAfterSelect(object sender, TreeViewEventArgs e)
        {
            addChild.Enabled = true;
        }

        private void treeViewPrintGoals(TreeNode tree, LinkedList<Classes.Goal> goals)
        {
            foreach(Classes.Goal goal in goals)
            {
                TreeNode treeNode = new TreeNode(goal.GoalText);
                tree.Nodes.Add(treeNode);
                if (goal.ChildGoals.Count != 0)
                    treeViewPrintGoals(treeNode, goal.ChildGoals);
            }
            
        }

        private void addChild_Click(object sender, EventArgs e)
        {
            NewGoal newGoalForm = new NewGoal();
            newGoalForm.ShowDialog();
            //treeViewGoals.SelectedNode.Text

            if (newGoalForm.getGoalText() != "")
            {
                Classes.Goal goal = myGoalsList.SearchGoals(treeViewGoals.SelectedNode.Text);
                goal.AddChild(newGoalForm.getGoalText());
                TreeNode treeNode = new TreeNode(newGoalForm.getGoalText());
                treeViewGoals.SelectedNode.Nodes.Add(treeNode);
                if (!treeViewGoals.SelectedNode.IsExpanded)
                    treeViewGoals.SelectedNode.Expand();
            }
        }
    }
}

