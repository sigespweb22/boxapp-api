using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoxBack.WebApi.Helpers.DataTable
{
    public class DataTableServerSideRequest
    {
        public int Draw { get; set; }
        public IList<DataTableServerSideRequestColumn> Columns { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public IList<DataTableServerSideRequestOrder> Order { get; set; }
        public DataTableServerSideRequestSearch Search { get; set; }
    }

    public class DataTableServerSideRequestOrder
    {
        public int Column { get; set; }
        public string Dir { get; set; }
    }

    public class DataTableServerSideRequestSearch
    {
        public string Value { get; set; }
        public bool Regex { get; set; }
    }

    public class DataTableServerSideRequestColumn : DataTableServerSideRequestSearch
    {
        public string Name { get; set; }
        public bool Searchable { get; set; }
        public bool Orderable { get; set; }
    }
}
