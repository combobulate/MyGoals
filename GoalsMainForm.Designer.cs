
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
            this.newGoal = new System.Windows.Forms.Button();
            this.treeViewGoals = new System.Windows.Forms.TreeView();
            this.addChild = new System.Windows.Forms.Button();
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
            this.treeViewGoals.AfterSelect += treeViewGoals_OnAfterSelect;
            this.treeViewGoals.HideSelection = false;
            this.treeViewGoals.Location = new System.Drawing.Point(29, 159);
            this.treeViewGoals.Name = "treeViewGoals";
            this.treeViewGoals.Size = new System.Drawing.Size(251, 432);
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
            // GoalsMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 623);
            this.Controls.Add(this.addChild);
            this.Controls.Add(this.treeViewGoals);
            this.Controls.Add(this.newGoal);
            this.Name = "GoalsMainForm";
            this.Text = "My Goal Tracker";
            this.Load += new System.EventHandler(this.GoalsMainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newGoal;
        private System.Windows.Forms.TreeView treeViewGoals;
        private System.Windows.Forms.Button addChild;
    }
}

