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
                else if (goal.ChildGoals.Count != 0)
                {
                    Goal foundGoal = FindGoal(goal.ChildGoals, Text);
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
        public LinkedList<Goal> ChildGoals = new LinkedList<Goal>();
        
        public Goal(string Text)
        {
            this.GoalText = Text;
        }

        public void AddChild(string Text)
        {
            Goal childGoal = new Goal(Text);
            this.ChildGoals.AddLast(childGoal);
        }

        /*
        public void AddChild(string Text, int Position)
        {
            Goal childGoal = new Goal(Text);
            this.ChildGoals.AddAfter(childGoal);
        }*/

    }
}
