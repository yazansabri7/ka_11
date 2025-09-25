using KASHOP.DAL.Models;

namespace KASHOP.DAL.Repository
{
    public interface ICategoryRepository
    {
        int Add(Category category);
        IEnumerable<Category> GetAll(bool withTracking = false);
        int Remove(Category category);
        int Update(Category category);
        Category? GetById(int id);
    }
}