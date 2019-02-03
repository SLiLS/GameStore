using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameStore.BLL.Interfaces;
using System.Threading.Tasks;
using GameStore.DAL.Interfaces;
using GameStore.BLL.DTO;
using GameStore.DAL.Entities;
using AutoMapper;


namespace GameStore.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        IUnitOfWork Database;
        public CategoryService(IUnitOfWork unit)
        {
            Database = unit;
        }

        public void CreateCategory(CategoryDTO categoryDTO)
        {
            Database.Categories.Create(new Category {Name=categoryDTO.Name });
            Database.Save();
        }
        public void DeleteCategory(int id)
        {
            Database.Categories.Delete(id);
            Database.Save();
        }
        public void Dispose()
        {
            Database.Dispose();
        }
        public IEnumerable<CategoryDTO> GetCategories()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(Database.Categories.GetAll());
        }

        public CategoryDTO GetCategory(int id)
        {
            Category category = Database.Categories.Get(id);
            return new CategoryDTO { Id = category.Id, Name = category.Name };

        }

        public void UpdateCategory(CategoryDTO categoryDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryDTO, CategoryDTO>()).CreateMapper();
            var category = mapper.Map<CategoryDTO, Category>(categoryDTO);
            Database.Categories.Update(category);
            Database.Save();
        }
    }
}
