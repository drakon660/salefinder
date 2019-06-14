using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using SaleFinder.DTO;
using Mapster.Adapters;
using Mapster;

namespace SaleFinder.Domain
{
    public class SaleFinderDbContext : DbContext
    {
        public static readonly LoggerFactory MyLoggerFactory = new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });

        public DbSet<LeafletModel> Leaflets { get; set; }
        public DbSet<LeafletPageModel> Pages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=salefinder.db").UseLazyLoadingProxies().UseLoggerFactory(MyLoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<LeafletModel>()
                .Property(e => e.Status)
                .HasConversion(
                    v => v.ToString(),
                    v => (LeafletModelStatus)Enum.Parse(typeof(LeafletModelStatus), v));

            modelBuilder.Entity<LeafletModel>().HasMany(x => x.Pages).WithOne(y=>y.LeafletModel).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<LeafletPageModel>()
        .HasOne(e => e.LeafletModel)
        .WithMany(c => c.Pages).OnDelete(DeleteBehavior.Cascade);
            //    modelBuilder.Entity<LeafletPageModel>()
            //    .HasOne(p => p.LeafletModel)
            //.   WithMany(b => b.Pages);

        }
    }

    public class SaleFinderDb
    {
        public static void InitDatabase()
        {
            using (SaleFinderDbContext context = new SaleFinderDbContext())
            { 
                context.Database.Migrate();
                context.SaveChanges();
            }
        }

        public static void AddLeaflet(LeafletModel leafletModel)
        {
            using (SaleFinderDbContext context = new SaleFinderDbContext())
            {
                context.Leaflets.Add(leafletModel);
                context.SaveChanges();
            }
        }

        public static IList<LeafletModel> FindInLeaflet(string groupName, string[] keyWords)
        { 
            using (SaleFinderDbContext context = new SaleFinderDbContext())
            {
                //var test = context.Leaflets.ToList().Where(x => x.GroupName == groupName && 
                //    x.Pages.Count(y => keyWords.Any(k => y.Text.Contains(k))) > 0 
                //).ToList();

                var test = context.Leaflets.Where(leaflet=>leaflet.GroupName == groupName).SelectMany(leaflet => leaflet.Pages)
                    .Where(leafletpage=> keyWords.Any(keyword => leafletpage.Text.Contains(keyword)) )
                    .Select(result=>new SaleResult { GroupName = groupName, PageNumber = result.PageNumber }).ToList();

                //test.Select(searchresult => new SaleResult { GroupName = groupName, KeyWord = ,  })
                return null;
            };
        }

        public static void DeleteLeaflets(string groupName)
        {
            using (SaleFinderDbContext context = new SaleFinderDbContext())
            {
                var leafletsToDelete = context.Leaflets.Where(x => x.GroupName == groupName).ToList();
                context.Leaflets.RemoveRange(leafletsToDelete);

                context.SaveChanges();
            }
        } 

        internal static List<LeafletDTO> LeafletDownloadUrlBy(string[] md5)
        {
            using (SaleFinderDbContext context = new SaleFinderDbContext())
            {
                var leaflets = context.Leaflets.Where(leaflet => md5.Any(x=>x == leaflet.Hash));
                return leaflets.ProjectToType<LeafletDTO>().ToList();
            }
        }
    }
}
