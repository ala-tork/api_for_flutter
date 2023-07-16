using api_for_flutter.Models.CategoryModels;

namespace api_for_flutter.Services.CategoryServices
{
    public interface ICategoryService
    {
        List<Categories> GetCategoryTree(int? parentId = null);
        Categories GetCategories (int id);
        Categories GetCategoryById (int id);
        Categories AddCategory(CreateCategory category);
        Categories UpdateCategory(int id,CreateCategory category);
        Categories DeleteCategory(int id);

    }
}
