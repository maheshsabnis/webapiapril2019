using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity.Attributes;
using WebApiApp.Models;
namespace WebApiApp.Repositories
{
    /// <summary>
    /// The repository performs CRUD Operations on Database
    /// using AppDbContext
    /// </summary>
    public class CategoryRepository : IRepository<Category, int>
    {
        //AppDbContext context;
        //public CategoryRepository(AppDbContext context)
        //{
        //    this.context = context;
        //}
        // the dependency injection using property
        // this is preferred for typed not implementing interface
        [Dependency]
        public AppDbContext context { get; set; }
        public Category Create(Category entity)
        {
            context.Categories.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            bool isDeleted = false;
            var rec = context.Categories.Find(id);
            if (rec != null)
            {
                context.Categories.Remove(rec);
                context.SaveChanges();
                isDeleted = true;
            }
            return isDeleted;
        }

        public IEnumerable<Category> Get()
        {
            return context.Categories.ToList();
        }

        public Category Get(int id)
        {
            return context.Categories.Find(id);
        }

        public bool Update(int id, Category entity)
        {
            bool isUpdated = false;
            var rec = context.Categories.Find(id);
            if (rec != null)
            {
                rec.CategoryName = entity.CategoryName;
                rec.BasePrice = entity.BasePrice;
                context.SaveChanges();
                isUpdated = true;
            }
            return isUpdated;
        }
    }
}