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
using System.Configuration;
using System.Data.SqlClient;
using Configuration;
using System.Data;

namespace DotoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class window2 : Window
    {
        public List<string> Values = new List<string>();
        public List<string> Values2 = new List<string>();
        public List<string> OutputList;


        public window2()
        {
            
            InitializeComponent();

            // Add columns
            var gridView = new GridView();
            this.listView.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Hero",
                DisplayMemberBinding = new Binding("Hero")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Win / Loss",
                DisplayMemberBinding = new Binding("WL")
            });



        }



        public class MyItem
        {
            public string Hero { get; set; }

            public string WL { get; set; }


        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            var a = textBox1.Text;
            var b = textBox2.Text;
            Values.Add(a);
            Values.Add(b);



            //add items to listview
            this.listView.Items.Add(new MyItem { Hero = textBox1.Text, WL = textBox2.Text });

            string connectionString;
            SqlConnection connection;

            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Simo\source\repos\DotoApp\DotoApp\DotaBase.mdf;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "";

            string hero = textBox1.Text;
            string wl = textBox2.Text;

            sql = "Insert into DotoTable (Hero, WL) values('" + hero + "' , '" + wl +"' )";

            command = new SqlCommand(sql, connection);

            adapter.InsertCommand = new SqlCommand(sql, connection);
            adapter.InsertCommand.ExecuteNonQuery();

            command.Dispose();
            connection.Close();

        }

        private void GetData_Click(object sender, RoutedEventArgs e)
        {
            listView1.Items.Clear();
            string connectionString;
            SqlConnection connection;

            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Simo\source\repos\DotoApp\DotoApp\DotaBase.mdf;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            //
            //Data Source=(localdb)\ProjectsV13;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
            connection.Open();
            MessageBox.Show("Yhteys auki");

            

            

            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";

            sql = "Select id, Hero, WL from DotoTable";
            command = new SqlCommand(sql, connection);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + " - " + dataReader.GetValue(2) + "\n";
            }

            MessageBox.Show(Output);
            OutputList = Output.Split('\n').ToList();


            foreach (string str in OutputList)
            {
                listView1.Items.Add(str);
            }

            
            //this.listView.Items.Add(new MyItem { Hero = textBox1.Text, WL = textBox2.Text });


            dataReader.Close();
            command.Dispose();
            connection.Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
             string connectionString;
             SqlConnection connection;

             connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Simo\source\repos\DotoApp\DotoApp\DotaBase.mdf;Integrated Security=True";
             connection = new SqlConnection(connectionString);

             connection.Open();
             MessageBox.Show("Yhteys auki");

             SqlCommand command;
             SqlDataAdapter adapter = new SqlDataAdapter();
            string dID = DeleteBox.Text;
            
             String sql = "";
            //Select id, Hero, WL from DotoTable"
            sql = "Delete FROM DotoTable WHERE id=('"+ dID + "')";
            //"Insert into DotoTable (Hero, WL) values('" + hero + "' , '" + wl +"' )";
            command = new SqlCommand(sql, connection);

              adapter.InsertCommand = new SqlCommand(sql, connection);
              adapter.InsertCommand.ExecuteNonQuery();

              command.Dispose();
              connection.Close();
            /*            string connectionString;
            SqlConnection connection;

            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Simo\source\repos\DotoApp\DotoApp\DotaBase.mdf;Integrated Security=True";
            connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "";

            string hero = textBox1.Text;
            string wl = textBox2.Text;

            sql = "Insert into DotoTable (Hero, WL) values('" + hero + "' , '" + wl +"' )";

            command = new SqlCommand(sql, connection);

            adapter.InsertCommand = new SqlCommand(sql, connection);
            adapter.InsertCommand.ExecuteNonQuery();

            command.Dispose();
            connection.Close()*/

        }



        /* public window2(string Output)
         {
             InitializeComponent();
             string Output2 = Output;



             var gridView2 = new GridView();
             this.listView.View = gridView2;
             gridView2.Columns.Add(new GridViewColumn
             {
                 Header = "Hero",
                 DisplayMemberBinding = new Binding("Hero")
             });
             gridView2.Columns.Add(new GridViewColumn
             {
                 Header = "Win / Loss",
                 DisplayMemberBinding = new Binding("WL")
             });


         }*/

    }
    }

