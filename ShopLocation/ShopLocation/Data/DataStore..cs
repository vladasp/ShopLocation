using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ShopLocation.Data;

namespace ShopLocation.Services
{
    public static class DataStore
    {
        static private List<ShopModel> _listOfShops;

        static DataStore()
        {
            _listOfShops = new List<ShopModel>();
        }

        public static void Create(List<ShopModel> shops)
        {
            _listOfShops = shops;
        }

        public static bool AddShop(ShopModel model)
        {
            if(_listOfShops.Any(shop => shop.Number == model.Number))
            {
                return false;
            }
            else
            {
                _listOfShops.Add(model);
                SaveData();
                return true;
            }
        }

        public static void AddShops(List<ShopModel> shops)
        {
        }

        public static void DeleteSHop(ShopModel model)
        {
            
        }

        public static List<ShopModel>  GetAllShops()
        {
            return _listOfShops;
        }

        public static ShopModel GetShop(int Id)
        {
            return _listOfShops.FirstOrDefault(shop => shop.Number == Id);
        }

        public static void UpdateShop(ShopModel model)
        {
            _listOfShops.Remove(_listOfShops.Find(shop => shop.Number == model.Number));
            _listOfShops.Add(model);
            SaveData();
        }

        static void SaveData()
        {
            using (var streamWriter = new StreamWriter(Strings.SourcePath, false))
            {
                var json = JsonConvert.SerializeObject(_listOfShops);
                streamWriter.WriteLine(json);
            }
        }
    }
}