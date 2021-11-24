using System;
using System.Net;
using System.Threading.Channels;

namespace WebSiteDataParser
{
    class Program
    {
        static void Main(string[] args)
        {
            PostData();
            Console.WriteLine("Hello World!");
        }

        public static void PostData()
        {
            string address = "https://www.lesegais.ru/open-area/graphql";
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(address);
            request.Method = "POST";
            request.Host = "www.lesegais.ru";
            request.ContentType = "application/json";
            var result = request.GetResponse();
        }


        public static void PostRequestStart()
        {
            var postRequset = new PostRequest("https://www.lesegais.ru/open-area/graphql");
            postRequset.ContentType = "application/json";
            
            var obj = new {
                query = "query SearchReportWoodDealCount($size: Int!, $number: Int!, $filter: Filter, $orders: [Order!]) {\n  searchReportWoodDeal(filter: $filter, pageable: {number: $number, size: $size}, orders: $orders) {\n    total\n    number\n    size\n    overallBuyerVolume\n    overallSellerVolume\n    __typename\n  }\n}\n",
                variables = new {
                size = 20,
                number =  0,
                filter = ""
            },
               operationName =  "SearchReportWoodDealCount"
            };
            
            // var json = JsonConvert.SerializeObject(obj);
            // var body = new StringContent(json, Encoding.UTF8, "application/json");
            //
            // var response = await client.PostAsync(url, body);
            //
            // var content = await response.Content.ReadAsStringAsync();
            // var watchResponse = JsonConvert.DeserializeObject<WatchResponse>(content);
            //
            // res = JsonConvert.SerializeObject(watchResponse);
        }
    }
}