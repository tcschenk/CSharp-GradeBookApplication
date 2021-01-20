using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            var averageGrades = Students.OrderByDescending(student => student.AverageGrade)
                                        .Select(student => student.AverageGrade).ToList();
            Console.WriteLine($"Average: {averageGrade}");
            foreach (var average in averageGrades)
            {
                Console.WriteLine($"Averages: {averageGrade}");
            }
            if (averageGrades.Take((averageGrades.Count / 5)).Contains(averageGrade))
            {
                return 'A';
            }
            if (averageGrades.Take((2 * averageGrades.Count / 5)).Contains(averageGrade))
            {
                return 'B';
            }
            if (averageGrades.Take((3 * averageGrades.Count / 5)).Contains(averageGrade))
            {
                return 'C';
            }
            if (averageGrades.Take((4 * averageGrades.Count / 5)).Contains(averageGrade))
            {
                return 'D';
            }

            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
