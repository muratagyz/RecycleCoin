namespace RecycleCoin.UI.Utilities.CoinConvert;

public static class Convert
{
    public static decimal RecycleCoinToCarbon(decimal carbonValue)
    {
        return (decimal)(carbonValue * 100000000);
    }

    public static decimal CarbonToRecycleCoin(decimal recycleValue)
    {
        return (decimal)(recycleValue  /100000000);
    }
}