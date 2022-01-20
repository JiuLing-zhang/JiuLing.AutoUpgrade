using System.Diagnostics;

namespace AutoUpgrade.Test
{
    public partial class FmMain : Form
    {
        public FmMain()
        {
            InitializeComponent();
        }

        private void FmMain_Load(object sender, EventArgs e)
        {
            LblVersion.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version?.ToString();
        }

        private void BtnCheckUpgrade_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AutoUpgrade.exe"));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"操作失败：{ex.Message}");
            }
        }
    }
}