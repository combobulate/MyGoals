
namespace MyGoals
{
    partial class GoalsMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GoalsMainForm));
            this.newGoal = new System.Windows.Forms.Button();
            this.treeViewGoals = new System.Windows.Forms.TreeView();
            this.addChild = new System.Windows.Forms.Button();
            this.markComplete = new System.Windows.Forms.Button();
            this.saveAndQuit = new System.Windows.Forms.Button();
            this.selectedGoal = new System.Windows.Forms.Label();
            this.selectedCreated = new System.Windows.Forms.Label();
            this.selectedStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // newGoal
            // 
            this.newGoal.Location = new System.Drawing.Point(36, 34);
            this.newGoal.Name = "newGoal";
            this.newGoal.Size = new System.Drawing.Size(91, 79);
            this.newGoal.TabIndex = 0;
            this.newGoal.Text = "New Goal";
            this.newGoal.UseVisualStyleBackColor = true;
            this.newGoal.Click += new System.EventHandler(this.newGoal_Click);
            // 
            // treeViewGoals
            // 
            this.treeViewGoals.HideSelection = false;
            this.treeViewGoals.Location = new System.Drawing.Point(36, 159);
            this.treeViewGoals.Name = "treeViewGoals";
            this.treeViewGoals.Size = new System.Drawing.Size(476, 432);
            this.treeViewGoals.TabIndex = 3;
            // 
            // addChild
            // 
            this.addChild.Enabled = false;
            this.addChild.Location = new System.Drawing.Point(161, 34);
            this.addChild.Name = "addChild";
            this.addChild.Size = new System.Drawing.Size(91, 79);
            this.addChild.TabIndex = 4;
            this.addChild.Text = "Add Child";
            this.addChild.UseVisualStyleBackColor = true;
            this.addChild.Click += new System.EventHandler(this.addChild_Click);
            // 
            // markComplete
            // 
            this.markComplete.Enabled = false;
            this.markComplete.Location = new System.Drawing.Point(290, 34);
            this.markComplete.Name = "markComplete";
            this.markComplete.Size = new System.Drawing.Size(91, 79);
            this.markComplete.TabIndex = 5;
            this.markComplete.Text = "Mark Complete";
            this.markComplete.UseVisualStyleBackColor = true;
            this.markComplete.Click += new System.EventHandler(this.markComplete_Click);
            // 
            // saveAndQuit
            // 
            this.saveAndQuit.Location = new System.Drawing.Point(421, 34);
            this.saveAndQuit.Name = "saveAndQuit";
            this.saveAndQuit.Size = new System.Drawing.Size(91, 79);
            this.saveAndQuit.TabIndex = 6;
            this.saveAndQuit.Text = "Save and Quit";
            this.saveAndQuit.UseVisualStyleBackColor = true;
            this.saveAndQuit.Click += new System.EventHandler(this.saveAndQuit_Click);
            // 
            // selectedGoal
            // 
            this.selectedGoal.AutoSize = true;
            this.selectedGoal.Location = new System.Drawing.Point(579, 210);
            this.selectedGoal.Name = "selectedGoal";
            this.selectedGoal.Size = new System.Drawing.Size(35, 13);
            this.selectedGoal.TabIndex = 7;
            this.selectedGoal.Text = "Goal: ";
            this.selectedGoal.Click += new System.EventHandler(this.selectedGoal_Click);
            // 
            // selectedCreated
            // 
            this.selectedCreated.AutoSize = true;
            this.selectedCreated.Location = new System.Drawing.Point(579, 246);
            this.selectedCreated.Name = "selectedCreated";
            this.selectedCreated.Size = new System.Drawing.Size(47, 13);
            this.selectedCreated.TabIndex = 8;
            this.selectedCreated.Text = "Created:";
            this.selectedCreated.Click += new System.EventHandler(this.selectedCreated_Click);
            // 
            // selectedStatus
            // 
            this.selectedStatus.AutoSize = true;
            this.selectedStatus.Location = new System.Drawing.Point(579, 282);
            this.selectedStatus.Name = "selectedStatus";
            this.selectedStatus.Size = new System.Drawing.Size(43, 13);
            this.selectedStatus.TabIndex = 9;
            this.selectedStatus.Text = "Status: ";
            this.selectedStatus.Click += new System.EventHandler(this.selectedStatus_Click);
            // 
            // GoalsMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 623);
            this.Controls.Add(this.selectedStatus);
            this.Controls.Add(this.selectedCreated);
            this.Controls.Add(this.selectedGoal);
            this.Controls.Add(this.saveAndQuit);
            this.Controls.Add(this.markComplete);
            this.Controls.Add(this.addChild);
            this.Controls.Add(this.treeViewGoals);
            this.Controls.Add(this.newGoal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GoalsMainForm";
            this.Text = "My Goal Tracker";
            this.Load += new System.EventHandler(this.GoalsMainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button newGoal;
        private System.Windows.Forms.TreeView treeViewGoals;
        private System.Windows.Forms.Button addChild;
        private System.Windows.Forms.Button markComplete;
        private System.Windows.Forms.Button saveAndQuit;
        private System.Windows.Forms.Label selectedGoal;
        private System.Windows.Forms.Label selectedCreated;
        private System.Windows.Forms.Label selectedStatus;
    }
}

