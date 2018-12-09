using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using ShopLocation.Data;
using ShopLocation.Services;

namespace ShopLocation
{
    [Activity(Icon = "@drawable/ATB", Theme = "@style/MyTheme")]
    public class AddingShopActivity : Activity
    {
        EditText _number;
        EditText _city;
        EditText _address;
        Button _addShop;
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AddingShop);

            ActionBar.Title = "Добавить магазин в базу";

            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetDisplayHomeAsUpEnabled(true);

            _number = FindViewById<EditText>(Resource.Id.addTextResultNum);
            _city = FindViewById<EditText>(Resource.Id.addTextResultCity);
            _address = FindViewById<EditText>(Resource.Id.addTextResultAdress);
            _addShop = FindViewById<Button>(Resource.Id.addButton);

            _addShop.Click += AddingShopActivity_Click;
            _number.TextChanged += Number_TextChanged;
            _city.TextChanged += City_TextChanged;
            _addShop.Enabled = false;
        }

        private void City_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(_number.Text))
            {
                _addShop.Enabled = true;
            }
        }

        private void Number_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(_city.Text))
            {
                _addShop.Enabled = true;
            }
        }

        private void AddingShopActivity_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(_number.Text) && !string.IsNullOrEmpty(_city.Text))
            {
                var shop = new ShopModel();
                shop.Number = int.Parse(_number.Text);
                shop.City = _city.Text;
                shop.Address = _address.Text;
                if(!DataStore.AddShop(shop))
                {
                    var dialog = new AlertDialog.Builder(this)
                        .SetPositiveButton("Перезаписать", (s, args) => 
                        {
                            DataStore.UpdateShop(shop);
                        })
                        .SetNegativeButton("Отмена", (s, args) => { /* User pressed Ok */ })
                        .SetMessage("Магазин с таким номером есть в базе.")
                        .SetTitle("Error")
                        .Show();
                }
                else
                {
                    var dialog = new AlertDialog.Builder(this)
                        .SetPositiveButton("Ok", (s, args) => { /* User pressed Ok */ })
                        .SetMessage(string.Format("Магазин с №{0} добавлен.", shop.Number))
                        .SetTitle("Info")
                        .Show();
                }
            }
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
    }
}