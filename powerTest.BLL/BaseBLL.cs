using powerTest.DalFactory;
using powerTest.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace powerTest.BLL
{
    public abstract partial class BaseBLL<T> where T:class
    {
        protected IDbSession dbSession = DbSessionFactory.GetDbSession();
        protected IBaseDal<T> curDal;
        protected abstract IBaseDal<T> GetDal();
        public BaseBLL()
        {
            curDal = GetDal();
        }
        public bool Add(T act)
        {
            curDal.Add(act);
            return dbSession.SaveChanges() > 0;
        }

        public bool Delete(int[] n)
        {
            curDal.Delete(n);
            return dbSession.SaveChanges() > 0;
        }

        public bool Delete(int n)
        {
            curDal.Delete(n);
            return dbSession.SaveChanges() > 0;
        }

        public bool Edit(T act)
        {
            curDal.Edit(act);
            return dbSession.SaveChanges() > 0;
        }

        public List<T> GetList()
        {
            return curDal.GetList();
        }
        public List<T> GetList(Expression<Func<T, bool>> whereLambda)
        {
            return curDal.GetList(whereLambda);
        }
        public T LoadById(int id)
        {
            T entity = curDal.LoadById(id);
            return entity;
        }
        //分页查询数据
        public List<T> GetPageList(int pageIndex, int pageSie, Expression<Func<T, int>> whereLambda, Expression<Func<T, bool>> selData, out int recordCount)
        {
            return curDal.GetPageList(pageIndex, pageSie, whereLambda, selData, out recordCount);
        }
    }
}
