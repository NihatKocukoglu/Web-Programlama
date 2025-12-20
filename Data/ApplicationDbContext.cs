using FCenter.Models;
using FCenter.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FCenter.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Gym> Gyms { get; set; }
        public DbSet<Trainer> Trainers { get; set; } // Bunu ekledik
        // Diğer tabloları (Trainers, Appointments) buraya ekleyeceğiz.
    }
}