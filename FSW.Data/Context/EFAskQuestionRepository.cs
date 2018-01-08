using FSW.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSW.Data.Entities;

namespace FSW.Data.Context
{
    public class EFAskQuestionRepository : IAskQestionRepository
    {
        public IEnumerable<AskQuestion> AskQuestions
        {
            get
            {
                using (var context = new FSWContext())
                {
                    return context.AskQuestions.Where(x => x.isCheked == false).ToList();
                }
            }
        }
        public IEnumerable<AskQuestion> AskQuestionsAll
        {
            get
            {
                using (var context = new FSWContext())
                {
                    return context.AskQuestions.Where(x => x.isCheked == true).ToList();
                }
            }
        }
        public void SaveQuestion(AskQuestion askQuestion)
        {
            using (var context = new FSWContext())
            {
                if (askQuestion.id == 0)
                    context.AskQuestions.Add(askQuestion);
                else
                {
                    AskQuestion dbEntry = context.AskQuestions.Find(askQuestion.id);
                    if (dbEntry != null)
                    {
                        dbEntry.Name = askQuestion.Name;
                        dbEntry.Email = askQuestion.Email;
                        dbEntry.TextMessage = askQuestion.TextMessage;
                        dbEntry.isCheked = askQuestion.isCheked;
                    }
                }
                context.SaveChanges();
            }
        }
        public AskQuestion FindQuestion(int Id)
        {
            using (var context = new FSWContext())
            {
                var dbEntry = context.AskQuestions.Find(Id);
                return dbEntry;
            }
        }
    }
}
