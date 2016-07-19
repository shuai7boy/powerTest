using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace powerTest.IBLL
{
   public partial interface IBaseDal<T>
    {
        int Add(T t);
        int Delete(int[] ids);
        int Delete(int id);
        int Edit(T t);
       List<T> GetList();
       List<T> GetList(Expression<Func<T, bool>> whereLambda);
       T LoadById(int id);
       List<T> GetPageList(int pageIndex, int pageSie, Expression<Func<T, int>> whereLambda, Expression<Func<T, bool>> selData, out int recordCount);
    }
}
