namespace Demo.Perestation.ViewModels.DepartmentVM
{
    public class DepartmentViewModel
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public DateOnly CreationOn { get; set; }
    }
}
