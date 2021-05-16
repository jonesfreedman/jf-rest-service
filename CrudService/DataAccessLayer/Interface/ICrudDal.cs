using CrudService.Models;
using System.Collections.Generic;

namespace CrudService.DataAccessLayer
{
    public interface ICrudDal
    {
        public List<Team> ReadAll();
        public Team ReadOne(int Id);
        public void Create(Team team);

        public void Update(int Id, Team team);
        public void Delete(Team team);
    }
}
