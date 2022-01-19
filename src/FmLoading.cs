using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoUpgrade
{
    public partial class FmLoading : Form
    {
        public FmLoading()
        {
            InitializeComponent();
        }

        private void FmLoading_Load(object sender, EventArgs e)
        {
            LblMsg.Text = "";
        }

        public void ShowLoading()
        {
            this.Visible = true;
        }

        public void HideLoading()
        {
            this.Visible = false;
        }

        public void SetMessage(string text)
        {
            if (LblMsg.InvokeRequired)
            {
                LblMsg.Invoke(() =>
                {
                    LblMsg.Text = text;
                });
            }
            else
            {
                LblMsg.Text = text;
            }
        }
    }
}
