using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CdastroEstudanteApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CdastroEstudanteApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        public DbSet<Estudante> Estudantes { get; set; }
    }
}