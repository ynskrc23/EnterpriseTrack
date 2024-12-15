using AutoMapper;
using Core.DTOs.Employee;
using Core.DTOs;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Core.Models;

namespace API.Controllers
{
    public class EmployeesController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeService _service;

        public EmployeesController(IMapper mapper, IEmployeeService employeeService)
        {

            _mapper = mapper;
            _service = employeeService;
        }

        /// GET api/employees
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var employees = await _service.GetAllAsync();
            var employeesDtos = _mapper.Map<List<EmployeeListDto>>(employees.ToList());
            return CreateActionResult(CustomResponseDto<List<EmployeeListDto>>.Success(200, employeesDtos));
        }

        // GET /api/employees/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _service.GetByIdAsync(id);
            var employeesDtos = _mapper.Map<EmployeeListDto>(employee);
            return CreateActionResult(CustomResponseDto<EmployeeListDto>.Success(200, employeesDtos));
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromForm] IFormFile photo, [FromForm] EmployeeCreateDto employeeDto)
        {
            if (photo == null || photo.Length == 0)
            {
                return BadRequest("No image uploaded.");
            }

            // Validate file type if needed
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var extension = Path.GetExtension(photo.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(extension))
            {
                return BadRequest("Invalid file type.");
            }

            var uploadsFolder = Path.Combine("wwwroot", "Uploads", "Employees");
            Directory.CreateDirectory(uploadsFolder);

            // Generate a unique filename
            var fileName = $"{Guid.NewGuid()}{extension}";
            var filePath = Path.Combine(uploadsFolder, fileName);

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await photo.CopyToAsync(stream);
                }
            }
            catch (Exception ex)
            {
                // Log the error
                return StatusCode(500, "Internal server error: " + ex.Message);
            }

            var employee = _mapper.Map<Employee>(employeeDto);
            employee.Photo = fileName; // Store the filename in the entity
            employee.PhotoPath = uploadsFolder;
            var createdEmployee = await _service.AddAsync(employee);
            var employeesDto = _mapper.Map<EmployeeCreateDto>(createdEmployee);

            return CreateActionResult(CustomResponseDto<EmployeeCreateDto>.Success(201, employeesDto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] IFormFile photo, [FromForm] EmployeeUpdateDto employeeDto)
        {
            var employee = await _service.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound("Employee not found.");
            }

            if (photo != null && photo.Length > 0)
            {
                // Validate file type if needed
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var extension = Path.GetExtension(photo.FileName).ToLowerInvariant();

                if (!allowedExtensions.Contains(extension))
                {
                    return BadRequest("Invalid file type.");
                }

                var uploadsFolder = Path.Combine("wwwroot", "Uploads", "Employees");
                Directory.CreateDirectory(uploadsFolder);

                // Generate a unique filename
                var fileName = $"{Guid.NewGuid()}{extension}";
                var filePath = Path.Combine(uploadsFolder, fileName);

                try
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await photo.CopyToAsync(stream);
                    }
                    employee.Photo = fileName; // Store the filename in the entity
                }
                catch (Exception ex)
                {
                    // Log the error
                    return StatusCode(500, "Internal server error: " + ex.Message);
                }
            }

            employee.LastName = employeeDto.LastName;
            employee.FirstName = employeeDto.FirstName;
            employee.Title = employeeDto.Title;
            employee.TitleOfCourtesy = employeeDto.TitleOfCourtesy;
            employee.BirthDate = employeeDto.BirthDate;
            employee.HireDate = employeeDto.HireDate;
            employee.Address = employeeDto.Address;
            employee.City = employeeDto.City;
            employee.Region = employeeDto.Region;
            employee.PostalCode = employeeDto.PostalCode;
            employee.Country = employeeDto.Country;
            employee.HomePhone = employeeDto.HomePhone;
            employee.Extension = employeeDto.Extension;
            employee.Notes = employeeDto.Notes;
            employee.ReportsTo = employeeDto.ReportsTo;

            await _service.UpdateAsync(employee);

            var employeesDto = _mapper.Map<EmployeeUpdateDto>(employee);
            return CreateActionResult(CustomResponseDto<EmployeeUpdateDto>.Success(204, employeesDto));
        }

        // DELETE api/employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var employee = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(employee);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
