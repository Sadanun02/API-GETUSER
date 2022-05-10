using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Data;

using System.Collections.Generic;



namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetUserLinqController : ControllerBase
    {
        private readonly ITestRepo _context;
       
      // private readonly SqlTestRepo _reposirtoy = new SqlTestRepo();
       
        public GetUserLinqController(ITestRepo context)
        {
            _context = context;
        }


        [HttpGet]
         public IEnumerable<UserItem> GetUsersALL()
        {
            try  
            {  
                return _context.GetUserDetails().ToList();  
            }  
            catch (Exception)  
            {  
                throw;  
            } 
        }
      [HttpGet("{id}")]
       public IEnumerable<UserItem> GetUsersALL (int id )
        {
              return _context.GetUserDetails().Where(x => x.Id == id).ToList(); 
        
        }
    }
}