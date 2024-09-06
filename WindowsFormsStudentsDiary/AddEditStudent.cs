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
    public partial class AddEditStudent : Form
    {
        private string _filePath = Path.Combine(Environment.CurrentDirectory, "students.txt");

        public AddEditStudent()
        {
            InitializeComponent();
        }

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

        public List<Student> DeserializeFromFile()
        {
            if (!File.Exists(_filePath))
                return new List<Student>();

            var serializer = new XmlSerializer(typeof(List<Student>));

            using (var streamReader = new StreamReader(_filePath))
            {
                var students = (List<Student>)serializer.Deserialize(streamReader);//rzutowanie na listę studentów
                streamReader.Close();
                return students;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var students = DeserializeFromFile();
            var studentWithHighestId = students.OrderByDescending(x => x.Id).FirstOrDefault();

            var studentId = studentWithHighestId == null ? 1 : studentWithHighestId.Id + 1;

            var student = new Student
            {
                Id = studentId,
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                Comments = rtbComments.Text,
                ForeignLang = tbForeignLang.Text,
                Math = tbMath.Text,
                Physics = tbPhisycs.Text,
                PolishLang = tbPolishLang.Text,
                Technology = tbTechnology.Text
            };

            students.Add(student);

            SerializeToFile(students);

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
