using System.Diagnostics;

namespace Exammm02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the type of exam (1 for Practical or 2 for Final): ");
            int examType = int.Parse(Console.ReadLine() ?? "0" );

            Console.WriteLine("Please enter the time for exam (30 min to 180 min): ");
            int examTime = int.Parse(Console.ReadLine() ?? "0" );

            Console.WriteLine("Please enter the number of questions: ");
            int numberOfQuestions = int.Parse(Console.ReadLine() ?? "0");

            Exam exam;
            if (examType == 1)
            {
                exam = new PracticalExam(examTime, numberOfQuestions);
            }
            else
            {
                exam = new FinalExam(examTime, numberOfQuestions);
            }

            for (int i = 0; i < numberOfQuestions; i++)
            {
                Console.WriteLine("Please enter the type of question ( -1 for MCQ or -2 for True/False): ");
                int questionType = int.Parse(Console.ReadLine() ?? "0");

                string questionHeader = $"Question {i + 1} ({(questionType == 1 ? "MCQ" : "True/False")})";
                Console.WriteLine($"{questionHeader}"); 

                Console.WriteLine("Please enter Question Body: ");
                string? questionBody = Console.ReadLine();

                Console.WriteLine("Please enter Question Mark: ");
                int questionMark = int.Parse(Console.ReadLine() ?? "0");

                if (string.IsNullOrWhiteSpace(questionBody))
                {
                    Console.WriteLine("Question Body cannot be empty. Please enter a valid value.");
                    questionBody = "Default Question Body";
                }

                if (questionType == 1)
                {
                    Answer[] answers = new Answer[3];
                    for (int j = 0; j < 3; j++)
                    {
                        Console.WriteLine($"Please enter choice number {j + 1}: ");

                        string? choiceText = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(choiceText))
                        {
                            choiceText = "Default Choice";
                        }

                        answers[j] = new Answer(j + 1, choiceText) ;
                    }

                    Console.WriteLine("Please enter the right Answer Id: ");
                    int rightAnswerId = int.Parse(Console.ReadLine() ?? "0");

                    MCQQuestion mcq = new MCQQuestion(questionHeader, questionBody , questionMark, answers, rightAnswerId);
                    exam.Questions.Add(mcq);
                }
                else
                {
                    TrueOrFalse true_False = new TrueOrFalse(questionHeader, questionBody, questionMark);
                    Console.WriteLine("Please enter the right Answer Id (1 for True, 2 for False): ");
                    true_False.RightAnswerId = int.Parse(Console.ReadLine() ?? "0");
                    exam.Questions.Add(true_False);
                }
            }

            Subject subject = new Subject(1, "Sample Subject");
            subject.CreateExam(exam);

            Console.WriteLine("Do you want to start the exam? (y/N): ");
            string? startExam = Console.ReadLine();

            if (startExam?.ToLower() == "y")
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                foreach (var question in exam.Questions)
                {
                    question.Display();
                    Console.WriteLine("Please enter your answer: ");
                    question.UserAnswerId = int.Parse(Console.ReadLine() ?? "0");
                }

                stopwatch.Stop();

                exam.DisplayResults();
                Console.WriteLine($"Time: {stopwatch.Elapsed}");

            }
        }
    }
}
