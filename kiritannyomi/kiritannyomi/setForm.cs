using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
namespace kiritannyomi
{
    public partial class setForm : Form
    {
        Form1 f1;
        public setForm(Form1 f1)
        {
            this.f1 = f1;
            InitializeComponent();
            if(f1.GetListKey(f1.KeysToken, "dotNETCSharp", "VOICEROIDPath")!=null)
                path.Text = f1.GetListKey(f1.KeysToken, "dotNETCSharp", "VOICEROIDPath");
           
        }

        private void setForm_Load(object sender, EventArgs e)
        {

        }

        private void getpath_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "VOICEROID.exe|*.exe";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path.Text = ofd.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            key list=new key();
            f1.KeysToken.Remove(f1.KeysToken.Find(delegate (key keys) { return keys.platform == "dotNETCSharp"; }));
            list.platform = "dotNETCSharp";
            list.keydata.Add(new keydata { keyName= "VOICEROIDPath",Value=path.Text });
            f1.KeysToken.Add(list);
            f1.xmlSave(f1.KeysToken);
            this.Close();
        }

        private void cannel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


}
