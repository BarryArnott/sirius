using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiriusApplication.Models
{
    public interface ISiriusApplicationContext
    {
        IQueryable<Image> Images { get; }
        IQueryable<Comment> Comments { get; }

        int SaveChanges();
        T Add<T>(T entity) where T : class;
        Image FindImageById(int ID);
        Image FindImageByTitle(string Title);
        Comment FindCommentById(int ID);
        T Delete<T>(T entity) where T : class;
    }
}
