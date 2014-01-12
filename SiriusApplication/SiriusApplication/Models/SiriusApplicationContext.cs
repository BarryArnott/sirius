using System.Data.Entity;
using System.Linq;
using SiriusApplication.Utils;

namespace SiriusApplication.Models
{
    public class SiriusApplicationContext : DbContext, ISiriusApplicationContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<SiriusApplication.Models.SiriusApplicationContext>());

        public SiriusApplicationContext() : base("name=SiriusApplicationContext")
        {
        }

        public DbSet<Image> Images { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Album> Albums { get; set; }

        IQueryable<Album> ISiriusApplicationContext.Albums
        {
            get { return Albums; }
        }

        IQueryable<Image> ISiriusApplicationContext.Images
        {
            get { return Images; }
        }

        IQueryable<Comment> ISiriusApplicationContext.Comments
        {
            get { return Comments; }
        }

        int ISiriusApplicationContext.SaveChanges()
        {
            return SaveChanges();
        }

        T ISiriusApplicationContext.Add<T>(T entity)
        {
            return Set<T>().Add(entity);
        }

        Album ISiriusApplicationContext.FindAlbumById(int ID)
        {
            return Set<Album>().Find(ID);
        }

        Album ISiriusApplicationContext.FindAlbumByTitle(string Title)
        {
            Album album = (from p in Set<Album>()
                           where p.Title == Title
                           select p).FirstOrDefault();
            return album;
        }

        Image ISiriusApplicationContext.FindImageById(int ID)
        {
            return Set<Image>().Find(ID);
        }

        Image ISiriusApplicationContext.FindImageByTitle(string Title)
        {
            Image image = (from p in Set<Image>()
                           where p.Title == Title
                           select p).FirstOrDefault();
            return image;
        }

        Image ISiriusApplicationContext.FindDefaultImageWhenNoImageFound()
        {
            //The default image id
            const int noImageFound = 1;

            return Set<Image>().Find(noImageFound);
        }

        Album ISiriusApplicationContext.FindAlbumCoverImageById(int ID)
        {
            return Set<Album>().Find(ID);
        }

        Comment ISiriusApplicationContext.FindCommentById(int ID)
        {
            return Set<Comment>().Find(ID);
        }

        T ISiriusApplicationContext.Delete<T>(T entity)
        {
            return Set<T>().Remove(entity);
        }
    }
}
