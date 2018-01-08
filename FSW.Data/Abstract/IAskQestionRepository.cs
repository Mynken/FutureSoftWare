using FSW.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSW.Data.Abstract
{
    public interface IAskQestionRepository
    {
        IEnumerable<AskQuestion> AskQuestions { get; }
        IEnumerable<AskQuestion> AskQuestionsAll { get; }
        void SaveQuestion(AskQuestion askQuestion);
        AskQuestion FindQuestion(int Id);
    }
}
