﻿using Mango.Service.ShoppingCartAPI.Models;
using Mango.Services.ShoppingCartAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Mango.Services.ShoppingCartAPI.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<CartHeader> CartHeaders { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }
    }
}
