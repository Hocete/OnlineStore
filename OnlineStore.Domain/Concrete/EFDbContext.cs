﻿using System;
using System.Collections.Generic;
using System.Linq;
using OnlineStore.Domain.Entities;
using System.Data.Entity;

namespace OnlineStore.Domain.Concrete
{
    public class EFDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
