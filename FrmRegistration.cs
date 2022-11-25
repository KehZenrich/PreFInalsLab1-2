using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;using System.Text.RegularExpressions;

namespace KEH
{
    public partial class FrmRegistration : Form
    {
        private string _FullName;
        private int _Age;
        private long _ContactNo;
        private long _StudentNo;

        public static string SetFileName;
        public FrmRegistration()
        {
            InitializeComponent();
        }
        public long StudentNumber(string studNum)
        {
            if (Regex.IsMatch(studNum, @"^[0-9]{1,20}$"))
            {
                _StudentNo = long.Parse(studNum);
            }
            else
            {
                throw new FormatException("User must only enter decimal character.");
            }

            return _StudentNo;
        }

        public long ContactNo(string Contact)
        {
            if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
            {
                _ContactNo = long.Parse(Contact);
            }
            else
            {
                throw new FormatException("User must only enter decimal character.");
            }

            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") && Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
            {
                _FullName = LastName + ", " + FirstName + ", " + MiddleInitial;
            }
            else
            {
                throw new FormatException("The user must enter a character.");
            }

            return _FullName;
        }

        public int Age(string age)
        {
            if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
            {
                _Age = Int32.Parse(age);
            }
            else
            {
                throw new FormatException("The user must enter decimal character.");
            }
            return _Age;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void FrmRegistration_Load(object sender, EventArgs e)
        { }
          

        private void cbPrograms_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

            {
                try
                {
                    StudentInformationClass.SetFullName = FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text);
                    StudentInformationClass.SetStudentNo = StudentNumber(txtStudentNo.Text);
                    StudentInformationClass.SetProgram = cbPrograms.Text;
                    StudentInformationClass.SetGender = cbGender.Text;
                    StudentInformationClass.SetContactNo = ContactNo(txtContactNo.Text);
                    StudentInformationClass.SetAge = Age(txtAge.Text);
                    StudentInformationClass.SetBirthDay = datePickerBirthday.Value.ToString("yyyy-MM-dd");

                }
                catch (FormatException x)
                {
                    MessageBox.Show(x.Message);
                }

                string getStudNo = txtStudentNo.Text;
                string getLastName = txtLastName.Text;
                string getFirstName = txtFirstName.Text;
                string getMiddleInitial = txtMiddleInitial.Text;
                string getAge = txtAge.Text;
                string getContactNo = txtContactNo.Text;
                string getPrograms = cbPrograms.Text;
                string getGender = cbGender.Text;
                string getBirthday = datePickerBirthday.Text;
                string SetFileName = txtStudentNo.Text + ".txt";

                string docpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docpath, SetFileName)))
                {
                    outputFile.WriteLine("Student No.: " + getStudNo);
                    outputFile.WriteLine("Full Name: " + getLastName + getFirstName + getMiddleInitial);
                    outputFile.WriteLine("Program: " + getPrograms);
                    outputFile.WriteLine("Gender: " + getGender);
                    outputFile.WriteLine("Age: " + getAge);
                    outputFile.WriteLine("Birthday: " + getBirthday);
                    outputFile.WriteLine("Contact No.: " + getContactNo);
                }
                this.Close();
            }
        }

        private void FrmRegistration_Load_1(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]{
                "BS Information Technology",
                "BS Computer Science",
                "BS Information Systems",
                "BS in Accountancy",
                "BS in Hospitality Management",
                "BS in Tourism Management"
            };
            for (int i = 0; i < 6; i++)
            {
                cbPrograms.Items.Add(ListOfProgram[i].ToString());
            }
            string[] GenderCb = new string[]{
                "Male",
                "Female",
                "Others"
            };
            for (int i = 0; i < 3; i++)
            {
                cbGender.Items.Add(GenderCb[i].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
    }
