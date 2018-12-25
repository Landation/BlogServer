using Microsoft.AspNetCore.Http;
using Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Common;
namespace Providers
{
    public interface IHostIPProvider
    {
        Task<RemoteInfo> GetRemote(HttpRequest request);
    }

    
    public class HostIPProvider:IHostIPProvider
    {
        private string _host;
        public HostIPProvider(AppSettings settings)
        {
            _host = "http://api.hostip.info/get_json.php";

        }

        public async Task<RemoteInfo> GetRemote(HttpRequest request)
        {
            var ip = "180.167.105.38";//RemoteUtils.IP(request);
            var url = _host + $"?ip={ip}&position=true";

            var response =await new HttpClient().GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var info = JsonConvert.DeserializeObject<IPInfo>(json);
                return new RemoteInfo()
                {
                    Ip = info.ip,
                    Agent = request.Headers["user-agent"],
                    City=info.city,
                    Country=info.country_name,
                    Coordinate = new RemoteInfo.CoordinateInfo {
                        Lat = info.lat,
                        Lng = info.lng
                    }
                };
            }
            return null;     
        }
    }

    public class IPInfo
    {
        public string country_name { get; set; }
        public string country_code { get; set; }
        public string city { get; set; }
        public string ip { get; set; }
        public double? lat { get; set; }
        public double? lng { get; set; }
    }





}
