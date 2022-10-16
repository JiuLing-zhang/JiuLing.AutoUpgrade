using System;
using System.Windows.Forms;

namespace JiuLing.AutoUpgrade
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
                LblMsg.Invoke(new Action(() =>
                {
                    LblMsg.Text = text;
                }));
            }
            else
            {
                LblMsg.Text = text;
            }
        }
    }
}
