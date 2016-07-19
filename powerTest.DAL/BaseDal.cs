using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace powerTest.DAL
{
   public partial class BaseDal<T> where T:class
    {
       private DbContext context = ContextFactory.GetContext();
        public int Add(T act)
        {
            context.Set<T>().Add(act);
            return 0;
        }

        public int Delete(int[] n)
        {
            for (int i = 0; i < n.Length; i++)
            {
                //T entity = context.Set<T>().Find(n[i]);
                //entity = true;
                //context.Entry(entity).State = EntityState.Modified;
                Delete(n[i]);
            }
            return 0;
        }

        public int Delete(int n)
        {
            T entity = context.Set<T>().Find(n);
            //entity.IsDelete = true;
            //context.Entry(entity).State = EntityState.Modified;
            //return context.SaveChanges();
            context.Entry(entity).Property("IsDelete").IsModified = true;
            context.Entry(entity).Property("IsDelete").CurrentValue = true;
            return 0;
        }

        public int Edit(T act)
        {
            context.Entry(act).State = EntityState.Modified;
           // return context.SaveChanges();
            return 0;
        }

        public List<T> GetList()
        {
            return context.Set<T>().ToList();
        }
        public List<T> GetList(Expression<Func<T, bool>> whereLambda)
        {
            return context.Set<T>().Where(whereLambda).ToList();
        }
        public T LoadById(int id)
        {
            T entity = context.Set<T>().Find(id);
            return entity;
        }
        //分页查询数据
        public List<T> GetPageList(int pageIndex, int pageSie, Expression<Func<T, int>> whereLambda, Expression<Func<T, bool>> selData, out int recordCount)
        {
            recordCount = context.Set<T>().Where(selData).ToList().Count();
            context.Configuration.LazyLoadingEnabled = false;
            context.Configuration.ProxyCreationEnabled = false; 
            return context.Set<T>().Where(selData).OrderBy(whereLambda).Skip((pageIndex - 1) * pageSie).Take(pageSie).ToList();
        }
    }
}
