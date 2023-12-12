using MEDEletro.ProductApi.DTOs;
using MEDEletro.ProductApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace MEDEletro.ProductApi.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAll() 
    {
        var categoriesDto = await _categoryService.GetCategories();
        if(categoriesDto is null)
            return NotFound("Categories not found");

        return Ok(categoriesDto);

    }
    [HttpGet("products")]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoriesProducts()
    {
        var categoriesDto = await _categoryService.GetCategoriesProducts();
        if (categoriesDto is null)
            return NotFound("Not Found");
        return Ok(categoriesDto);
    }

    [HttpGet("{id}", Name = "GetCategory")]
    public async Task<ActionResult<CategoryDTO>> Get(int id)
    {
        var categoryDto = await _categoryService.GetById(id);
        if (categoryDto is null)
            return NotFound("Not Found");
        return Ok(categoryDto);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDto)
    {
        if (categoryDto is null)
            return BadRequest("Invalid Data");
        await _categoryService.AddCategory(categoryDto);
        return new CreatedAtRouteResult("GetCategory", new { id = categoryDto.CategoryId }, categoryDto);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDto)
    {
        if (id != categoryDto.CategoryId)
            return BadRequest();
        if (categoryDto is null)
            return BadRequest();
        await _categoryService.UpdateCategory(categoryDto); 
        return Ok(categoryDto);
    }

    [HttpDelete("{id}")]
    public async  Task<ActionResult<CategoryDTO>> Delete(int id)
    {
        var categoryDto = await _categoryService.GetById(id);
        if (categoryDto is null)
            return NotFound("Category Not Found");
        await _categoryService.RemoveCategory(id);

        return Ok(categoryDto);
    }

}



