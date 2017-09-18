using System;
using FMS;
using FMS.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRender))]
namespace FMS.iOS
{
    public class CustomEditorRender : EditorRenderer
    {
        private string Placeholder { get; set; }
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            var element = this.Element as CustomEditor;

            if (Control != null && element != null)
            {
                Placeholder = element.Placeholder;
                Control.TextColor = UIColor.FromRGB(48, 48, 48);
                if (Control.Text == "")
                {
                    Control.Text = Placeholder;
                }

                //Control.Text = Placeholder;

                Control.ShouldBeginEditing += (UITextView textView) =>
                {
                    if (textView.Text == Placeholder)
                    {
                        textView.Text = "";
                        textView.TextColor = UIColor.FromRGB(48, 48, 48); // Text Color
                    }

                    return true;
                };

                Control.ShouldEndEditing += (UITextView textView) =>
                {
                    if (textView.Text == "")
                    {
                        textView.Text = Placeholder;
                        textView.TextColor = UIColor.FromRGB(48, 48, 48); // Placeholder Color
                    }

                    return true;
                };

                Control.Layer.BorderColor = Color.FromHex("#e5e5e5").ToCGColor();

                Control.Layer.MasksToBounds = true;
                Control.Layer.CornerRadius = 1;
                Control.Layer.BorderWidth = 1f;
                Control.Layer.BorderColor = Color.FromHex("#999999").ToCGColor();
                Control.Layer.BackgroundColor = Color.Transparent.ToCGColor();
                Control.SpellCheckingType = UITextSpellCheckingType.No;             // No Spellchecking
                Control.AutocorrectionType = UITextAutocorrectionType.No;           // No Autocorrection
                Control.AutocapitalizationType = UITextAutocapitalizationType.None; // No Autocapitalization
                Control.InputAccessoryView.Hidden = true;//For Removing Done button from editor keyboard.
                Control.KeyboardType = UIKeyboardType.ASCIICapable;//For Removing Emoticons from keyboard.

            }
        }
    }
}