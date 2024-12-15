using AutoMapper;
using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;

namespace Service.Services
{
    public class EmployeeService : Service<Employee>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IGenericRepository<Employee> repository, IUnitOfWork unitOfWork, IMapper mapper, IEmployeeRepository employeeRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }
    }
}
