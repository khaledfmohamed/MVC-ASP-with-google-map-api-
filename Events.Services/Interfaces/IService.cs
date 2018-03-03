using Events.Repository.Interfaces;
using MessageTube;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Services.Interfaces
{
    public interface IService<Entity>
    {
       
        void AddNew(Entity entity);
        List<Entity> GetAll(params String[] RelatedFields);
        List<Entity> GetAll();
        List<Entity> GetFromIndex(int startIndex , int size);
        List<Entity> Search(string cretria);
        Entity Delete(int id);
        void Edit(Entity entity);
        Entity Get(int id);
    }
}
