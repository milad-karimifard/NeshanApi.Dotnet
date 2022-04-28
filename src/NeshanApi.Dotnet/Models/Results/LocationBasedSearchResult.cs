using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NeshanApi.Dotnet.Models.Results
{
    public class LocationBasedSearchResult : IEquatable<LocationBasedSearchResult>
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("items")]
        public List<LocationBasedSearchItem> Items { get; set; }

        #region Equatablity

        public bool Equals(LocationBasedSearchResult other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Count == other.Count && Items == other.Items;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((LocationBasedSearchResult) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Count, Items);
        }

        #endregion
    }
}