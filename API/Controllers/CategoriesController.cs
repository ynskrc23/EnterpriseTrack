using API.Filters;
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

        [ServiceFilter(typeof(NotFoundFilter<Category>))]
        // GET /api/categories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _service.GetByIdAsync(id);
            var categoriesDto = _mapper.Map<CategoryListDto>(category);
            return CreateActionResult(CustomResponseDto<CategoryListDto>.Success(200, categoriesDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryCreateDto categoryDto)
        {
            var category = await _service.AddAsync(_mapper.Map<Category>(categoryDto));
            var categoriesDto = _mapper.Map<CategoryCreateDto>(category);
            return CreateActionResult(CustomResponseDto<CategoryCreateDto>.Success(201, categoriesDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoryUpdateDto categoryDto)
        {
            await _service.UpdateAsync(_mapper.Map<Category>(categoryDto));
            return CreateActionResult(CustomResponseDto<CategoryUpdateDto>.Success(204));
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
