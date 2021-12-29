using System;
namespace BookStoreApi.Models
{
	public class BookStoreDatabaseSettings
	{
		public string ConnectingString { get; set; } = null!;

		public string DatabaseName { get; set; } = null!;

		public string BooksCollectionName { get; set; } = null!;
	}
}

