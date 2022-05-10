using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Data;

using System.Collections.Generic;
using System.Text.Json;
using System.Data;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetUserController : ControllerBase
    {
        private readonly ITestRepo _context;
       
      // private readonly SqlTestRepo _reposirtoy = new SqlTestRepo();
       
        public GetUserController(ITestRepo context)
        {
            _context = context;
        }


        [HttpGet]
         public ActionResult <UserItem> GetUsersALL()
        {
            var result = _context.GetUsers();
            return Ok(result);
        }
      [HttpGet("{id}")]
       public ActionResult <UserItem> GetUsersALL (string id )
        {
             
            var result = _context.GetUsers(id);
            return Ok(result);


        }


        public class User
   {
        public int    id { get; set; }
        public string full_name { get; set; }
        public string name { get; set; }
        public string english_name { get; set; }
        public string emp_num { get; set; }
        public string Default_Language { get; set; }
        public string mail_address { get; set; }
        public string emp_code1 { get; set; }
        public bool RememberMe { get; set; }
        public string password { get; set; }
        public string ConfirmPassword { get; set; }
    }



         [HttpGet]
        [Route("GetUsersALLFormat")]
        public ActionResult<UserItem> GetUsersALLFormat ()
        {
             
            var result = _context.GetUsers();
            
            return  Ok(result);
            
        }




        
        [HttpPost]
        [Route("AddUsers")]
        public bool AddUsers([FromBody] AddUser person)
        {
            try
            {
                    bool check = _context.AddUsersDetails(person);
                    if (check)
                    {
                     return true;  
                    }
                    return false;
            }
            catch
            {
                return false;
            }
        }
    }
}