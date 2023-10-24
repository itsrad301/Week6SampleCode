using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols;
using ProductModel;

namespace Week6SampleCode
{
    public class BusinessContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SupplierProduct> SupplierProducts { get; set; }

        public BusinessContext()
        {
        }

        public BusinessContext(DbContextOptions<BusinessContext> options) : base (options)
        {
        }
        

        // Necessary if you are going to use migrations
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Hard code or use the configuration manager
            //var myconnectionstring = ConfigurationManager.ConnectionStrings["Rad301Week2Lab2023Connection"].ConnectionString;

            var myconnectionstring = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Week6SampleDB-PPOWELL";
            optionsBuilder.UseSqlServer(myconnectionstring)
              .LogTo(Console.WriteLine,
                     new[] { DbLoggerCategory.Database.Command.Name },
                     LogLevel.Information).
                        EnableSensitiveDataLogging(true);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>(e => {
                e.HasKey(e => e.CategoryID);
                e.Property(k => k.CategoryID)
                .UseIdentityColumn(1, 1);
            });

            modelBuilder.Entity<Product>()
                .HasKey(e => e.ProductID);

            modelBuilder.Entity<Supplier>()
                .HasKey(e => e.SupplierID);

            // Composite Key
            modelBuilder.Entity<SupplierProduct>()
                .HasKey(e => new { e.ProductID, e.SupplierID });

            // Referential integeraty constraints
            modelBuilder.Entity<Category>()
                .HasMany(p => p.Products)
                .WithOne(c => c.associatedCategory);

            modelBuilder.Entity<Supplier>()
                .HasMany(p => p.Products)
                .WithMany(s => s.Suppliers)
                .UsingEntity<SupplierProduct>();

            modelBuilder.Entity<Category>()
                .HasData(new Category[] {
                new Category { CategoryID=1, Description="Hardware" },
                new Category { CategoryID=2, Description="Electrical Appliances" }
                    }
                );
            modelBuilder.Entity<Product>()
                .HasData(new Product[] {
                    new Product { ProductID=1,Description="9 inch nails", QuantityInStock=200, dateFirstIssued=new DateTime(2019,12,07).AddDays(6), CategoryID=1, UnitPrice= 0.1f},
                    new Product { ProductID=2,Description="9 inch bolts", QuantityInStock=120, dateFirstIssued=new DateTime(2019,12,15).AddDays(2), CategoryID=1, UnitPrice= 0.2f},
                    new Product { ProductID=3,Description="Chimney Hoover", QuantityInStock=10,dateFirstIssued=new DateTime(2019,12,10).AddDays(11), CategoryID=2, UnitPrice= 100.5f},
                    new Product { ProductID=4,Description="Wassing Machine", QuantityInStock=7,dateFirstIssued=new DateTime(2019,12,09).AddDays(11), CategoryID=2, UnitPrice= 399.99f},

                });
            modelBuilder.Entity<Supplier>()
                .HasData(new Supplier[] {
                    new Supplier { SupplierID=1,SupplierName="Joe bloggs",SupplierAddressLine1="The Coop", SupplierAddressLine2="Copersville"},
                    new Supplier { SupplierID=2,SupplierName="Mary Quant",SupplierAddressLine1="Priory Road", SupplierAddressLine2="Paris"},

                });

            modelBuilder.Entity<SupplierProduct>()
                .HasData(new SupplierProduct[] { 
                    new SupplierProduct { SupplierID=1, ProductID = 1, DateFirstSupplied = new DateTime(2019,12,07)},
                    new SupplierProduct { SupplierID=1, ProductID = 2, DateFirstSupplied = new DateTime(2019,12,15)},
                    new SupplierProduct { SupplierID=2, ProductID =3,  DateFirstSupplied = new DateTime(2019,12,10)},
                    new SupplierProduct { SupplierID=2, ProductID = 4, DateFirstSupplied = new DateTime(2019,12,09)},
                });
        }
    }
}
