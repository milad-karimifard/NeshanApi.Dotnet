using System;
using Newtonsoft.Json;

namespace NeshanApi.Dotnet.Models
{
    public class Duration : IEquatable<Duration>
    {
        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        #region Equatablity

        public bool Equals(Duration other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value == other.Value && Text == other.Text;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Duration) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Text);
        }

        #endregion
    }
}