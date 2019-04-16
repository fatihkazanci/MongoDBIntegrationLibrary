using MongoDB.Driver;
using MongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB.Repositories
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        Response Add(TEntity entity);
        UpdateResponse Update(string uniqKey, Expression<Func<TEntity, object>> columnExpression, object newValue);
        UpdateResponse Update(string uniqKey, string columName, object newValue);
        UpdateListResponse Update(TEntity entity);
        DeleteResponse Delete(string uniqKey);
        IFindFluent<TEntity, TEntity> SearchFor(Expression<Func<TEntity, bool>> columnExpression);
        IFindFluent<TEntity, TEntity> GetAll();
        IFindFluent<TEntity, TEntity> GetById(string uniqKey);
    }
}
