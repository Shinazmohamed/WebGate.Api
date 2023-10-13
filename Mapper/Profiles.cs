using AutoMapper;
using WebGate.EntityFramework.Entities;
using WebGate.Shared.Requests;

namespace WebGate.Api.Mapper
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Employee, EmployeeRequest>();
            CreateMap<EmployeeRequest, Employee>();
        }
    }
}
