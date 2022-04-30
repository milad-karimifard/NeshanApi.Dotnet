using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NeshanApi.Dotnet.Models.Results
{
    public class NeshanDirectionResult : IEquatable<NeshanDirectionResult>
    {
        [JsonProperty("routes")]
        public List<Route> Routes { get; set; }

        #region Equatablity

        public bool Equals(NeshanDirectionResult other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Routes.Equals(other.Routes);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NeshanDirectionResult) obj);
        }

        public override int GetHashCode()
        {
            return (Routes != null ? Routes.GetHashCode() : 0);
        }

        #endregion
    }
}