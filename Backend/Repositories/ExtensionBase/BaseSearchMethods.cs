using BackendApp.Backend.Models.ExtensionBase;
using BackendApp.Data;
using BackendApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Backend.Repositories.ExtensionBase
{
    /// <summary>
    /// класс содержащий методы с повторяющейся логикой в определенных классах
    /// </summary>
    public class BaseSearchMethods<T> where T: class, IHasDateRange
    {
        private readonly ApplicationDbContext _context;

        public BaseSearchMethods(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<T>> GetDataBySearchFilter(T FilterDto)
        {
            IQueryable<T> table = _context.Set<T>();

            if (
                (FilterDto.DateBeg != null
                    && FilterDto.DateBeg != default(DateTime))
                && (FilterDto.DateEnd != null
                    && FilterDto.DateEnd != default(DateTime))
            )
            {
                table = table
                    .Where(c =>
                        c.DateBeg >= FilterDto.DateBeg
                        && c.DateEnd <= FilterDto.DateEnd
                    );
            }
            else
            {
                if (FilterDto.DateBeg != null
                    && FilterDto.DateBeg != default(DateTime)
                )
                {
                    table = table
                        .Where(c =>
                            c.DateBeg == FilterDto.DateBeg
                        );
                }

                if (FilterDto.DateEnd != null
                    && FilterDto.DateEnd != default(DateTime)
                )
                {
                    table = table
                        .Where(c =>
                            c.DateEnd == FilterDto.DateEnd
                        );
                }
            }

            return table;
        }
    }
}
