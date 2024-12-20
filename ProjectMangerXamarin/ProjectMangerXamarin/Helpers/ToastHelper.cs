using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ProjectMangerXamarin.Helpers
{
    public static class ToastHelper
    {
        public static void Show(string message)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                DependencyService.Get<IToast>().Show(message);
            });
        }
    }

    public interface IToast
    {
        void Show(string message);
    }
}
