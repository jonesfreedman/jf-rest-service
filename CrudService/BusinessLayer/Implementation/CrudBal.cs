using CrudService.DataAccessLayer;
using CrudService.Exceptions;
using CrudService.Helper;
using CrudService.Models;
using System.Collections.Generic;

namespace CrudService.BusinessLayer
{
    public class CrudBal : ICrudBal
    {
        private readonly ICrudDal _crudDal;
        public CrudBal(ICrudDal crudDal)
        {
            _crudDal = crudDal;
        }

        public List<Team> ViewMembers()
        {
            List<Team> result = _crudDal.ReadAll();
            if (result.Count > 0)
            {
                return result;
            }
            else
            {
                throw new NotFoundException(Constants.TABLEEMPTY);
            }
        }

        public Team FindMember(int Id)
        {
            Team result = _crudDal.ReadOne(Id);
            if (!string.IsNullOrEmpty(result.FirstName))
            {
                return result;
            }
            else
            {
                throw new NotFoundException(Constants.PERSONNOTFOUND);
            }
        }

        public void AddMember(Team team)
        {
            _crudDal.Create(team);
        }

        public void DeleteMember(int Id)
        {
            Team result = _crudDal.ReadOne(Id);
            if (!string.IsNullOrEmpty(result.FirstName))
            {
                _crudDal.Delete(result);
            }
            else
            {
                throw new NotFoundException(Constants.PERSONNOTFOUND);
            }
        }

        public void UpdateMember(int Id, Team team)
        {
            Team result = _crudDal.ReadOne(Id);
            if (!string.IsNullOrEmpty(result.FirstName))
            {
                _crudDal.Update(Id, team);
            }
            else
            {
                throw new NotFoundException(Constants.PERSONNOTFOUND);
            }
        }
    }
}
