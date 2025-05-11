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
    public class AdminManager : IGenericService<Admin>
    {
        private readonly IAdminDal _adminDal;
        public void TDelete(int id)
        {
           _adminDal.Delete(id);
        }

        public List<Admin> TGetAll()
        {
            return _adminDal.GetAll();
        }

        public Admin TGetById(int id)
        {
            return _adminDal.GetById(id);
        }

        public void TInsert(Admin entity)
        {
          _adminDal.Insert(entity);
        }

        public void TUpdate(Admin entity)
        {
            _adminDal.Update(entity);
        }
    }
}
