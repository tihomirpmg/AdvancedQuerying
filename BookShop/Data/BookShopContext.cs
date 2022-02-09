namespace BookShop.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System;
    using System.Runtime.InteropServices;
    using Models.Configurations;

    public class BookShopContext : DbContext
    {
        public BookShopContext() 
        { 

        }

        public BookShopContext(DbContextOptions options):base(options) 
        {

        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<BookCategory> BooksCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-IUBR93H\TIHOMIR1705;Database=BookShopDB;Integrated Security=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfig());

            modelBuilder.ApplyConfiguration(new BookCategoryConfig());

            modelBuilder.ApplyConfiguration(new BookConfig());

            modelBuilder.ApplyConfiguration(new CategoryConfig());
        }
    }
}