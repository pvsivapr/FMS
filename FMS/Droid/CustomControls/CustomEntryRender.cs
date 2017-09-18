using System;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Text;
using Android.Text.Method;
using Android.Util;
using FMS.Android;
using FMS;
using FMS.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Graphicss = Android.Graphics;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRender))]
namespace FMS.Android
{
    public class CustomEntryRender : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            try
            {
                CustomEntry element = Element as CustomEntry;
                if (e.NewElement != null)
                {
                    element = Element as CustomEntry;
                }
                else
                {
                    element = e.OldElement as CustomEntry;
                }
                if (element.IsCustomPassword == true)
                {
                    Control.TransformationMethod = PasswordTransformationMethod.Instance;
                    //Control.InputType = InputTypes.TextVariationPassword;
                    //Control.InputType = InputTypes.TextVariationPassword | InputTypes.ClassText;
                }
                if (Control != null)
                {
                    //var element = Element as CustomEntry;

                    GradientDrawable gd = new GradientDrawable();
                    //gd.SetCornerRadius(45); // increase or decrease to changes the corner look
                    gd.SetColor(global::Android.Graphics.Color.Transparent);
                    //global::Android.Graphics.Color color = ColorExtensions.ToAndroid(element.BorderColors);
                    //var color = global::Android.Graphics.Color.ParseColor(element.BorderColors);
                    //gd.SetStroke(2, color);
                    gd.SetStroke(2, global::Android.Graphics.Color.ParseColor(element.BorderColors));
                    //gd.SetStroke(2, global::Android.Graphics.Color.Gray);
                    this.Control.SetBackgroundDrawable(gd);
                    this.Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
                    //Control.SetHintTextColor(ColorStateList.ValueOf(global::Android.Graphics.Color.Black));//for placeholder  
                    //this.Control.InputType = InputTypes.TextVariationPassword;
                    if (element.CustomFontSize != 0.0)
                    {
                        Control.SetTextSize(ComplexUnitType.Dip, element.CustomFontSize);
                    }
                    if (element.CustomFontFamily == "Avenir65")
                    {
                        Graphicss.Typeface font = Graphicss.Typeface.CreateFromAsset(Forms.Context.Assets, "AvenirLTStd-Medium.ttf");
                        Control.Typeface = font;
                    }
                    else if (element.CustomFontFamily == "Avenir45")
                    {
                        Graphicss.Typeface font = Graphicss.Typeface.CreateFromAsset(Forms.Context.Assets, "AvenirLTStd-Book.ttf");
                        Control.Typeface = font;
                    }
                    else
                    {
                    }

                    if (element.IsPhoneNumber == true)
                    {
                        Control.SetRawInputType(global::Android.Text.InputTypes.ClassPhone);
                    }
                    else if (element.IsNumeric == true)
                    {
                        Control.SetRawInputType(global::Android.Text.InputTypes.ClassNumber);
                    }
                    else if (element.IsEmail == true)
                    {
                        Control.SetRawInputType(global::Android.Text.InputTypes.TextVariationEmailAddress);
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            try
            {
                CustomEntry element = Element as CustomEntry;

                if (element.IsCustomPassword == true)
                {
                    Control.TransformationMethod = PasswordTransformationMethod.Instance;

                    //Control.InputType = InputTypes.TextVariationPassword;
                    //Control.InputType = InputTypes.TextVariationPassword | InputTypes.ClassText;
                }
                else
                {
                    Control.TransformationMethod = HideReturnsTransformationMethod.Instance; //PasswordTransformationMethod.Instance;
                }
                if (Control != null)
                {
                    //var element = Element as CustomEntry;

                    GradientDrawable gd = new GradientDrawable();
                    //gd.SetCornerRadius(45); // increase or decrease to changes the corner look
                    gd.SetColor(global::Android.Graphics.Color.Transparent);
                    //global::Android.Graphics.Color color = ColorExtensions.ToAndroid(element.BorderColors);
                    //var color = global::Android.Graphics.Color.ParseColor(element.BorderColors);
                    //gd.SetStroke(2, color);
                    gd.SetStroke(2, global::Android.Graphics.Color.ParseColor(element.BorderColors));
                    //gd.SetStroke(2, global::Android.Graphics.Color.Gray);
                    this.Control.SetBackgroundDrawable(gd);
                    this.Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
                    //Control.SetHintTextColor(ColorStateList.ValueOf(global::Android.Graphics.Color.Black));//for placeholder  
                    //this.Control.InputType = InputTypes.TextVariationPassword;
                    if (element.CustomFontSize != 0.0)
                    {
                        Control.SetTextSize(ComplexUnitType.Dip, element.CustomFontSize);
                    }
                    if (element.CustomFontFamily == "Avenir65")
                    {
                        Graphicss.Typeface font = Graphicss.Typeface.CreateFromAsset(Forms.Context.Assets, "AvenirLTStd-Medium.ttf");
                        Control.Typeface = font;
                    }
                    else if (element.CustomFontFamily == "Avenir45")
                    {
                        Graphicss.Typeface font = Graphicss.Typeface.CreateFromAsset(Forms.Context.Assets, "AvenirLTStd-Book.ttf");
                        Control.Typeface = font;
                    }
                    else
                    {
                    }

                    if (element.IsPhoneNumber == true)
                    {
                        Control.SetRawInputType(global::Android.Text.InputTypes.ClassPhone);
                    }
                    else if (element.IsNumeric == true)
                    {
                        Control.SetRawInputType(global::Android.Text.InputTypes.ClassNumber);
                    }
                    else if (element.IsEmail == true)
                    {
                        Control.SetRawInputType(global::Android.Text.InputTypes.TextVariationEmailAddress);
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
    }
}


