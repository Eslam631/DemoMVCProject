namespace Demo.Perestation.ViewModels.UsersVM
{
    public class UsersViewModel
    {
        public string Id { get; set; } = default!;
        public string FName { get; set; } = default!;
        public string? LName { get; set; } = default!;

        public string? Email { get; set; } 
        public string? PhoneNumber { get; set; } = default!;
        public string? Role { get; set; }
    }
}
