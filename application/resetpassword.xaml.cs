using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace application
{
    
    /// <summary>
    /// Interaction logic for resetpassword.xaml
    /// </summary>
    public partial class resetpassword : Window
    {
        string username;

        public resetpassword()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (reset.Text == vreset.Text)
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-2CEKQRL\\SQL2022;Initial Catalog=LoginDB;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[tbluser] SET [Password] = '" + vreset.Text + "' WHERE UserName='" + username+ "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Reset Successfully");

            }
            else
            {
                MessageBox.Show("the password couldnot match");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mn = new MainWindow();
            this.Hide();
            mn.Show();
        }
    }
}