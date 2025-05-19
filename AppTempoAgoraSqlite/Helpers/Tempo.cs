namespace AppTempoAgoraSqlite.Helpers.MauiAppTempoSQLite.Helpers
{
    internal class Tempo
    {
        internal double lat;
        internal double lon;
        internal string? description;
        internal string? main;
        internal double temp_min;
        internal double temp_max;
        internal double speed;
        internal int visibility;
        internal string sunrise;
        internal string sunset;

        public int Id { get; internal set; }
    }
}