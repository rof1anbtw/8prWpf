using Newtonsoft.Json;

namespace JsonDeser
{
    public class JsonDeser
    {
        public static T Deserealize<T>()
        {
            string json = File.ReadAllText("C:\\Users\\percy\\source\\repos\\pr8Wpf\\pr8Wpf\\json.json");
            T list = JsonConvert.DeserializeObject<T>(json);
            return list;
        }
        public static void Serial<T>(T list)
        {
            string json = JsonConvert.SerializeObject(list);
            File.WriteAllText("C:\\Users\\percy\\source\\repos\\pr8Wpf\\pr8Wpf\\json.json", json);

        }
    }
}