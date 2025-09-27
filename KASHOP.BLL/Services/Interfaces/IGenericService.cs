using KASHOP.DAL.DTO.Requests;
using KASHOP.DAL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.BLL.Services.Interfaces
{
    public interface IGenericService<TRequest,TResponse,TEntity>
    {
        //int CreateCategory(CategoeyRequest request);
        //IEnumerable<CategoeyResponse> GetAllCategories();
        //CategoeyResponse? GetCategoryById(int id);
        //int UpdateCategory(int id, CategoeyRequest request);
        //int DeleteCategory(int id);
        //bool ToggleStatus(int id);
        int Create(TRequest request);
        IEnumerable<TResponse> GetAll();
        TResponse? GetById(int id);
        int Update(int id, TRequest request);
        int Delete(int id);
        bool ToggleStatus(int id);
    }
}
