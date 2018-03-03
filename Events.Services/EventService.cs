using Events.Model;
using Events.Services.Bases;
using Events.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Events.Repository.Interfaces;
using MessageTube;

namespace Events.Services
{
    public class EventService : ServiceBase<Event>, IEventService
    {
        public EventService(IMessageList messageList, IUnitOfWork unitOfWork) : base(messageList, unitOfWork)
        {
        }

        public override List<Event> GetAll()
        {
            return _unitOfWork.Event.GetAll();
            
        }

        public override Event Get(int id)
        {
            return _unitOfWork.Event.Get(id);
        }
        public override void Edit(Event entity)
        {
            _unitOfWork.Event.Update(entity);
        }
        public override void AddNew(Event entity)
        {
            _unitOfWork.Event.Add(entity);
        }

        public override Event Delete(int id)
        {
            Event _event = _unitOfWork.Event.Get(id);
            _unitOfWork.Event.Remove(_event);
            return _event;
        }

        public override List<Event> GetFromIndex(int startIndex, int size)
        {
            return _unitOfWork.Event.GetFromIndex(startIndex, size);
        }

        

    }
}
