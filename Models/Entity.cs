using MongoDB.Bson;

namespace Models
{
    public class Entity : IEntity
    {
		public ObjectId Id { get; set; }
	}

	public interface IEntity
	{
		
	}
}