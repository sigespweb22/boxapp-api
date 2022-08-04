using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoxBack.Domain.Models.DataTable
{
    public class DataTableServerSideResult<T> where T : class
    {
        public int Draw { get; set; }
        public int _iRecordsTotal { get; set; }
        public int _iRecordsDisplay { get; set; }
        public IList<T> Data { get; set; }
    }
}
