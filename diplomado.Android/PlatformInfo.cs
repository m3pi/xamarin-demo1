using System;
using Android.OS;
using Xamarin.Forms;

[assembly: Dependency(typeof(diplomado.Droid.PlatformInfo))]

namespace diplomado.Droid
{
    public class PlatformInfo:IPlatformInfo
    {
        public string GetModel()
        {
            return String.Format("{0} {1}", Build.Manufacturer,
                                            Build.Model);
        }

        public string GetVersion()
        {
            return Build.VERSION.Release.ToString();
        }
    }
}
