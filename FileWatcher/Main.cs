using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FileWatcher
{
    public partial class FileWatcher : Form
    {
        public FileWatcher() { InitializeComponent(); }

        int last_count = 0;

        private void change_WatchersState(bool state)
        {
            C_Watcher.EnableRaisingEvents = state;
            D_Watcher.EnableRaisingEvents = state;
        }

        //C_Watcher의 반응
        private void C_Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            string fullpath = e.FullPath;
            if (e.ChangeType != WatcherChangeTypes.Changed)
                return;
            foreach (string i in blacklist.Items)
                if (fullpath.Contains(i))
                    return;

            ListViewItem lvi = new ListViewItem($"[{DateTime.Now.ToString("HH:mm:ss")}] 수정 : [{fullpath}]");
            lvi.SubItems.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            lvi.SubItems.Add("수정");
            lvi.SubItems.Add(fullpath);
            foreach (string i in whitelist.Items)
                if (fullpath.Contains(i))
                    lvi.ForeColor = Color.Red;
            log.Items.Add(lvi);     
        }
        private void C_Watcher_Created(object sender, FileSystemEventArgs e)
        {
            string fullpath = e.FullPath;
            foreach (string i in blacklist.Items)
                if (fullpath.Contains(i))
                    return;

            ListViewItem lvi = new ListViewItem($"[{DateTime.Now.ToString("HH:mm:ss")}] 생성 : [{fullpath}]");
            lvi.SubItems.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            lvi.SubItems.Add("생성");
            lvi.SubItems.Add(fullpath);
            foreach (string i in whitelist.Items)
                if (fullpath.Contains(i))
                    lvi.ForeColor = Color.Red;
            log.Items.Add(lvi);
        }
        private void C_Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            string fullpath = e.FullPath;
            foreach (string i in blacklist.Items)
                if (fullpath.Contains(i))
                    return;

            ListViewItem lvi = new ListViewItem($"[{DateTime.Now.ToString("HH:mm:ss")}] 삭제 : [{fullpath}]");
            lvi.SubItems.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            lvi.SubItems.Add("삭제");
            lvi.SubItems.Add(fullpath);
            foreach (string i in whitelist.Items)
                if (fullpath.Contains(i))
                    lvi.ForeColor = Color.Red;
            log.Items.Add(lvi);
        }
        private void C_Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            string fullpath = e.FullPath;
            foreach (string i in blacklist.Items)
                if (fullpath.Contains(i))
                    return;

            ListViewItem lvi = new ListViewItem($"[{DateTime.Now.ToString("HH:mm:ss")}] 이름 변경 : [{fullpath}]");
            lvi.SubItems.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            lvi.SubItems.Add("이름 변경");
            lvi.SubItems.Add(fullpath);
            lvi.SubItems.Add(e.OldFullPath);
            foreach (string i in whitelist.Items)
                if (fullpath.Contains(i))
                    lvi.ForeColor = Color.Red;
            log.Items.Add(lvi);
        }

        //D_Watcher의 반응
        private void D_Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            string fullpath = e.FullPath;
            if (e.ChangeType != WatcherChangeTypes.Changed)
                return;
            foreach (string i in blacklist.Items)
                if (fullpath.Contains(i))
                    return;

            ListViewItem lvi = new ListViewItem($"[{DateTime.Now.ToString("HH:mm:ss")}] 수정 : [{fullpath}]");
            lvi.SubItems.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            lvi.SubItems.Add("수정");
            lvi.SubItems.Add(fullpath);
            foreach (string i in whitelist.Items)
                if (fullpath.Contains(i))
                    lvi.ForeColor = Color.Red;
            log.Items.Add(lvi);
        }
        private void D_Watcher_Created(object sender, FileSystemEventArgs e)
        {
            string fullpath = e.FullPath;
            foreach (string i in blacklist.Items)
                if (fullpath.Contains(i))
                    return;

            ListViewItem lvi = new ListViewItem($"[{DateTime.Now.ToString("HH:mm:ss")}] 생성 : [{fullpath}]");
            lvi.SubItems.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            lvi.SubItems.Add("생성");
            lvi.SubItems.Add(fullpath);
            foreach (string i in whitelist.Items)
                if (fullpath.Contains(i))
                    lvi.ForeColor = Color.Red;
            log.Items.Add(lvi);
        }
        private void D_Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            string fullpath = e.FullPath;
            foreach (string i in blacklist.Items)
                if (fullpath.Contains(i))
                    return;

            ListViewItem lvi = new ListViewItem($"[{DateTime.Now.ToString("HH:mm:ss")}] 삭제 : [{fullpath}]");
            lvi.SubItems.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            lvi.SubItems.Add("삭제");
            lvi.SubItems.Add(fullpath);
            foreach (string i in whitelist.Items)
                if (fullpath.Contains(i))
                    lvi.ForeColor = Color.Red;
            log.Items.Add(lvi);
        }
        private void D_Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            string fullpath = e.FullPath;
            foreach (string i in blacklist.Items)
                if (fullpath.Contains(i))
                    return;

            ListViewItem lvi = new ListViewItem($"[{DateTime.Now.ToString("HH:mm:ss")}] 이름 변경 : [{fullpath}]");
            lvi.SubItems.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            lvi.SubItems.Add("이름 변경");
            lvi.SubItems.Add(fullpath);
            lvi.SubItems.Add(e.OldFullPath);
            foreach (string i in whitelist.Items)
                if (fullpath.Contains(i))
                    lvi.ForeColor = Color.Red;
            log.Items.Add(lvi);
        }

        //메인 폼 버튼들의 상호작용
        private void start_btn_Click(object sender, EventArgs e)
        {
            if (start_btn.Text == "감시 시작") 
            {
                change_WatchersState(true);
                start_btn.Text = "감시 종료";
            }
            else
            {
                change_WatchersState(false);
                start_btn.Text = "감시 시작";
            }
        }
        private void clear_btn_Click(object sender, EventArgs e)
        { 
            log.Items.Clear();
            last_count = 0;
        }

        //사용자의 입력에 따른 반응
        private void blacklist_wordbox_TextChanged(object sender, EventArgs e)
        {
            if (blacklist_wordbox.Text.Length > 0) add_blacklist.Enabled = true;
            else add_blacklist.Enabled = false;
        }
        private void blacklist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (blacklist.SelectedItem != null) sub_blacklist.Enabled = true;
            else sub_blacklist.Enabled = false;
        }
        private void whitelist_wordbox_TextChanged(object sender, EventArgs e)
        {
            if (whitelist_wordbox.Text.Length > 0) add_whitelist.Enabled = true;
            else add_whitelist.Enabled = false;
        }
        private void whitelist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (whitelist.SelectedItem != null) sub_whitelist.Enabled = true;
            else sub_whitelist.Enabled = false;
        }

        //blacklist와 whitelist의 버튼들 상호작용
        private void add_blacklist_Click(object sender, EventArgs e)
        {
            blacklist.Items.Add(blacklist_wordbox.Text);
            blacklist_wordbox.Clear();
        }
        private void sub_blacklist_Click(object sender, EventArgs e) { blacklist.Items.Remove(blacklist.SelectedItem); }
        private void add_whitelist_Click(object sender, EventArgs e)
        {
            whitelist.Items.Add(whitelist_wordbox.Text);
            whitelist_wordbox.Clear();
        }
        private void sub_whitelist_Click(object sender, EventArgs e) { whitelist.Items.Remove(whitelist.SelectedItem); }

        //자동 스크롤 관련 메서드들
        private void FileWatcher_Load(object sender, EventArgs e)
        {
            ColumnHeader h = new ColumnHeader();
            h.Width = log.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
            log.Columns.Add(h);
        }
        private void FileWatcher_SizeChanged(object sender, EventArgs e) { log.Columns[0].Width = log.ClientSize.Width - SystemInformation.VerticalScrollBarWidth; }
        private void scroll_loop_Tick(object sender, EventArgs e)
        {
            if (last_count != log.Items.Count)
            {
                log.EnsureVisible(log.Items.Count - 1);
                last_count = log.Items.Count;
            }
        }
        private void autoscroll_check_CheckedChanged(object sender, EventArgs e)
        {
            if (autoscroll_check.Checked == true) scroll_loop.Start();
            else scroll_loop.Stop();
        }

        //메시지
        private void log_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem lvi = log.SelectedItems[0];
            string oldpath = lvi.SubItems.Count > 4 ? $"\n변경 : {lvi.SubItems[4].Text}" : "";
            if (MessageBox.Show($"{lvi.SubItems[1].Text}에 {lvi.SubItems[2].Text}함\n원본 : {lvi.SubItems[3].Text}{oldpath}\n폴더를 여시겠습니까?", "파일 감시자", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                Process.Start(Path.GetDirectoryName(lvi.SubItems[3].Text));
        }
    }
}
