using System;
using FMS;
using FMS.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Foundation;
using CoreText;

[assembly: ExportRenderer(typeof(CustomUnderLineLabelView), typeof(CustomUnderLineLabelViewRender))]
namespace FMS.iOS
{
    public class CustomUnderLineLabelViewRender : ViewRenderer<CustomUnderLineLabelView, UIView>
    {
        public CustomUnderLineLabelViewRender() { }
        //this render is not working properly you have to check this onces
        protected override void OnElementChanged(ElementChangedEventArgs<CustomUnderLineLabelView> e)
        {
            base.OnElementChanged(e);

            CustomUnderLineLabelView element = new CustomUnderLineLabelView();
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

            UIView customUIView = new UIView()
            {
                BackgroundColor = Color.Green.ToUIColor(),
            };
            customUIView.BackgroundColor = UIColor.Green;

            UILabel uLineUILabel = new UILabel()
            {
            };
            uLineUILabel.BackgroundColor = Color.Accent.ToUIColor();

            if (Control == null)
            {
                try
                {
                    if (element.ShallUnderLine == true)
                    {
                        nint startind = 0, charLength = 0;
                        startind = element.StartIndex;

                        //var label = (UILabel)Control;
                        //var text = (NSMutableAttributedString)label.AttributedText;

                        var text = new NSMutableAttributedString(element.Text);
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
                        //text.AddAttribute(UIStringAttributeKey.StrikethroughStyle, NSNumber.FromInt32((int)NSUnderlineStyle.Single), new NSRange(0, attrString.Length));
                        //var attrString = new NSAttributedString("The text",   strikethroughStyle: NSUnderlineStyle.Single);

                        uLineUILabel.AttributedText = text;


                        customUIView.AddSubview(uLineUILabel);
                        SetNativeControl(customUIView);
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

