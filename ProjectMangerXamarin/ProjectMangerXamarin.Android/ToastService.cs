using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ProjectMangerXamarin.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(ProjectMangerXamarin.Droid.ToastService))]
namespace ProjectMangerXamarin.Droid
{
    public class ToastService : IToast
    {
        public void Show(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
        }
    }
}