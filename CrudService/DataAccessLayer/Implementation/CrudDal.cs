using CrudService.Models;
using System.Collections.Generic;
using System.Linq;

namespace CrudService.DataAccessLayer
{
    public class CrudDal : ICrudDal
    {
        private readonly CRUDContext _crudContext;
        public CrudDal(CRUDContext crudContext)
        {
            _crudContext = crudContext;
        }

        public List<Team> ReadAll()
        {
            return _crudContext.Teams.ToList();
        }

        public Team ReadOne(int Id)
        {
            return _crudContext.Teams.FirstOrDefault(x => x.PersonId.Equals(Id));
        }

        public void Create(Team team)
        {
            _crudContext.Teams.Add(team);
            _crudContext.SaveChanges();
        }

        public void Delete(Team team)
        {
            _crudContext.Teams.Remove(team);
            _crudContext.SaveChanges();
        }

        public void Update(int Id, Team team)
        {
            Team result = _crudContext.Teams.FirstOrDefault(x => x.PersonId.Equals(Id));
            result.FirstName = team.FirstName;
            result.LastName = team.LastName;
            result.City = team.City;
            _crudContext.Teams.Update(result);
            _crudContext.SaveChanges();
        }
    }
}
