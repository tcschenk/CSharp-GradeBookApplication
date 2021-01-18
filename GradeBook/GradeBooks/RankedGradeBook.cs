using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
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
    }
}
