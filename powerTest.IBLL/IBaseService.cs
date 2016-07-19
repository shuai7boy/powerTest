using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace powerTest.IBLL
{
   public partial  interface IBaseService<T> where T:class
    {
        bool Add(T t);
        bool Delete(int[] ids);
        bool Delete(int id);
        bool Edit(T t);
        List<T> GetList();
        List<T> GetList(Expression<Func<T, bool>> whereLambda);
        T LoadById(int id);
        List<T> GetPageList(int pageIndex, int pageSie, Expression<Func<T, int>> whereLambda, Expression<Func<T, bool>> selData, out int recordCount);
    }
}
