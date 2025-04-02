using Demo.Business.DTO.DepartmentDto;

namespace Demo.Business.Services.DepartmentSevices
{
    public interface IDepartmentService
    {
        int AddDepartment(AddDepartmentDto departmentDto);
        bool DeleteDepartment(int id);
        IEnumerable<DepartmentGetAllDto> GetAllDepartment();
        DepartmentByIdDto? GetDepartmentById(int id);
        int UpdateDepartment(UpdateDepartmentDto departmentDto);
    }
}