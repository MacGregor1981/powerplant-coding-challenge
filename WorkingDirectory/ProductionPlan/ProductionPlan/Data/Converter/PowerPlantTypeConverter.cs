using ProductionPlan.Data.Enums;

namespace ProductionPlan.Data.Converter
{
    //public class PowerPlantTypeConverter : JsonConverter
    //{
    //    public override bool CanConvert(Type objectType)
    //    {
    //        return objectType == typeof(string);
    //    }

    //    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    //    {
    //        if(reader.Value is null)
    //            return null;
    //        var enumString = (string)reader.Value;

    //        return Enum.Parse(typeof(PowerPlantType), enumString, true);
    //    }

    //    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    //    {
    //        if (value is null) return;
    //        PowerPlantType pppt = (PowerPlantType)value;

    //        switch(pppt) 
    //        {
    //            case PowerPlantType.windturbine:
    //                writer.WriteValue("windturbine");
    //                break;
    //            case PowerPlantType.turbojet:
    //                writer.WriteValue("turbojet");
    //                break;
    //            case PowerPlantType.gasfired:
    //                writer.WriteValue("gasfired");
    //                break;
    //        }


    //    }
    //}
}
