using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace BiBo
{
    public partial class Form1 : Form
    {
        //content
        private String LoginAsUserName;
        private String UserStatusText;

        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            makeResponsivOnce(this);

            //init content
            this.LoginAsUserName = "Philipp Dahse";
            this.UserStatusText = "Admin";

            //render view
            publishContent();
        }

        private void publishContent()
        {
            //login as label
            userName.Text += this.LoginAsUserName;

            //User Status Label
            userStat.Text += this.UserStatusText;

            DataTable ds = new DataTable("UserTable");
            ds.Columns.Add("checkbox",typeof(String));
            ds.Columns.Add("ID", typeof(int));
            ds.Columns.Add("Vorname", typeof(String));
            ds.Columns.Add("Nachname", typeof(String));
            ds.Columns.Add("geliehende Bücher", typeof(int));

            for (int i = 0; i < 100; i++)
            {
                ds.Rows.Add(
                    "",
                    random.Next(1000,9999),
                    new String[] { "Peter", "Klaus", "Alex", "Daniel", "Michael", "Carlos", "Jack", "Ricko", "Karjiv", "Laszlo" }.GetValue(random.Next(10)),
                    new String[] { "Dahse", "Münzberg", "Korepin", "Dambeck", "Müller", "Mainer", "Schultze", "Mustermann", "Karbaum", "Galu" }.GetValue(random.Next(10)),
                    random.Next(5)
                );
            }


            userTableDataSet.DataSource = ds;


        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //makeResponsiv((Form)sender);
        }

        private void makeResponsivOnce(Form window)
        {
            makeResponsiv(window);
        }

        private void makeResponsiv(Form window)
        {

            int deskHeight = Screen.PrimaryScreen.Bounds.Height;
          	int deskWidth = Screen.PrimaryScreen.Bounds.Width;

            window.Width = deskWidth;
            window.Height = deskHeight;

            //get current window size
            int windowHeight = window.Height;
            int windowWidth = window.Width;


            //resize main panel
            MainPanel.Width = windowWidth - 235;
            MainPanel.Height = windowHeight - 115;

            //resize add user panel
            UserAddPanel.Width = MainPanel.Width * 3 / 4 - 25;
            UserAddPanel.Height = MainPanel.Height / 3 - 25;

            //resize user statstic panel
            userStatistic.Location = new System.Drawing.Point(MainPanel.Width * 3 / 4 - 4, 13);
            userStatistic.Height = UserAddPanel.Height;
            userStatistic.Width = MainPanel.Width / 4 - 7;


            //resize user table panel
            UserTablePanel.Location = new System.Drawing.Point(13, MainPanel.Height / 3 - 5); 
            UserTablePanel.Width = MainPanel.Width * 3 / 4 - 25;
            UserTablePanel.Height = MainPanel.Height * 2 / 3 - 10;                  

            //resize user details panel
            userDetails.Location = new System.Drawing.Point(MainPanel.Width * 3 / 4 - 2, MainPanel.Height / 3 - 5);
            userDetails.Width = MainPanel.Width / 4 - 10;
            userDetails.Height = MainPanel.Height * 2 / 3 - 10;

            //resize user table 
            userTableDataSet.Width = UserTablePanel.Width - 15;
            userTableDataSet.Height = UserTablePanel.Height - 25;

           
            
        }
    }
}
 