using AsisTIC.Models;
using AsisTIC.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace AsisTIC.Contexts
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ITHTicket>()
                .ToTable(tb => tb.HasTrigger("trgEnviarCorreoTicketUsuario"));
        }

        public DbSet<ITHTicket> ITHticket { get; set; }
        public DbSet<ITHTicketDto> ITHTicketDtos { get; set; }
    }
}
