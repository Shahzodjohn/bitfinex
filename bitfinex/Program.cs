using Bitfinex.Net.Clients;


Console.Write("Enter a value you want to get trade hsitory. Instance (btcusd) => ");
var valute = Console.ReadLine().ToUpper();

var bitfinexClient = new BitfinexClient();

var symbolData = await bitfinexClient.SpotApi.ExchangeData.GetTradeHistoryAsync($"t{valute}");
foreach (var symbol in symbolData.Data)
    Console.WriteLine("ID = " + symbol.Id + 
        "\nTimestamp = " + symbol.Quantity + 
        "\nTimestamp = " + symbol.Price + 
        "\nTimestamp = " + symbol.Timestamp +
        "\n----------------------------------------");
Console.WriteLine("Press enter to  get tickers ...");
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