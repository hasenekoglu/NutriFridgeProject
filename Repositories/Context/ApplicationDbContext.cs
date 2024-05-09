using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;
using Microsoft.Extensions.Configuration;
using Models.ChatsModel;
using Models.GPTChatsModel;

namespace Repositories.Context
{
    public class ApplicationDbContext :DbContext
    {
 
      //  protected IConfiguration Configuration { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodMaterial> FoodsMaterials { get; set; }
        public DbSet<MessageModel> Messages { get; set; }
        public DbSet<Chat> Chats { get; set; }


       

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {
       
        }

        public ApplicationDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                base.OnConfiguring(optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=NutriFridgeDataBase"));

            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Material>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Food>()
                .HasKey(f => f.Id);


            modelBuilder.Entity<FoodMaterial>()
                .HasKey(fm => new { fm.FoodId, fm.MaterialId });

            modelBuilder.Entity<MessageModel>()
                .HasOne(m => m.Chat)
                .WithMany(c => c.Messages)
                .HasForeignKey(m => m.ChatId);
            //modelBuilder.Entity<FoodMaterial>()
            //    .HasOne(fm => fm.Food)
            //    .WithMany(f => f.FoodMaterials)
            //    .HasForeignKey(fm => fm.FoodId);

            //modelBuilder.Entity<FoodMaterial>()
            //    .HasOne(fm => fm.Material)
            //    .WithMany(m => m.FoodMaterials)
            //    .HasForeignKey(fm => fm.MaterialId);

            modelBuilder.Entity<Material>().HasData(
                new Material { Id = 1, Name = "Egg", FoodValue = "10g protein" },
                new Material { Id = 2, Name = "Tomato", FoodValue = "100g Vitamin C" }

            );


            modelBuilder.Entity<Food>().HasData(
                new Food { Id = 1, Name = "Scrambled Eggs", FoodValue = "Delicious and nutritious", Recipe = "Scramble eggs and add diced tomatoes" },
                new Food { Id = 2, Name = "Tomato Salad", FoodValue = "Fresh and healthy", Recipe = "Slice tomatoes and add olive oil" }

            );


            base.OnModelCreating(modelBuilder);
        }
    }
}
