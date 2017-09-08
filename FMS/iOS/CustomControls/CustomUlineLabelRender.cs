using System;
using FMS;
using FMS.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomUlineLabel), typeof(CustomUlineLabelRender))]
namespace FMS.iOS
{
    public class CustomUlineLabelRender : LabelRenderer
    {
        public CustomUlineLabelRender()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            CustomUlineLabel element = Element as CustomUlineLabel;
            if (e.NewElement != null)
            {
                element = Element as CustomUlineLabel;
            }
            else
            {
                element = e.OldElement as CustomUlineLabel;
            }
            if (Control != null)
            {
                try
                {
                    if (element.ShallUnderLine == true)
                    {
                        nint startind = 0, charLength = 0;
                        startind = element.StartIndex;

                        var label = (UILabel)Control;
                        var text = (NSMutableAttributedString)label.AttributedText;
                        if (element.NoOfChar == 0 && element.EndIndex == 0)
                        {
                            charLength = text.Length;
                        }
                        else if (element.EndIndex != 0 && element.NoOfChar != 0)
                        {
                            charLength = element.NoOfChar;
                        }
                        else if (element.EndIndex == 0)
                        {
                            charLength = element.NoOfChar;
                        }
                        else if (element.NoOfChar == 0)
                        {
                            charLength = element.EndIndex - element.StartIndex;
                        }
                        else
                        {
                            charLength = text.Length;
                        }
                        var range = new NSRange(startind, charLength);
                        text.AddAttribute(UIStringAttributeKey.UnderlineStyle, NSNumber.FromInt32((int)NSUnderlineStyle.Single), range);
                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }
    }
}

