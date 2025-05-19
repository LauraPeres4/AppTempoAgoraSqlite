using AppTempoAgoraSqlite.Helpers.MauiAppTempoSQLite.Helpers;
using Newtonsoft.Json.Linq;

internal static class DataServiceHelpers
{
    public static async Task<Tempo?> GetPrevisao(string cidade, JObject rascunho)
    {
        Tempo? t = null;

        string chave = "6135072afe7f6cec1537d5cb08a5a1a2";

        string url = $"https://api.openweathermap.org/data/2.5/weather?" +
                     $"q={cidade}&units=metric&appid={chave}";

        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage resp = await client.GetAsync(url);

            if (resp.IsSuccessStatusCode)
            {
                string json = await resp.Content.ReadAsStringAsync();

                JObject jObject = JObject.Parse(json);

                DateTime time = new();
                DateTime sunrise = time.AddSeconds((double)((JObject?)jObject)["sys"]["sunrise"]).ToLocalTime();
                DateTime sunset = time.AddSeconds((double)((JObject?)jObject)["sys"]["sunset"]).ToLocalTime();

                t = new()
                {
                    lat = (double)((JObject?)jObject)["coord"]["lat"],
                    lon = (double)((JObject?)jObject)["coord"]["lon"],
                    description = (string)((JObject?)jObject)["weather"][0]["description"],
                    main = (string)((JObject?)jObject)["weather"][0]["main"],
                    temp_min = (double)((JObject?)jObject)["main"]["temp_min"],
                    temp_max = (double)((JObject?)jObject)["main"]["temp_max"],
                    speed = (double)((JObject?)jObject)["wind"]["speed"],
                    visibility = (int)((JObject?)jObject)["visibility"],
                    sunrise = sunrise.ToString(),
                    sunset = sunset.ToString(),
                }; // Fecha obj do Tempo.
            } // Fecha if se o status do servidor foi de sucesso
        } // fecha laço using

        return t;
    }
}