using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using Newtonsoft.Json;
using ShopLocation.Data;
using ShopLocation.Services;

namespace ShopLocation
{
    [Activity(Icon = "@drawable/ATB",  ScreenOrientation = Android.Content.PM.ScreenOrientation.Landscape, Theme ="@style/MyTheme")]
    public class MainActivity : Activity
    {
        private EditText textInputNum;
        private EditText textResultNum;
        private EditText textResultCity;
        private EditText textResultAdress;
        private Button buttonGetAdress;
        private List<ShopModel> initList;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            ActionBar.Title = "Поиск АТБ";

            try
            {
                if (!File.Exists(Strings.SourcePath))
                {
                    AssetManager assets = Assets;
                    StreamReader stream = null;
                    //Open assets sourse
                    var ass = assets.Open(Strings.AssetsFileName, Access.Streaming);
                    stream = new StreamReader(ass);

                    //Check directory
                    if (!File.Exists(Strings.CustomPath))
                    {
                        Directory.CreateDirectory(Strings.CustomPath);
                    }

                    //Write data to directory 
                    using (var streamWriter = new StreamWriter(Strings.SourcePath, true))
                    {
                        streamWriter.WriteLine(stream.ReadToEnd());
                    }
                }
                string dataString = default(string);

                //Read data from directory 
                using (var reader = new StreamReader(Strings.SourcePath))
                {
                    dataString = reader.ReadToEnd();
                }

                JsonSerializerSettings settings = new JsonSerializerSettings();
                var datas = JsonConvert.DeserializeObject<List<ShopModel>>(dataString);
                initList = datas;
            }
            catch (Exception ex)
            {
            }

            DataStore.Create(initList);

            buttonGetAdress = FindViewById<Button>(Resource.Id.buttonGetAdress);
            textInputNum = FindViewById<EditText>(Resource.Id.editTextInputNum);
            textResultNum = FindViewById<EditText>(Resource.Id.editTextResultNum);
            textResultCity = FindViewById<EditText>(Resource.Id.editTextResultCity);
            textResultAdress = FindViewById<EditText>(Resource.Id.editTextResultAdress);

            textResultNum.Enabled = false;
            textResultCity.Enabled = false;
            textResultAdress.Enabled = false;

            buttonGetAdress.Click += ButtonGetAdress_Click;
            textInputNum.Click += TextInputNum_Click; 
        }

        protected override void OnStart()
        {
            base.OnStart();
            textInputNum.Text = string.Empty;
            ClearEditFields();
        }

        private void TextInputNum_Click(object sender, EventArgs e)
        {
            textInputNum.Text = string.Empty;
            ClearEditFields();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_edit:
                    StartActivity(new Intent(this, typeof(AddingShopActivity)));
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        private void ButtonGetAdress_Click(object sender, EventArgs e)
        {
            HideKeyboard();

            int number;
            if(ValidateInputData(textInputNum.Text, out number))
            {
                //TODO: Find from parsed data
                ShopModel shop = DataStore.GetShop(number);

                if(shop != null)
                {
                    textResultNum.LayoutParameters.Height = ViewGroup.LayoutParams.WrapContent;
                    textResultCity.LayoutParameters.Height = ViewGroup.LayoutParams.WrapContent;
                    textResultAdress.LayoutParameters.Height = ViewGroup.LayoutParams.WrapContent;

                    textResultNum.Text = string.Format("Номер магазина - {0}", shop.Number);
                    textResultCity.Text = string.Format("Город - {0}", shop.City);
                    textResultAdress.Text = string.Format("Адрес - {0}", shop.Address);
                }
                else
                {
                    var dialog = new AlertDialog.Builder(this)
                            .SetPositiveButton("Ok", (s, args) => { ClearEditFields(); })
                            .SetMessage("Нет такого номера в базе")
                            .SetTitle("Error")
                            .Show();
                }
            }
            else
            {
                var dialog = new AlertDialog.Builder(this)
                            .SetPositiveButton("Ok", (s, args) => { ClearEditFields(); })
                            .SetMessage("Проверте корректность ввода")
                            .SetTitle("Error")
                            .Show();
            }
        }

        void ClearEditFields()
        {
            textResultNum.Text = "Номер магазина";
            textResultCity.Text = "Город";
            textResultAdress.Text = "Адрес";
        }

        bool ValidateInputData(string numberStr, out int number)
        {
            return int.TryParse(numberStr, out number);
        }

        void HideKeyboard()
        {
            InputMethodManager inputManager = (InputMethodManager)GetSystemService(InputMethodService);
            inputManager.HideSoftInputFromWindow(CurrentFocus.WindowToken, HideSoftInputFlags.NotAlways);
        }

    }
}