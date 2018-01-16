using System;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Text;
using System.Drawing;
using System.Linq;

namespace Launcher
{
    public partial class Launcher : Form
    {
        DateTime destDate = new DateTime(2018, 6, 15);

        public const int WM_DEVICECHANGE = 0x219;
        public const int DBT_DEVICEARRIVAL = 0x8000;    //如果m.Msg的值为0x8000那么表示有U盘插入
        public const int DBT_CONFIGCHANGECANCELED = 0x0019;
        public const int DBT_CONFIGCHANGED = 0x0018;
        public const int DBT_CUSTOMEVENT = 0x8006;
        public const int DBT_DEVICEQUERYREMOVE = 0x8001;
        public const int DBT_DEVICEQUERYREMOVEFAILED = 0x8002;
        public const int DBT_DEVICEREMOVECOMPLETE = 0X8004;
        public const int DBT_DEVICEREMOVEPENDING = 0x8003;
        public const int DBT_DEVICETYPESPECIFIC = 0x8005;
        public const int DBT_DEVNODES_CHANGED = 0x0007;
        public const int DBT_QUERYCHANGECONFIG = 0x0017;
        public const int DBT_USERDEFINED = 0xFFFF;

        public Launcher()
        {
            InitializeComponent();
            bt_copyright.Location = new System.Drawing.Point(Screen.PrimaryScreen.WorkingArea.Width - 115, Screen.PrimaryScreen.WorkingArea.Height-64);
            // pb_back.Size = new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
        }

        #region 获取Windows桌面背景
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern int SystemParametersInfo(int uAction, int uParam, StringBuilder lpvParam, int fuWinIni);
        private const int SPI_GETDESKWALLPAPER = 0x0073;
        private Image cachedDesktop;
        #endregion
        private void SetDesktop()
        {
            StringBuilder desktopPath = new StringBuilder(300);
            SystemParametersInfo(SPI_GETDESKWALLPAPER, 300, desktopPath, 0);
            Image desktop = Image.FromFile(desktopPath.ToString());
            if (cachedDesktop == null)
            {
                cachedDesktop = desktop;
                BackgroundImage = desktop;
            }
        }

        private void Launcher_Load(object sender, EventArgs e)
        {
            SetDesktop();
            setRemain(ref destDate);
            ProgramUpd.Execute();
            List_USB();
        }

        private void setRemain(ref DateTime timeRemain)
        {
            TimeSpan ts = timeRemain - DateTime.Now;
            lb_remain.Text = ts.Days + "天 " + ts.Hours + "小时 " + ts.Seconds + "秒";
        }

        // public Message mm;

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            try
            {
                System.IO.DriveInfo[] disk = System.IO.DriveInfo.GetDrives();
                if (m.Msg == WM_DEVICECHANGE)
                {
                    switch (m.WParam.ToInt32())
                    {
                        case WM_DEVICECHANGE:
                            break;
                        case DBT_DEVICEARRIVAL:         //U盘插入
                            DriveInfo[] drives = DriveInfo.GetDrives();
                            foreach (DriveInfo drive in drives)
                            {
                                if ((drive.DriveType == DriveType.Removable))
                                {
                                    list_usb.Items.Clear();
                                    bt_usb_browse.Enabled = false;
                                    bt_usb_eject.Enabled = false;
                                    bt_open_all.Enabled = false;
                                    List_USB();
                                }
                            }

                            break;
                        case DBT_CONFIGCHANGECANCELED:
                            break;
                        case DBT_CONFIGCHANGED:
                            break;
                        case DBT_CUSTOMEVENT:
                            break;
                        case DBT_DEVICEQUERYREMOVE:
                            list_usb.Items.Clear();
                            List_USB();
                            break;
                        case DBT_DEVICEQUERYREMOVEFAILED:
                            break;
                        case DBT_DEVICEREMOVECOMPLETE:   //U盘卸载
                            list_usb.Items.Clear();
                            bt_usb_browse.Enabled = false;
                            bt_usb_eject.Enabled = false;
                            bt_open_all.Enabled = false;
                            List_USB();
                            break;
                        case DBT_DEVICEREMOVEPENDING:
                            break;
                        case DBT_DEVNODES_CHANGED:
                            break;
                        case DBT_QUERYCHANGECONFIG:
                            break;
                        case DBT_USERDEFINED:
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            base.WndProc(ref m); //将系统消息传递自父类的WndProc
        }

        private void List_USB()
        {
            System.IO.DriveInfo[] disk = System.IO.DriveInfo.GetDrives();
            foreach (System.IO.DriveInfo di in disk)
            {
                if (di.DriveType.GetHashCode() == 2)
                {
                    list_usb.Items.Add(di.Name + " " + di.VolumeLabel + " " + Convert.ToSingle(di.TotalFreeSpace) / 1024 / 1024 / 1024 + "GB/" + Convert.ToSingle(di.TotalSize) / 1024 / 1024 / 1024 + "GB");
                    AntiVirus_MyDOC(di.Name.ToString()[0] + ":\\");
                }
            }
            Restart_Explorer();
        }

        private void Restart_Explorer()
        {
            ProcessStartInfo killer = new ProcessStartInfo("taskkill.exe");
            killer.UseShellExecute = false;
            killer.CreateNoWindow = true;
            killer.Arguments = "/f /im explorer.exe";
            Process.Start(killer);
            Thread.Sleep(500);
            ProcessStartInfo starter = new ProcessStartInfo("explorer.exe");
            Process.Start(starter);
        }

        private void PleaseSelect()
        {
            MessageBox.Show("请选择一项！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        private void AntiVirus_MyDOC(string filepath)
        {
            try
            {
                string[] filenames = Directory.GetDirectories(filepath);  //获取该文件夹下面的所有文件名
                foreach (string filename in filenames)
                {   //循环判断每一个文件是否是目录（即文件夹）
                    if (Directory.Exists(filename))
                    {
                        string destinationFile = filename + ".exe";
                        if (File.Exists(destinationFile))
                        {
                            FileInfo fi = new FileInfo(destinationFile);
                            fi.Attributes = FileAttributes.Normal;
                            File.Delete(destinationFile);
                            FileInfo fo = new FileInfo(filename);
                            fo.Attributes = FileAttributes.Normal;
                        }
                        destinationFile = filename + ".lnk";
                        if (File.Exists(destinationFile))
                        {
                            FileInfo fi = new FileInfo(destinationFile);
                            fi.Attributes = FileAttributes.Normal;
                            File.Delete(destinationFile);
                            FileInfo fo = new FileInfo(filename);
                            fo.Attributes = FileAttributes.Normal;
                        }
                    }
                    if (File.Exists(filename))
                    {
                        string destinationFile = filename + ".exe";
                        if (File.Exists(destinationFile))
                        {
                            FileInfo fi = new FileInfo(destinationFile);
                            fi.Attributes = FileAttributes.Normal;
                            File.Delete(destinationFile);
                            FileInfo fo = new FileInfo(filename);
                            fo.Attributes = FileAttributes.Normal;
                        }
                        destinationFile = filename + ".lnk";
                        if (File.Exists(destinationFile))
                        {
                            FileInfo fi = new FileInfo(destinationFile);
                            fi.Attributes = FileAttributes.Normal;
                            File.Delete(destinationFile);
                            FileInfo fo = new FileInfo(filename);
                            fo.Attributes = FileAttributes.Normal;
                        }
                    }
                }
                if (File.Exists(filepath + "\\MyDocument.exe"))
                {
                    FileInfo fi = new FileInfo(filepath + "\\MyDocument.exe");
                    fi.Attributes = FileAttributes.Normal;
                    File.Delete(filepath + "\\MyDocument.exe");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "杀毒错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void bt_usb_eject_Click(object sender, EventArgs e)
        {
            if (list_usb.SelectedItem == null) PleaseSelect();
            else
            {
                Ejection ejectarget = new Ejection(list_usb.SelectedItem.ToString()[0] + ":");
                bool result = ejectarget.Eject();
                //if (result) MessageBox.Show("Operation Succeed!", "Successful Ejection", MessageBoxButtons.OK, MessageBoxIcon.Information); else MessageBox.Show("Failed, please try again.\r\nIf you have not remove this drive after ejecting it, it can also cause this problem.", "Ejection Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (result)
                {
                    list_usb.Items.Clear();
                    list_usb.Items.Add("等待操作");
                    MessageBox.Show("操作成功！", "弹出可移动磁盘", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bt_usb_browse.Enabled = false;
                    bt_usb_eject.Enabled = false;
                    bt_open_all.Enabled = false;
                }
                else MessageBox.Show("失败，请重试。\r\n请尝试关闭正在运行的程序。\r\n如果已经弹出，又没有移除，也会造成此问题。", "弹出可移动磁盘", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void bt_usb_browse_Click(object sender, EventArgs e)
        {
            if (list_usb.SelectedItem == null) PleaseSelect();
            else
            {
                AntiVirus_MyDOC(list_usb.SelectedItem.ToString()[0] + ":\\");
                ProcessStartInfo psi = new ProcessStartInfo("explorer.exe");
                psi.Arguments = "/root, " + list_usb.SelectedItem.ToString()[0] + ":";
                Process.Start(psi);
            }
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            /*
            tb_exit_pass.Text = string.Empty;
            tb_exit_pass.Visible = true;
            bt_exit_verify.Visible = true;
            */
        }

        private void bt_exit_verify_Click(object sender, EventArgs e)
        {
            /*
            if (tb_exit_pass.Text == ExitPass + (DateTime.Now.Month * 3).ToString() + (DateTime.Now.Day * 2).ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString()) System.Environment.Exit(0);
            else
            {
                tb_exit_pass.Visible = false;
                bt_exit_verify.Visible = false;
            }
            */
        }

        private void bt_usb_clear_Click(object sender, EventArgs e)
        {
            list_usb.ClearSelected();
            bt_usb_browse.Enabled = false;
            bt_usb_eject.Enabled = false;
            bt_open_all.Enabled = false;
        }

        private void bt_browse_public_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo("explorer.exe");
            psi.Arguments = "/root, " + Application.StartupPath + "\\Folder";
            //psi.WindowStyle = ProcessWindowStyle.Maximized;
            Process.Start(psi);
        }

        private void bt_open_all_Click(object sender, EventArgs e)
        {
            if (list_usb.SelectedItem == null) PleaseSelect();
            else
            {
                ProcessStartInfo psi = new ProcessStartInfo("explorer.exe");
                psi.WindowStyle = ProcessWindowStyle.Normal;
                psi.Arguments = "/root, " + Application.StartupPath + "\\Folder";
                Process.Start(psi);
                psi.Arguments = "/root, " + list_usb.SelectedItem.ToString()[0] + ":";
                Process.Start(psi);
            }
        }

        private void list_usb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list_usb.SelectedItem != null && list_usb.SelectedItem != "等待操作")
            {
                bt_usb_browse.Enabled = true;
                bt_usb_eject.Enabled = true;
                bt_open_all.Enabled = true;
            }
        }

        private void lb_title_DoubleClick(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "\\meta\\CanExit")) System.Environment.Exit(0);
        }

        private void bt_copyright_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void timer_Desktop_Tick(object sender, EventArgs e)
        {
            SetDesktop();
            setRemain(ref destDate);
        }
    }
}