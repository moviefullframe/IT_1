﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IT
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ITEntities2 : DbContext
    {
        public ITEntities2()
            : base("name=ITEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<customer> customer { get; set; }
        public virtual DbSet<employees> employees { get; set; }
        public virtual DbSet<orders> orders { get; set; }
        public virtual DbSet<product> product { get; set; }
        public virtual DbSet<user_roles> user_roles { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<quantity> quantity { get; set; }
    }
}