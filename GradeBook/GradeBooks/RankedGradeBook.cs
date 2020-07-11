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
        throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
      }
      
      // First i'm going to order the students by the average grade 
      List<Student> orderedList = Students.OrderBy(x => x.AverageGrade).ToList();
      // Take the index position of the students.
      int listPosition = orderedList.FindIndex(x => x.AverageGrade == averageGrade);
      listPosition++;
      // Make the division to check the % position.
      double percentage = Convert.ToDouble(decimal.Divide(listPosition, studentsTotal));
      // Returning the required answers.
      if (percentage > .8) { return 'A'; }
      if (percentage > .6) { return 'B'; }
      if (percentage > .4) { return 'C'; }
      if (percentage > .2) { return 'D'; }
      return 'F';
    }

    public override void CalculateStatistics()
    {
      if (Students.Count < 5)
      {
        throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
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
        throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
      }
      else
      {
        base.CalculateStudentStatistics(name);
      }
    }
  }
}