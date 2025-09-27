using Azure;
using Azure.Core;
using KASHOP.BLL.Services.Interfaces;
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
    public class GenericService<TRequest, TResponse, TEntity> : IGenericService<TRequest, TResponse, TEntity> where TEntity : BaseModel
    {
        public IGenericRepository<TEntity> genericRepository { get; set; }
        public GenericService(IGenericRepository<TEntity> genericRepository)
        {
            this.genericRepository = genericRepository;

        }
        public int Create(TRequest request)
        {
           var entity = request.Adapt<TEntity>();
            return genericRepository.Add(entity);
        }

        public int Delete(int id)
        {
            var entity = genericRepository.GetById(id);
            if (entity is null)
                return 0;
            return genericRepository.Remove(entity);

        }

        public IEnumerable<TResponse> GetAll()
        {
            var entities = genericRepository.GetAll();
            return entities.Adapt<IEnumerable<TResponse>>();
        }

        public TResponse? GetById(int id)
        {
            var entity = genericRepository.GetById(id);
            return entity is null ?  default : entity.Adapt<TResponse>();
        }

        public bool ToggleStatus(int id)
        {
            var entity = genericRepository.GetById(id);
            if(entity is null) return false;
            entity.status = entity.status == status.Active ? status.Inactive : status.Active;
            genericRepository.Update(entity);
            return true;
        }

        public int Update(int id, TRequest request)
        {
            var entity = genericRepository.GetById(id);
            if(entity is null) return 0;
            var updatedEntity = request.Adapt(entity);

            return genericRepository.Update(entity);
        }
    }
}
