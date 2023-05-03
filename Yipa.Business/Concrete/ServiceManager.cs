using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yipa.Core.Abstract;
using Yipa.Entities.Concrete;

namespace Yipa.Business.Concrete
{
    public class ServiceManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<Service> _validator;
        public ServiceManager(IUnitOfWork unitOfWork, IValidator<Service> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public IEnumerable<Service> GetAll()
        {
            var serviceList = _unitOfWork.Services.GetAll();
            return serviceList;
        }
 

        public ValidationResult AddService(Service service)
        {
            var validation = _validator.Validate(service);

            if (validation.IsValid)
            {
                _unitOfWork.Services.Add(service);
                _unitOfWork.Save();
            }
            return validation;
        }

        public void UpdateService(Service p)
        {
            var service = _unitOfWork.Services.Find(x => x.Id == p.Id);
            if (service != null)
            {
                service!.Title = p.Title;
                service.Content = p.Content;
              
                _unitOfWork.Services.Update(service);
                _unitOfWork.Save();
            }
        }

        public void DeleteService(int id)
        {
            var service = _unitOfWork.Services.Find(x => x.Id == id);

            if (service != null)
            {
                _unitOfWork.Services.Remove(service);
                _unitOfWork.Save();
            }
        }

        public Service GetServiceId(int id)
        {
            var service = _unitOfWork.Services.Find(x => x.Id == id);
            return service!;
        }
    }
}
