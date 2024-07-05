using System;

namespace Assets.Scripts
{
    [Serializable]
    public class ConvertationData
    {
        public string ToCurrencyName;
        public string FromCurrencyName;
        public CurrencyType ToCurrencyType;
        public CurrencyType FromCurrencyType;
        public decimal ToAmount;
        public decimal FromAmount;
    }
}
