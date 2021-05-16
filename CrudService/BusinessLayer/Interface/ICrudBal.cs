using CrudService.Models;
using System.Collections.Generic;

namespace CrudService.BusinessLayer
{
    public interface ICrudBal
    {
        public List<Team> ViewMembers();
        public Team FindMember(int Id);
        public void AddMember(Team team);
        public void UpdateMember(int Id, Team team);
        public void DeleteMember(int Id);
    }
}
