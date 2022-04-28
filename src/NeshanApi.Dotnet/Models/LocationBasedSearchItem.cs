using System;
using Newtonsoft.Json;

namespace NeshanApi.Dotnet.Models
{
    public class LocationBasedSearchItem : IEquatable<LocationBasedSearchItem>
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("neighbourhood")]
        public string Neighbourhood { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        #region Equatablity

        public bool Equals(LocationBasedSearchItem other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Title == other.Title &&
                   Address == other.Address &&
                   Neighbourhood == other.Neighbourhood &&
                   Region == other.Region &&
                   Type == other.Type &&
                   Category == other.Category &&
                   Location.Equals(other.Location);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((LocationBasedSearchItem) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Address, Neighbourhood, Region, Type, Category, Location);
        }

        #endregion
    }
}