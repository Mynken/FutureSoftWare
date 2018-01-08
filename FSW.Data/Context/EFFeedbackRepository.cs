using FSW.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSW.Data.Entities;

namespace FSW.Data.Context
{
    public class EFFeedbackRepository : IFeedbackRepository
    {
        public IEnumerable<Feedback> Feedbacks
        {
            get
            {
                using (var context = new FSWContext())
                {
                    return context.Feedbacks.Where(x => x.isCheked == false).ToList();
                }
            }
        }
        public IEnumerable<Feedback> FeedbacksAll
        {
            get
            {
                using (var context = new FSWContext())
                {
                    return context.Feedbacks.Where(x => x.isCheked == true).ToList();
                }
            }
        }
        public void DeleteFeedback(int Id)
        {
            using (var context = new FSWContext())
            {
                Feedback dbEntry = context.Feedbacks.Find(Id);
                if (dbEntry != null)
                {
                    context.Feedbacks.Remove(dbEntry);
                    context.SaveChanges();
                }
            }
        }
        public Feedback FindFeedback(int Id)
        {
            using (var context = new FSWContext())
            {
                var dbEntry = context.Feedbacks.Find(Id);
                return dbEntry;
            }
        }
        public void SaveFeedback(Feedback feedback)
        {
            using (var context = new FSWContext())
            {
                if (feedback.id == 0)
                    context.Feedbacks.Add(feedback);
                else
                {
                    Feedback dbEntry = context.Feedbacks.Find(feedback.id);
                    if (dbEntry != null)
                    {
                        dbEntry.Name = feedback.Name;
                        dbEntry.Email = feedback.Email;
                        dbEntry.Review = feedback.Review;
                        dbEntry.isCheked = feedback.isCheked;
                    }
                }
                context.SaveChanges();
            }
        }
        public bool Validation(Feedback feedback)
        {
            feedback.CreatedTime = DateTime.Now;
            using (var context = new FSWContext())
            {
                // .AsEnumerable() or  SqlFunctions.StringConvert(variable);
                var validation = context.Feedbacks
                .AsEnumerable()
                .Where(
                    v => v.Email == feedback.Email &&
                    v.CreatedTime.Date == feedback.CreatedTime.Date);
                if (validation.FirstOrDefault() == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
