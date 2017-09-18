using System;
using FMS.iOS;
using FMS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRender))]
namespace FMS.iOS
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

                if (Control != null)
                {
                    // do whatever you want to the UITextField here
                    //var element = Element as CustomEntry;
                    Control.BorderStyle = UITextBorderStyle.Line;
                    Control.Layer.CornerRadius = 0;
                    Control.ExclusiveTouch = true;
                    //Control.MinimumFontSize = 15f;
                    Control.AdjustsFontSizeToFitWidth = true;
                    Control.TextColor = UIColor.Black;//for place holder
                                                      //var entry1 = new Entry();
                                                      //Control.Layer.BorderColor = Color.FromHex("#0000").ToCGColor();
                                                      //Control.Layer.BorderWidth = 0;
                                                      //entry1.Layer.BorderWidth = 1f;
                                                      //Control.TintColor = UIColor.Gray;
                                                      //Control.TintColor = Color.FromHex(element.BorderColors).ToUIColor();
                    Control.TintColor = UIColor.Gray;
                    Control.Layer.BorderWidth = 1f;
                    //Control.Layer.BorderColor = Color.FromHex(element.BorderColors).ToCGColor();
                    if (element.BorderColors == "#ff0000")
                    {
                        Control.Layer.BorderColor = Color.Red.ToCGColor();
                    }
                    else if (element.BorderColors == "#6C6C6C")
                    {
                        Control.Layer.BorderColor = Color.Gray.ToCGColor();
                    }

                    //Layer.BorderColor = Color.FromHex("F78F1E").ToCGColor();
                    //Layer.BorderWidth = 0.1f;
                    //Control.TintColor = Color.FromHex("#F78F1E").ToUIColor();
                    if (element.CustomFontFamily == "Avenir65")
                    {
                        Control.Font = UIFont.FromName("AvenirLTStd-Medium.ttf", 20.0f);
                    }
                    else if (element.CustomFontFamily == "Avenir45")
                    {
                        Control.Font = UIFont.FromName("AvenirLTStd-Book.ttf", 20.0f);
                    }
                    else
                    {
                    }
                    if (element.CustomFontSize != 0)
                    {
                        UIFont font = Control.Font.WithSize(element.CustomFontSize);
                        Control.Font = font;
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
                if (Control != null)
                {
                    // do whatever you want to the UITextField here
                    //var element = Element as CustomEntry;
                    Control.BorderStyle = UITextBorderStyle.Line;
                    Control.Layer.CornerRadius = 0;
                    Control.ExclusiveTouch = true;
                    //Control.MinimumFontSize = 15f;
                    Control.AdjustsFontSizeToFitWidth = true;
                    Control.TextColor = UIColor.Black;//for place holder
                                                      //var entry1 = new Entry();
                                                      //Control.Layer.BorderColor = Color.FromHex("#0000").ToCGColor();
                                                      //Control.Layer.BorderWidth = 0;
                                                      //entry1.Layer.BorderWidth = 1f;
                                                      //Control.TintColor = UIColor.Gray;
                                                      //Control.TintColor = Color.FromHex(element.BorderColors).ToUIColor();
                    Control.TintColor = UIColor.Gray;
                    Control.Layer.BorderWidth = 1f;
                    //Control.Layer.BorderColor = Color.FromHex(element.BorderColors).ToCGColor();
                    if (element.BorderColors == "#ff0000")
                    {
                        Control.Layer.BorderColor = Color.Red.ToCGColor();
                    }
                    else if (element.BorderColors == "#6C6C6C")
                    {
                        Control.Layer.BorderColor = Color.Gray.ToCGColor();
                    }
                    //Control.Layer.BorderColor = Color.FromHex("F78F1E").ToCGColor();
                    //Control.Layer.BorderWidth = 0.1f;
                    //Control.TintColor = Color.FromHex("#F78F1E").ToUIColor();
                    if (element.CustomFontFamily == "Avenir65")
                    {
                        Control.Font = UIFont.FromName("AvenirLTStd-Medium.ttf", 20.0f);
                    }
                    else if (element.CustomFontFamily == "Avenir45")
                    {
                        Control.Font = UIFont.FromName("AvenirLTStd-Book.ttf", 20.0f);
                    }
                    else
                    {
                    }
                    if (element.CustomFontSize != 0)
                    {
                        UIFont font = Control.Font.WithSize(element.CustomFontSize);
                        Control.Font = font;
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