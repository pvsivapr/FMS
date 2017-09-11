using Android.Graphics;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;
using ag = Android.Graphics;
using Android.OS;
using Android.Views.InputMethods;
using Android.App;
using Android.Views;
using FMS;
using FMS.Droid;
using Graphicss = Android.Graphics;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEdiotrRenderer))]
namespace FMS.Droid
{
	public class CustomEdiotrRenderer : EditorRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
				var element = e.NewElement as CustomEditor;
				this.Control.Hint = element.Placeholder;
				this.Control.SetHintTextColor(ag.Color.Gray);
				this.Control.SetBackgroundColor(global::Android.Graphics.Color.White);
				this.Control.SetCursorVisible(true);
				//if (Control != null)
				//{
					Graphicss.Drawables.GradientDrawable gd = new Graphicss.Drawables.GradientDrawable();
					gd.SetColor(global::Android.Graphics.Color.Transparent);
					gd.SetStroke(2, global::Android.Graphics.Color.Gray);
					this.Control.SetBackgroundDrawable(gd);
				//}
				//	this.Control.Background = this.Resources.GetDrawable(Resource.Drawable.withBorder);
			}

			// This line do the trick
			//			Control.FocusChange += Control_FocusChange;
		}

		void Control_FocusChange(object sender, FocusChangeEventArgs e)
		{
			if (e.HasFocus)
			{
				if (Xamarin.Forms.Application.Current.Properties.ContainsKey("count"))
				{
					int ct = Convert.ToInt32(App.Current.Properties["count"]);
					if (ct > 1)
					{
						(Forms.Context as Activity).Window.SetSoftInputMode(SoftInput.AdjustPan);
					}
					else
					{
						(Forms.Context as Activity).Window.SetSoftInputMode(SoftInput.AdjustResize);
					}
				}

			}
			else
			{
				(Forms.Context as Activity).Window.SetSoftInputMode(SoftInput.AdjustNothing);
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == CustomEditor.PlaceholderProperty.PropertyName)
			{
				var element = this.Element as CustomEditor;
				this.Control.Hint = element.Placeholder;
				this.Control.SetHintTextColor(ag.Color.ParseColor("#e5e5e5"));
			}

			if (Control != null)
			{
				Graphicss.Drawables.GradientDrawable gd = new Graphicss.Drawables.GradientDrawable();
				gd.SetColor(global::Android.Graphics.Color.Transparent);
				gd.SetStroke(2, global::Android.Graphics.Color.Gray);
				this.Control.SetBackgroundDrawable(gd);
			}
		}
	}
}


