using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
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
    /// Interaction logic for sendCode.xaml
    /// </summary>
    public partial class sendCode : Window
    {
        string randomCode;
        public static string? to;
        public sendCode()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string from, pass, messageBody;
            Random rand = new Random();
            randomCode = (rand.Next(999999)).ToString();
            MailMessage Message = new MailMessage();
            to = (email.Text).ToString();
            from = "jaditi973@gmail.com";
            pass = "enftqbqomaynuuqo";
            messageBody = "your reset code is" + randomCode;
            Message.To.Add(to);
            Message.From = new MailAddress(from);
            Message.Body = messageBody;
            Message.Subject = "password reseting code";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtp.Send(Message);
                MessageBox.Show("code send successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (randomCode == (code.Text).ToString())
            {
                to = email.Text;
                resetpassword rp = new resetpassword();
                this.Hide();
                rp.Show();
            }
            else
            {
                MessageBox.Show("Wrong Code");
            }
        }
    }
}