using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exammm02
{
    public class MCQQuestion : Question
    {
        public MCQQuestion(string header, string body, int mark, Answer[] answers, int rightAnswerId)
            : base(header, body ?? string.Empty, mark)
        {
            Answers = answers;
            RightAnswerId = rightAnswerId;
        }

        public override void Display()
        {
            Console.WriteLine($"{Header}\n{Body}");
            for (int i = 0; i < Answers.Length; i++)
            {
                Console.WriteLine($"{Answers[i].Id}. {Answers[i].Text}");
            }
        }
    }
}
