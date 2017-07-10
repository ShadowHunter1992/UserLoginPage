using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data.Entity;
namespace UserLoginPage
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public  class  user
    {
        public   string login;
        public   string password;
    }
    public partial class MainWindow : Window
    {   
        SqlConnection conn = new SqlConnection();
        public MainWindow()
        {
         
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        public List<user> getUser()
        {;
            var users = new List<user>();
            conn.ConnectionString = @"Data Source=P201\FRGRFG;Initial Catalog=Acc;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            conn.Open();
            string cmd = String.Format("select * from dbo.usersList");
            SqlCommand cmnd = new SqlCommand(cmd, conn);
            cmnd.CommandType = System.Data.CommandType.Text;
            var dr = cmnd.ExecuteReader();
            while (dr.Read())
            {
                users.Add(new user()
                {
                    login = dr["Username"].ToString(),
                   password=dr["password"].ToString()
                });

            }
            return users;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
          

            
           foreach(var i in getUser())
            {
                if(i.login==username.Text&&i.password==password.Password)
                {
                   MessageBox.Show("tiydirmisen");
                }
            }
            conn.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
