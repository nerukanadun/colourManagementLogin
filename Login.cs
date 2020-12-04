using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;


namespace colourManagement
{
  
    {
        //panel move mouse handler
        public const int WM_NCLBUTTONDOWN = 0xa1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hwnd, int msg, int wParm, int Ipram);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public Login()
        {
            InitializeComponent();
        }

       
        

        private void Login_Load(object sender, EventArgs e)
        {

        } 

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\C# projects\colourManagement\colourManagement\CMSdatabase.mdf;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("select * from dob.Table where Username = '" + txtUsername + "' and Password= '" + txtPassword.Text + "'", con);
                DataTable dt = new DataTable();
                con.ConnectionString = "connection_string";
                con.Open();
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    MainForm mf = new MainForm();
                    mf.Show();
                }
                else
                {
                    MessageBox.Show("Username or Password is incorrect");
                }
            }
           catch (Exception e01)
            {
                MessageBox.Show("ERROR!" + e01);
            } 
        }

        private void pnlMove_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlMove_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle ,WM_NCLBUTTONDOWN, HT_CAPTION,0);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit( );
        }
    }
}
