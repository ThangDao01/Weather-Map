using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace U57
{
    class OpenWeatherMapProxy
    {
        public async static Task<RootObject> GetWeather(string q)
        {
            var http = new HttpClient();
            var url = String.Format("https://api.openweathermap.org/data/2.5/weather?q="+q+"&appid=9420349c2c7004a98f7e5370d227d4a9");
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObject)serializer.ReadObject(ms);

            return data;
        }
    }
    [DataContract]
    public class Coord
    {
        [DataMember]
        public double lon { get; set; }

        [DataMember]
        public double lat { get; set; }
     
    }
    [DataContract]

    public class Weather
    {
        [DataMember]

        public int id { get; set; }
        [DataMember]

        public string main { get; set; }
        [DataMember]

        public string description { get; set; }

        [DataMember]
        public string icon { get; set; }
    }
    [DataContract]
    public class Sys
    {
        [DataMember]
        public string country { get; set; }
    }

    [DataContract]

    public class RootObject
    {
        [DataMember]

        public Coord coord { get; set; }

        [DataMember]

        public List<Weather> weather { get; set; }


        [DataMember]
        public string name { get; set; }

        [DataMember]

        public Sys sys { get; set; }


    }
}
