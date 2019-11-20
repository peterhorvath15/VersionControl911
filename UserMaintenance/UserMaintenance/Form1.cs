using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            lblFullName.Text = Resource1.FullName; // label1
            btnAdd.Text = Resource1.Add; // button1

            // listbox1
            listUsers.DataSource = users;
            listUsers.ValueMember = "ID";
            listUsers.DisplayMember = "FullName";

            var u = new User()
            {
                FullName = txtFullName.Text,
            };
            users.Add(u);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.FileName = "DefaultOutputName.txt";
            save.Filter = "Text File | *.txt";

            if (save.ShowDialog() == DialogResult.OK)

            {
                StreamWriter writer = new StreamWriter(save.OpenFile());
                for (int i = 0; i < listUsers.Items.Count; i++)
                {
                    writer.WriteLine(listUsers.Items[i].ToString());
                }
                writer.Dispose();
                writer.Close();
            }
        }
    }
}
