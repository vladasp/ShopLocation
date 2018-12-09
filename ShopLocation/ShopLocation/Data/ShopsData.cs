using System.Collections.Generic;

namespace ShopLocation.Data
{
    enum City
    {
        �����,
        ���������,
        �������������,
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
                City = City.�����.ToString(),
                Address = "��. ������ �����������, 111"
            });

            Shops.Add(2, new ShopModel()
            {
                Number = 2,
                City = City.�����.ToString(),
                Address = "��. ����������, 5"
            });

            Shops.Add(3, new ShopModel()
            {
                Number = 3,
                City = City.�����.ToString(),
                Address = "��� ���������, ��. 8 �����, 3"
            });

            Shops.Add(4, new ShopModel()
            {
                Number = 4,
                City = City.�����.ToString(),
                Address = "��. ���������������, 12"
            });

            Shops.Add(5, new ShopModel()
            {
                Number = 5,
                City = City.�����.ToString(),
                Address = "��. �������, 3"
            });

            Shops.Add(6, new ShopModel()
            {
                Number = 6,
                City = City.�����.ToString(),
                Address = "���. �������, 3"
            });

            Shops.Add(7, new ShopModel()
            {
                Number = 7,
                City = City.�����.ToString(),
                Address = "��. ������ �����������, 8"
            });

            Shops.Add(8, new ShopModel()
            {
                Number = 8,
                City = City.�����.ToString(),
                Address = "��. ������, 29�"
            });

            Shops.Add(9, new ShopModel()
            {
                Number = 9,
                City = City.�����.ToString(),
                Address = "��. �������, 16"
            });

            Shops.Add(10, new ShopModel()
            {
                Number = 10,
                City = City.�����.ToString(),
                Address = "��. ������, 7"
            });

            Shops.Add(11, new ShopModel()
            {
                Number = 11,
                City = City.�����.ToString(),
                Address = "���. �����, 17�/20"
            });

            Shops.Add(18, new ShopModel()
            {
                Number = 18,
                City = City.�����.ToString(),
                Address = "�/� ������������, ��. ��������, 21"
            });

            Shops.Add(20, new ShopModel()
            {
                Number = 20,
                City = City.�����.ToString(),
                Address = " ��. ����� ������ ������, 113"
            });

            Shops.Add(22, new ShopModel()
            {
                Number = 22,
                City = City.�����.ToString(),
                Address = "�/� ��������, ��. �. ���������, 31"
            });


        }
    }
}