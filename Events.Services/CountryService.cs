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
    public class CountryService : ServiceBase<Country>, ICountryService
    {
        public CountryService(IMessageList messageList, IUnitOfWork unitOfWork) : base(messageList, unitOfWork)
        {
        }

        public override List<Country> GetAll()
        {
            return _unitOfWork.Country.GetAll();
            
        }
        public override void Edit(Country entity)
        {
            _unitOfWork.Country.Update(entity);
        }
        public override void AddNew(Country entity)
        {
            _unitOfWork.Country.Add(entity);
        }

        public override Country Delete(int id)
        {
            Country _country = _unitOfWork.Country.Get(id);
            _unitOfWork.Country.Remove(_country);
            return _country;
        }

       
    }
}
