using LDI.BusinessLogic.Abstract;
using LDI.DataAccess.Abstract;
using LDI.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LDI.BusinessLogic.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryRepo categoryRepo;

        public CategoryManager(ICategoryRepo _categoryRepo)
        {
            categoryRepo = _categoryRepo;
        }

        public bool Add(Category data)
        {

            return categoryRepo.Add(data);

        }

        public Category GetCategory(Expression<Func<Category, bool>> expression)
        {

            return categoryRepo.Get(expression);

        }

        public ICollection<Category> GetList(Expression<Func<Category, bool>> expression)
        {
            return categoryRepo.GetList(expression);
        }
    }
}
