using System;
class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new("Samuel Bennet", "Multiplication");
        assignment.GetSummary();
        
        MathAssignment mathAssignment = new("Roberto Rodriguez", "Fractions", "Section 7.3", "Problems 8-19");

        mathAssignment.GetSummary();
        mathAssignment.GetHomeworkList();


        WritingAssignment writingAssignment = new("Mary Waters", "European History", "The Causes of WWII");

        writingAssignment.GetSummary();
        writingAssignment.GetWritingInformation();

    }
}