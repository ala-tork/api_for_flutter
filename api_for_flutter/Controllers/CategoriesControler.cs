using api_for_flutter.Data;
using api_for_flutter.Models.CategoryModels;
using api_for_flutter.Services.CategoryServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_for_flutter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesControler : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesControler (ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // get all categorys 
        [HttpGet("GetAllCategories")]
        public ActionResult<IEnumerable<Categories>> GetCategories()
        {
            var categories = _categoryService.GetCategoryTree();
            return Ok(categories);
        }


        // get category withe shildren by id
        [HttpGet("{id}")]
        public ActionResult<Categories> GetCategoryById(int id)
        {
            var category = _categoryService.GetCategoryTree(id);
            var categ = _categoryService.GetCategories(id);
            if (categ == null)
                return NotFound();

            categ.Children = category;
            return Ok(categ);
        }


        //create category
        [HttpPost("CreayeCategories")]
        public ActionResult<Categories> CreateCategory(CreateCategory category)
        {
             var categ=_categoryService.AddCategory(category);
            if(categ == null) return NotFound();
            else return CreatedAtAction(nameof(GetCategoryById), new { id = categ.IdCateg }, categ);
        }


        //update category
        [HttpPut("{id}")]
        public ActionResult UpdateCategory(int id, CreateCategory category)
        {
            var categ = _categoryService.UpdateCategory(id,category!);
            if(categ == null)
                return BadRequest();


            return Ok(categ);
        }
        //delete category by id
        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            var categ = _categoryService.DeleteCategory(id);
            if(categ == null)
                return NotFound();
            return Ok(categ);
        }
    }
}
