namespace Demo.Perestation.ViewModels.UsersVM
{
    public class UserDetailsViewModel
    {
        public string Id { get; set; } = default!;
        public string FName { get; set; } = default!;
        public string? LName { get; set; } = default!;

        public string? UserName {  get; set; } = default!;

        public string? Email { get; set; }
        public string? PhoneNumber { get; set; } = default!;

    }
}
