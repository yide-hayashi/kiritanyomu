using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
//code autotest 
using Codeer.Friendly;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.Friendly.Windows.NativeStandardControls;

using Ong.Friendly.FormsStandardControls;
using System.IO;

namespace kiritannyomi
{
    public partial class Form1 : Form
    {
        FormsButton playbtn, savebtn;
        WindowControl tb;
        bool close = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            TCPage1.Parent = null;
            //var browser = new ChromiumWebBrowser();
            kiritanimg.SizeMode = PictureBoxSizeMode.StretchImage;
            
            if (Process.GetProcessesByName("VOICEROID").Count() == 0)
            {
                startvoiceroid();
            }
            //利用"WindowsAppFriend"去控制對方視窗

            controlvoiceroid();

            //chrome data input 

            Thread inputdeta = new Thread(loopinputdate);
            inputdeta.Start();
            this.WindowState = FormWindowState.Minimized;
        }

        private void startvoiceroid()
        {
            ProcessStartInfo voiceroid = new ProcessStartInfo();
            voiceroid.FileName = @"D:\\安裝程式\\東北きりたん\\VOICEROID.exe";
            voiceroid.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;
            voiceroid.CreateNoWindow = true;
            voiceroid.UseShellExecute = false;
            Process.Start(voiceroid);
            Thread.Sleep(2000);
        }
        private void  controlvoiceroid()
        {
            //VOICEROIDの起動
            Process watch;
            watch = Process.GetProcessesByName("VOICEROID")[0];
            var w = new WindowsAppFriend(watch);
            var main = WindowControl.FromZTop(w);
            //テキストボックス
            tb = main.IdentifyFromZIndex(2, 0, 0, 1, 0, 1, 1);

            //再生ボタン
            playbtn = new FormsButton(main.IdentifyFromZIndex(2, 0, 0, 1, 0, 1, 0, 3));

            //保存ボタン
            savebtn = new FormsButton(main.IdentifyFromZIndex(2, 0, 0, 1, 0, 1, 0, 1));
            //main.GetFromWindowText(" 再生") 用spy++ 去看function 找出來
            //new FormsButton(指定某個東西 EXmain.GetFromWindowText(" 再生")).EmulateClick(); 點他(event)
            //或是main.IdentifyFromZIndex 一層一層往下找 跟psy++ 所標得 大小相同就是那個object
        }

        private void kiritanyomu_Click(object sender, EventArgs e)
        {
            try
            {
                if (Process.GetProcessesByName("VOICEROID").Count() == 0)
                {
                    startvoiceroid();
                    controlvoiceroid();
                }
                kiritanhe(context.Text);
            }
            catch(Exception ex){ }
        }
        /// <summary>
        /// 傳給kiritan 
        /// </summary>
        /// <param name="str">傳入文字</param>
        private void kiritanhe(string str)
        {
            tb["Text"](str);
            playbtn.EmulateClick();
            while (!savebtn.Enabled)
            { Thread.Sleep(200); }
        }
        private void loopinputdate()
        {
            while(true)
            {
                OSS();
                Thread.Sleep(3);
                if(close==true)
                {
                    break;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.notifyIcon1.Visible = true;
            if (WindowState == FormWindowState.Normal && !close)
            {
                e.Cancel = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            close = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            close = true;
            this.Dispose();
            this.Close();
        }

       
        private void OSS()
        {
            try
            {
                Stream stdin = Console.OpenStandardInput();
                int length = 0;
                byte[] bytes = new byte[4];
                byte[] temp = new byte[65536];


                stdin.Read(bytes, 0, 4);
                length = System.BitConverter.ToInt32(bytes, 0);

                string input = "";
                for (int i = 0; i < length; i++)
                {
                    temp[i] = (byte)stdin.ReadByte();
                    if (i == 65535)
                    {
                        Array.Resize(ref temp, i + 1);
                    }

                }
                input += Encoding.UTF8.GetString(temp);
                if (length > 0)
                {
                    input = input.Replace(@"{""message"":""", "");
                    input = input.Replace(@"""}", "");
                    //context.Text = input;
                    if (Process.GetProcessesByName("VOICEROID").Count() == 0)
                    {
                        startvoiceroid();
                        controlvoiceroid();
                    }
                    kiritanhe(input);
                    
                }
                stdin.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
    }
}
