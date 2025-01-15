namespace UI
{
    partial class TicketCreateForm
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
            TickeTitleBox = new TextBox();
            label1 = new Label();
            btnCancel = new Button();
            btnSave = new Button();
            DescriptionBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            PriorityBox = new ComboBox();
            StatusBox = new ComboBox();
            StatusPanel = new Panel();
            StatusPanel.SuspendLayout();
            SuspendLayout();
            // 
            // TickeTitleBox
            // 
            TickeTitleBox.Location = new Point(127, 15);
            TickeTitleBox.Margin = new Padding(2);
            TickeTitleBox.Name = "TickeTitleBox";
            TickeTitleBox.Size = new Size(221, 23);
            TickeTitleBox.TabIndex = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(56, 18);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 15;
            label1.Text = "Title:";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(243, 212);
            btnCancel.Margin = new Padding(2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(78, 20);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(93, 212);
            btnSave.Margin = new Padding(2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(78, 20);
            btnSave.TabIndex = 13;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // DescriptionBox
            // 
            DescriptionBox.Location = new Point(127, 53);
            DescriptionBox.Multiline = true;
            DescriptionBox.Name = "DescriptionBox";
            DescriptionBox.Size = new Size(221, 81);
            DescriptionBox.TabIndex = 21;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 53);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 22;
            label2.Text = "Description:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 152);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 23;
            label3.Text = "Priority:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 11);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 27;
            label4.Text = "Status:";
            // 
            // PriorityBox
            // 
            PriorityBox.DropDownStyle = ComboBoxStyle.DropDownList;
            PriorityBox.FormattingEnabled = true;
            PriorityBox.Items.AddRange(new object[] { "low", "normal", "high" });
            PriorityBox.Location = new Point(73, 149);
            PriorityBox.Name = "PriorityBox";
            PriorityBox.Size = new Size(118, 23);
            PriorityBox.TabIndex = 28;
            // 
            // StatusBox
            // 
            StatusBox.DropDownStyle = ComboBoxStyle.DropDownList;
            StatusBox.FormattingEnabled = true;
            StatusBox.Items.AddRange(new object[] { "open", "pending", "resolved", "closed" });
            StatusBox.Location = new Point(51, 8);
            StatusBox.Name = "StatusBox";
            StatusBox.Size = new Size(105, 23);
            StatusBox.TabIndex = 29;
            // 
            // StatusPanel
            // 
            StatusPanel.Controls.Add(label4);
            StatusPanel.Controls.Add(StatusBox);
            StatusPanel.Location = new Point(208, 140);
            StatusPanel.Name = "StatusPanel";
            StatusPanel.Size = new Size(172, 39);
            StatusPanel.TabIndex = 30;
            // 
            // TicketCreateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 250);
            Controls.Add(StatusPanel);
            Controls.Add(PriorityBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(DescriptionBox);
            Controls.Add(TickeTitleBox);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Name = "TicketCreateForm";
            Text = "TicketCreateForm";
            StatusPanel.ResumeLayout(false);
            StatusPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TickeTitleBox;
        private Label label1;
        private Button btnCancel;
        private Button btnSave;
        private TextBox DescriptionBox;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox PriorityBox;
        private ComboBox StatusBox;
        private Panel StatusPanel;
    }
}