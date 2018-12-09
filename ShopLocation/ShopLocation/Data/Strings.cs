using Android.OS;
using System.IO;
using Java.IO;

namespace ShopLocation.Data
{
    public static class Strings
    {
        public const string AssetsFileName = "Shops.json";

        public const string SourceFileName = "shops.json";

        public static string CustomPath { get; set; }

        public static string SourcePath => Path.Combine(CustomPath, SourceFileName);
    }
}