using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exammm02
{
    public abstract class Exam
    {
        public int Time { get; set; }
        public int NumberOfQuestions { get; set; }
        public List<Question> Questions { get; set; }

        public Exam(int time, int numberOfQuestions)
        {
            Time = time;
            NumberOfQuestions = numberOfQuestions;
            Questions = new List<Question>();
        }

        public abstract void ShowExam();

        public void DisplayResults()
        {
            
            int totalMarks = 0;
            int obtainedMarks = 0;
            foreach (var question in Questions)
       
                {
                    Console.WriteLine($"{question.Header}:\n{question.Body}");
                    Console.WriteLine($"Your Answer => {question.Answers[question.UserAnswerId - 1].Text}");
                    Console.WriteLine($"Right Answer => {question.Answers[question.RightAnswerId - 1].Text}");
                    Console.WriteLine();


                    totalMarks += question.Mark;
                    if (question.UserAnswerId == question.RightAnswerId)
                    {
                        obtainedMarks += question.Mark;
                    }
                }

            double percentage = (double)obtainedMarks / totalMarks * 100;

            Console.WriteLine($"Your Grade is {obtainedMarks} from {totalMarks}");
           
            if (percentage >= 60)
            {
                Console.WriteLine("Congratulations! You passed the exam.");
            }
            else
            {
                Console.WriteLine("Sorry, you failed. Please try again.");
            }

      
            Console.WriteLine("Thank you for taking the exam.");
            
        }
    }

    // FinalExam 
    public class FinalExam : Exam
    {
        public FinalExam(int time, int numberOfQuestions)
            : base(time, numberOfQuestions)
        {
        }

        public override void ShowExam()
        {
            foreach (var question in Questions)
            {
                question.Display();
                Console.WriteLine();
            }
        }
    }

    // PracticalExam 
    public class PracticalExam : Exam
    {
        public PracticalExam(int time, int numberOfQuestions)
            : base(time, numberOfQuestions)
        {
        }

        public override void ShowExam()
        {
            foreach (var question in Questions)
            {
                question.Display();
                Console.WriteLine();
                Console.WriteLine($"Correct Answer: {question.RightAnswerId}");
            }
        }
    }
}
