using System;
using BookStoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStoreApi.Services
{
	public class BooksService
	{
		private readonly IMongoCollection<Book> _booksCollection;

		public BooksService(
			IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings)
		{
			var mongoClient = new MongoClient(
				bookStoreDatabaseSettings.Value.ConnectingString);

			var mongoDatabase = mongoClient.GetDatabase(
				bookStoreDatabaseSettings.Value.DatabaseName);

			_booksCollection = mongoDatabase.GetCollection<Book>(
				bookStoreDatabaseSettings.Value.BooksCollectionName);
		}

		//Get function
		public async Task<List<Book>> GetAsync() =>
			await _booksCollection.Find(_ => true).ToListAsync();

		//Get by Id
		public async Task<Book?> GetAsync(string id) =>
			await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

		//Post
		public async Task CreateAsync(Book newBook) =>
			await _booksCollection.InsertOneAsync(newBook);

		//Put
		public async Task UpdateAsync(string id, Book updatedBook) =>
			await _booksCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

		//Delete
		public async Task RemoveAsync(string id) =>
			await _booksCollection.DeleteOneAsync(x => x.Id == id);
    }
}

