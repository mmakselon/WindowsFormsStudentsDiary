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

namespace WindowsFormsStudentsDiary
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            var path = $@"{Path.GetDirectoryName(Application.ExecutablePath)}\..\NowyPlik2.txt";

            if (!File.Exists(path))
            {
             File.Create(path);
            }
            //File.WriteAllText(path, "Zostań programistą .NET\n");
            File.AppendAllText(path, "Zostań programistą .NET\n");

            var text = File.ReadAllText(path);
            MessageBox.Show(text);
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }
    }
}
