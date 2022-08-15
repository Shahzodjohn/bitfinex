using Bitfinex.Net.Clients;
using Bitfinex.Net.Enums;


var clients = new BitfinexSocketClient();
var bitfinexClient = new BitfinexClient();
Console.Write("Enter a value you want to get trade hsitory. Instance (btcusd) => ");
var valute = Console.ReadLine().ToUpper();

var orderBookData = await bitfinexClient.SpotApi.ExchangeData.GetOrderBookAsync("tBTCUST", Precision.PrecisionLevel0);

var sunscribe = await clients.SpotStreams.SubscribeToOrderBookUpdatesAsync("tBTCUST", Precision.PrecisionLevel0, Frequency.Realtime, 25, data =>
{
    
});

var symbolData = await bitfinexClient.SpotApi.ExchangeData.GetTradeHistoryAsync($"t{valute}");
foreach (var symbol in symbolData.Data)
    Console.WriteLine("ID = " + symbol.Id + 
        "\nTimestamp = " + symbol.Quantity + 
        "\nTimestamp = " + symbol.Price + 
        "\nTimestamp = " + symbol.Timestamp +
        "\n----------------------------------------");
Console.WriteLine("Press enter to  get tickers ...");
Console.ReadLine();



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