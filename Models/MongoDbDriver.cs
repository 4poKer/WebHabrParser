using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using WebHabrParser.Models;

namespace WebHabrParser
{
    public class MongoDbDriver
    {
        private static readonly string _dbName = ConfigurationManager.AppSettings["dbName"];

        private static IMongoDatabase _mongoDatabase;

        private static IMongoCollection<HabrArticle> _habrArticleCollection;

        private static void Connect()
        {

            IMongoClient client = new MongoClient();
            _mongoDatabase = client.GetDatabase(_dbName);

        }

        public static HabrArticle GetHabrArticleByIdFromDb(int habrArticleId)
        {
            Connect();

            _habrArticleCollection = _mongoDatabase?.GetCollection<HabrArticle>(_dbName);

            return _habrArticleCollection?.AsQueryable()?.FirstOrDefault(ha => ha.HabrId == habrArticleId);

        }

        public static List<HabrArticle> GetHabrArticlesFromDb()
        {
            Connect();

            _habrArticleCollection = _mongoDatabase?.GetCollection<HabrArticle>(_dbName);

            return _habrArticleCollection?.AsQueryable().ToList();
        }
        
        public static void AddHabrArticleToDb(HabrArticle habrArticle)
        {
            Connect();

            _habrArticleCollection?.InsertOne(habrArticle);

        }

        public static void DeleteHabrArticleFromDb(int habrArticleId)
        {
            Connect();
 
            _habrArticleCollection.DeleteOne(ha => ha.HabrId == habrArticleId);
           
        }
    }
}