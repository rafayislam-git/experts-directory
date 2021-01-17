using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataProviderLayer.Entities 
{
    public class ExpertDbContext : DbContext
    {
        public ExpertDbContext(DbContextOptions<ExpertDbContext> options) : base(options)
        {

        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Heading> Headings { get; set; }
    }
    
    
}
