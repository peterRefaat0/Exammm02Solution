using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Exammm02
{
    public class TrueOrFalse : Question
    {
        public TrueOrFalse(string header, string body, int mark)
            : base(header, body, mark)
        {
            Answers = new Answer[]
            {
                new Answer(1, "True"),
                new Answer(2, "False")
            };
        }
         
        public override void Display()
        {
            Console.WriteLine($"{Header}\n{Body}\n1. True\n2. False");
        }
  


}
}
