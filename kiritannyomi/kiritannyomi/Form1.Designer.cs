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
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TC = new System.Windows.Forms.TabControl();
            this.TCPage2 = new System.Windows.Forms.TabPage();
            this.TCPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.kiritanimg = new System.Windows.Forms.PictureBox();
            this.UC = new kiritannyomi.CefBrowser();
            this.contextMenuStrip1.SuspendLayout();
            this.TC.SuspendLayout();
            this.TCPage2.SuspendLayout();
            this.TCPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kiritanimg)).BeginInit();
            this.SuspendLayout();
            // 
            // kiritanyomu
            // 
            this.kiritanyomu.Location = new System.Drawing.Point(274, 393);
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
            this.context.Size = new System.Drawing.Size(612, 370);
            this.context.TabIndex = 1;
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
            this.exitToolStripMenuItem,
            this.settingToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(112, 48);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.exitToolStripMenuItem.Text = "Setting";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.settingToolStripMenuItem.Text = "Exit";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // TC
            // 
            this.TC.Controls.Add(this.TCPage2);
            this.TC.Controls.Add(this.TCPage1);
            this.TC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TC.ItemSize = new System.Drawing.Size(52, 16);
            this.TC.Location = new System.Drawing.Point(3, 3);
            this.TC.Name = "TC";
            this.TC.Padding = new System.Drawing.Point(9, 3);
            this.TC.SelectedIndex = 0;
            this.TC.Size = new System.Drawing.Size(633, 541);
            this.TC.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TC.TabIndex = 4;
            // 
            // TCPage2
            // 
            this.TCPage2.Controls.Add(this.UC);
            this.TCPage2.Location = new System.Drawing.Point(4, 20);
            this.TCPage2.Name = "TCPage2";
            this.TCPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TCPage2.Size = new System.Drawing.Size(625, 517);
            this.TCPage2.TabIndex = 1;
            this.TCPage2.Text = "twitter";
            this.TCPage2.UseVisualStyleBackColor = true;
            // 
            // TCPage1
            // 
            this.TCPage1.Controls.Add(this.context);
            this.TCPage1.Controls.Add(this.kiritanyomu);
            this.TCPage1.Location = new System.Drawing.Point(4, 20);
            this.TCPage1.Name = "TCPage1";
            this.TCPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TCPage1.Size = new System.Drawing.Size(606, 517);
            this.TCPage1.TabIndex = 0;
            this.TCPage1.Text = "tabPage1";
            this.TCPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.TC, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.kiritanimg, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(959, 547);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // kiritanimg
            // 
            this.kiritanimg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kiritanimg.Image = ((System.Drawing.Image)(resources.GetObject("kiritanimg.Image")));
            this.kiritanimg.Location = new System.Drawing.Point(642, 3);
            this.kiritanimg.Name = "kiritanimg";
            this.kiritanimg.Size = new System.Drawing.Size(314, 541);
            this.kiritanimg.TabIndex = 2;
            this.kiritanimg.TabStop = false;
            // 
            // UC
            // 
            this.UC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UC.Location = new System.Drawing.Point(3, 3);
            this.UC.Name = "UC";
            this.UC.Size = new System.Drawing.Size(619, 511);
            this.UC.TabIndex = 0;
            this.UC.SizeChanged += new System.EventHandler(this.UC_SizeChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(959, 547);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "きりたん読む";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.TC.ResumeLayout(false);
            this.TCPage2.ResumeLayout(false);
            this.TCPage1.ResumeLayout(false);
            this.TCPage1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kiritanimg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button kiritanyomu;
        private System.Windows.Forms.TextBox context;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabControl TC;
        private System.Windows.Forms.TabPage TCPage2;
        private System.Windows.Forms.TabPage TCPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox kiritanimg;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private CefBrowser UC;
    }
}

