// Generated by https://quicktype.io

namespace Scraper
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class WebhallenCard
    {
        [JsonProperty("products")]
        public Product[] Products { get; set; }

        [JsonProperty("totalProductCount")]
        public long TotalProductCount { get; set; }
    }

    public partial class Product
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }

        [JsonProperty("stock")]
        public Stock Stock { get; set; }



    }


   

    public partial class Price
    {
        [JsonProperty("price")]
        public string PricePrice { get; set; }

        [JsonProperty("currency")]
        public Currency Currency { get; set; }

        [JsonProperty("vat")]
        public double Vat { get; set; }

        [JsonProperty("type")]
        public object Type { get; set; }

        [JsonProperty("endAt")]
        public DateTimeOffset EndAt { get; set; }

        [JsonProperty("maxQtyPerCustomer")]
        public object MaxQtyPerCustomer { get; set; }
    }

    public partial class Release
    {
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("format")]
        public Format Format { get; set; }
    }

    public partial class Stock
    {
        [JsonProperty("1")]
        public long The1 { get; set; }

        [JsonProperty("2")]
        public long The2 { get; set; }

        [JsonProperty("5")]
        public long The5 { get; set; }

        [JsonProperty("8")]
        public long The8 { get; set; }

        [JsonProperty("9")]
        public long The9 { get; set; }

        [JsonProperty("10")]
        public long The10 { get; set; }

        [JsonProperty("11")]
        public long The11 { get; set; }

        [JsonProperty("14")]
        public long The14 { get; set; }

        [JsonProperty("15")]
        public long The15 { get; set; }

        [JsonProperty("16")]
        public long The16 { get; set; }

        [JsonProperty("19")]
        public long The19 { get; set; }

        [JsonProperty("20")]
        public long The20 { get; set; }

        [JsonProperty("21")]
        public long The21 { get; set; }

        [JsonProperty("22")]
        public long The22 { get; set; }

        [JsonProperty("23")]
        public long The23 { get; set; }

        [JsonProperty("26")]
        public long The26 { get; set; }

        [JsonProperty("27")]
        public long The27 { get; set; }

        [JsonProperty("28")]
        public long The28 { get; set; }

        [JsonProperty("29")]
        public long The29 { get; set; }

        [JsonProperty("web")]
        public long Web { get; set; }

        [JsonProperty("supplier")]
        public long? Supplier { get; set; }

        [JsonProperty("displayCap")]
        [JsonConverter(typeof(DecodingChoiceConverter))]
        public long DisplayCap { get; set; }

        [JsonProperty("orders", NullValueHandling = NullValueHandling.Ignore)]
        public OrdersUnion? Orders { get; set; }
    }

    public partial class OrdersClass
    {
        [JsonProperty("2", NullValueHandling = NullValueHandling.Ignore)]
        public The2 The2 { get; set; }

        [JsonProperty("CL", NullValueHandling = NullValueHandling.Ignore)]
        public Cl Cl { get; set; }

        [JsonProperty("22", NullValueHandling = NullValueHandling.Ignore)]
        public The2 The22 { get; set; }
    }

    public partial class Cl
    {
        [JsonProperty("status")]
        public long Status { get; set; }
    }

    public partial class The2
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("days_since")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long DaysSince { get; set; }
    }

    public enum CategoryTree { DatorkomponenterGrafikkortGpuGeForceGtxRtx };



    public enum Currency { Sek };

    public enum Format { YMD };

    public partial struct OrdersUnion
    {
        public long? Integer;
        public OrdersClass OrdersClass;

        public static implicit operator OrdersUnion(long Integer) => new OrdersUnion { Integer = Integer };
        public static implicit operator OrdersUnion(OrdersClass OrdersClass) => new OrdersUnion { OrdersClass = OrdersClass };
    }

    public partial class WebhallenCard
    {
        public static WebhallenCard FromJson(string json) => JsonConvert.DeserializeObject<WebhallenCard>(json, Scraper.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this WebhallenCard self) => JsonConvert.SerializeObject(self, Scraper.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                CategoryTreeConverter.Singleton,
                CurrencyConverter.Singleton,
                FormatConverter.Singleton,
                OrdersUnionConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class CategoryTreeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(CategoryTree) || t == typeof(CategoryTree?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Datorkomponenter/Grafikkort GPU/GeForce GTX/RTX")
            {
                return CategoryTree.DatorkomponenterGrafikkortGpuGeForceGtxRtx;
            }
            throw new Exception("Cannot unmarshal type CategoryTree");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (CategoryTree)untypedValue;
            if (value == CategoryTree.DatorkomponenterGrafikkortGpuGeForceGtxRtx)
            {
                serializer.Serialize(writer, "Datorkomponenter/Grafikkort GPU/GeForce GTX/RTX");
                return;
            }
            throw new Exception("Cannot marshal type CategoryTree");
        }

        public static readonly CategoryTreeConverter Singleton = new CategoryTreeConverter();
    }

   
        



    

    internal class CurrencyConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Currency) || t == typeof(Currency?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "SEK")
            {
                return Currency.Sek;
            }
            throw new Exception("Cannot unmarshal type Currency");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Currency)untypedValue;
            if (value == Currency.Sek)
            {
                serializer.Serialize(writer, "SEK");
                return;
            }
            throw new Exception("Cannot marshal type Currency");
        }

        public static readonly CurrencyConverter Singleton = new CurrencyConverter();
    }

    internal class FormatConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Format) || t == typeof(Format?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Y-m-d")
            {
                return Format.YMD;
            }
            throw new Exception("Cannot unmarshal type Format");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Format)untypedValue;
            if (value == Format.YMD)
            {
                serializer.Serialize(writer, "Y-m-d");
                return;
            }
            throw new Exception("Cannot marshal type Format");
        }

        public static readonly FormatConverter Singleton = new FormatConverter();
    }

    internal class DecodingChoiceConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                    var integerValue = serializer.Deserialize<long>(reader);
                    return integerValue;
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    long l;
                    if (Int64.TryParse(stringValue, out l))
                    {
                        return l;
                    }
                    break;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value);
            return;
        }

        public static readonly DecodingChoiceConverter Singleton = new DecodingChoiceConverter();
    }

    internal class OrdersUnionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(OrdersUnion) || t == typeof(OrdersUnion?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                    var integerValue = serializer.Deserialize<long>(reader);
                    return new OrdersUnion { Integer = integerValue };
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<OrdersClass>(reader);
                    return new OrdersUnion { OrdersClass = objectValue };
            }
            throw new Exception("Cannot unmarshal type OrdersUnion");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (OrdersUnion)untypedValue;
            if (value.Integer != null)
            {
                serializer.Serialize(writer, value.Integer.Value);
                return;
            }
            if (value.OrdersClass != null)
            {
                serializer.Serialize(writer, value.OrdersClass);
                return;
            }
            throw new Exception("Cannot marshal type OrdersUnion");
        }

        public static readonly OrdersUnionConverter Singleton = new OrdersUnionConverter();
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}