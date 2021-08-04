using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LINQPROJ.Models;

namespace LINQPROJ.Data
{
    public class LINQPROJContext : DbContext
    {
        public LINQPROJContext (DbContextOptions<LINQPROJContext> options)
            : base(options)
        {
        }

        public DbSet<LINQPROJ.Models.Empdetail> Empdetail { get; set; }
    }
}
