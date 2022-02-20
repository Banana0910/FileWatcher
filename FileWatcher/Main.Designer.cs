
namespace FileWatcher
{
    partial class FileWatcher
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileWatcher));
            this.C_Watcher = new System.IO.FileSystemWatcher();
            this.D_Watcher = new System.IO.FileSystemWatcher();
            this.start_btn = new System.Windows.Forms.Button();
            this.autoscroll_check = new System.Windows.Forms.CheckBox();
            this.scroll_loop = new System.Windows.Forms.Timer(this.components);
            this.clear_btn = new System.Windows.Forms.Button();
            this.blacklist = new System.Windows.Forms.ListBox();
            this.add_blacklist = new System.Windows.Forms.Button();
            this.blacklist_wordbox = new System.Windows.Forms.TextBox();
            this.sub_blacklist = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.whitelist = new System.Windows.Forms.ListBox();
            this.sub_whitelist = new System.Windows.Forms.Button();
            this.add_whitelist = new System.Windows.Forms.Button();
            this.whitelist_wordbox = new System.Windows.Forms.TextBox();
            this.log = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.C_Watcher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.D_Watcher)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // C_Watcher
            // 
            this.C_Watcher.IncludeSubdirectories = true;
            this.C_Watcher.Path = "C:\\";
            this.C_Watcher.SynchronizingObject = this;
            this.C_Watcher.Changed += new System.IO.FileSystemEventHandler(this.C_Watcher_Changed);
            this.C_Watcher.Created += new System.IO.FileSystemEventHandler(this.C_Watcher_Created);
            this.C_Watcher.Deleted += new System.IO.FileSystemEventHandler(this.C_Watcher_Deleted);
            this.C_Watcher.Renamed += new System.IO.RenamedEventHandler(this.C_Watcher_Renamed);
            // 
            // D_Watcher
            // 
            this.D_Watcher.IncludeSubdirectories = true;
            this.D_Watcher.Path = "D:\\";
            this.D_Watcher.SynchronizingObject = this;
            this.D_Watcher.Changed += new System.IO.FileSystemEventHandler(this.D_Watcher_Changed);
            this.D_Watcher.Created += new System.IO.FileSystemEventHandler(this.D_Watcher_Created);
            this.D_Watcher.Deleted += new System.IO.FileSystemEventHandler(this.D_Watcher_Deleted);
            this.D_Watcher.Renamed += new System.IO.RenamedEventHandler(this.D_Watcher_Renamed);
            // 
            // start_btn
            // 
            this.start_btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.start_btn.Location = new System.Drawing.Point(12, 518);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(461, 28);
            this.start_btn.TabIndex = 1;
            this.start_btn.Text = "감시 시작";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // autoscroll_check
            // 
            this.autoscroll_check.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.autoscroll_check.AutoSize = true;
            this.autoscroll_check.Location = new System.Drawing.Point(623, 522);
            this.autoscroll_check.Name = "autoscroll_check";
            this.autoscroll_check.Size = new System.Drawing.Size(107, 23);
            this.autoscroll_check.TabIndex = 2;
            this.autoscroll_check.Text = "자동 스크롤";
            this.autoscroll_check.UseVisualStyleBackColor = true;
            this.autoscroll_check.CheckedChanged += new System.EventHandler(this.autoscroll_check_CheckedChanged);
            // 
            // scroll_loop
            // 
            this.scroll_loop.Interval = 1;
            this.scroll_loop.Tick += new System.EventHandler(this.scroll_loop_Tick);
            // 
            // clear_btn
            // 
            this.clear_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clear_btn.Location = new System.Drawing.Point(480, 518);
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.Size = new System.Drawing.Size(135, 28);
            this.clear_btn.TabIndex = 3;
            this.clear_btn.Text = "비우기";
            this.clear_btn.UseVisualStyleBackColor = true;
            this.clear_btn.Click += new System.EventHandler(this.clear_btn_Click);
            // 
            // blacklist
            // 
            this.blacklist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blacklist.Font = new System.Drawing.Font("나눔고딕 Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.blacklist.FormattingEnabled = true;
            this.blacklist.IntegralHeight = false;
            this.blacklist.ItemHeight = 15;
            this.blacklist.Location = new System.Drawing.Point(6, 25);
            this.blacklist.Name = "blacklist";
            this.blacklist.Size = new System.Drawing.Size(97, 154);
            this.blacklist.TabIndex = 4;
            this.blacklist.SelectedIndexChanged += new System.EventHandler(this.blacklist_SelectedIndexChanged);
            // 
            // add_blacklist
            // 
            this.add_blacklist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.add_blacklist.Enabled = false;
            this.add_blacklist.Font = new System.Drawing.Font("나눔고딕 Light", 12F);
            this.add_blacklist.Location = new System.Drawing.Point(6, 217);
            this.add_blacklist.Name = "add_blacklist";
            this.add_blacklist.Size = new System.Drawing.Size(45, 28);
            this.add_blacklist.TabIndex = 5;
            this.add_blacklist.Text = "+";
            this.add_blacklist.UseVisualStyleBackColor = true;
            this.add_blacklist.Click += new System.EventHandler(this.add_blacklist_Click);
            // 
            // blacklist_wordbox
            // 
            this.blacklist_wordbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.blacklist_wordbox.Font = new System.Drawing.Font("나눔고딕 Light", 12F);
            this.blacklist_wordbox.Location = new System.Drawing.Point(6, 185);
            this.blacklist_wordbox.Name = "blacklist_wordbox";
            this.blacklist_wordbox.Size = new System.Drawing.Size(97, 26);
            this.blacklist_wordbox.TabIndex = 6;
            this.blacklist_wordbox.TextChanged += new System.EventHandler(this.blacklist_wordbox_TextChanged);
            // 
            // sub_blacklist
            // 
            this.sub_blacklist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sub_blacklist.Enabled = false;
            this.sub_blacklist.Location = new System.Drawing.Point(58, 217);
            this.sub_blacklist.Name = "sub_blacklist";
            this.sub_blacklist.Size = new System.Drawing.Size(45, 28);
            this.sub_blacklist.TabIndex = 7;
            this.sub_blacklist.Text = "-";
            this.sub_blacklist.UseVisualStyleBackColor = true;
            this.sub_blacklist.Click += new System.EventHandler(this.sub_blacklist_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.blacklist);
            this.groupBox1.Controls.Add(this.sub_blacklist);
            this.groupBox1.Controls.Add(this.add_blacklist);
            this.groupBox1.Controls.Add(this.blacklist_wordbox);
            this.groupBox1.Font = new System.Drawing.Font("나눔고딕 Light", 9F);
            this.groupBox1.Location = new System.Drawing.Point(621, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(109, 252);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "블랙리스트";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.whitelist);
            this.groupBox2.Controls.Add(this.sub_whitelist);
            this.groupBox2.Controls.Add(this.add_whitelist);
            this.groupBox2.Controls.Add(this.whitelist_wordbox);
            this.groupBox2.Font = new System.Drawing.Font("나눔고딕 Light", 9F);
            this.groupBox2.Location = new System.Drawing.Point(623, 260);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(109, 252);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "화이트리스트";
            // 
            // whitelist
            // 
            this.whitelist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.whitelist.Font = new System.Drawing.Font("나눔고딕 Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.whitelist.FormattingEnabled = true;
            this.whitelist.IntegralHeight = false;
            this.whitelist.ItemHeight = 15;
            this.whitelist.Location = new System.Drawing.Point(6, 25);
            this.whitelist.Name = "whitelist";
            this.whitelist.Size = new System.Drawing.Size(97, 154);
            this.whitelist.TabIndex = 4;
            this.whitelist.SelectedIndexChanged += new System.EventHandler(this.whitelist_SelectedIndexChanged);
            // 
            // sub_whitelist
            // 
            this.sub_whitelist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sub_whitelist.Enabled = false;
            this.sub_whitelist.Location = new System.Drawing.Point(58, 217);
            this.sub_whitelist.Name = "sub_whitelist";
            this.sub_whitelist.Size = new System.Drawing.Size(45, 28);
            this.sub_whitelist.TabIndex = 7;
            this.sub_whitelist.Text = "-";
            this.sub_whitelist.UseVisualStyleBackColor = true;
            this.sub_whitelist.Click += new System.EventHandler(this.sub_whitelist_Click);
            // 
            // add_whitelist
            // 
            this.add_whitelist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.add_whitelist.Enabled = false;
            this.add_whitelist.Location = new System.Drawing.Point(6, 217);
            this.add_whitelist.Name = "add_whitelist";
            this.add_whitelist.Size = new System.Drawing.Size(45, 28);
            this.add_whitelist.TabIndex = 5;
            this.add_whitelist.Text = "+";
            this.add_whitelist.UseVisualStyleBackColor = true;
            this.add_whitelist.Click += new System.EventHandler(this.add_whitelist_Click);
            // 
            // whitelist_wordbox
            // 
            this.whitelist_wordbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.whitelist_wordbox.Font = new System.Drawing.Font("나눔고딕 Light", 12F);
            this.whitelist_wordbox.Location = new System.Drawing.Point(6, 185);
            this.whitelist_wordbox.Name = "whitelist_wordbox";
            this.whitelist_wordbox.Size = new System.Drawing.Size(97, 26);
            this.whitelist_wordbox.TabIndex = 6;
            this.whitelist_wordbox.TextChanged += new System.EventHandler(this.whitelist_wordbox_TextChanged);
            // 
            // log
            // 
            this.log.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.log.BackColor = System.Drawing.Color.White;
            this.log.Font = new System.Drawing.Font("나눔고딕 Light", 10F);
            this.log.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.log.HideSelection = false;
            this.log.LabelWrap = false;
            this.log.Location = new System.Drawing.Point(14, 10);
            this.log.MultiSelect = false;
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(601, 502);
            this.log.TabIndex = 8;
            this.log.UseCompatibleStateImageBehavior = false;
            this.log.View = System.Windows.Forms.View.Details;
            this.log.DoubleClick += new System.EventHandler(this.log_DoubleClick);
            // 
            // FileWatcher
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(742, 556);
            this.Controls.Add(this.log);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.clear_btn);
            this.Controls.Add(this.autoscroll_check);
            this.Controls.Add(this.start_btn);
            this.Font = new System.Drawing.Font("나눔고딕 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FileWatcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "파일 감시자";
            this.Load += new System.EventHandler(this.FileWatcher_Load);
            this.SizeChanged += new System.EventHandler(this.FileWatcher_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.C_Watcher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.D_Watcher)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.FileSystemWatcher C_Watcher;
        private System.IO.FileSystemWatcher D_Watcher;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.CheckBox autoscroll_check;
        private System.Windows.Forms.Timer scroll_loop;
        private System.Windows.Forms.Button clear_btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox blacklist;
        private System.Windows.Forms.Button sub_blacklist;
        private System.Windows.Forms.Button add_blacklist;
        private System.Windows.Forms.TextBox blacklist_wordbox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox whitelist;
        private System.Windows.Forms.Button sub_whitelist;
        private System.Windows.Forms.Button add_whitelist;
        private System.Windows.Forms.TextBox whitelist_wordbox;
        private System.Windows.Forms.ListView log;
    }
}

