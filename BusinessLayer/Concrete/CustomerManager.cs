using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

       
        public void TDelete(int id)
        {
            _customerDal.Delete(id);
        }

        public List<Customer> TGetAll()
        {
            return _customerDal.GetAll();
        }

        public Customer TGetById(int id)
        {
            return _customerDal.GetById(id);
        }

        public void TInsert(Customer t)
        {
            if (t.Name != "" && t.Surname.Length >= 3 && t.City != null && t.Surname != "" && t.Name.Length <= 30)
            {
                _customerDal.Insert(t);
            }
            else
            {
                // Hata mesajı
            }
        }

        public void TUpdate(Customer t)
        {
            if (t.Id != 0 && t.City.Length >= 3)
            {
                _customerDal.Update(t);
            }
            else
            {
                // Hata mesajI
            }
        }
    }
}

