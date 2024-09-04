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
using System.Xml.Serialization;

namespace WindowsFormsStudentsDiary
{
    public partial class Main : Form
    {
        private string _filePath = Path.Combine(Environment.CurrentDirectory, "students.txt");
        public Main()
        {
            InitializeComponent();

        }

        /*public void SerializeToFile(List<Student>students)
        {
            var serialized = new XmlSerializer(typeof(List<Student>));
            StreamWriter streamWriter = null;

            try
            {
                streamWriter = new StreamWriter(_filePath);
                serialized.Serialize(streamWriter, students);
                streamWriter.Close();
                streamWriter.Dispose();
            }
            finally
            {
                streamWriter.Dispose();
            }
        }*/

        public void SerializeToFile(List<Student> students)
        {
            var serialized = new XmlSerializer(typeof(List<Student>));

            //jeśli w using jest deklaracja obiektu to za każdym razem zostanie na końcu wykonana metoda dispose
            using (var streamWriter = new StreamWriter(_filePath))
            {
                serialized.Serialize(streamWriter, students);
                streamWriter.Close();
            }
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
