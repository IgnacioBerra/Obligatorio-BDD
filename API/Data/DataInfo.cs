using Microsoft.EntityFrameworkCore;
using API.Clases;
using Microsoft.AspNetCore.Hosting.Server;

namespace API.Data
{
    public class DataInfo:DbContext
    {
        public DataInfo(DbContextOptions<DataInfo> options) : base(options)
        {

        }

        public DbSet<Funcionarios> funcionarios { get; set; }
        public DbSet<Agenda> agenda { get; set; }
        public DbSet<CarnetSalud> carnetSalud { get; set; }
        public DbSet<Logins> logins { get; set; }

        public DbSet<PeriodosActualizacion> periodosActualizacion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionarios>().ToTable("funcionarios").HasKey(f => new { f.CI });
            modelBuilder.Entity<Funcionarios>().HasOne(f => f.Log).WithMany().HasForeignKey(f => f.logId);
            modelBuilder.Entity<Logins>().HasKey(l => l.logId);
            modelBuilder.Entity<Agenda>().ToTable("agenda").HasKey(a => new { a.nro });
            modelBuilder.Entity<Agenda>().HasOne(a => a.FuncId).WithMany().HasForeignKey(a => a.CI);
            modelBuilder.Entity<Funcionarios>().HasKey(f => f.CI);
            modelBuilder.Entity<CarnetSalud>().ToTable("carnet_salud").HasKey(c => new { c.CI, c.fechaEmision }); ;
            modelBuilder.Entity<CarnetSalud>().HasOne(cs => cs.FuncCI).WithMany().HasForeignKey(cs => cs.CI);
            modelBuilder.Entity<Funcionarios>().HasKey(f => f.CI);
            modelBuilder.Entity<Logins>().ToTable("logins").HasKey(l => new { l.logId });
            modelBuilder.Entity<PeriodosActualizacion>().ToTable("periodos_actualizacion").HasKey(p => new { p.fechaInicio, p.fechaFin });
        }

    }
}
