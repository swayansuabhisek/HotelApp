using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelWebAPI.Models
{
    [Table("HotelMenu")]
    public class Hotel
    {
        [Key]
        public int DishId { get; set; }
        public string DishName { get; set; } = string.Empty;
        public string DishDesc { get; set; } = string.Empty;
        public int DishPrice { get; set; }
        public int DishRating { get; set; }
        public string DishImage { get; set; } = string.Empty;
    }

    public class HotelMenuContext : DbContext
    {
        public DbSet<Hotel> MenuItem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string strConnection = @"Data Source=W-674PY03-1;Initial Catalog=AbhisekDb;Persist Security Info=True;User ID=sa;Password=Password@12345;TrustServerCertificate=True";
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(strConnection);
        }
    }

    public interface IHotelMenuComponent
    {
        List<Hotel> GetAllDishes();
        Hotel FindDish(int id);
        void AddDish(Hotel pb);
        void UpdateDish(Hotel pb);
        void DeleteDish(int id);
    }

    public class HotelMenuComponent : IHotelMenuComponent
    {
        public void AddDish(Hotel pb)
        {
            var context = new HotelMenuContext();
            context.MenuItem.Add(pb);
            context.SaveChanges();
        }

        public void DeleteDish(int id)
        {
            var context = new HotelMenuContext();
            var rec = context.MenuItem.FirstOrDefault(e => e.DishId == id);
            if (rec != null)
            {
                context.MenuItem.Remove(rec);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Dish not found to delete");
            }
        }

        public Hotel FindDish(int id)
        {
            var context = new HotelMenuContext();
            var rec = context.MenuItem.FirstOrDefault(e => e.DishId == id);
            if (rec != null)
            {
                return rec;
            }
            else
            {
                throw new Exception("Dish not found");
            }
        }

        public List<Hotel> GetAllDishes()
        {
            var context = new HotelMenuContext();
            return context.MenuItem.ToList();
        }

        public void UpdateDish(Hotel hm)
        {
            var context = new HotelMenuContext();
            var rec = context.MenuItem.FirstOrDefault(e => e.DishId == hm.DishId);
            if (rec != null)
            {
                rec.DishId = hm.DishId;
                rec.DishName = hm.DishName;
                rec.DishPrice = hm.DishPrice;
                rec.DishDesc = hm.DishDesc;
                rec.DishRating = hm.DishRating;
                rec.DishImage = hm.DishImage;
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Dish not found to update");
            }
        }
    }
}
