using DevExpress.Utils.Filtering.Internal;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Client.Api
{
    internal class MongoDB
    {
        private static readonly Lazy<MongoDB> _instance = 
            new Lazy<MongoDB>(() => new MongoDB());

        private readonly IMongoDatabase _database;

        public static MongoDB Instance => _instance.Value;

        private MongoDB()
        {
            var client = new MongoClient("mongodb+srv://wnstjd637:45wnstjd%21%21@cluster0.lr0j6ui.mongodb.net/?appName=Cluster0");

            _database = client.GetDatabase("chat_auth");
        }

        public IMongoCollection<Model.UserModel> Users =>
            _database.GetCollection<Model.UserModel>("users");
    }
}
