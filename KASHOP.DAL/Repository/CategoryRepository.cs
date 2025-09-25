using KASHOP.DAL.Data;
using KASHOP.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public ApplicationDbContext context;
        public CategoryRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public int Add(Category category)
        {
           context.Categories.Add(category);
            return context.SaveChanges();
        }

        public IEnumerable<Category> GetAll(bool withTracking = false)
        {
            if (withTracking) { 
            return context.Categories.ToList();
            }
            return context.Categories.AsNoTracking().ToList();
        }

        public Category? GetById(int id)=>  context.Categories.Find(id);
        

        public int Remove(Category category)
        {
            context.Categories.Remove(category);
            return context.SaveChanges();
        }

        public int Update(Category category)
        {
            context.Categories.Update(category);
            return context.SaveChanges();
        }
    }
}
