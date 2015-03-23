using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StoreCatalog.ViewModels
{
    public class UpdateBookRequestData
    {
        [JsonProperty("title")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a valid title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("genre")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a valid genre")]
        public string Genre { get; set; }

        [JsonProperty("authors")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide the authors")]
        public List<AuthorMetadata> Authors { get; set; }

        [JsonProperty("format")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a valid format")]
        public string Format { get; set; }

        [JsonProperty("language")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a language")]
        public string Language { get; set; }

        [JsonProperty("price")]
        [Range(0.01, Double.MaxValue, ErrorMessage ="Please provide a valid price")]
        public double Price { get; set; }
    }
}