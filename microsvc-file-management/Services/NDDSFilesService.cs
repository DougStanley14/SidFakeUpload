using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
//using microsvc_file_management.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System.Diagnostics;
namespace microsvc_file_management.Services
{
    public class NDDSFilesService
    {
        private readonly IGridFSBucket _bucket;
        public NDDSFilesService(IOptions<MongoDBSettings> MongoDBSettings)
        {
            //var mongoClient = new MongoClient(MongoDBSettings.Value.ConnectionString);
            //var mongoDatabase = mongoClient.GetDatabase(MongoDBSettings.Value.DatabaseName);
            //_bucket = new GridFSBucket(mongoDatabase);
        }
    }

    public class MongoDBSettings
    {
        public MongoClientSettings ConnectionString { get; internal set; }
        public string DatabaseName { get; internal set; }
    }
}