using Newtonsoft.Json.Linq;

namespace SurfsUp.Models;
    
public enum DAYS {
    Monday      = 0b0000001,
    Tuesday     = 0b0000010,
    Wednesday   = 0b0000100,
    Thursday    = 0b0001000,
    Friday      = 0b0010000,
    Saturday    = 0b0100000,
    Sunday      = 0b1000000,
    Weekend     = Saturday | Sunday,
    Weekdays    = Monday | Tuesday | Wednesday | Thursday | Friday
}

public struct DayData(float maxTemp, float minTemp, float uvIndex, float windSpd, string date, long unix) {
    public float MaxTemperature = maxTemp;
    public float MinTemperature = minTemp;
    public float UvIndex = uvIndex;
    public float WindSpeed = windSpd;
    public string DateString = date;
    public long DateUnix = unix;

    public override readonly string ToString()
    { return $"{MaxTemperature} / {MinTemperature}"; }
}

public class WeatherData
{
    private Dictionary<DAYS, DayData> _dayData = [];

    /// <summary>
    /// An object containing temps and alike for each day of the week.
    /// </summary>
    /// <param name="init_data">Wether or populate the weather data object with... well, data</param>
    public WeatherData(bool init_data = true) {
        if  (init_data) { UpdateData(); }
    }

    /// <summary>
    /// Update the Weather data object
    /// </summary>
    public void UpdateData() {
        // Fill dict with random test data
        // !TODO ... Replace with some actual weather data
        // Look into: https://openweathermap.org/forecast5 <- This is stinky doodoo >:(
        Random r = new();
        var days = Enum.GetValues<DAYS>();
        _dayData.Clear();

        Dictionary<DAYS, DayData> data = GetWeatherData().GetAwaiter().GetResult();
        foreach (DAYS d in days.Where(d => d != DAYS.Weekdays && d != DAYS.Weekend)) {
            _dayData.Add(d, data[d]);
            // This fucking sucks... double -> string -> float?!?!?!! Fy for helvede >:(            
            //float temp = $"{d}" == $"{DateTime.Now.DayOfWeek}" ? tmp[0] : float.Parse((r.NextDouble() * (-15.0 - 35.5) + 35.5).ToString("0.00"));
            //_dayTemps.Add(d, temp);
        }
    }

    /// <summary>
    /// Get temps for each day.
    /// </summary>
    /// <param name="days">Which day(s) to get temps from (DAYS.Monday | DAYS.Tuesday gets both monday and tuesday).</param>
    /// <returns>A float array with temps for each day, ordered by weekday.</returns>
    public DayData[] GetDayData(DAYS days) {
        List<DayData> data = [];
        var days_list = Enum.GetValues<DAYS>();
        
        foreach (DAYS curr_day in days_list.Where(d => d != DAYS.Weekdays && d != DAYS.Weekend).ToArray()) {
            if (((int)days & (int)curr_day) != 0)
            { data.Add(_dayData[curr_day]); }
        }

        return [.. data];
    }

    private async Task<string> FetchData(string url) {
        using (HttpClient client = new()) {
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            { return await response.Content.ReadAsStringAsync(); }
            else
            { throw new HttpRequestException($"Couldn't fetch the data... whoops... {response.StatusCode}"); }
        }
    }

    private async Task<Dictionary<DAYS, DayData>> GetWeatherData() {
        // Get weather data for the next 7 days B)
        // The latitude and longitude is for Odense
        string _url = string.Format("https://api.open-meteo.com/v1/forecast?latitude={0}&longitude={1}&daily=temperature_2m_max,temperature_2m_min,uv_index_max,wind_speed_10m_max&timeformat=unixtime&timezone=Europe/Berlin", "55.3959", "10.3883");
        string _json = await FetchData(_url);
        NullReferenceException nullrefEx = new("JSON data was null... tihi :)");

        Dictionary<DAYS, DayData> _dataDict = [];
        var _data = JObject.Parse(_json)["daily"] ?? throw nullrefEx;
        // All of this stinky code needs some error checking... but not right now B)
        var _unixStamps = _data["time"] ?? throw nullrefEx;
        for (int i = 0; i < _unixStamps.Count(); i++) {
            long unixSec = Convert.ToInt64(_unixStamps[i]);
            var d = DateTimeOffset.FromUnixTimeSeconds(unixSec).LocalDateTime;
            DAYS dow = (DAYS)Enum.Parse(typeof(DAYS), d.DayOfWeek.ToString());
            
            float? maxTemp = float.Parse(_data["temperature_2m_max"][i].ToString());
            float? minTemp = float.Parse(_data["temperature_2m_min"][i].ToString());
            float? uvIndex = float.Parse(_data["uv_index_max"][i].ToString());
            float? windSpd = float.Parse(_data["wind_speed_10m_max"][i].ToString());

            _dataDict.Add(dow, new(maxTemp ?? -9.9f, minTemp ?? -9.9f, uvIndex ?? -9.9f, windSpd ?? -9.9f, d.Date.ToString("dd MMM"), unixSec));
        }
        return _dataDict;
    }
}