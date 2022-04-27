using System;
using Newtonsoft.Json;

namespace NeshanApi.Dotnet.Models.Results
{
    public class NeshanReverseGeocodingResult : IEquatable<NeshanReverseGeocodingResult>
    {
        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("neighbourhood")] public string Neighbourhood { get; set; }

        [JsonProperty("municipality_zone")] public string MunicipalityZone { get; set; }

        [JsonProperty("state")] public string State { get; set; }

        [JsonProperty("city")] public string City { get; set; }

        [JsonProperty("in_traffic_zone")] public bool InTrafficZone { get; set; }

        [JsonProperty("in_odd_even_zone")] public bool InOddEvenZone { get; set; }

        [JsonProperty("route_name")] public string RouteName { get; set; }

        [JsonProperty("route_type")] public string RouteType { get; set; }

        [JsonProperty("place")] public string Place { get; set; }

        [JsonProperty("district")] public string District { get; set; }

        [JsonProperty("formatted_address")] public string FormattedAddress { get; set; }

        [JsonProperty("village")] public string Village { get; set; }

        #region Equatablity

        public bool Equals(NeshanReverseGeocodingResult other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Status == other.Status &&
                   Neighbourhood == other.Neighbourhood &&
                   MunicipalityZone == other.MunicipalityZone &&
                   State == other.State &&
                   City == other.City &&
                   InTrafficZone == other.InTrafficZone &&
                   InOddEvenZone == other.InOddEvenZone &&
                   RouteName == other.RouteName &&
                   RouteType == other.RouteType &&
                   Place == other.Place &&
                   District == other.District &&
                   FormattedAddress == other.FormattedAddress &&
                   Village == other.Village;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NeshanReverseGeocodingResult) obj);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Status);
            hashCode.Add(Neighbourhood);
            hashCode.Add(MunicipalityZone);
            hashCode.Add(State);
            hashCode.Add(City);
            hashCode.Add(InTrafficZone);
            hashCode.Add(InOddEvenZone);
            hashCode.Add(RouteName);
            hashCode.Add(RouteType);
            hashCode.Add(Place);
            hashCode.Add(District);
            hashCode.Add(FormattedAddress);
            hashCode.Add(Village);
            return hashCode.ToHashCode();
        }

        #endregion
    }
}