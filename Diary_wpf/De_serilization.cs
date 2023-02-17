using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Diary_wpf
{
    public static class De_serilization
    {
        public static void Serialization<T>(T models)
        {
            string json = JsonConvert.SerializeObject(models);
            File.WriteAllText("C:\\Users\\paulscriptum\\source\\repos\\Diary_wpf\\Diary_wpf\\Storage.json", json);
        }

        public static T Deserialize<T>()
        {
            string json = File.ReadAllText("C:\\Users\\paulscriptum\\source\\repos\\Diary_wpf\\Diary_wpf\\Storage.json");
            T models = JsonConvert.DeserializeObject<T>(json);
            return models;
        }
    }
}
