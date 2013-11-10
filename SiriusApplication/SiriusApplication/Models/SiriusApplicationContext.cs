﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SiriusApplication.Models
{
    public class SiriusApplicationContext : DbContext
    {
        public DbSet<Image> Images { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}