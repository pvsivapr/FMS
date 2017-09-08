using System;
using Android.Gms.Maps;
using FMS;
using FMS.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Maps.Android;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRender))]
namespace FMS.Droid
{
    public class CustomMapRender : MapRenderer
    {
        public CustomMapRender()
        {

        }

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Xamarin.Forms.Maps.Map> e)
        {
            base.OnElementChanged(e);
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

#pragma warning disable CS0618 // Type or member is obsolete
            var map = ((MapView)Control).Map;
#pragma warning restore CS0618 // Type or member is obsolete
            //var maps = ((global::Android.Gms.Maps.MapView)Control).Map;
            map.UiSettings.ZoomControlsEnabled = false;
            map.UiSettings.MyLocationButtonEnabled = false;
        }
    }
}

