using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.BLL.DTO;

namespace GameStore.BLL.Interfaces
{
    public interface ICategoryService
    {
        void CreateCategory(CategoryDTO game);
        void UpdateCategory(CategoryDTO game);
        void DeleteCategory(int id);
        CategoryDTO GetCategory(int id);
        IEnumerable<CategoryDTO> GetCategories();

        void Dispose();
    }
}
