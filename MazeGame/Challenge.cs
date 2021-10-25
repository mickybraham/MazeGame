using System;
using System.Collections.Generic;
using System.Text;

namespace MazeGame
{
    public class Challenge
    {
        string question;
        string answer;
        int x;
        int y;
        
        public Challenge(string question, string answer)
        {
            this.question = question;
            this.answer = answer;
        }
        public string GetQuestion()
        {
            return question;
        }
        public string GetAnswer()
        {
            return answer;
        }


    }
}
