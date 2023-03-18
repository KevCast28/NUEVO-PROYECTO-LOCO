using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NUEVO_PROYECTO_LOCO.Models;

namespace NUEVO_PROYECTO_LOCO.Services
{
    public class MarcasServices
    {
        private readonly IMongoCollection<Marcas> _brandsCollection;

        public MarcasServices(IOptions<telefoniaDBSettings> telefoniaDBSettings)
        {
            MongoClient mongoClient = new MongoClient(telefoniaDBSettings.Value.Server);
            var database = mongoClient.GetDatabase(telefoniaDBSettings.Value.Database);
            _brandsCollection = database.GetCollection<Marcas>(telefoniaDBSettings.Value.CollectionBrands);
        }

        public async Task<List<Marcas>> FindAsync() =>
            await _brandsCollection.Find(_ => true).ToListAsync();
        
        public async Task<Marcas> FindById (string id) =>
            await _brandsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task Insert(Marcas brandNew) =>
            await _brandsCollection.InsertOneAsync(brandNew);

        public async Task UpdateOne(string id, Marcas brandUpdated) =>
            await _brandsCollection.ReplaceOneAsync(x => x.Id == id, brandUpdated);

        public async Task DeleteOne(string id) =>
            await _brandsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
