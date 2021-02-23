/* 
 * STUDENT SUMMARY
 * Daniel Tibbotts
 * 23/02/2021
 * 
 */

using System;

namespace StudentSummary
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a one-dimensional array of size 6 to hold subject names and populate it with some test data.
            string[] subjects = new string[6] { "English", "Maths", "Science", "Music", "Art", "Social Studies" };

            // Create a two-dimensional array of float values to store the list of grades by subject (percentage grades out of 100). 
            // Assume that each student has three subjects and each subject has four assessments and therefore four grades.
            float[,] gradesBySubject = new float[3,4];

            // Populate the array with some test data.

            // Row 1 - English (Average = 73.5725 - B)
            gradesBySubject[0, 0] = 75.77F;
            gradesBySubject[0, 1] = 65.92F;
            gradesBySubject[0, 2] = 80.50F;
            gradesBySubject[0, 3] = 72.10F;

            // Row 2 - Maths (Average = 84.175 - A)
            gradesBySubject[1, 0] = 77.92F;
            gradesBySubject[1, 1] = 80.00F;
            gradesBySubject[1, 2] = 91.67F;
            gradesBySubject[1, 3] = 87.11F;

            // Row 3 - Science (Average = 40.74 - F)
            gradesBySubject[2, 0] = 15.17F;
            gradesBySubject[2, 1] = 31.28F;
            gradesBySubject[2, 2] = 55.01F;
            gradesBySubject[2, 3] = 61.50F;


            // Calculate the final average grade as both a percentage of and a letter for each subject, 
            // and display it as an end-of-year summary in the following format:
            //
            // <Subject code1>: grades (grade1%, grade2%, grade3%, grade4%) - average grade (grade% - average letter)

            Console.WriteLine("End-of-year transcript:");

            for (int subject = 0; subject < gradesBySubject.GetLength(0); subject++)
            {
                // Print Subject Name and Grade Label
                Console.Write($"{ subjects[subject] }: grades (");

                float gradeSum = 0;
                int totalAssessments = gradesBySubject.GetLength(1);

                // Loop through 
                for (int grade = 0; grade < totalAssessments ; grade++)
                {
                    Console.Write($"{ gradesBySubject[subject, grade].ToString("0.0") }%");

                    // Insert comma except on final iteration
                    if (grade != totalAssessments - 1)
                    {
                        Console.Write(", ");
                    }

                    // Add current grade to sumtotal
                    gradeSum += gradesBySubject[subject, grade];
                }

                // Calculate average grade
                float gradeAverage = gradeSum / totalAssessments;

                // Write Average Grade to Console
                Console.WriteLine($") - average grade ({ gradeAverage.ToString("0.00") }% - { CalculateGradeLetter(gradeAverage) })");
            }

            // Await for input to terminate.
            Console.WriteLine();
            Console.Write("Press any key to terminate program...");
            Console.ReadLine();
        }


        /// <summary>
        /// Calculate the grade letter based on the average assessment scores.
        /// 
        /// Average grade calculated as: 
        ///   'A' - 100 % -80 %
        ///   'B' - 70 % -80 %
        ///   'C' - 60 % -70 %
        ///   'D' - 50 % -60 %
        ///   'F' - < 50 %
        /// 
        /// </summary>
        /// <param name="average"></param>
        public static char CalculateGradeLetter(float average)
        {
            if (average >= 80)
            {
                return 'A';
            }
            else if (average >= 70)
            {
                return 'B';
            }
            else if (average >= 60)
            {
                return 'C';
            }
            else if (average >= 50)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }   
    }
}
