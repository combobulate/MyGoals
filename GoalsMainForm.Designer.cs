
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
            this.labelTest = new System.Windows.Forms.Label();
            this.textBoxTest = new System.Windows.Forms.TextBox();
            this.treeViewGoals = new System.Windows.Forms.TreeView();
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
            // labelTest
            // 
            this.labelTest.AutoSize = true;
            this.labelTest.Location = new System.Drawing.Point(36, 174);
            this.labelTest.Name = "labelTest";
            this.labelTest.Size = new System.Drawing.Size(88, 13);
            this.labelTest.TabIndex = 1;
            this.labelTest.Text = "test label content";
            // 
            // textBoxTest
            // 
            this.textBoxTest.Location = new System.Drawing.Point(36, 141);
            this.textBoxTest.Name = "textBoxTest";
            this.textBoxTest.Size = new System.Drawing.Size(100, 20);
            this.textBoxTest.TabIndex = 2;
            // 
            // treeViewGoals
            // 
            this.treeViewGoals.Location = new System.Drawing.Point(29, 214);
            this.treeViewGoals.Name = "treeViewGoals";
            this.treeViewGoals.Size = new System.Drawing.Size(244, 377);
            this.treeViewGoals.TabIndex = 3;
            // 
            // GoalsMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 623);
            this.Controls.Add(this.treeViewGoals);
            this.Controls.Add(this.textBoxTest);
            this.Controls.Add(this.labelTest);
            this.Controls.Add(this.newGoal);
            this.Name = "GoalsMainForm";
            this.Text = "My Goal Tracker";
            this.Load += new System.EventHandler(this.GoalsMainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button newGoal;
        private System.Windows.Forms.Label labelTest;
        private System.Windows.Forms.TextBox textBoxTest;
        private System.Windows.Forms.TreeView treeViewGoals;
    }
}

