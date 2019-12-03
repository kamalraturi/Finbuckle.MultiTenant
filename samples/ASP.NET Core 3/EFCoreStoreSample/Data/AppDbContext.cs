//    Copyright 2018 Andrew White
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.

using Finbuckle.MultiTenant.Stores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;

namespace EFCoreStoreSample.Data
{

    public class AppDbContext : EFCoreStoreDbContext<AppTenantInfo>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseInMemoryDatabase("EFCoreStoreSampleDb");
           // if (!optionsBuilder.IsConfigured) { optionsBuilder.UseSqlServer("DefaultConnectionString"); }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<ToDoItem>().IsMultiTenant();

            base.OnModelCreating(modelBuilder);
        }
    }

    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // Get DbContext from DI system
            var resolver = new DependencyResolver
            {
                //CurrentDirectory = Path.Combine(Directory.GetCurrentDirectory(), "../EfDesignDemo.Web")
                CurrentDirectory = Path.Combine(Directory.GetCurrentDirectory())
            };
            return resolver.ServiceProvider.GetService(typeof(AppDbContext)) as AppDbContext;
        }
    }
}