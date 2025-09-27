using KASHOP.DAL.DTO.Requests;
using KASHOP.DAL.DTO.Responses;
using KASHOP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.BLL.Services.Interfaces
{
    public interface ICategoryService : IGenericService<CategoeyRequest,CategoeyResponse,Category>
    {
        //int CreateCategory(CategoeyRequest request);
        //IEnumerable<CategoeyResponse> GetAllCategories();
        //CategoeyResponse? GetCategoryById(int id);
        //int UpdateCategory(int id , CategoeyRequest request);
        //int DeleteCategory(int id);
        //bool ToggleStatus(int id);
    }
}
