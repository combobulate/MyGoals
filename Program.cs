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
        /// <summary>
        /// The main goal management class
        /// </summary>
        private LinkedList<Goal> MyGoals = new LinkedList<Goal>();
        private string saveLocation = @"files/mySaveFile.Xml";

        /// <summary>
        /// Make a new save file if one doesn't exist already
        /// </summary> 
        public Goals()
        {            
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

        /// <summary>
        /// Accessor for the root goals list
        /// </summary> 
        public LinkedList<Goal> GetGoals()
        {
            return MyGoals;
        }

        /// <summary>
        /// Add a new root goal 
        /// </summary>
        public Goal AddGoal(string Text)
        {
            Goal rootGoal = new Goal(Text);
            MyGoals.AddLast(rootGoal);
            return MyGoals.Last();
        }

        public Goal GetSelectedGoal(string GoalPath, bool IncompleteOnly)
        {
            return GetGoal(MyGoals, GoalPath, IncompleteOnly);
        }

        public Goal GetGoal(LinkedList<Goal> goals, string GoalPath, bool IncompleteOnly)
        {
            int nextLevel = GoalPath.IndexOf("\\");
            string thisGoal = GoalPath;
            if (nextLevel != -1)
                thisGoal = GoalPath.Substring(0, nextLevel);
            
            foreach (Goal goal in goals)
            {
                if (goal.GoalText == thisGoal)
                {
                    if (nextLevel != -1)
                        return GetGoal(goal.GetChildGoals(IncompleteOnly), GoalPath.Substring(nextLevel + 1), IncompleteOnly); 
                    else
                        return goal;
                }    
            }
            return null;            
        }

        /// <summary>
        /// Exact string match search
        /// </summary>
        public Goal SearchGoals(string Text)
        {
            return FindGoal(MyGoals, Text);
        }

        /// <summary>
        /// Recursive search function to go through goal list
        /// </summary>
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

        /// <summary>
        /// Saves current state of all goals in memory
        /// </summary>
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

        /// <summary>
        /// Recursive function for saving goals based on presence in passed in list
        /// </summary>
        private void SaveGoals(LinkedList<Goal> goals, XmlTextWriter writer)
        {
            foreach (Goal goal in goals)
            {
                // Start this goal node
                writer.WriteStartElement("goal");

                // Goal text element
                writer.WriteStartElement("GoalText");
                writer.WriteString(goal.GoalText);
                writer.WriteEndElement();

                // Goal isComplete element
                writer.WriteStartElement("IsComplete");
                writer.WriteString(goal.IsComplete.ToString());
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

        /// <summary>
        /// Loads goals from save file into memory
        /// </summary>
        public void Load()
        {
            XmlTextReader reader = new XmlTextReader(saveLocation);

            // Advance to first node before calling recursive loader
            reader.Read();
            LoadGoals(null, reader);

            reader.Close();
        }

        /// <summary>
        /// Recursive function for loading goals from file. File structure is expected like:
        /// <?xml version="1.0"?>
        /// < root >
        ///    < goal >
        ///       < GoalText > First level goal name </ GoalText >
        ///       < IsComplete > True </ IsComplete >
        ///       < goal >
        ///          < GoalText > Second level goal name </ GoalText >
        ///          < IsComplete > True </ IsComplete >
        ///       </ goal >
        ///       < goal >
        ///          < GoalText > Another second level goal name</ GoalText >
        ///          < IsComplete > True </ IsComplete >
        ///             < goal >
        ///                < GoalText > Third level goal name </ GoalText >
        ///                < IsComplete > True </ IsComplete >
        ///             </ goal >
        ///       </ goal >
        ///    </ goal >
        ///    < goal >
        ///       < GoalText > Another first level goal name </ GoalText >
        ///       < IsComplete > True </ IsComplete >
        /// ...
        /// < /root >
        /// IE all goals have a base set of elements, and may have one or more child goals.
        /// </summary>
        private void LoadGoals(Goal goal, XmlTextReader reader)
        {
            Goal newGoal = new Goal("");
            bool inGoal = false;
            bool inGoalText = false;
            bool inIsCompleteText = false;

            do
            {
                // Relevant node types are Element, EndElement, and Text. The first two are used to set flags indicating
                // how to handle the next node. "goal" is the only Element without a following Text. Encountering a new
                // "goal" while already in a goal calls this function again to be handled on that child goal level.
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
        /// <summary>
        /// The goal class itself
        /// </summary>
        public string GoalText { get; set; }
        public bool IsComplete { get; set; }
        private LinkedList<Goal> ChildGoals = new LinkedList<Goal>();

        /// <summary>
        /// Goal initializer takes a string as the goal text ad defaults the goal to not complete.
        /// </summary>
        /// <param name="Text">The text for the goal</param>
        public Goal(string Text)
        {
            this.GoalText = Text;
            this.IsComplete = false;
        }

        /// <summary>
        /// Adds a child to this goal.
        /// </summary>
        /// <param name="Text">The text for the child goal</param>
        /// <returns>The newly added child goal</returns>
        public Goal AddChild(string Text)
        {
            Goal childGoal = new Goal(Text);
            this.ChildGoals.AddLast(childGoal);
            return ChildGoals.Last();
        }

        /// <summary>
        /// Marks goal complete, if the goal has no incomplete children.
        /// </summary>
        public void CompleteGoal()
        {
            if (this.GetChildGoals(true).Count == 0)
                IsComplete = true;
        }

        /// <summary>
        /// Gets children of this goal.
        /// </summary>
        /// <param name="incompleteOnly">If true, gets incomplete child goals only; if false, gets all children</param>
        /// <returns>Linked list of goals (incomplete or all, depending on input parameter) which are children of this goal</returns>
        public LinkedList<Goal> GetChildGoals(bool incompleteOnly)
        {
            if (incompleteOnly)
            {
                LinkedList<Goal> activeChildGoals = new LinkedList<Goal>();
                foreach (Goal goal in ChildGoals)
                {
                    if (!goal.IsComplete)
                        activeChildGoals.AddLast(goal);
                }
                return activeChildGoals;
            }
            else
                return ChildGoals;
        }
    }
}
