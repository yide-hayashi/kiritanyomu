namespace kiritannyomi
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.kiritanyomu = new System.Windows.Forms.Button();
            this.context = new System.Windows.Forms.TextBox();
            this.kiritanimg = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TC = new System.Windows.Forms.TabControl();
            this.TCPage1 = new System.Windows.Forms.TabPage();
            this.TCPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.kiritanimg)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.TC.SuspendLayout();
            this.TCPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kiritanyomu
            // 
            this.kiritanyomu.Location = new System.Drawing.Point(132, 382);
            this.kiritanyomu.Name = "kiritanyomu";
            this.kiritanyomu.Size = new System.Drawing.Size(99, 23);
            this.kiritanyomu.TabIndex = 0;
            this.kiritanyomu.Text = "きりたん読む";
            this.kiritanyomu.UseVisualStyleBackColor = true;
            this.kiritanyomu.Click += new System.EventHandler(this.kiritanyomu_Click);
            // 
            // context
            // 
            this.context.Location = new System.Drawing.Point(6, 6);
            this.context.Multiline = true;
            this.context.Name = "context";
            this.context.Size = new System.Drawing.Size(342, 370);
            this.context.TabIndex = 1;
            // 
            // kiritanimg
            // 
            this.kiritanimg.Image = ((System.Drawing.Image)(resources.GetObject("kiritanimg.Image")));
            this.kiritanimg.Location = new System.Drawing.Point(358, -1);
            this.kiritanimg.Name = "kiritanimg";
            this.kiritanimg.Size = new System.Drawing.Size(277, 443);
            this.kiritanimg.TabIndex = 2;
            this.kiritanimg.TabStop = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "きりたん読む";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(94, 26);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // TC
            // 
            this.TC.Controls.Add(this.TCPage2);
            this.TC.Controls.Add(this.TCPage1);
            this.TC.Location = new System.Drawing.Point(0, -1);
            this.TC.Name = "TC";
            this.TC.SelectedIndex = 0;
            this.TC.Size = new System.Drawing.Size(359, 443);
            this.TC.TabIndex = 4;
            // 
            // TCPage1
            // 
            this.TCPage1.Controls.Add(this.context);
            this.TCPage1.Controls.Add(this.kiritanyomu);
            this.TCPage1.Location = new System.Drawing.Point(4, 22);
            this.TCPage1.Name = "TCPage1";
            this.TCPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TCPage1.Size = new System.Drawing.Size(351, 417);
            this.TCPage1.TabIndex = 0;
            this.TCPage1.Text = "tabPage1";
            this.TCPage1.UseVisualStyleBackColor = true;
            // 
            // TCPage2
            // 
            this.TCPage2.Location = new System.Drawing.Point(4, 22);
            this.TCPage2.Name = "TCPage2";
            this.TCPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TCPage2.Size = new System.Drawing.Size(351, 417);
            this.TCPage2.TabIndex = 1;
            this.TCPage2.Text = "twitter";
            this.TCPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(635, 438);
            this.Controls.Add(this.TC);
            this.Controls.Add(this.kiritanimg);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "きりたん読む";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kiritanimg)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.TC.ResumeLayout(false);
            this.TCPage1.ResumeLayout(false);
            this.TCPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button kiritanyomu;
        private System.Windows.Forms.TextBox context;
        private System.Windows.Forms.PictureBox kiritanimg;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabControl TC;
        private System.Windows.Forms.TabPage TCPage2;
        private System.Windows.Forms.TabPage TCPage1;
    }
}

