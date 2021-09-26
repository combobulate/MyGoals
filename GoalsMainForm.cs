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
        GoalManagement.Goals myGoalsList = new GoalManagement.Goals();
        
        public GoalsMainForm()
        {
            InitializeComponent();
            treeViewGoals.AfterSelect += treeViewGoals_OnAfterSelect;
            myGoalsList.Load();
            /*myGoalsList.AddGoal("Starter Set");
            myGoalsList.AddGoal("Starter Set 2");
            GoalManagement.Goal goal = myGoalsList.SearchGoals("Starter Set");
            goal.AddChild("Test child 1");
            goal.AddChild("Test child 2");
            goal = myGoalsList.SearchGoals("Starter Set 2");
            goal.AddChild("Test child 3");
            goal.AddChild("Test child 5");*/

            //
            
        }

        private void GoalsMainForm_Load(object sender, EventArgs e)
        {
            foreach (GoalManagement.Goal goal in myGoalsList.GetGoals())
            {
                if (!goal.IsComplete())
                {
                    TreeNode treeNode = new TreeNode(goal.GoalText);
                    treeViewGoals.Nodes.Add(treeNode);
                    if (goal.GetChildGoals(true).Count != 0)
                        treeViewPrintGoals(treeNode, goal.GetChildGoals(true));
                }
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
            GoalManagement.Goal goal = myGoalsList.SearchGoals(treeViewGoals.SelectedNode.Text);
            if (goal.GetChildGoals(true).Count == 0)
                markComplete.Enabled = true;
            else
                markComplete.Enabled = false;
        }

        private void treeViewPrintGoals(TreeNode tree, LinkedList<GoalManagement.Goal> goals)
        {
            foreach(GoalManagement.Goal goal in goals)
            {
                if (!goal.IsComplete())
                {
                    TreeNode treeNode = new TreeNode(goal.GoalText);
                    tree.Nodes.Add(treeNode);
                    if (goal.GetChildGoals(true).Count != 0)
                        treeViewPrintGoals(treeNode, goal.GetChildGoals(true));
                }
                
            }
            
        }

        private void addChild_Click(object sender, EventArgs e)
        {
            NewGoal newGoalForm = new NewGoal();
            newGoalForm.ShowDialog();

            if (newGoalForm.getGoalText() != "")
            {
                GoalManagement.Goal goal = myGoalsList.SearchGoals(treeViewGoals.SelectedNode.Text);
                goal.AddChild(newGoalForm.getGoalText());
                TreeNode treeNode = new TreeNode(newGoalForm.getGoalText());
                treeViewGoals.SelectedNode.Nodes.Add(treeNode);
                if (!treeViewGoals.SelectedNode.IsExpanded)
                    treeViewGoals.SelectedNode.Expand();
            }
        }

        private void markComplete_Click(object sender, EventArgs e)
        {
            if (treeViewGoals.SelectedNode != null)
            {
                GoalManagement.Goal goal = myGoalsList.SearchGoals(treeViewGoals.SelectedNode.Text);
                goal.CompleteGoal();
                treeViewGoals.SelectedNode.Remove();
            }

        }
        private void saveAndQuit_Click(object sender, EventArgs e)
        {
            myGoalsList.Save();
            Application.Exit();
        }
    }
}

