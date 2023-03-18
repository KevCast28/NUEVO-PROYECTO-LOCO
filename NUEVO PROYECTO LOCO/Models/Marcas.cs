using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NUEVO_PROYECTO_LOCO.Models
{
    public class Marcas
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("nombre")]
        public string? nombre { get; set; }
        [BsonElement("year")]
        public int? year { get; set; }
    }
}
