using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security.Principal;
using System.Windows.Forms;

namespace FileWatcher
{
    public partial class FileWatcher : Form
    {
        public FileWatcher() { InitializeComponent(); }

        int last_count = 0;

        bool IsUserAdministrator() {
            WindowsIdentity user = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(user);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }        
        private void change_WatchersState(bool state)
        {
            C_Watcher.EnableRaisingEvents = state;
            D_Watcher.EnableRaisingEvents = state;
        }

        private void change_minsizeState(bool state)
        {
            minsize_check.Visible = state;
            minsize_box.Visible = state;
            mb_label.Visible = state;
        }

        private bool check_target(string path) {
            if (onlyFile_check.Checked) {
                try {
                    FileAttributes attr = File.GetAttributes(path);
                    if ((attr & FileAttributes.Directory) == FileAttributes.Directory) return false;
                    if (minsize_check.Checked) {
                        long length = new FileInfo(path).Length;
                        long minsize = int.Parse(minsize_box.Text)*1048576;
                        if (length < minsize) return false;
                    }
                } catch {
                    return false;
                }
            }
            return true;
        }

        private void run_alarm(string path, string type) {
            if (!alarm_check.Checked) return;
            notificate.ShowBalloonTip(5000, this.Text, $"{path}의 {type}이(가) 감지 되었습니다!", ToolTipIcon.Info);
        }

        private void append_log(FileSystemEventArgs e, WatcherChangeTypes type, string type_name)
        {
            string fullpath = e.FullPath;

            if (e.ChangeType != type) return;
            if (!check_target(fullpath)) return;
            foreach (string i in blacklist.Items)
                if (fullpath.Contains(i))
                    return;
            ListViewItem lvi = new ListViewItem($"[{DateTime.Now.ToString("HH:mm:ss")}] {type_name} : [{fullpath}]");
            lvi.SubItems.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            lvi.SubItems.Add(type_name);
            lvi.SubItems.Add(fullpath);
            foreach (string i in whitelist.Items)
                if (fullpath.Contains(i))
                    lvi.ForeColor = Color.Red;
            log.Items.Add(lvi);
            run_alarm(fullpath, type_name);
        }

        private void append_rename_log(string oldpath, string newpath) 
        {
            string type_name = "이름 변경";
            if (!check_target(newpath)) return;
            foreach (string i in blacklist.Items)
                if (newpath.Contains(i))
                    return;
            ListViewItem lvi = new ListViewItem($"[{DateTime.Now.ToString("HH:mm:ss")}] {type_name} : [{newpath}]");
            lvi.SubItems.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            lvi.SubItems.Add(type_name);
            lvi.SubItems.Add(newpath);
            lvi.SubItems.Add(oldpath);
            foreach (string i in whitelist.Items)
                if (newpath.Contains(i))
                    lvi.ForeColor = Color.Red;
            log.Items.Add(lvi);
            run_alarm(newpath, type_name);
        }

        //C_Watcher의 이벤트
        private void C_Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            append_log(e,WatcherChangeTypes.Changed,"수정");
        }
        private void C_Watcher_Created(object sender, FileSystemEventArgs e)
        {
            append_log(e,WatcherChangeTypes.Created,"생성");
        }
        private void C_Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            append_log(e,WatcherChangeTypes.Deleted,"삭제");
        }
        private void C_Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            append_rename_log(e.OldFullPath, e.FullPath);
        }

        //D_Watcher의 반응
        private void D_Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            append_log(e,WatcherChangeTypes.Changed,"수정");
        }
        private void D_Watcher_Created(object sender, FileSystemEventArgs e)
        {
            append_log(e,WatcherChangeTypes.Created,"생성");
        }
        private void D_Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            append_log(e,WatcherChangeTypes.Deleted,"삭제");
        }
        private void D_Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            append_rename_log(e.OldFullPath, e.FullPath);
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
            change_WatchersState(false);
            if (!IsUserAdministrator()) warning_label.Text = "※ 관리자 권한으로 실행을 안하시면 일부 파일이 탐지가 안될 수 있습니다.";
            font_size_box.Text = log.Font.Size.ToString();
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
        //폰트 관련 이벤트
        private void font_sizeup_btn_Click(object sender, EventArgs e) {
            log.Font = new Font(log.Font.FontFamily, log.Font.Size + 1);
        }
        private void font_sizedwn_btn_Click(object sender, EventArgs e) {
            log.Font = new Font(log.Font.FontFamily, log.Font.Size - 1);
        }
        private void log_FontChanged(object sender, EventArgs e) {
            font_size_box.Text = log.Font.Size.ToString();
        }
        private void font_size_box_TextChanged(object sender, EventArgs e) {
            if (int.TryParse(font_size_box.Text, out int size)) {
                log.Font = new Font(log.Font.FontFamily, size);
            }
        }

        //파일 관련 메서드
        private void onlyFile_check_CheckChanged(object sender, EventArgs e) {
            change_minsizeState(onlyFile_check.Checked);
        }
        private void minsize_check_CheckChanged(object sender, EventArgs e) {
            minsize_box.Enabled = minsize_check.Checked;
        }
        private void minsize_box_Leave(object sender, EventArgs e) {
            if (!int.TryParse(minsize_box.Text, out int t)) {
                minsize_box.Text = "0";
            }
        }

        //메시지
        private void log_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem lvi = log.SelectedItems[0];
            string oldpath = lvi.SubItems.Count > 4 ? $"\n변경 : {lvi.SubItems[4].Text}" : "";
            if (MessageBox.Show($"{lvi.SubItems[1].Text}에 {lvi.SubItems[2].Text}함\n원본 : {lvi.SubItems[3].Text}{oldpath}\n폴더를 여시겠습니까?", "파일 감시자", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                Process.Start(Path.GetDirectoryName(lvi.SubItems[3].Text));
        }

        private void FileWatcher_Click(object sender, EventArgs e)
        {
            minsize_box_Leave(sender, e);
        }

        private void notificate_BalloonTipClicked(object sender, EventArgs e)
        {
            this.Show();
        }

        private void notificate_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }

        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FileWatcher_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            this.Hide();
        }

    }
}
