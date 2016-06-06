using System.Collections.Generic;
using Project.Model;

namespace Project.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
    }
}
