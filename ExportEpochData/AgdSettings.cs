using ServiceStack.DataAnnotations;

namespace ExportEpochData
{
    [Alias("settings")]
    public class AgdSettings
    {
        [Alias("settingID")]
        [PrimaryKey]
        [AutoIncrement]
        public long Id { get; set; }

        [Alias("settingName")]
        [StringLength(64)]
        public string Name { get; set; }

        [Alias("settingValue")]
        [StringLength(8192)]
        public string Value { get; set; }
    }

    [Alias("data")]
    public class AgdTableTimestampAxis1
    {
        [Alias("dataTimestamp")]
        public long TimestampTicks { get; set; }

        [Alias("axis1")]
        public double Axis1Counts { get; set; }
    }
}