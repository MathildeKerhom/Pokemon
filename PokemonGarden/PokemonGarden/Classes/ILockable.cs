namespace PokemonGarden.Classes
{
	public interface ILockable
	{
		/// <summary>
		/// enable / disable object
		/// </summary>
		bool IsEnable
		{
			get;
			set;
		}
	}
}