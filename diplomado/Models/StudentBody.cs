using System;
using System.Collections.ObjectModel;

namespace diplomado.Models
{
    public class StudentBody: ViewModelBase
    {
        string school;
        ObservableCollection<Student> students = new ObservableCollection<Student>();


        public string School
        {
            get { return school; }
            set { SetProperty(ref school, value); }
        }

        public ObservableCollection<Student> Students
        {
            get { return students; }
            set { SetProperty(ref students, value); }
        }

        //methods to implement commands to move and remove students
        public void MoveStudentToTop(Student student)
        {
            Students.Move(Students.IndexOf(student), 0);
        }

        public void MoveStudentToBottom(Student student)
        {
            Students.Move(Students.IndexOf(student), Students.Count - 1);
        }

        public void RemoveStudent(Student student)
        {
            Students.Remove(student);
        }

    }
}
