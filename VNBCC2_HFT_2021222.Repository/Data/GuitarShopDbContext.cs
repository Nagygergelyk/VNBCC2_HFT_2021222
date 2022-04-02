using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNBCC2_HFT_2021222.Models;

namespace VNBCC2_HFT_2021222.Repository.Data
{
    public partial class GuitarShopDbContext : DbContext
    {
        public DbSet<Shape> Shapes { get; set; }
        public DbSet<Guitar> Guitars { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public GuitarShopDbContext()
        {
            this.Database.EnsureCreated();
        }


        public GuitarShopDbContext(DbContextOptions<GuitarShopDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder
                    .UseInMemoryDatabase("guitarshopdb")
                    .UseLazyLoadingProxies();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guitar>(guitar => guitar
                            .HasOne(guitar => guitar.Brand)
                            .WithMany(Brand => Brand.Guitars)
                            .HasForeignKey(guitar => guitar.BrandId)
                            .HasForeignKey(guitar => guitar.ShapeId)
                            .OnDelete(DeleteBehavior.ClientSetNull));

            modelBuilder.Entity<Guitar>().HasData(new Guitar[]
            {
                new Guitar("1#1950#4999#1#4"),
                new Guitar("2#1960#1499#1#5"),
                new Guitar("3#1954#999#1#6"),
                new Guitar("4#1971#2999#1#9"),
                new Guitar("5#1996#1999#1#10"),
                new Guitar("6#2000#499#2#5"),
                new Guitar("7#1958#399#2#9"),
                new Guitar("8#1952#1999#3#1"),
                new Guitar("9#1954#1999#3#2"),
                new Guitar("10#1999#1999#3#2"),
                new Guitar("11#2020#1999#3#3"),
                new Guitar("12#2008#299#4#2"),
                new Guitar("13#1990#399#4#1"),
                new Guitar("14#2015#599#5#15"),
                new Guitar("15#2018#199#6#11"),
                new Guitar("16#2019#179#6#9"),
                new Guitar("17#2020#149#7#4"),
                new Guitar("18#2011#99#7#5"),
                new Guitar("19#1960#999#8#9"),
                new Guitar("20#1972#1199#8#10"),
                new Guitar("21#2013#599#9#13"),
                new Guitar("22#1986#799#9#13"),
                new Guitar("23#2003#1099#10#11"),
                new Guitar("24#1997#1199#10#13"),
                new Guitar("25#1988#999#10#7"),
                new Guitar("26#2019#1999#1#10"),
                new Guitar("27#1999#2599#1#11"),
                new Guitar("28#2013#1299#3#3"),
                new Guitar("29#1967#10999#3#1"),
                new Guitar("30#1996#4999#3#12"),
            });

            modelBuilder.Entity<Brand>().HasData(new Brand[]
            {
                new Brand("1#Gibson"),
                new Brand("2#Epiphone"),
                new Brand("3#Fender"),
                new Brand("4#Squier"),
                new Brand("5#Ibanez"),
                new Brand("6#Harley Benton"),
                new Brand("7#Cort"),
                new Brand("8#Gretsch"),
                new Brand("9#Jackson"),
                new Brand("10#ESP"),
            }); ;

            modelBuilder.Entity<Shape>().HasData(new Shape[]
            {
                new Shape("1#Telecaster"),
                new Shape("2#Stratocaster"),
                new Shape("3#Jazzmaster"),
                new Shape("4#SG"),
                new Shape("5#Les Paul"),
                new Shape("6#Flying V"),
                new Shape("7#Explorer"),
                new Shape("8#Firebird"),
                new Shape("9#ES-335"),
                new Shape("10#ES-355"),
                new Shape("11#Explorer 90"),
                new Shape("12#Jaguar"),
                new Shape("13#Soloist"),
                new Shape("14#V-2"),
                new Shape("15#Iceman"),
            });
        }

    }
}
