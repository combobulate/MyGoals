using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoalManagement;

namespace MyGoals
{
    public partial class GoalsMainForm : Form
    {
        private Goals myGoalsList = new Goals();
        
        public GoalsMainForm()
        {
            InitializeComponent();
            treeViewGoals.AfterSelect += treeViewGoals_OnAfterSelect;
            myGoalsList.Load();            
        }

        private void GoalsMainForm_Load(object sender, EventArgs e)
        {
            foreach (GoalNode goal in myGoalsList.GetGoals().Nodes)
            {
                if (!goal.IsComplete)
                {
                    TreeNode treeNode = new TreeNode(goal.Text);
                    treeViewGoals.Nodes.Add(treeNode);
                    if (goal.IncompleteChildGoals())
                        treeViewPrintGoals(treeNode, goal);
                }
            }
        }

        private void treeViewGoals_OnAfterSelect(object sender, TreeViewEventArgs e)
        {
            addChild.Enabled = true;
            GoalNode goal = myGoalsList.GetSelectedGoal(treeViewGoals.SelectedNode.FullPath, true);
            checkForChildren(goal);
        }

        private void checkForChildren(GoalNode goal)
        {
            if (!goal.IncompleteChildGoals())
                markComplete.Enabled = true;
            else
                markComplete.Enabled = false;
        }

        private void treeViewPrintGoals(TreeNode tree, GoalNode goals)
        {
            foreach(GoalNode goal in goals.Nodes)
            {
                if (!goal.IsComplete)
                {
                    TreeNode treeNode = new TreeNode(goal.Text);
                    tree.Nodes.Add(treeNode);
                    if (goal.IncompleteChildGoals())
                        treeViewPrintGoals(treeNode, goal);
                }
                
            }
            
        }

        private void newGoal_Click(object sender, EventArgs e)
        {
            NewGoal newGoalForm = new NewGoal();
            newGoalForm.ShowDialog();

            if (newGoalForm.getGoalText() != "")
            {
                GoalNode existingGoal = myGoalsList.GetSelectedGoal(newGoalForm.getGoalText(), false);
                
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
                GoalNode goal = myGoalsList.GetSelectedGoal(treeViewGoals.SelectedNode.FullPath, true);
                GoalNode existingGoal = myGoalsList.GetSelectedGoal(treeViewGoals.SelectedNode.FullPath + "\\" + newGoalForm.getGoalText(), false);
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

                checkForChildren(goal);
            }
        }

        private void markComplete_Click(object sender, EventArgs e)
        {
            if (treeViewGoals.SelectedNode != null)
            {
                GoalNode goal = myGoalsList.GetSelectedGoal(treeViewGoals.SelectedNode.FullPath, true);
                if(goal.CompleteGoal())
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

