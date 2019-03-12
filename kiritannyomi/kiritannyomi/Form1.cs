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
using CefSharp.WinForms;
using CefSharp;
using CoreTweet;
using static CoreTweet.OAuth;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Runtime.InteropServices;

namespace kiritannyomi
{
    
    public partial class Form1 : Form
    {
        
        OAuthSession os;
        FormsButton playbtn, savebtn;
        WindowControl tb;
        /// <summary>
        /// きりたん是否在run
        /// きりたん起動してる?
        /// </summary>
        bool runing = false;
        /// <summary>
        /// ThreadTimelineReadAudio String
        /// </summary>
        List<string> TTRAstr = new List<string>();
        /// <summary>
        /// Consumer API keys
        /// </summary>
        string API;
        /// <summary>
        ///  Consumer secret
        /// </summary>
        string secretkey;

        /// <summary>
        /// //Access token & access token secret
        /// </summary>
        public List<key> KeysToken = new List<key>();
        /// <summary>
        /// this Run or close
        /// </summary>
        bool close = false;
        public Form1()
        {
            InitializeComponent();

           
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                UC.f = this;
                UC.start("https://twitter.com/");
                if (!File.Exists(Application.StartupPath + "\\context.xml"))
                {
                    setForm sf = new setForm(this);
                    sf.ShowDialog();
                }
                else
                {
                    xmlload(Application.StartupPath + "\\context.xml");
                }

                Thread runkiritan = new Thread(Runkiritan);
                runkiritan.Start();
                TCPage1.Parent = null;
                kiritanimg.SizeMode = PictureBoxSizeMode.StretchImage;
                //twitterData();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }


        /****************************************Form Event****************************************************************/
        #region Form Event
        private void UC_SizeChanged(object sender, EventArgs e)
        {
            if (UC.geturl() != "" && UC.gethtmlsource()!="")
                UC.callJS();
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
        private void UC_Load(object sender, EventArgs e)
        {

        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {

            setForm setf = new setForm(this);
            setf.ShowDialog();
        }

        private void Runkiritan()
        {
            if (Process.GetProcessesByName("VOICEROID").Count() == 0)
            {
                startvoiceroid();
            }
            Thread getctrl = new Thread(controlvoiceroid);
            //利用"WindowsAppFriend"去控制對方視窗 WindowsAppFriendで外部ウィンドウを操作する
            getctrl.Start();
            //chrome data input 
            Thread inputdeta = new Thread(loopinputdate);
            inputdeta.Start();
        }
        #endregion
        /***************************************きりたんへ********************************************************************/
        #region user32を導入する
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool BringWindowToTop(IntPtr hWnd);
        /* https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-showwindow */
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        #endregion

        #region きりたんへ
        public static extern IntPtr FindWindow(String lpClassName, String lpWindowName);
        /// <summary>
        /// 起動きりたん(exe)
        /// </summary>
        private void startvoiceroid()
        {
            ProcessStartInfo voiceroid = new ProcessStartInfo();
            voiceroid.FileName = GetListKey(KeysToken, "dotNETCSharp", "VOICEROIDPath");
            voiceroid.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;
            voiceroid.CreateNoWindow = true;
            voiceroid.UseShellExecute = false;
            Process.Start(voiceroid);
            Thread.Sleep(2000);
        }
        /// <summary>
        /// 起動きりたん(Process) I/O取得
        /// </summary>
        private void controlvoiceroid()
        {
            //VOICEROID起動
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


            ShowWindow(FindWindow(main.IdentifyFromZIndex(0).WindowClassName, null), 2);
        }
        /// <summary>
        /// 傳給きりたん
        /// きりたんに出力
        /// </summary>
        /// <param name="str">傳入文字</param>
        private void kiritanhe(string str)
        {
            tb["Text"](str);
            playbtn.EmulateClick();
            while (!savebtn.Enabled)
            { Thread.Sleep(200); }
        }
        /// <summary>
        /// 控制きりたん
        /// きりたん操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            catch (Exception ex) { }
        }
        public void putoutkiritan(string s)
        {
            Thread th;
            TTRAstr.Add(Gethtmlstr(s));
            if (!runing )
            {
                th = new Thread(ThreadTimelineReadAudio);
                th.Start();
            }
                
            
        }
        private void ThreadTimelineReadAudio()
        {
            runing = true;
            while(TTRAstr.Count>0)
            {
                kiritanhe(TTRAstr[0]);
                TTRAstr.RemoveAt(0);
            }
            
            runing = false;
        }

        #endregion
        /***************************************chrome プラグイン**************************************************************/
        #region chrome プラグイン
        /// <summary>
        /// 等待接收data(從I/O)
        /// データを待って(I/Oから)
        /// </summary>
        private void loopinputdate()
        {
            while (true)
            {
                OSS();
                Thread.Sleep(3);
                if (close == true)
                {
                    break;
                }
            }
        }
        /// <summary>
        /// 讀入data(I/O)
        /// データをよむ(I/O)
        /// </summary>
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
        #endregion
        /***************************************twitter API********************************************************************/
        #region twitterAPI 使わない
        private void twitterData()
        {

            //Consumer API keys
            secretkey = "1OJmfQ2mMrnUpxQ5fS1QLXaWWAn1cnrCZx92MGaHmwVwFHhqPF";
            API = "xHBnAs1VGUS719yrBmD14SYa4";

            /*
            //Access token & access token secret
            KeysToken.keydata[1].Value = "601900069-LwMBnujIvrcku3yosdLbpKnnGiuMpWZV747kCsD2";
            KeysToken.keydata[0].Value = "Fx3XojaxVoEYaBJscFRHfE6D4eStYQvGYPrV1UUolIrWP";
            */
            if (File.Exists(Application.StartupPath + "\\context.xml"))
            {
                UC.browser.Load("https://twitter.com/");
                xmlload(Application.StartupPath + "\\context.xml");

                Thread timelist = new Thread(GetTtitterHomeline);
                timelist.Start();
            }
            else
            {
                //Oath
                os = OAuth.Authorize(API, secretkey);
                //"https://twitter.com/"
                UC.browser.Load(os.AuthorizeUri.AbsoluteUri);

                Thread t1 = new Thread(waitdata);
                t1.Start();
            }
            
        }

        private void waitdata()
        {

            string finishurl = @"https://api.twitter.com/oauth/authorize";
            while (true)
            {
                if (UC.geturl() == finishurl)
                {
                    if (twitterAuthenticateHtml(UC.gethtmlsource()))
                    {
                        break;
                    }
                }
                Thread.Sleep(100);

            }
        }
        private void opentwitterurl()
        {
            UC.browser.Load("https://twitter.com/");
        }
        private bool twitterAuthenticateHtml(string html)
        {
            string pin = "";
            Regex reg = new Regex(@"<code>[0-9]*</");
            MatchCollection mc = reg.Matches(html);

            foreach (Match x in mc)
            {
                pin = x.Groups[0].Value;
            }
            if (pin != "")
            {
                pin = pin.Substring(6, 7);
                if (os != null)
                {

                    TwitterHomeTimelineAsync(pin);
                }
                else
                {
                    MessageBox.Show("認証に失敗しました");
                }
                return true;
            }
            else
                return false;
        }
        private async void TwitterHomeTimelineAsync(string pin)
        {

            /*
             * OAuthによるトークン発行
             */
            Tokens tokens = os.GetTokens(pin);

            /*
             * save Token data
             * 
             */


            key keys = new key();
            keys.platform = "twitter";
            keys.keydata.Add(new keydata { keyName = "AccessSecret", Value = tokens.AccessTokenSecret });
            keys.keydata.Add(new keydata { keyName = "AccessToken", Value = tokens.AccessToken });

            KeysToken.Add(keys);
            /*
             * xml處理
             */
            xmlSave(KeysToken);

            Thread timelist = new Thread(GetTtitterHomeline);
            timelist.Start();
            opentwitterurl();

            //すでに発行されたトークンを利用
            //Tokens tokens = Tokens.Create(API, secretkey, AccessToken, AccessSecret);
        }
        private void GetTtitterHomeline()
        {
            string temp = "";
            string nowName = "";
            bool firstloop = true;
            DateTime dateTime = new DateTime();
            while (true)
            {
                
                Tokens tokens = Tokens.Create(API, secretkey, GetListKey(KeysToken, "AccessToken","twitter"), GetListKey(KeysToken, "AccessSecret", "twitter"));
                var tl2 = tokens.Statuses.HomeTimeline(count => 1, include_rts => true, include_entities=>true, tweet_mode => "extended");
                foreach (var item in tl2)
                {
                    if (firstloop || (dateTime != item.CreatedAt.LocalDateTime || nowName != item.User.Name))
                    {
                        Regex testreg = new Regex(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
                        MatchCollection regsee = testreg.Matches(item.FullText);
                        string waitText = item.FullText;
                        foreach (Match x in regsee)
                        {

                            waitText = waitText.Remove(waitText.IndexOf(x.Groups[0].Value, x.Groups[0].Length));
                        }
                        temp = item.User.Name + "さんから\r\n" + waitText + "\r\n";
                        dateTime = item.CreatedAt.LocalDateTime;
                        nowName = item.User.Name;
                        firstloop = false;

                        /*
                         * runThread 東北きりたんに読ませる
                         */
                        try
                        {
                            if (Process.GetProcessesByName("VOICEROID").Count() == 0)
                            {
                                startvoiceroid();
                                controlvoiceroid();
                            }
                            kiritanhe(temp);
                        }
                        catch (Exception ex) { }
                    }

                }


                Thread.Sleep(5000);
                if (close)
                    break;
            }

        }
        /// <summary>
        /// Get key value
        /// 値を取得する
        /// 取得key值
        /// </summary>
        /// <param name="list"></param>
        /// <param name="keyName"></param>
        /// <param name="platformName"></param>
        /// <returns>keyValue keyの値　key的值</returns>
        public string GetListKey(List<key> list, string platformName, string keyName)
        {
            if(list.Find(
                delegate (key keys)
                {
                    return keys.platform == platformName;
                }
            ) !=null)
            {
                    if(list.Find(
                    delegate (key keys)
                    {
                        return keys.platform == platformName;
                    }
                ).keydata.Find(
                    delegate (keydata kd)
                    {
                        return kd.keyName == keyName;
                    }
                )!=null)
                    {
                            return list.Find(
                        delegate (key keys)
                        {
                            return keys.platform == platformName;
                        }
                    ).keydata.Find(
                        delegate (keydata kd)
                        {
                            return kd.keyName == keyName;
                        }
                    ).Value;
                    }
                else
                    return null;
            }
            else
                return null;
            

        }
        #endregion
        /******************************************xml処理*********************************************************************/
        #region ml処理
        public void xmlSave(List<key> list)
        {
            if (File.Exists(Application.StartupPath + "\\context.xml"))
            {
                File.Delete(Application.StartupPath + "\\context.xml");
            }
            XDocument xml = new XDocument();
            XElement xe;
            xml.Declaration = new XDeclaration("1.0", "utf-8", null);
            foreach (var i in list)
            {
                xe = new XElement(i.platform);
                foreach (var x in i.keydata)
                {
                    xe.Add(new XElement(x.keyName, new XText(x.Value)));
                }
            
                xml.Add(new XElement("keys", xe));
            }
            xml.Save(Application.StartupPath + "\\context.xml");
        }

        public void xmlload(string path)
        {
            XDocument xd = XDocument.Load(path);
            key key = new key();
            foreach(var x in xd.Element("keys").Elements())
            {
                key.platform = x.Name.LocalName;
                foreach(var i in x.Elements())
                {
                    key.keydata.Add(new keydata { keyName = i.Name.LocalName, Value = i.Value });
                }
                KeysToken.Add(key);
            }
            
        }

        #endregion
        /******************************************Text処理*********************************************************************/

        #region Text処理
        private string enmojiRemove(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if ((s[i] >= 0x2194 && s[i] <= 0x3299) ||( s[i] >= 0x1F004 && s[i] <= 0x1FFFD))
                {
                    s=s.Remove(i, 1);
                }
            }
            return s;
        }

        public string Gethtmlstr(string s)
        {
            //s=enmojiRemove(s);
            Regex reg = new Regex(@"[0-9]*件の返信|[0-9|,]*件のリツイート|[0-9|,]* いいね\n|いいね [0-9|,]*|リツイート [0-9|,]*|@[\w]*|返信 [0-9|,]*|ダイレクトメッセージ( )?([0-9|,]*)+\n");
            Regex RegRepateTimeWord = new Regex(@"[0-9]*(秒|分|時間)");
            Regex RegRemveNewLine = new Regex(@"[\S]+(\S*| {1,2}| {1,3})+[\S]");
            MatchCollection mc = reg.Matches(s);
            string temp = "";
            bool retweet = false;
            int i = 0;
            foreach (Match x in mc)
            {
                s =s.Replace(x.Groups[0].Value,"");
            }
            mc = RegRepateTimeWord.Matches(s);
            for ( i=0; i< mc.Count;i=i+2)
            {
                s = s.Remove(s.IndexOf(mc[i].Value), mc[i].Value.Length);
            }

            s = s.Replace("その他\n", "").Replace("認証済みアカウント","").Replace("その他 ", "");
            mc = RegRemveNewLine.Matches(s);
            
            for(i=0;i<mc.Count;i++)
            {
                if(mc[i].Value.IndexOf("がリツイート")>0 )
                {
                    retweet = true;
                }
                if(mc[i].Value!= "")
                {
                    if(!retweet && i==0  && mc[i].Value.IndexOf("新しい会話") == -1)
                    {
                        temp += mc[i].Value + "さんから\r\n";
                    }
                    else if (i == 1 && retweet)
                    {
                        temp += mc[i].Value + "さん言った\r\n";
                    }
                    else
                    {
                        temp += mc[i].Value + "\r\n";
                    }
                }
            }
            s = temp;
            return s;
        }

        #endregion
    }


    /***********************************************************************************************/
    public class keydata
    {
        public string keyName { set; get; }
        public string Value { set; get; }
    }
    public class key
    {
        public string platform { set; get; }
        public List<keydata> keydata = new List<keydata>();


    }
    public class SaveData
    {
        
    }
}
