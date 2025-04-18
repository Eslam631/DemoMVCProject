using System.ComponentModel.DataAnnotations;

namespace Demo.Perestation.ViewModels.UsersVM
{
    public class EditUserViewModel
    {
        public string FName { get; set; } = default!;
        public string? LName { get; set; }

        
        
        public string? PhoneNumber {  get; set; }

    }
}
