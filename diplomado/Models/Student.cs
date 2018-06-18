using System;
using System.Windows.Input;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace diplomado.Models
{
    public class Student: ViewModelBase
    {
        string fullName, firstName, middleName;
        string lastName, sex, photoFilename;
        double gradePointAverage;
        string notes;

        public Student()
        {
            ResetGpaCommand = new Command(() => GradePointAverage = 2.5);
            MoveToTopCommand = new Command(() => StudentBody.MoveStudentToTop(this));
            MoveToBottomCommand = new Command(() => StudentBody.MoveStudentToBottom(this));
            RemoveCommand = new Command(() => StudentBody.RemoveStudent(this));
        }

        public string FullName
        {
            get { return fullName; }
            set { SetProperty(ref fullName, value); }
        }

        public string FirsName
        {
            get { return firstName; }
            set { SetProperty(ref firstName, value); }
        }

        public string MiddleName
        {
            get { return middleName; }
            set { SetProperty(ref middleName, value); }
        }

        public string LastName
        {
            get { return lastName; }
            set { SetProperty(ref lastName, value); }
        }

        public string Sex
        {
            get { return sex; }
            set { SetProperty(ref sex, value); }
        }

        public string PhotoFilename
        {
            get { return photoFilename; }
            set { SetProperty(ref photoFilename, value); }
        }

        public double GradePointAverage
        {
            get { return gradePointAverage; }
            set { SetProperty(ref gradePointAverage, value); }
        }

        //For program in Chapter 25
        public string Notes
        {
            get { return notes; }
            set { SetProperty(ref notes, value); }
        }

        //Properties foir implementing commands
        [XmlIgnore]
        public ICommand ResetGpaCommand { get; private set; }

        [XmlIgnore]
        public ICommand MoveToTopCommand{ get; private set;}

        [XmlIgnore]
        public ICommand MoveToBottomCommand { get; private set; }

        [XmlIgnore]
        public ICommand RemoveCommand { get; private set; }

        [XmlIgnore]
        public StudentBody StudentBody { get; set; }


    }
}
