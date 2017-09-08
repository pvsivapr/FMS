using System;
using Android.Graphics;
using Android.Widget;
using FMS;
using FMS.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Support.V4.App;
using Android.OS;
using Android.Text;
using Android.Text.Style;

[assembly: ExportRenderer(typeof(CustomUlineLabel), typeof(CustomUlineLabelRender))]
namespace FMS.Droid
{
    public class CustomUlineLabelRender : LabelRenderer
    {
        public CustomUlineLabelRender()
        { }

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
                        int startind = 0, charLength = 0;
                        startind = element.StartIndex;

                        var label = (TextView)Control;
                        /*
                        //this below line underlines the entire text
                        label.PaintFlags |= PaintFlags.UnderlineText;
                        */

                        var text = element.Text;
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
                        var string1 = element.Text.Substring(0, element.StartIndex);
                        if (string1 == "<")
                        {
                            string1 = "&lt;";
                            //&lt; or &#60;
                        }
                        else
                        {

                        }
                        var string2 = element.Text.Substring(element.StartIndex, charLength);
                        var string3 = element.Text.Substring(element.StartIndex + charLength, (element.Text.Length - (element.StartIndex + charLength)));

                        string finalText = "<p>" + string1 + "<u>" + string2 + "</u>" + string3 + "</p>";
                        label.TextFormatted = Html.FromHtml(finalText);


                        SpannableString mySpannableString = new SpannableString("My String");
                        mySpannableString.SetSpan(new UnderlineSpan(), mySpannableString.Length(), 0, SpanTypes.Paragraph);
                        label.TextFormatted = mySpannableString;


                        //                        // the below line has to be like if(Build.VERSION.SdkInt >= Build.VERSION_CODES.LollipopMr1)
                        //                        //if(Build.VERSION.SdkInt >= Build.VERSION_CODES.LollipopMr1)
                        //                        if (Build.VERSION.SdkInt > Build.VERSION_CODES.N)
                        //                        {
                        //#pragma warning disable CS0618 // Type or member is obsolete
                        //                            label.SetText(Html.FromHtml(Resources.GetString(Resource.String.registerText)));
                        //#pragma warning restore CS0618 // Type or member is obsolete
                        //                        }
                        //                        else
                        //                        {
                        //                            //label.SetText(Html.FromHtml("<h2>Title</h2><br><p>Description here</p>", Html.FromHtmlModeCompact));
                        //                            //label.setText(Html.fromHtml(bodyData,Html.FROM_HTML_MODE_LEGACY));
                        //                        }

                        /*
                        t.setText(first + next, BufferType.SPANNABLE);
                        Spannable s = (Spannable)t.getText();
                        int start = first.length();
                        int end = start + next.length();
                        s.setSpan(new ForegroundColorSpan(0xFFFF0000), start, end, Spannable.SPAN_EXCLUSIVE_EXCLUSIVE);
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

