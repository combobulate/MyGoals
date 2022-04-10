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
        private GoalManagement.Goals myGoalsList = new GoalManagement.Goals();
        
        public GoalsMainForm()
        {
            InitializeComponent();
            treeViewGoals.AfterSelect += treeViewGoals_OnAfterSelect;
            myGoalsList.Load();            
        }

        private void GoalsMainForm_Load(object sender, EventArgs e)
        {
            foreach (GoalManagement.Goal goal in myGoalsList.GetGoals())
            {
                if (!goal.IsComplete)
                {
                    TreeNode treeNode = new TreeNode(goal.GoalText);
                    treeViewGoals.Nodes.Add(treeNode);
                    if (goal.GetChildGoals(true).Count != 0)
                        treeViewPrintGoals(treeNode, goal.GetChildGoals(true));
                }
            }
        }


        private void treeViewGoals_OnAfterSelect(object sender, TreeViewEventArgs e)
        {
            addChild.Enabled = true;
            GoalManagement.Goal goal = myGoalsList.GetSelectedGoal(treeViewGoals.SelectedNode.FullPath, true);
            if (goal.GetChildGoals(true).Count == 0)
                markComplete.Enabled = true;
            else
                markComplete.Enabled = false;
            selectedGoal.Text = "Goal: " + goal.GoalText;
            selectedCreated.Text = "Created: " + goal.Created.ToString("MMMM d yyyy");
        }

        private void treeViewPrintGoals(TreeNode tree, LinkedList<GoalManagement.Goal> goals)
        {
            foreach(GoalManagement.Goal goal in goals)
            {
                if (!goal.IsComplete)
                {
                    TreeNode treeNode = new TreeNode(goal.GoalText);
                    tree.Nodes.Add(treeNode);
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
                GoalManagement.Goal existingGoal = myGoalsList.GetSelectedGoal(newGoalForm.getGoalText(), false);
                
                if (existingGoal is null)
                {
                    this.myGoalsList.AddGoal(newGoalForm.getGoalText());
                    TreeNode treeNode = new TreeNode(newGoalForm.getGoalText());
                    treeViewGoals.Nodes.Add(treeNode);
                }
                else if (existingGoal.IsComplete)
                    MessageBox.Show("That goal has already been added and completed.");
                else
                    MessageBox.Show("That goal has already been added.");
            }
        }
        private void addChild_Click(object sender, EventArgs e)
        {
            NewGoal newGoalForm = new NewGoal();
            newGoalForm.ShowDialog();

            if (newGoalForm.getGoalText() != "")
            {
                GoalManagement.Goal goal = myGoalsList.GetSelectedGoal(treeViewGoals.SelectedNode.FullPath, true);
                GoalManagement.Goal existingGoal = myGoalsList.GetSelectedGoal(treeViewGoals.SelectedNode.FullPath + "\\" + newGoalForm.getGoalText(), false);
                if (existingGoal is null)
                {
                    goal.AddChild(newGoalForm.getGoalText());
                    TreeNode treeNode = new TreeNode(newGoalForm.getGoalText());
                    treeViewGoals.SelectedNode.Nodes.Add(treeNode);
                    if (!treeViewGoals.SelectedNode.IsExpanded)
                        treeViewGoals.SelectedNode.Expand();
                }
                else if (existingGoal.IsComplete)
                    MessageBox.Show("That goal has already been added and completed.");
                else
                    MessageBox.Show("That goal has already been added.");
            }
        }

        private void markComplete_Click(object sender, EventArgs e)
        {
            if (treeViewGoals.SelectedNode != null)
            {
                GoalManagement.Goal goal = myGoalsList.GetSelectedGoal(treeViewGoals.SelectedNode.FullPath, true);
                goal.CompleteGoal();
                treeViewGoals.SelectedNode.Remove();
            }

        }
        private void saveAndQuit_Click(object sender, EventArgs e)
        {
            myGoalsList.Save();
            Application.Exit();
        }

        private void selectedGoal_Click(object sender, EventArgs e)
        {

        }

        private void selectedCreated_Click(object sender, EventArgs e)
        {

        }
    }
}

