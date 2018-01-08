using FSW.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSW.Data.Context
{
    public class FSWContext : DbContext
    {
        public DbSet<AskQuestion> AskQuestions { get; set; }
        public DbSet<OrderSite> OrderSites { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
    }
}