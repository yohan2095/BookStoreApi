﻿using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

//Creates the Data Structure
namespace BookStoreApi.Models
{
	public class Book
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public String? Id { get; set; }

		[BsonElement("Name")]
		public string BookName { get; set; } = null!;

		public decimal Price { get; set; }

		public string Category { get; set; } = null!;

		public string Author { get; set; } = null!;
	}
}

