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
    public class CityService : ServiceBase<City>, ICityService
    {
        public CityService(IMessageList messageList, IUnitOfWork unitOfWork) : base(messageList, unitOfWork)
        {
        }

        public override List<City> GetAll()
        {
            return _unitOfWork.City.GetAll();
            
        }
        public override void Edit(City entity)
        {
            _unitOfWork.City.Update(entity);
        }
        public override void AddNew(City entity)
        {
            _unitOfWork.City.Add(entity);
        }

        public override City Delete(int id)
        {
            City _city = _unitOfWork.City.Get(id);
            _unitOfWork.City.Remove(_city);
            return _city;
        }

        public List<City> GetByCountry(int countryId)
        {
           return  _unitOfWork.City.GetByCountry(countryId);

        }
    }
}
