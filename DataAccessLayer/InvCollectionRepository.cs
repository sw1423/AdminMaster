using BusinessEntities;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccessLayer
{
    public class InvCollectionRepository : IInvCollectionRepository
    {
        public static DbContext Context { get; private set; }
        public InvCollectionRepository()
        {
            Context = DbContext.OpDB();
        }
        public IEnumerable<inv_inventory_collect> Inventory_Collects => Context.CurrentDb.GetList();
        public inv_inventory_collect GetT(dynamic id)
        {
            return Context.CurrentDb.GetById(id);
        }
        public List<inv_inventory_collect> GetList()
        {
            return Context.CurrentDb.GetList();
        }
        public List<inv_inventory_collect> GetList(Expression<Func<inv_inventory_collect, bool>> whereExpression)
        {
            return Context.CurrentDb.GetList(whereExpression);
        }
        /// <summary>
        /// 根据表达式查询分页
        /// </summary>
        /// <returns></returns>
        public virtual List<inv_inventory_collect> GetPageList(Expression<Func<inv_inventory_collect, bool>> whereExpression, PageModel pageModel)
        {
            return Context.CurrentDb.GetPageList(whereExpression, pageModel);
        }

        /// <summary>
        /// 根据表达式查询分页并排序
        /// </summary>
        /// <param name="whereExpression">it</param>
        /// <param name="pageModel"></param>
        /// <param name="orderByExpression">it=>it.id或者it=>new{it.id,it.name}</param>
        /// <param name="orderByType">OrderByType.Desc</param>
        /// <returns></returns>
        public virtual List<inv_inventory_collect> GetPageList(Expression<Func<inv_inventory_collect, bool>> whereExpression, PageModel pageModel, Expression<Func<inv_inventory_collect, object>> orderByExpression = null, OrderByType orderByType = OrderByType.Asc)
        {
            return Context.CurrentDb.GetPageList(whereExpression, pageModel, orderByExpression, orderByType);
        }
        
        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <returns></returns>
        public virtual List<inv_inventory_collect> GetById(dynamic id)
        {
            return Context.CurrentDb.GetById(id);
        }

        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Delete(dynamic id)
        {
            if (string.IsNullOrEmpty(id.ObjToString))
            {
                Console.WriteLine(string.Format("要删除的主键id不能为空值！"));
            }
            return Context.CurrentDb.Delete(id);
        }


        /// <summary>
        /// 根据实体删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Delete(inv_inventory_collect data)
        {
            if (data == null)
            {
                Console.WriteLine(string.Format("要删除的实体对象不能为空值！"));
            }
            return Context.CurrentDb.Delete(data);
        }

        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Delete(dynamic[] ids)
        {
            if (ids.Length <= 0)
            {
                Console.WriteLine(string.Format("要删除的主键ids不能为空值！"));
            }
            return Context.CurrentDb.AsDeleteable().In(ids).ExecuteCommand() > 0;
        }

        /// <summary>
        /// 根据表达式删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Delete(Expression<Func<inv_inventory_collect, bool>> whereExpression)
        {
            return Context.CurrentDb.Delete(whereExpression);
        }


        /// <summary>
        /// 根据实体更新，实体需要有主键
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Update(inv_inventory_collect obj)
        {
            if (obj == null)
            {
                Console.WriteLine(string.Format("要更新的实体不能为空，必须带上主键！"));
            }
            return Context.CurrentDb.Update(obj);
        }

        /// <summary>
        ///批量更新
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Update(List<inv_inventory_collect> objs)
        {
            if (objs.Count <= 0)
            {
                Console.WriteLine(string.Format("要批量更新的实体不能为空，必须带上主键！"));
            }
            return Context.CurrentDb.UpdateRange(objs);
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Insert(inv_inventory_collect obj)
        {
            return Context.CurrentDb.Insert(obj);
        }


        /// <summary>
        /// 批量
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Insert(List<inv_inventory_collect> objs)
        {
            return Context.CurrentDb.InsertRange(objs);
        }

    }
}
