using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

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

namespace GoalManagement
{
    public class Goals
    {
        private LinkedList<Goal> MyGoals = new LinkedList<Goal>();
        private string saveLocation = @"files/mySaveFile.Xml";
        public Goals()
        {
            // Initialize save file if one doesn't exist already
            if (!File.Exists(saveLocation))
            {
                XmlWriter writer = XmlWriter.Create(saveLocation);

                writer.WriteStartDocument();
                writer.WriteStartElement("root");
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }
        }

        public LinkedList<Goal> GetGoals()
        {
            return MyGoals;
        }

        public Goal AddGoal(string Text)
        {
            Goal rootGoal = new Goal(Text);
            MyGoals.AddLast(rootGoal);
            return MyGoals.Last();
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

        public void Save()
        {
            XmlTextWriter writer = new XmlTextWriter(saveLocation, null);

            writer.WriteStartDocument();
            writer.WriteStartElement("root");
            SaveGoals(MyGoals, writer);
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        private void SaveGoals(LinkedList<Goal> goals, XmlTextWriter writer)
        {
            foreach (Goal goal in goals)
            {
                // Start this goal node
                writer.WriteStartElement("goal");

                // Goal text element
                writer.WriteStartElement("GoalText");
                writer.WriteString(goal.Text());
                writer.WriteEndElement();

                // Goal isComplete element
                writer.WriteStartElement("IsComplete");
                writer.WriteString(goal.IsComplete().ToString());
                writer.WriteEndElement();

                // Add each child goal as a child goal element
                if (goal.GetChildGoals(false).Count != 0)
                {
                    SaveGoals(goal.GetChildGoals(false), writer);
                }

                // End this goal node
                writer.WriteEndElement();
            }
        }

        public void Load()
        {
            XmlTextReader reader = new XmlTextReader(saveLocation);

            // Advance to first node
            reader.Read();

            LoadGoals(null, reader);

            reader.Close();
        }

        private void LoadGoals(Goal goal, XmlTextReader reader)
        {
            Goal newGoal = new Goal("");
            bool inGoal = false;
            bool inGoalText = false;
            bool inIsCompleteText = false;

            do
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "goal":
                            if (inGoal)
                            {
                                LoadGoals(newGoal, reader);
                                inGoal = false;
                            }
                            else
                                inGoal = true;
                            break;
                        case "GoalText":
                            inGoalText = true;
                            break;
                        case "IsComplete":
                            inIsCompleteText = true;
                            break;
                    }
                }
                else if (reader.NodeType == XmlNodeType.Text)
                {
                    if (inGoalText)
                    {
                        if (goal == null)
                            newGoal = AddGoal(reader.Value);
                        else
                            newGoal = goal.AddChild(reader.Value);
                    }
                    else if (inIsCompleteText & bool.Parse(reader.Value))
                        newGoal.CompleteGoal();
                }
                else if (reader.NodeType == XmlNodeType.EndElement)
                {
                    switch (reader.Name)
                    {
                        case "goal":
                            if (inGoal)
                                inGoal = false;
                            else
                                return;
                            break;
                        case "GoalText":
                            inGoalText = false;
                            break;
                        case "IsComplete":
                            inIsCompleteText = false;
                            break;
                    }
                }

            } while (reader.Read());
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

        public string Text()
        {
            return GoalText;
        }
        
        public Goal AddChild(string Text)
        {
            Goal childGoal = new Goal(Text);
            this.ChildGoals.AddLast(childGoal);
            return ChildGoals.Last();
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

    public class XmlData
    {
        
    }
}
