using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGoals
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GoalsMainForm());
        }
    }
}

namespace Classes
{
    public class Goals
    {
        private LinkedList<Goal> MyGoals = new LinkedList<Goal>();

        public Goals()
        {

        }

        public LinkedList<Goal> GetGoals()
        {
            return MyGoals;
        }

        public void AddGoal(string Text)
        {
            Goal rootGoal = new Goal(Text);
            MyGoals.AddLast(rootGoal);
        }

        public string ListGoals()
        {
            string output = "";
            foreach (Goal goal in this.MyGoals)
            {
                output += goal.GoalText;
            }
            return output;
        }

        public Goal SearchGoals(string Text)
        {
            return FindGoal(MyGoals, Text);
        }
        private Goal FindGoal(LinkedList<Goal> goals, string Text)
        {
            foreach (Goal goal in goals)
            {
                if (goal.GoalText == Text)
                    return goal;
                else if (goal.GetChildGoals(true).Count != 0)
                {
                    Goal foundGoal = FindGoal(goal.GetChildGoals(true), Text);
                    if (foundGoal != null)
                        return foundGoal;
                }
                    
            }
            return null;
        }
    }

    public class Goal
    {
        public string GoalText { get; set; }
        private LinkedList<Goal> ChildGoals = new LinkedList<Goal>();
        private bool isComplete = false;
        
        public Goal(string Text)
        {
            this.GoalText = Text;
        }
        
        public void AddChild(string Text)
        {
            Goal childGoal = new Goal(Text);
            this.ChildGoals.AddLast(childGoal);
        }

        public void CompleteGoal()
        {
            isComplete = true;
        }

        public bool IsComplete()
        {
            return isComplete;
        }

        public LinkedList<Goal> GetChildGoals(bool activeOnly)
        {
            if (activeOnly)
            {
                LinkedList<Goal> activeChildGoals = new LinkedList<Goal>();
                foreach (Goal goal in ChildGoals)
                {
                    if (!goal.isComplete)
                        activeChildGoals.AddLast(goal);
                }
                return activeChildGoals;
            }
            else
                return ChildGoals;
        }
    }
}
