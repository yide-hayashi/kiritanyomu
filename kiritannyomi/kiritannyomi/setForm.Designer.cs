namespace kiritannyomi
{
    partial class setForm
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
            this.eh1 = new System.Windows.Forms.Integration.ElementHost();
            this.label1 = new System.Windows.Forms.Label();
            this.path = new System.Windows.Forms.TextBox();
            this.getpath = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cannel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // eh1
            // 
            this.eh1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eh1.Location = new System.Drawing.Point(0, 0);
            this.eh1.Name = "eh1";
            this.eh1.Size = new System.Drawing.Size(404, 113);
            this.eh1.TabIndex = 0;
            this.eh1.Text = " ";
            this.eh1.Child = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "VOICEROID＋ 東北きりたん EX パス:";
            // 
            // path
            // 
            this.path.Location = new System.Drawing.Point(13, 25);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(351, 22);
            this.path.TabIndex = 2;
            // 
            // getpath
            // 
            this.getpath.Location = new System.Drawing.Point(368, 23);
            this.getpath.Name = "getpath";
            this.getpath.Size = new System.Drawing.Size(31, 24);
            this.getpath.TabIndex = 3;
            this.getpath.Text = "...";
            this.getpath.UseVisualStyleBackColor = true;
            this.getpath.Click += new System.EventHandler(this.getpath_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(73, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "設定する";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cannel
            // 
            this.cannel.Location = new System.Drawing.Point(233, 68);
            this.cannel.Name = "cannel";
            this.cannel.Size = new System.Drawing.Size(75, 23);
            this.cannel.TabIndex = 5;
            this.cannel.Text = "キャンセル";
            this.cannel.UseVisualStyleBackColor = true;
            this.cannel.Click += new System.EventHandler(this.cannel_Click);
            // 
            // setForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 113);
            this.ControlBox = false;
            this.Controls.Add(this.cannel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.getpath);
            this.Controls.Add(this.path);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.eh1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "setForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "setForm";
            this.Load += new System.EventHandler(this.setForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost eh1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox path;
        private System.Windows.Forms.Button getpath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cannel;
    }
}