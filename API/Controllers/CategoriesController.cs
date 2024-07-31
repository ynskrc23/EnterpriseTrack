using AutoMapper;
using Core.DTOs;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Core.Models;
using Core.DTOs.Category;

namespace API.Controllers
{
    public class CategoriesController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _service;

        public CategoriesController(IMapper mapper, ICategoryService categoryService)
        {

            _mapper = mapper;
            _service = categoryService;
        }

        /// GET api/categories
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var categories = await _service.GetAllAsync();
            var categoriesDtos = _mapper.Map<List<CategoryListDto>>(categories.ToList());
            return CreateActionResult(CustomResponseDto<List<CategoryListDto>>.Success(200, categoriesDtos));
        }

        // GET /api/categories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _service.GetByIdAsync(id);
            var categoriesDto = _mapper.Map<CategoryListDto>(category);
            return CreateActionResult(CustomResponseDto<CategoryListDto>.Success(200, categoriesDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromForm] IFormFile picture, [FromForm] CategoryCreateDto categoryDto)
        {
            if (picture == null || picture.Length == 0)
            {
                return BadRequest("No image uploaded.");
            }

            // Validate file type if needed
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var extension = Path.GetExtension(picture.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(extension))
            {
                return BadRequest("Invalid file type.");
            }

            var uploadsFolder = Path.Combine("wwwroot", "Uploads", "Categories");
            Directory.CreateDirectory(uploadsFolder);

            // Generate a unique filename
            var fileName = $"{Guid.NewGuid()}{extension}";
            var filePath = Path.Combine(uploadsFolder, fileName);

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await picture.CopyToAsync(stream);
                }
            }
            catch (Exception ex)
            {
                // Log the error
                return StatusCode(500, "Internal server error: " + ex.Message);
            }

            var category = _mapper.Map<Category>(categoryDto);
            category.Picture = fileName; // Store the filename in the entity
            var createdCategory = await _service.AddAsync(category);
            var categoriesDto = _mapper.Map<CategoryCreateDto>(createdCategory);

            return CreateActionResult(CustomResponseDto<CategoryCreateDto>.Success(201, categoriesDto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] IFormFile picture, [FromForm] CategoryUpdateDto categoryDto)
        {
            var category = await _service.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound("Category not found.");
            }

            if (picture != null && picture.Length > 0)
            {
                // Validate file type if needed
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var extension = Path.GetExtension(picture.FileName).ToLowerInvariant();

                if (!allowedExtensions.Contains(extension))
                {
                    return BadRequest("Invalid file type.");
                }

                var uploadsFolder = Path.Combine("wwwroot", "Uploads", "Categories");
                Directory.CreateDirectory(uploadsFolder);

                // Generate a unique filename
                var fileName = $"{Guid.NewGuid()}{extension}";
                var filePath = Path.Combine(uploadsFolder, fileName);

                try
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await picture.CopyToAsync(stream);
                    }
                    category.Picture = fileName; // Store the filename in the entity
                }
                catch (Exception ex)
                {
                    // Log the error
                    return StatusCode(500, "Internal server error: " + ex.Message);
                }
            }

            category.CategoryName = categoryDto.CategoryName;
            category.Description = categoryDto.Description;

            await _service.UpdateAsync(category);

            var categoriesDto = _mapper.Map<CategoryUpdateDto>(category);
            return CreateActionResult(CustomResponseDto<CategoryUpdateDto>.Success(204, categoriesDto));
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var category = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(category);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
