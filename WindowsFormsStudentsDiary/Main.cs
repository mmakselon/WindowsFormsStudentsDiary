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

            var students = DeserializeFromFile();
            dgvDiary.DataSource = students;

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
            var serializer = new XmlSerializer(typeof(List<Student>));

            //jeśli w using jest deklaracja obiektu to za każdym razem zostanie na końcu wykonana metoda dispose
            using (var streamWriter = new StreamWriter(_filePath))
            {
                serializer.Serialize(streamWriter, students);
                streamWriter.Close();
            }
        }
            
        public List<Student> DeserializeFromFile()
        {
            if (!File.Exists(_filePath))
                return new List<Student>();

            var serializer = new XmlSerializer(typeof(List<Student>));

            using (var streamReader = new StreamReader(_filePath))
            {
                //rzutowanie na listę studentów
                var students = (List<Student>)serializer.Deserialize(streamReader);
                streamReader.Close();
                return students;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addEditStudent = new AddEditStudent();
            addEditStudent.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            var students = DeserializeFromFile();
            dgvDiary.DataSource = students;

        }
    }
}
