using System.ComponentModel.DataAnnotations;

namespace Demo.Perestation.ViewModels.AccountVM
{
    public class ResetPasswordViewModel
    {

        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;

    }
}
