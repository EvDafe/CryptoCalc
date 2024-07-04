using System;
using System.Net;
using System.Web;
using UnityEngine;

namespace Assets.Scripts
{
    public class Test : MonoBehaviour
    {
        private const string API_KEY = "95a02fe4-52f5-4ab4-84aa-236a7e4c43a2";

        private RUB _rub = new();
        private BTC _btc;
        private USD _usd;

        private void Start()
        {
            try
            {
                Debug.Log(MakeAPICall());
            }
            catch (WebException e)
            {
                Debug.Log(e.Message);
            }
        }

        private string MakeAPICall()
        {
            var URL = new UriBuilder("https://sandbox-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["start"] = "1";
            queryString["limit"] = "20000";
            queryString["convert"] = "RUB";
            URL.Query = queryString.ToString();

            var client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
            client.Headers.Add("Accepts", "application/json");

            _rub = JsonUtility.FromJson<RUB>(URL.ToString());

            queryString["convert"] = "USD";
            URL.Query = queryString.ToString();
            _usd = JsonUtility.FromJson<USD>(URL.ToString());

            queryString["convert"] = "BTC";
            URL.Query = queryString.ToString();
            _btc = JsonUtility.FromJson<BTC>(URL.ToString());

            return client.DownloadString(URL.ToString());
        }
    }

    [Serializable]
    public class RUB
    {
        public double? price;
        public int? volume_24h;
        public double? volume_change_24h;
        public double? percent_change_1h;
        public double? percent_change_24h;
        public double? percent_change_7d;
        public double? market_cap;
        public int? market_cap_dominance;
        public double? fully_diluted_market_cap;
        public DateTime? last_updated;
    }

    [Serializable]
    public class USD
    {
        public double? price;
        public int? volume_24h;
        public double? volume_change_24h;
        public double? percent_change_1h;
        public double? percent_change_24h;
        public double? percent_change_7d;
        public double? market_cap;
        public int? market_cap_dominance;
        public double? fully_diluted_market_cap;
        public DateTime? last_updated;
    }

    [Serializable]
    public class BTC
    {
        public double? price;
        public int? volume_24h;
        public double? volume_change_24h;
        public double? percent_change_1h;
        public double? percent_change_24h;
        public double? percent_change_7d;
        public double? market_cap;
        public int? market_cap_dominance;
        public double? fully_diluted_market_cap;
        public DateTime? last_updated;
    }
}
