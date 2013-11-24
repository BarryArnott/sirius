﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SiriusApplication.Models;

namespace SiriusTests.Mocks
{
    class FakeSiriusContext : ISiriusApplicationContext
    {
        //This object is a keyed collection we use to mock an 
        //entity framework context in memory
        SetMap _map = new SetMap();

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

        public Image FindImageById(int ID)
        {
            Image item = (from p in this.Images
                    where p.ImageID == ID
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