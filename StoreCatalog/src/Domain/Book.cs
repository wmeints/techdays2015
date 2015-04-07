using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using Newtonsoft.Json;

namespace Catalog {
	public class Book {
		public Book() {

		}

		public Book(string title, string description, string genre, Author author, DateTime publicationDate) {
			this.Title = title;
			this.Description = description;
			this.Genre = genre;
			this.Author = author;
			this.PublicationDate = publicationDate;
		}

		[BsonId(IdGenerator = typeof(ObjectIdGenerator))]
		[JsonProperty("id")]
		public ObjectId Id { get; set; }

		[JsonProperty("title")]
		public String Title { get; set; }

		[JsonProperty("description")]
		public String Description { get; set; }

		[JsonProperty("genre")]
		public String Genre { get; set; }

		[JsonProperty("author")]
		public Author Author { get; set; }

		[JsonProperty("publicationDate")]
		[BsonDateTimeOptions(DateOnly = true)]
		public DateTime PublicationDate { get; set; }
	}
}
