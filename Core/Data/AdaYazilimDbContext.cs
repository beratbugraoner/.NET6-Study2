using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public class AdaYazilimDbContext : DbContext
    {
        public AdaYazilimDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Sepet> Sepetler { get; set; }


        public DbSet<SepetUrun> SepetUrunler { get; set; }
    }
}
