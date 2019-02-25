using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name): base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            char retVal;
            int gradeInterval = 0;
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            gradeInterval = Students.Count / 5;
            List<double> grades = new List<double>();
            foreach( var student in Students)
            {
                grades.Add(student.AverageGrade);
            }
            grades.Sort();
            grades.Reverse();
            if(averageGrade >= grades[gradeInterval - 1])
            {
                retVal = 'A';
            }
            else if(averageGrade >= grades[gradeInterval*2-1] )
            {
                retVal = 'B';
            }
            else if(averageGrade >= grades[gradeInterval*3-1])
            {
                retVal = 'C';
            }
            else if(averageGrade >= grades[gradeInterval*4-1])
            {
                retVal = 'D';
            }
            else
            {
                retVal = 'F';
            }
            return retVal;
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a students's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a students's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
