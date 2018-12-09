using System.Collections.Generic;

namespace ShopLocation.Data
{
    enum City
    {
        Днепр,
        Камянское,
        ГоришниПлавни,
    }

    internal class ShopsData
    {
        public static Dictionary<int, ShopModel> Shops;
        static ShopsData()
        {
            InitData();
        }

        private static void InitData()
        {
            Shops = new Dictionary<int, ShopModel>();

            Shops.Add(1, new ShopModel()
            {
                Number = 1,
                City = City.Днепр.ToString(),
                Address = "ул. Героев Сталинграда, 111"
            });

            Shops.Add(2, new ShopModel()
            {
                Number = 2,
                City = City.Днепр.ToString(),
                Address = "ул. Казакевича, 5"
            });

            Shops.Add(3, new ShopModel()
            {
                Number = 3,
                City = City.Днепр.ToString(),
                Address = "пгт Юбилейный, ул. 8 Марта, 3"
            });

            Shops.Add(4, new ShopModel()
            {
                Number = 4,
                City = City.Днепр.ToString(),
                Address = "ул. Метростроевская, 12"
            });

            Shops.Add(5, new ShopModel()
            {
                Number = 5,
                City = City.Днепр.ToString(),
                Address = "ул. Щербины, 3"
            });

            Shops.Add(6, new ShopModel()
            {
                Number = 6,
                City = City.Днепр.ToString(),
                Address = "пер. Вольный, 3"
            });

            Shops.Add(7, new ShopModel()
            {
                Number = 7,
                City = City.Днепр.ToString(),
                Address = "ул. Героев Сталинграда, 8"
            });

            Shops.Add(8, new ShopModel()
            {
                Number = 8,
                City = City.Днепр.ToString(),
                Address = "ул. Титова, 29б"
            });

            Shops.Add(9, new ShopModel()
            {
                Number = 9,
                City = City.Днепр.ToString(),
                Address = "ул. Паршина, 16"
            });

            Shops.Add(10, new ShopModel()
            {
                Number = 10,
                City = City.Днепр.ToString(),
                Address = "пр. Кирова, 7"
            });

            Shops.Add(11, new ShopModel()
            {
                Number = 11,
                City = City.Днепр.ToString(),
                Address = "бул. Славы, 17а/20"
            });

            Shops.Add(18, new ShopModel()
            {
                Number = 18,
                City = City.Днепр.ToString(),
                Address = "ж/м Приднепровск, ул. Роторная, 21"
            });

            Shops.Add(20, new ShopModel()
            {
                Number = 20,
                City = City.Днепр.ToString(),
                Address = " пр. имени Газеты Правда, 113"
            });

            Shops.Add(22, new ShopModel()
            {
                Number = 22,
                City = City.Днепр.ToString(),
                Address = "ж/м Западный, ул. Д. Галицкого, 31"
            });


        }
    }
}