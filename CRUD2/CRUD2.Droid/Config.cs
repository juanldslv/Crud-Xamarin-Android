using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinAndroid;
using Xamarin.Forms;


[assembly: Dependency(typeof(CRUD2.Droid.Config))]
namespace CRUD2.Droid
{

        public class Config : IConfig
        {
            private string direc;
            private ISQLitePlatform plata;

        public string DirecotrioDB
        {
            get
            {
                if (string.IsNullOrEmpty(direc))
                {
                    direc = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                return direc;
            }
        }

        

            public ISQLitePlatform Plataforma
            {
                get
                {
                    if (plata == null)
                    {
                        plata = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                    }
                    return plata;

                }


            }

        }
    }