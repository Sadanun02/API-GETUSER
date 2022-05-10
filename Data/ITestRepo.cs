using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.Models;
 

namespace TodoApi.Data
{
    public interface ITestRepo 
    {
      // List<UserItem> GetUsers ();
    IEnumerable<UserItem> GetUsers();
    IEnumerable<UserItem> GetUsers(string id);
   // bool AddUsersDetails(int id, string full_name, string name, string englist_name, string emp_num, string default_language, string mail_address, string emp_code1, string password);
    IEnumerable<UserItem> GetUserDetails();
    IEnumerable<UserItem> GetUserDetails(string id);

     bool AddUsersDetails(AddUser _object);  

    }

}