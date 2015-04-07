using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

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
		public ObjectId Id { get; set; }

		public String Title { get; set; }

		public String Description { get; set; }

		public String Genre { get; set; }

		public Author Author { get; set; }

		[BsonDateTimeOptions(DateOnly = true)]
		public DateTime PublicationDate { get; set; }
	}
}
