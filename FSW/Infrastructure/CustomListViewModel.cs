using FSW.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FSW.Infrastructure
{
    public class CustomListViewModel<T> where T: class    {
        public IEnumerable<T> Items { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}