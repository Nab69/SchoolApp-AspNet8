﻿using DomainModel;
using Microsoft.EntityFrameworkCore;

namespace Dal
{
    public class SchoolContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }

        #region Constructors
        public SchoolContext()
            : base()
        {
        }

        public SchoolContext(DbContextOptions options)
            : base(options)
        {
        }
        #endregion
    }
}
