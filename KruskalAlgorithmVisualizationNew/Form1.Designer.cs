﻿namespace KruskalAlgorithmVisualizationNew
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.GenerateGraphButton = new System.Windows.Forms.Button();
            this.numNodesLabel = new System.Windows.Forms.Label();
            this.numNodesTextBox = new System.Windows.Forms.TextBox();
            this.graphPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.graphPictureBox)).BeginInit();
            this.SuspendLayout();

            // GenerateGraphButton
            this.GenerateGraphButton.Location = new System.Drawing.Point(12, 12);
            this.GenerateGraphButton.Name = "GenerateGraphButton";
            this.GenerateGraphButton.Size = new System.Drawing.Size(120, 30);
            this.GenerateGraphButton.Text = "Generate Graph";
            this.GenerateGraphButton.UseVisualStyleBackColor = true;
            this.GenerateGraphButton.Click += new System.EventHandler(this.GenerateGraphButton_Click);

            // numNodesLabel
            this.numNodesLabel.AutoSize = true;
            this.numNodesLabel.Location = new System.Drawing.Point(150, 20);
            this.numNodesLabel.Name = "numNodesLabel";
            this.numNodesLabel.Size = new System.Drawing.Size(94, 15);
            this.numNodesLabel.Text = "Number of Nodes:";

            // numNodesTextBox
            this.numNodesTextBox.Location = new System.Drawing.Point(250, 17);
            this.numNodesTextBox.Name = "numNodesTextBox";
            this.numNodesTextBox.Size = new System.Drawing.Size(50, 23);
            this.numNodesTextBox.Text = "10";

            // graphPictureBox
            this.graphPictureBox.Location = new System.Drawing.Point(12, 50);
            this.graphPictureBox.Name = "graphPictureBox";
            this.graphPictureBox.Size = new System.Drawing.Size(500, 400);
            this.graphPictureBox.TabStop = false;
            this.graphPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.GraphPictureBox_Paint);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(524, 461);
            this.Controls.Add(this.GenerateGraphButton);
            this.Controls.Add(this.numNodesLabel);
            this.Controls.Add(this.numNodesTextBox);
            this.Controls.Add(this.graphPictureBox);
            this.Name = "MainForm";
            this.Text = "Kruskal Algorithm Visualization";
            ((System.ComponentModel.ISupportInitialize)(this.graphPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button GenerateGraphButton;
        private System.Windows.Forms.Label numNodesLabel;
        private System.Windows.Forms.TextBox numNodesTextBox;
        private System.Windows.Forms.PictureBox graphPictureBox;
    }
}
