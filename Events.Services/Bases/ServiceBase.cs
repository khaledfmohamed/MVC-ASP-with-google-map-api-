using Events.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Events.Repository.Interfaces;
using MessageTube;

namespace Events.Services.Bases
{
    public abstract class ServiceBase<Entity> : IService<Entity>
    {
        protected IMessageList _messageList ; 
        protected IUnitOfWork _unitOfWork;
        public ServiceBase(IMessageList messageList , IUnitOfWork unitOfWork)
        {
            _messageList = messageList;
            _unitOfWork = unitOfWork;
        }

        public virtual void AddNew(Entity entity)
        {
            throw new NotImplementedException();
        }

        public virtual Entity Delete(int id)
        {
            throw new NotImplementedException();
        }

        public virtual void Edit(Entity entity)
        {
            throw new NotImplementedException();
        }

        public virtual Entity Get(int id)
        {
            throw new NotImplementedException();
        }

        public virtual List<Entity> GetAll(params string[] RelatedFields)
        {
            throw new NotImplementedException();
        }

        public virtual List<Entity> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual List<Entity> GetFromIndex(int startIndex, int size)
        {
            throw new NotImplementedException();
        }

        public virtual List<Entity> Search(string cretria)
        {
            throw new NotImplementedException();
        }
    }
}
