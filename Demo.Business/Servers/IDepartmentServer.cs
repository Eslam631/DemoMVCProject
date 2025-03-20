using Demo.Business.DTO.DepartmentDto;

namespace Demo.Business.Servers
{
    public interface IDepartmentServer
    {
        int AddDepartment(AddDepartmentDto departmentDto);
        bool DeleteDepartment(int id);
        IEnumerable<DepartmentGetAllDto> GetAllDepartment();
        DepartmentByIdDto? GetDepartmentById(int id);
        int UpdateDepartment(UpdateDepartmentDto departmentDto);
    }
}