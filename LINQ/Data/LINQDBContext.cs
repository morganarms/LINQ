using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LINQ.Models;

    public class LINQDBContext : DbContext
    {
        public LINQDBContext (DbContextOptions<LINQDBContext> options)
            : base(options)
        {
        }

        public DbSet<LINQ.Models.Employee> Employee { get; set; }
    }
