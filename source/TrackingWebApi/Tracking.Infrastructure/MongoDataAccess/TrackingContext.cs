namespace Tracking.Infrastructure.MongoDataAccess
{
    using MongoDB.Bson.Serialization;
    using MongoDB.Driver;
    using Tracking.Domain;

    public class TrackingContext
    {
        private readonly MongoClient mongoClient;
        private readonly IMongoDatabase database;

        public TrackingContext(string connectionString, string databaseName)
        {
            this.mongoClient = new MongoClient(connectionString);
            this.database = mongoClient.GetDatabase(databaseName);
            Map();
        }

        public IMongoCollection<Domain.Tracking.Order> Orders
        {
            get
            {
                return database.GetCollection<Domain.Tracking.Order>("Orders");
            }
        }

        private void Map()
        {
            BsonClassMap.RegisterClassMap<Entity>(cm =>
            {
                cm.AutoMap();
            });

            BsonClassMap.RegisterClassMap<Domain.Tracking.Order>(cm =>
            {
                cm.AutoMap();
            });
        }
    }
}
