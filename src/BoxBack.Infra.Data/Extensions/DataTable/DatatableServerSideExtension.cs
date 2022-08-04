using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using BoxBack.Domain.Models.DataTable;
using BoxBack.Infra.Data.Extensions;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BoxBack.Infra.Data.Extensions.DataTable
{
    public static class DataTableServerSideExtension
    {
        public static DataTableServerSideResult<T> GetDatatableResult<T>(this IQueryable<T> query,
            DataTableServerSideRequest request) where T : class
        {
            var recordsTotal = query.Count();
            query = FilterQueryDataTable(query, request);
            var recordsFiltered =  query.Count();

            query = OrderDataTable(query, request);

            var dataTableServerSideResult = new DataTableServerSideResult<T>
            {
                Draw = request.Draw,
                _iRecordsDisplay = recordsFiltered,
                _iRecordsTotal = recordsTotal,
                Data = query.Skip(request.Start).Take(request.Length).ToList()
            };

            return dataTableServerSideResult;
        }

        public static async Task<DataTableServerSideResult<T>> GetDatatableResultAsync<T>(this IQueryable<T> query,
            DataTableServerSideRequest request) where T : class
        {
            var recordsTotal = await query.CountAsync();
            query = FilterQueryDataTable(query, request);
            var recordsFiltered = await query.CountAsync();
            query = OrderDataTable(query, request);

            var dataTableServerSideResult = new DataTableServerSideResult<T>
            {
                Draw = request.Draw,
                _iRecordsDisplay = recordsFiltered,
                _iRecordsTotal = recordsTotal,
                Data = await query.Skip(request.Start).Take(request.Length).ToListAsync()
            };

            return dataTableServerSideResult;
        }

        private static IQueryable<T> OrderDataTable<T>(IQueryable<T> query,
            DataTableServerSideRequest request)
        {
            if (request.Order.Any())
            {
                string ordering = string.Empty;
                string aux = string.Empty;
                foreach (var order in request.Order)
                {
                    var column = request.Columns[order.Column];

                    if (string.IsNullOrWhiteSpace(column.Name))
                        continue;

                    if (request.Order.Count() <= 1)
                    {
                        if (order.Dir == "desc")
                            ordering += $"{column.Name} DESC";
                        else
                            ordering += $"{column.Name} ASC";
                    }
                    else
                    {
                        if (request.Order.IndexOf(order) 
                            != (request.Order.Count() - 1))
                        {
                            aux = ",";
                        }

                        if (order.Dir == "desc")
                            ordering += $"{column.Name} DESC{aux}";
                        else
                            ordering += $"{column.Name} ASC{aux}";
                        aux = "";
                        
                    }
                }

                if (!string.IsNullOrEmpty(ordering))
                {
                    return query.OrderBy(ordering);
                }
            }

            return query;
        }

        private static IQueryable<T> FilterQueryDataTable<T>(IQueryable<T> query,
            DataTableServerSideRequest request)
        {
            if (request.Search.Regex || string.IsNullOrWhiteSpace(request.Search.Value))
            {
                return query;
            }

            var columnsSearchable = request.Columns.Where(c => c.Searchable && !string.IsNullOrEmpty(c.Name)).ToList();
            string search = string.Empty;
            string aux = string.Empty;
            foreach (var column in columnsSearchable)
            {
                if (StringHelpers.HasData(column.Name))
                {
                    query = query.Where(ExpressionUtils.BuildPredicate<T>(column.Name, "==", request.Search.Value));
                }
                else
                {
                    query = query.Where(ExpressionUtils.BuildPredicate<T>(column.Name, "Contains", request.Search.Value));
                }
            }

            return query;
        }
    }
}
