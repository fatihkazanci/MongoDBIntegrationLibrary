using MongoDB.Driver;
using MongoDBCore.Models;
using MongoDBCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MongoDBCore.Repositories
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        Response Add(TEntity entity);
        UpdateResponse Update(string uniqKey, Expression<Func<TEntity, object>> columnExpression, object newValue);
        UpdateListResponse Update(TEntity entity);
        DeleteResponse Delete(string uniqKey);
        IFindFluent<TEntity, TEntity> GetAll();
        IFindFluent<TEntity, TEntity> SearchFor(Expression<Func<TEntity, bool>> columnExpression);
        IFindFluent<TEntity, TEntity> GetById(string uniqKey);
        UpdateResponse Update(string uniqKey, string columName, object newValue);
    }
}
