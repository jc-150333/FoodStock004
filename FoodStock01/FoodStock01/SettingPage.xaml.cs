using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodStock01
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingPage : ContentPage
	{
        int alert = 0;//SetPickerの値を一時的に保持する

        int select_max;

        DateTime p_hour = new DateTime(DateTime.Now.Hour);

        DateTime p_minute = new DateTime(DateTime.Now.Minute);

        int hour = 1;

        int minute = 1;

        public SettingPage(string title)
        {

            if (SettingModel.SelectSetting() != null)
            {
                //タブに表示される文字列
                Title = title;

                InitializeComponent();
            }
            else
            {
                SettingModel.InsertSetting(1, 3);

                //タブに表示される文字列
                Title = title;

                InitializeComponent();
            }
        }

        /***********通知日数を選択したとき************************************/
        private void SetPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var x = SetPicker.SelectedIndex;

            alert = x + 1;//
        }

        /**********保存ボタンを押した時**************************/
        private void Set_Save_Clicked(object sender, EventArgs e)
        {
            if (alert == 0)
            {
                DisplayAlert("通知日数エラー", "通知日数を選択してください", "OK");
            }
            else
            {
                SettingModel.UpdateSetting(1,alert);
                DisplayAlert("通知日数", alert.ToString(), "OK");
            }
        }

        private void Select_Max_Clicked(object sender, EventArgs e)
        {
            select_max = SettingModel.SelectSetting_Max();

            DisplayAlert("最新の通知日数", select_max.ToString(), "OK");
        }

        private void TPicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }

        private void Time_Button_Clicked(object sender, EventArgs e)
        {
            //p_hour = new DateTime(TPicker.Time.Hours);

            //p_hour = new DateTime(TPicker.Time.Hours);
            

            hour = TPicker.Time.Hours;

            minute = TPicker.Time.Minutes;
            //p_minute = new DateTime(TPicker.Time.Minutes);

            string d = p_hour.ToString();

            string d2 = p_minute.ToString();

            DisplayAlert(d,d2, "OK");

            //int d3 = int.Parse(d);
            
            //int d4 = int.Parse(d2);

            //TimeModel.UpdateTime(d3,d4);
        }
    }
}