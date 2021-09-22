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
        public LinkedList<Goal> MyGoals = new LinkedList<Goal>();

        public Goals()
        {

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

        public Goal FindGoal(string Text)
        {
            foreach (Goal goal in MyGoals)
            {
                if (goal.GoalText == Text)
                    return goal;
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
