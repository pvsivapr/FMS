using System;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Widget;
using FMS;
using FMS.Droid;
using android = global::Android;
using Android.Text;

[assembly: ExportRenderer(typeof(CustomULineLabelView), typeof(CustomULineLabelViewRender))]
namespace FMS.Droid
{
    public class CustomULineLabelViewRender : ViewRenderer<CustomULineLabelView, LinearLayout>
    {
        public CustomULineLabelViewRender() { }


        protected override void OnElementChanged(ElementChangedEventArgs<CustomULineLabelView> e)
        {
            base.OnElementChanged(e);

            CustomULineLabelView element = new CustomULineLabelView();
            if (e.OldElement != null)
            {
                element = e.OldElement;
                // Unsubscribe
                //cameraPreview.Click -= OnCameraPreviewClicked;
            }
            if (e.NewElement != null)
            {
                element = e.NewElement;
                //Control.Preview = Camera.Open ((int)e.NewElement.Camera);

                // Subscribe
                //cameraPreview.Click += OnCameraPreviewClicked;
            }

            if (Control == null)
            {
                try
                {
                    var customLinearLayout = new LinearLayout(Context);
                    customLinearLayout.SetBackgroundColor(android.Graphics.Color.Green);

                    TextView uLineTextView = new TextView(Context);

                    if (element.ShallUnderLine == true)
                    {
                        int startind = 0, charLength = 0;
                        startind = element.StartIndex;

                        //var label = (TextView)Control;
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
                        }
                        else
                        {

                        }
                        var string2 = element.Text.Substring(element.StartIndex, charLength);
                        var string3 = element.Text.Substring(element.StartIndex + charLength, (element.Text.Length - (element.StartIndex + charLength)));
                        string finalText = "<table><tr><td>" + string1 + "<u>" + string2 + "</u>" + string3 + "</td></tr></table>";
                        uLineTextView.TextFormatted = Html.FromHtml(finalText);
                    }
                    uLineTextView.SetTextColor(android.Graphics.Color.Orchid);
                    uLineTextView.LayoutParameters = new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
                    uLineTextView.SetBackgroundColor(android.Graphics.Color.Yellow);
                    uLineTextView.Gravity = android.Views.GravityFlags.Center;



                    /*//this is also working sample
                    string string1 = "h", string2 = "ell", string3 = "o";
                    string finalText = "<table><tr><td>" + string1 + "<u>" + string2 + "</u>" + string3 + "</td></tr></table>";
                    //string finalText = "<p valign=\"center\">" + string1 + "<u>" + string2 + "</u>" + string3 + "</p>";
                    //uLineTextView.Text = "<back";
                    uLineTextView.TextFormatted = Html.FromHtml(finalText);
                    uLineTextView.SetTextColor(android.Graphics.Color.Orchid);
                    uLineTextView.LayoutParameters = new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
                    //uLineTextView.LayoutParameters = new android.Views.LayoutParameters(LayoutParams.MatchParent, LayoutParams.MatchParent);
                    //uLineTextView.SetForegroundGravity(android.Views.GravityFlags.CenterVertical);
                    uLineTextView.SetBackgroundColor(android.Graphics.Color.Yellow);
                    uLineTextView.Gravity = android.Views.GravityFlags.Center;
                    */



                    customLinearLayout.AddView(uLineTextView);
                    SetNativeControl(customLinearLayout);
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

/*
var customLinearLayout = new LinearLayout(Context);
customLinearLayout.SetBackgroundColor(android.Graphics.Color.Green);


                TextView uLineTextView = new TextView(Context);

                try
                {
                    if (element.ShallUnderLine == true)
                    {
                        int startind = 0, charLength = 0;
startind = element.StartIndex;

                        //var label = (TextView)Control;
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
                        }
                        else
                        {

                        }
                        var string2 = element.Text.Substring(element.StartIndex, charLength);
var string3 = element.Text.Substring(element.StartIndex + charLength, (element.Text.Length - (element.StartIndex + charLength)));

string finalText = "<p valign=\"center\">" + string1 + "<u>" + string2 + "</u>" + string3 + "</p>";
//label.TextFormatted = Html.FromHtml(finalText);

//uLineTextView.Text = "<back";
uLineTextView.TextFormatted = Html.FromHtml(finalText);
                        uLineTextView.SetTextColor(android.Graphics.Color.Orchid);
                        uLineTextView.LayoutParameters = new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
//uLineTextView.LayoutParameters = new android.Views.LayoutParameters(LayoutParams.MatchParent, LayoutParams.MatchParent);
//uLineTextView.SetForegroundGravity(android.Views.GravityFlags.CenterVertical);
uLineTextView.SetBackgroundColor(android.Graphics.Color.Yellow);
                        uLineTextView.Gravity = android.Views.GravityFlags.Center;
                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
                customLinearLayout.AddView(uLineTextView);

				SetNativeControl(customLinearLayout);

*/