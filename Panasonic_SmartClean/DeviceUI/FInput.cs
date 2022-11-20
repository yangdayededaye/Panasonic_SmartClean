using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Panasonic_SmartClean.DeviceUI
{
    public partial class FInput : UIForm
    {
        public string Input
        {
            get { return txtKey.Text; }
        }

        public FInput(string FormTxt,string TitleTxt)
        {
            InitializeComponent();
            this.Text = FormTxt;
            lbTitle.Text = TitleTxt;
        }

        private void btn(object sender, EventArgs e)
        {
            UIButton btn = sender as UIButton;
            if (btn.Name.ToString().Contains("Del"))
            {
                txtKey.Text = "";
            }
            else if (btn.Name.ToString().Contains("Exit"))
            {
                Close();
            }
            else
            {
                txtKey.Text += btn.Name.Substring(3, 1);
            }

        }

    }
}
