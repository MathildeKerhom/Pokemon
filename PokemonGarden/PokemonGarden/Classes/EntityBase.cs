using SQLite.Net.Attributes;

namespace PokemonGarden.Classes
{
	public partial class EntityBase
	{
		[PrimaryKey, AutoIncrement]
		[Column("id")]
		public int Id
		{
			get; set;
		}
	}
}