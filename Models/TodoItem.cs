
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace TodoApi.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
    }
 
    public class TodoItemDTO
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
    }

 
    public class UserItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Full_name { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Emp_Num { get; set; }
         
    }
    public class AddUser
    {
        public int id { get; set; }
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

}
