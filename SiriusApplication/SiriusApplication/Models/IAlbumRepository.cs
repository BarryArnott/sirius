﻿namespace SiriusApplication.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public interface IAlbumRepository
    {
        IQueryable<Album> Albums { get; }

        Album GetAlbumById(int ID);

        List<Album> GetAllAlbumsOrderedDescending();

        List<Album> GetAlbumsOrderedDescending(int number);

        Album GetAlbumByTitle(string Title);

        Album GetDefaultAlbumWhenNoAlbumFound();
    }
}