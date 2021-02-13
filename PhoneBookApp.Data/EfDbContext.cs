using PhoneBookApp.Data.Ef.Concrete;
using Microsoft.EntityFrameworkCore;

namespace PhoneBookApp.Data
{
    public class EfDbContext: DbContext
    {
        public EfDbContext(DbContextOptions<EfDbContext> options) : base(options)
        {
        }

        public DbSet<Entry> Entries { get; set; }
        public DbSet<PhoneBook> PhoneBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entry>().ToTable("Entry");
            modelBuilder.Entity<PhoneBook>().ToTable("PhoneBook");
        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       // {
         //  optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Bongani.COMCORPOFFICE\Desktop\assesment\PhoneBookApp\PhoneBookApp.API\AppData\PhoneBookDB.mdf;Integrated Security=True");
            //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Bongani.COMCORPOFFICE\Desktop\assesment\PhoneBookApp\PhoneBookApp.API\AppData\PhoneBookDB.mdf;Integrated Security=True
        //}
    }
}
