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

        public DbSet<ActualizacionFuncionario> actualizacion { get; set; }
        public DbSet<Agenda> agenda { get; set; }
        public DbSet<CarnetSalud> carnetSalud { get; set; }
        public DbSet<Logins> logins { get; set; }

        public DbSet<PeriodosActualizacion> periodosActualizacion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionarios>().ToTable("funcionarios").HasKey(f =>  f.CI );
            modelBuilder.Entity<Funcionarios>().HasOne(f => f.Logins).WithMany().HasForeignKey(l => l.LogId);
            modelBuilder.Entity<Logins>().ToTable("logins").HasKey(l => l.LogId);
            modelBuilder.Entity<PeriodosActualizacion>().ToTable("periodos_actualizacion").HasKey(p => new { p.Fch_Inicio, p.Fch_Fin });
            modelBuilder.Entity<ActualizacionFuncionario>().HasOne(a => a.Funcionarios).WithMany().HasForeignKey(a => a.FuncCI);
            modelBuilder.Entity<ActualizacionFuncionario>().HasKey(a => a.CI);
            modelBuilder.Entity<Agenda>().ToTable("agenda").HasKey(a =>  a.Nro );
            modelBuilder.Entity<Agenda>().HasOne(a => a.Funcionarios).WithMany().HasForeignKey(a => a.CI);
            modelBuilder.Entity<CarnetSalud>().ToTable("carnet_salud").HasKey(c => new { c.CI, c.Fch_Emision }); ;
            modelBuilder.Entity<CarnetSalud>().HasOne(cs => cs.Funcionarios).WithMany().HasForeignKey(cs => cs.FuncCI);
           
        }
    }
}
