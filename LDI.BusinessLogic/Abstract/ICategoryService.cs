using LDI.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LDI.BusinessLogic.Abstract
{
    public interface ICategoryService
    {

        ICollection<Category> GetList(Expression<Func<Category, bool>> expression);
        Category GetCategory(Expression<Func<Category, bool>> expression);
        bool Add(Category data);

    }
}
