using System.Net;
using Newtonsoft.Json.Linq;

namespace ClashRoyale.Server.Managers
{
    internal class LocationManager
    {
        private readonly string BaseJSON;
        private readonly IPEndPoint Endpoint;

        private readonly JObject Object;

        public LocationManager(IPEndPoint Endpoint)
        {
            this.Endpoint = Endpoint;

            using (var Client = new WebClient())
            {
                BaseJSON = Client.DownloadString("http://ip-api.com/json/" + this.Endpoint.Address);
                Object = JObject.Parse(BaseJSON);
            }
        }

        internal string GetRegion => IsSuccess ? Object["region"].ToObject<string>() : "NJ";

        internal string GetCity => IsSuccess ? Object["city"].ToObject<string>() : "Clifton";

        internal string GetCountryCode => IsSuccess ? Object["countryCode"].ToObject<string>() : "US";

        internal bool IsSuccess
        {
            get
            {
                var Status = Object["status"].ToObject<string>();

                return Status == "success";
            }
        }
    }
}