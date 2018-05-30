using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using MyWeather.View;
using MyWeather.ViewModels;
using Xamarin.Forms;
using static System.Diagnostics.Debug;

namespace MyWeather
{
    public class App : Application
    {
        public App()
        {
            var tabs = new TabbedPage
            {
                Title ="My Dip Weather",
                BindingContext = new WeatherViewModel(),
                Children =
                {
                    new WeatherView(),
                    new ForecastView()
                }
            };


            
            
            MainPage = new NavigationPage(tabs)
            {
                BarBackgroundColor = Color.FromHex("3498db"),
                BarTextColor = Color.White
            };
        }

        protected override void OnStart()
        {
            base.OnStart();

            Microsoft.AppCenter.AppCenter.Start("android=df0f03f9-103c-42c5-b68d-a7d2f5aab1fc" ,
                  //"uwp={Your UWP App secret here};" +
                  //"ios={Your iOS App secret here}",
                  typeof(Analytics), typeof(Crashes));

            WriteLine("Application OnStart");
        }

        protected override void OnSleep()
        {
            base.OnSleep();
            WriteLine("Application OnSleep");
        }

        protected override void OnResume()
        {
            base.OnResume();
            WriteLine("Application OnResume");
        }
    }
}

