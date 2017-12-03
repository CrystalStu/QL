using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Launcher
{
    class ProgramUpd
    {
        public static void Execute()
        {
            // time_status.Enabled = false;
            // time_status.Interval = 100;
            checkprogramver();
        }

        /// <summary>
        /// http下载文件
        /// </summary>
        /// <param name="url">下载文件地址</param>
        /// <param name="path">文件存放地址，包含文件名</param>
        /// <returns></returns>
        private static bool HttpDownload(string url, string path)
        {
            string tempPath = System.IO.Path.GetDirectoryName(path) + @"\temp";
            System.IO.Directory.CreateDirectory(tempPath);  //创建临时文件目录
            string tempFile = tempPath + @"\" + System.IO.Path.GetFileName(path) + ".temp"; //临时文件
            if (System.IO.File.Exists(tempFile))
            {
                System.IO.File.Delete(tempFile);    //存在则删除
            }
            try
            {
                FileStream fs = new FileStream(tempFile, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                // 设置参数
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //发送请求并获取相应回应数据
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                Stream responseStream = response.GetResponseStream();
                //创建本地文件写入流
                //Stream stream = new FileStream(tempFile, FileMode.Create);
                byte[] bArr = new byte[1024];
                int size = responseStream.Read(bArr, 0, (int)bArr.Length);
                while (size > 0)
                {
                    //stream.Write(bArr, 0, size);
                    fs.Write(bArr, 0, size);
                    size = responseStream.Read(bArr, 0, (int)bArr.Length);
                }
                //stream.Close();
                fs.Close();
                responseStream.Close();
                System.IO.File.Move(tempFile, path);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private static bool checkfile(string fileUrl)
        {
            HttpWebRequest re = null;
            HttpWebResponse res = null;
            try
            {
                re = (HttpWebRequest)WebRequest.Create(fileUrl);
                res = (HttpWebResponse)re.GetResponse();
                if (res.ContentLength != 0)
                {
                    //MessageBox.Show("文件存在");
                    return true;
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("无此文件");
                return false;
            }
            finally
            {
                if (re != null)
                {
                    re.Abort();//销毁关闭连接
                }
                if (res != null)
                {
                    res.Close();//销毁关闭响应
                }
            }
            return false;
        }

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(int Description, int ReservedValue);
        private static bool checknet()
        {
            int Description = 0;
            return InternetGetConnectedState(Description, 0);
        }

        private static string getText(string getmotd_url)
        {
            WebClient client = new WebClient();
            byte[] buffer = client.DownloadData(getmotd_url);
            return System.Text.ASCIIEncoding.ASCII.GetString(buffer);
        }

        private static void checkprogramver()
        {
            if (!checknet()) return;
            if (Application.ProductVersion != getText("http://get.cstu.gq/metadata/xinyuan/quicklauncher/ver.txt").Trim())
            {
                MessageBox.Show("This launcher is outdated, confirm to update it.", "Require to Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HttpDownload(getText("http://get.cstu.gq/metadata/xinyuan/quicklauncher/update.txt"), Application.StartupPath + "\\Launcher.temp");
                checkver_fileexist:
                if(File.Exists(Application.StartupPath+"\\temp"))
                {
                    Thread.Sleep(50);
                    goto checkver_fileexist;
                }
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = "/c @ECHO OFF&&TITLE Launcher Update Console&&meta\\update.bat";
                p.Start();//启动程序
                sortie();
            }
        }

        private static void sortie()
        {
            System.Environment.Exit(0);
        }
    }
}
