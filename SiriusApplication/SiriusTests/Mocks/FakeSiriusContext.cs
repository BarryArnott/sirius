using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SiriusApplication.Models;
using SiriusApplication.Utils;

namespace SiriusTests.Mocks
{
    class FakeSiriusContext : ISiriusApplicationContext
    {
        //This object is a keyed collection we use to mock an 
        //entity framework context in memory
        SetMap _map = new SetMap();

        public IQueryable<Album> Albums
        {
            get { return _map.Get<Album>().AsQueryable(); }
            set { _map.Use<Album>(value); }
        }

        public IQueryable<Image> Images
        {
            get { return _map.Get<Image>().AsQueryable(); }
            set { _map.Use<Image>(value); }
        }

        public IQueryable<Comment> Comments
        {
            get { return _map.Get<Comment>().AsQueryable(); }
            set { _map.Use<Comment>(value); }
        }

        public bool ChangesSaved { get; set; }

        public int SaveChanges()
        {
            ChangesSaved = true;
            return 0;
        }

        public T Add<T>(T entity) where T : class
        {
            _map.Get<T>().Add(entity);
            return entity;
        }

        public Album FindAlbumById(int ID)
        {
            Album item = (from p in this.Albums
                          where p.AlbumID == ID
                          select p).First();

            return item;
        }

        public Album FindAlbumByTitle(string Title)
        {
            Album item = (from p in this.Albums
                          where p.Title == Title
                          select p).FirstOrDefault();

            return item;
        }

        public Image FindImageById(int ID)
        {
            Image item = (from p in this.Images
                    where p.ImageID == ID
                    select p).First();
 
            return item;
        }

        public Album FindAlbumCoverImageById(int ID)
        {
            Album item = (from p in this.Albums
                          where p.AlbumID == ID
                          select p).First();

            return item;

        }

        public Image FindImageByTitle(string Title)
        {
            Image item = (from p in this.Images
                          where p.Title == Title
                          select p).FirstOrDefault();

            return item;
        }

        public Image FindDefaultImageWhenNoImageFound()
        {
            const int noImageFound = 1;

            Image item = (from p in this.Images
                          where p.ImageID == noImageFound
                          select p).First();

            return item;
        }

        public Comment FindCommentById(int ID)
        {
            Comment item = (from c in this.Comments
                          where c.CommentID == ID
                          select c).First();
            return item;
        }

        public T Delete<T>(T entity) where T : class
        {
            _map.Get<T>().Remove(entity);
            return entity;
        }

        class SetMap : KeyedCollection<Type, object>
        {

            public HashSet<T> Use<T>(IEnumerable<T> sourceData)
            {
                var set = new HashSet<T>(sourceData);
                if (Contains(typeof(T)))
                {
                    Remove(typeof(T));
                }
                Add(set);
                return set;
            }

            public HashSet<T> Get<T>()
            {
                return (HashSet<T>) this[typeof(T)];
            }

            protected override Type GetKeyForItem(object item)
            {
                return item.GetType().GetGenericArguments().Single();
            }
        }
    }
}
