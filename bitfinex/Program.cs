using Bitfinex.Net.Clients;
using System.Net;;

Console.Write("Введите валюту которую хотели бы проверить. Например (btcusd) => ");
var valute = Console.ReadLine().ToUpper();
Console.Write("Введите время за какой период хотели бы проверить. Например (1m) => ");
var time = Console.ReadLine();

//var url = $"https://api-pub.bitfinex.com/v2/candles/trade:1m:tBTCUSD/hist";
var url = $"https://api-pub.bitfinex.com/v2/candles/trade:{time}:t{valute}/hist";
var request = WebRequest.Create(url);
request.Method = "GET";
using var webResponse = request.GetResponse();
using var webStream = webResponse.GetResponseStream();
using var reader = new StreamReader(webStream);
var data = reader.ReadToEnd();

Console.WriteLine(data + "\n\n" + "Нажмите ENTER что бы посмотреть Тиккеры");
Console.ReadLine();

var clients = new BitfinexSocketClient();
var subscribeResult = await clients.SpotStreams.SubscribeToTickerUpdatesAsync($"t{valute}", data =>
{
    Console.WriteLine("HighPrice = " + data.Data.HighPrice +
                 "\n" + "LastPrice = " + data.Data.LastPrice +
                 "\nLowPrice = " + data.Data.LowPrice +
                 "\nBestBidPrice = " + data.Data.BestBidPrice +
                 "\nBestBidQuantity = " + data.Data.BestBidQuantity +
                 "\nBestAskPrice = " + data.Data.BestAskPrice +
                 "\nDailyChangePercentage = " + data.Data.DailyChangePercentage +
                 "\n-----------------------------------------------------------");
});
Console.ReadLine();