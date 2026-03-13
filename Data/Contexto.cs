using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Sistema_de_Facturacion_Electronica.Modelos;
using Sistema_de_Facturacion_Electronica.ModelosAuditoria;

namespace Sistema_de_Facturacion_Electronica.Data
{
    public class Contexto : IdentityDbContext<Usuario>
    {
        public Contexto(DbContextOptions<Contexto> Option) : base(Option) { }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Impuesto> Impuestos { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<InfoTributaria> InfoTributaria { get; set; }
        public DbSet<AuditoriaPago> AuditoriaPagos { get; set; }
        public DbSet<AuditoriaFactura> AuditoriaFacturas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Factura>()
                .HasOne(m => m.Cliente)
                .WithMany(n => n.FacturaList)
                .HasForeignKey(p => p.IdCliente);

            modelBuilder.Entity<Factura>()
                .HasOne(m => m.Usuario)
                .WithMany(n => n.facturas)
                .HasForeignKey(p => p.IdUsuario);

            modelBuilder.Entity<Factura>()
                .Property(m => m.XmlFactura)
                .HasColumnType("xml");

            modelBuilder.Entity<Factura>(entity =>
            {
                  entity.HasKey(n => n.Id);
                  entity.Property(f => f.Id).UseIdentityColumn();
            });

            List<IdentityRole> Roles = new List<IdentityRole>()
            {
                new IdentityRole
                {
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "User",
                    NormalizedName = "USER"
                }
            };
            modelBuilder.Entity<IdentityRole>().HasData(Roles);
        }
    }
}
