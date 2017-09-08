using System;
using FMS;
using FMS.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Maps.iOS;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRender))]
namespace FMS.iOS
{
	public class CustomMapRender : MapRenderer
	{
		public CustomMapRender(){}

		protected override void OnElementChanged(Xamarin.Forms.Platform.iOS.ElementChangedEventArgs<View> e)
		{
			base.OnElementChanged(e);
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
		}
	}
}
