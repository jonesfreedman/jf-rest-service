using CrudService.BusinessLayer;
using CrudService.Helper;
using CrudService.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CrudService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ICrudBal _crudBal;
        public TeamController(ICrudBal crudBal)
        {
            _crudBal = crudBal;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _crudBal.ViewMembers();
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet("{Id}", Name = "Get")]
        public IActionResult Get(int Id)
        {
            if (Id == 0)
            {
                return StatusCode(400);
            }
            else
            {
                try
                {
                    var result = _crudBal.FindMember(Id);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return StatusCode(500);
                }
            }
        }

        [HttpPost]
        public IActionResult Post(Team team)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }
            else
            {
                try
                {
                    _crudBal.AddMember(team);
                    return Ok(Constants.CREATESUCCESS);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return StatusCode(500);
                }
            }
        }

        [HttpPut("{Id}")]
        public IActionResult Put(int Id, Team team)
        {
            if (Id == 0)
            {
                return StatusCode(400);
            }
            else
            {
                try
                {
                    _crudBal.UpdateMember(Id, team);
                    return Ok(Constants.UPDATESUCCESS);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return StatusCode(500);
                }
            }
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            if (Id == 0)
            {
                return StatusCode(400);
            }
            else
            {
                try
                {
                    _crudBal.DeleteMember(Id);
                    return Ok(Constants.DELETESUCCESS);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return StatusCode(500);
                }
            }
        }
    }
}
