using api_for_flutter.Data;
using api_for_flutter.Models.CategoryModels;
using Microsoft.EntityFrameworkCore;

namespace api_for_flutter.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDBContext _context;
        public CategoryService(ApplicationDBContext context) {  _context = context; }

        public Categories AddCategory(CreateCategory category)
        {
            var categ = new Categories
            {
                title = category.title,
                description = category.description,
                image = category.image,
                Active = category.Active
            };
            if(category.idparent != null && category.idparent!=0) { categ.idparent = category.idparent; }
            _context.Categories.Add(categ);
            _context.SaveChanges();

            return categ;
        }

        public Categories DeleteCategory(int id)
        {
            var category = GetCategoryById(id);
            if (category == null)
                return null;

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return category;
        }


        public  Categories GetCategories (int id)
        {
            var categ =   _context.Categories.FirstOrDefault(c=>c.IdCateg == id && c.Active==1);
                return categ;
        }

        public Categories GetCategoryById(int id)
        {
            var categ = _context.Categories.FirstOrDefault(c=> c.IdCateg == id && c.Active==1);
            return categ;
        }

        // a methode to get me the sons of a parent if it's exist
        public List<Categories> GetCategoryTree(int? parentId = null)
        {
            //get children by id parent 
            var categories = _context.Categories.Where(c => c.idparent == parentId && c.Active==1).ToList();
            //parcour the list of shildren and make kal back to this function with the id of the son
            foreach (var category in categories)
            {
                category.Children = GetCategoryTree(category.IdCateg);
            }
            return categories;
        }

        public Categories UpdateCategory(int id,CreateCategory category)
        {
            var categ = GetCategoryById(id);
            if(category != null)
            {
                categ.title = category.title;
                categ.description = category.description;
                categ.image = category.image;
                if(category.idparent != null)
                {
                categ.idparent = category.idparent;
                }
                categ.Active = category.Active;
                _context.Entry(categ).State = EntityState.Modified;
                _context.SaveChanges();
                return categ;
            }else
            return null; 
        }
    }
}
