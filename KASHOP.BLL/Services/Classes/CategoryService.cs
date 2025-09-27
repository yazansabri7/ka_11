using KASHOP.BLL.Services.Interfaces;
using KASHOP.DAL.DTO.Requests;
using KASHOP.DAL.DTO.Responses;
using KASHOP.DAL.Models;
using KASHOP.DAL.Repository.Interfaces;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.BLL.Services.Classes
{
    public class CategoryService :GenericService<CategoeyRequest, CategoeyResponse,Category>, ICategoryService
    {
        public CategoryService(ICategoryRepository repository):base(repository) {
        
        
        }
        //public ICategoryRepository CategoryRepository;
        //public CategoryService(ICategoryRepository categoryRepository) 
        //{
        //    CategoryRepository = categoryRepository;
        //}


        //public int CreateCategory(CategoeyRequest request)
        //{
        //    var category = request.Adapt<Category>();
        //    return CategoryRepository.Add(category);
        //}

        //public int DeleteCategory(int id)
        //{
        //   var category = CategoryRepository.GetById(id);
        //    if(category is null)
        //    {
        //        return 0;
        //    }
        //    return CategoryRepository.Remove(category);
        //}

        //public IEnumerable<CategoeyResponse> GetAllCategories()
        //{
        //    var categories = CategoryRepository.GetAll();
        //    return categories.Adapt<IEnumerable<CategoeyResponse>>();
        //}

        //public CategoeyResponse? GetCategoryById(int id)
        //{
        //    var category = CategoryRepository.GetById(id);

        //    return category is null ? null : category.Adapt<CategoeyResponse>();
        //}

        //public int UpdateCategory(int id, CategoeyRequest request)
        //{
        //    var category = CategoryRepository.GetById(id);
        //    if (category is null) {
        //        return 0;
        //    }
        //    category.Name = request.Name;
        //    return CategoryRepository.Update(category);
        //}
        //public bool ToggleStatus(int id) 
        //{
        //    var category = CategoryRepository.GetById(id);
        //    if(category is null) { return false; }
        //    category.status = category.status == status.Active ? status.Inactive : status.Active;
        //    return true;
        //}
    }
}
