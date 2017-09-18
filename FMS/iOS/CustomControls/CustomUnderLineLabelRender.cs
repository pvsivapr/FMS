using System;
using FMS;
using FMS.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomUnderLineLabel), typeof(CustomUnderLineLabelRender))]
namespace FMS.iOS
{
    public class CustomUnderLineLabelRender : LabelRenderer
    {
        public CustomUnderLineLabelRender()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            CustomUnderLineLabel element = Element as CustomUnderLineLabel;
            if (e.NewElement != null)
            {
                element = Element as CustomUnderLineLabel;
            }
            else
            {
                element = e.OldElement as CustomUnderLineLabel;
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
                        var htmlString = @"<a href='http://xamarin.com/'>Xamarin</a>";
                        var error = new NSError();
                        var docAttributes = new NSAttributedStringDocumentAttributes()
                        {
                            StringEncoding = NSStringEncoding.UTF8,
                            DocumentType = NSDocumentType.HTML
                        };
                        //var AttributedText = new NSAttributedString(htmlString, docAttributes, ref error);
                        //text.AddAttribute(AttributedText);

                        Control.AttributedText = new NSAttributedString(htmlString, docAttributes, ref error);

                        /*
                       NSMutableAttributedString footerText = new NSMutableAttributedString(element.Text, new UIStringAttributes
                       {
                           ForegroundColor = UIColor.White,

                           Link = new NSUrl("https://www.google.com")
                       });

                       //Set footext
                       Control.AttributedText = footerText;
                       */

                        /*
                        if (element.NoOfChar == 0 && element.EndIndex == 0)
                        {
                            charLength = element.Text.Length;
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
                            charLength = element.Text.Length;
                        }


                        var string1 = element.Text.Substring(0, element.StartIndex);
                        if (string1 == "<")
                        {
                            string1 = "&lt;";
                            //&lt; or &#60;
                        }
                        else
                        {

                        }
                        var string2 = element.Text.Substring(element.StartIndex, Convert.ToInt32(charLength));
                        var string3 = element.Text.Substring(Convert.ToInt32(element.StartIndex + charLength), Convert.ToInt32((element.Text.Length - (element.StartIndex + charLength))));

                        //string finalText = "<p valign=\"center\">" + string1 + "<u>" + string2 + "</u>" + string3 + "</p>";
                        //string finalText = "<table><tr><td>" + string1 + "<u>" + string2 + "</u>" + string3 + "</td></tr></table>"; ;
                        string htmlLink = "<table><tr><td>" + string1 + "<u>" + "<a href=\"https://www.google.co.in\">" + string2 + "</a>" + "</u>" + string3 + "</td></tr></table>";

                        //var link = "http://www.google.com";
                        //var htmlLink = String.Format("<a href='{0}'>{1}</a>", link, link);

                        var attr = new NSAttributedStringDocumentAttributes()
                        {
                            DocumentType = NSDocumentType.HTML,
                            StringEncoding = NSStringEncoding.UTF8
                        };

                        var nsError = new NSError();

                        Control.UserInteractionEnabled = true;
                        //MyTextView.Editable = false;
                        Control.AttributedText = new NSAttributedString(htmlLink, attr, ref nsError);
                        */


                        /*
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
                        */

                        /*
                        var range = new NSRange(startind, charLength);
                        UIStringAttributes attrHyperlink = new UIStringAttributes()
                        {
                            Link = new NSUrl("https://ryder.com/terms-of-use")
                        };
                        attrHyperlink.UnderlineStyle = NSUnderlineStyle.Single;
                        attrHyperlink.ForegroundColor = UIColor.Purple;

                        NSMutableAttributedString attString = new NSMutableAttributedString(text);
                        text.AddAttributes(attrHyperlink, range);
                        this.UserInteractionEnabled = true;
                        */

                        /*//this is original from website
                        UIStringAttributes attrHyperlink = new UIStringAttributes();
                        attrHyperlink.UnderlineStyle = NSUnderlineStyle.Single;
                        attrHyperlink.ForegroundColor = UIColor.Purple.CGColor;


                        NSMutableAttributedString attString = new NSMutableAttributedString(StringValue);
                        attString.AddAttributes(attrHyperlink, new NSRange(0, StringValue.Length));
                        MyTextView.AttributedText = attString;
                        */
                        //NSMutableAttributedString attString = new NSMutableAttributedString(text);
                        //attString.AddAttributes(attrHyperlink, range);
                        //text.AttributedText = attString;

                        //text.AddAttribute(UIStringAttributeKey.UnderlineStyle, NSNumber.FromInt32((int)NSUnderlineStyle.Single), range);

                        /*
                        NSMutableAttributedString footerText = new NSMutableAttributedString(myFooterText, new UIStringAttributes
                        {
                            ForegroundColor = UIColor.White,

                            Link = new NSUrl(myLinkString)
                        });

                        //Set footext
                        MyTextView.AttributedText = footerText;
                        */
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

