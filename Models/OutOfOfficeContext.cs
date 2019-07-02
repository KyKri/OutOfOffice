using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OutOfOffice.Models
{
    public class OutOfOfficeContext : DbContext
    {
        public OutOfOfficeContext(DbContextOptions<OutOfOfficeContext> options) : base(options)
        {

        }

        public DbSet<OutOfOffice.Models.Request> Request { get; set; }
    }
}