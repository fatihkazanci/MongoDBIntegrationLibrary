using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using MongoDBCore.Models;
using MongoDBCore.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace MongoDBCore.Repositories
{
    public class MongoDbRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        private IMongoDatabase CurrentDatabase;
        private IMongoCollection<TEntity> CurrentCollection;
        public MongoDbRepository()
        {
            IMongoClient client = new MongoClient(MongoDbConfig.ConnectionString);
            CurrentDatabase = client.GetDatabase(MongoDbConfig.DatabaseName);
            CurrentCollection = CurrentDatabase.GetCollection<TEntity>(typeof(TEntity).Name);
        }
        public MongoDbRepository(string connectionString, string databaseName)
        {
            IMongoClient client = new MongoClient(connectionString);
            CurrentDatabase = client.GetDatabase(databaseName);
            CurrentCollection = CurrentDatabase.GetCollection<TEntity>(typeof(TEntity).Name);
        }
        public Response Add(TEntity entity)
        {
            Response response = new Response();
            try
            {
                Guid newGuid = Guid.NewGuid();
                entity.Id = newGuid;
                entity.UniqKey = newGuid.ToString();
                CurrentCollection.InsertOne(entity);
                response.UniqKey = newGuid.ToString();
                response.Result = true;
            }
            catch (Exception ex)
            {
                response.Exception = ex;
                response.Result = false;
            }
            return response;
        }
        public UpdateResponse Update(string uniqKey, Expression<Func<TEntity, object>> columnExpression, object newValue)
        {
            UpdateResponse updateResponse = new UpdateResponse();
            try
            {
                PropertyInfo column = (PropertyInfo)columnExpression.Body.GetType().GetProperty("Member").GetValue(columnExpression.Body);
                UpdateDefinition<TEntity> update = Builders<TEntity>.Update.Set(column.Name, newValue);
                updateResponse.UpdateResult = CurrentCollection.UpdateOne(i => i.UniqKey == uniqKey, update);
                updateResponse.Result = true;
                return updateResponse;
            }
            catch (Exception ex)
            {
                updateResponse.Exception = ex;
                updateResponse.Result = false;
                return updateResponse;
            }
        }
        public UpdateListResponse Update(TEntity entity)
        {
            UpdateListResponse resultMessage = new UpdateListResponse();
            try
            {
                PropertyInfo[] entityProperties = entity.GetType().GetProperties();
                foreach (PropertyInfo item in entityProperties)
                {
                    UpdateDefinition<TEntity> update = Builders<TEntity>.Update.Set(item.Name, item.GetValue(entity));
                    resultMessage.UpdateResultList.Add(CurrentCollection.UpdateOne(ix => ix.UniqKey == entity.UniqKey, update));
                }

                resultMessage.Result = true;
                return resultMessage;
            }
            catch (Exception ex)
            {
                resultMessage.Exception = ex;
                resultMessage.Result = false;
                return resultMessage;
            }
        }
        public DeleteResponse Delete(string uniqKey)
        {
            DeleteResponse resultMessage = new DeleteResponse();
            try
            {
                DeleteResult result = CurrentCollection.DeleteOne(i => i.UniqKey == uniqKey);
                resultMessage.DeleteResult = result;
                resultMessage.Result = true;
            }
            catch (Exception ex)
            {
                resultMessage.Exception = ex;
                resultMessage.Result = false;
            }
            return resultMessage;
        }
        public IFindFluent<TEntity, TEntity> SearchFor(Expression<Func<TEntity, bool>> columnExpression)
        {
            return CurrentCollection.Find(columnExpression);
        }
        public IFindFluent<TEntity, TEntity> GetById(string uniqKey)
        {
            return CurrentCollection.Find(i => i.UniqKey == uniqKey);
        }
        public IFindFluent<TEntity, TEntity> SearchForObject(Expression<Func<TEntity, bool>> columnExpression)
        {
            return CurrentCollection.Find(columnExpression);
        }
        public IFindFluent<TEntity, TEntity> GetAll()
        {
            return CurrentCollection.Find(Builders<TEntity>.Filter.Empty);
        }
        public UpdateResponse Update(string uniqKey, string columName, object newValue)
        {
            UpdateResponse updateResponse = new UpdateResponse();
            UpdateDefinition<TEntity> update = Builders<TEntity>.Update.Set(columName, newValue);
            updateResponse.UpdateResult = CurrentCollection.UpdateOne(ix => ix.UniqKey == uniqKey, update);
            updateResponse.Result = true;
            return updateResponse;
        }
    }
}
