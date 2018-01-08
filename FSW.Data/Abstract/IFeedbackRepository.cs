using FSW.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSW.Data.Abstract
{
    public interface IFeedbackRepository
    {
        IEnumerable<Feedback> Feedbacks { get; }
        IEnumerable<Feedback> FeedbacksAll { get; }
        void SaveFeedback(Feedback feedback);
        Feedback FindFeedback(int Id);
        void DeleteFeedback(int phoneId);
        bool Validation(Feedback feedback);
    }
}
