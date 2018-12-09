using System.IO;

namespace ShopLocation.Data
{
    public static class Strings
    {
        private static string _assetsFileName = "Shops.json";
        public static string AssetsFileName
        {
            get
            {
                return _assetsFileName;
            }
        }

        private static string _sourceFileName = "shops.json";
        public static string SourceFileName
        {
            get
            {
                return _sourceFileName;
            }
        }

        private static string _path = Android.OS.Environment.ExternalStorageDirectory.ToString() + "/ATB/";

        public static string CustomPath
        {
            get
            {
                return _path;
            }
        }

        private static string _sourcePath = Path.Combine(_path, _sourceFileName);

        public static string SourcePath
        {
            get
            {
                return _sourcePath;
            }
        }
    }
}