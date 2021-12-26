using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using postgre1.Models;

namespace PostGreTestN
{
    class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options) { }

        public virtual DbSet<Patient> patients { get; set; }
    }

}
