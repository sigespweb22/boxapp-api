using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoxBack.Application.ViewModels
{
    public class DataTableServerSideResultViewModel<T> where T : class
    {
        public int Draw { get; set; }
        public int RecordsFiltered { get; set; }
        public int RecordsTotal { get; set; }
        public bool Success { get; set; }
        public IList<T> Data { get; set; }
    }
}