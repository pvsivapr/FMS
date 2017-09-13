using System;

using Xamarin.Forms;
using System.Threading.Tasks;
using System.Net;

namespace FMS
{
    public abstract class BaseContentPage : ContentPage
    {
        public AbsoluteLayout contentLayout;
        public ActivityIndicator aiLoader;
        public StackLayout PageLoading, stackDisplayHolder, PageControlsStackLayout;
        Label lblErrorTitle, lblErrorMsg;

        public static int screenHeight, screenWidth;

        public BaseContentPage()
        {
            this.BackgroundColor = Color.Transparent;

            aiLoader = new ActivityIndicator
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Color = Color.White,
                //BackgroundColor = Color.FromRgba (0, 0, 0, 0.3),
                IsEnabled = true,
                IsVisible = true,
                IsRunning = true,
            };

            contentLayout = new AbsoluteLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            PageLoading = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.FromRgba(0, 0, 0, 0.4),
                //BackgroundColor = Color.Transparent,
                IsVisible = false,
                Children = { aiLoader }
            };
            lblErrorTitle = new Label()
            {
                Text = "",
                MinimumHeightRequest = (screenHeight * 20) / 100,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            lblErrorMsg = new Label()
            {
                Text = "",
                MinimumHeightRequest = (screenHeight * 20) / 100,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Button btnAcceptMSG = new Button()
            {
                Text = "OK",
                HeightRequest = (screenHeight * 10) / 100,
                BackgroundColor = AppGlobalVariables.Gray,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            btnAcceptMSG.Clicked += CloseMsgDisplay;

            Frame frameBackground = new Frame()
            {
                HasShadow = false,
                CornerRadius = 10,
                WidthRequest = (screenWidth * 80) / 100,
                BackgroundColor = Color.White,
                OutlineColor = Color.White,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            Grid gridErrorMsgHolder = new Grid()
            {
                RowDefinitions =
                {
                    new RowDefinition{ Height = GridLength.Auto},
                    new RowDefinition{ Height = GridLength.Auto},
                    new RowDefinition{ Height = GridLength.Auto}
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition{ Width=new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition{ Width=new GridLength(1, GridUnitType.Star)}
                },
                RowSpacing = 0,
                WidthRequest = (screenWidth * 80) / 100,
                Padding = new Thickness(0, 0, 0, 0),
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            gridErrorMsgHolder.Children.Add(frameBackground, 0, 2, 0, 3);
            gridErrorMsgHolder.Children.Add(lblErrorMsg, 0, 2, 1, 2);
            gridErrorMsgHolder.Children.Add(lblErrorTitle, 0, 2, 0, 1);
            gridErrorMsgHolder.Children.Add(btnAcceptMSG, 0, 2, 2, 3);

            stackDisplayHolder = new StackLayout()
            {
                Children = { gridErrorMsgHolder },
                IsVisible = false,
                BackgroundColor = AppGlobalVariables.Transparent,
                Padding = new Thickness((Width * 10) / 100, (screenHeight * 10) / 100, (Width * 10) / 100, (screenHeight * 10) / 100)
            };

            PageControlsStackLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                //                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0),
                Spacing = 0
            };
            AbsoluteLayout.SetLayoutFlags(PageControlsStackLayout, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(PageControlsStackLayout, new Rectangle(0, 0, 1, 1));
            contentLayout.Children.Add(PageControlsStackLayout);

            AbsoluteLayout.SetLayoutFlags(stackDisplayHolder, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(stackDisplayHolder, new Rectangle(0.5, 0.5, 1, 1));
            contentLayout.Children.Add(stackDisplayHolder);

            AbsoluteLayout.SetLayoutFlags(PageLoading, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(PageLoading, new Rectangle(0.5, 0.5, 1, 1));
            contentLayout.Children.Add(PageLoading);
            Content = contentLayout;
        }

        public void DisplayCustomAlert(string Title, FormattedString message)
        {
            lblErrorTitle.Text = Title;
            lblErrorMsg.FormattedText = message;
            stackDisplayHolder.IsVisible = true;
        }

        void CloseMsgDisplay(object sender, EventArgs e)
        {
            stackDisplayHolder.IsVisible = false;
        }

        public void DisplayThisAlert(string Title, string message)
        {
            DisplayAlert(Title, message, "OK");
        }

        public void DisplayThisAlert(string message)
        {
            DisplayAlert("Alert", message, "OK");
        }

        public async Task<bool> DisplayThisChoice(string Title, string message)
        {
            var response = await DisplayAlert(Title, message, "OK", "Cancel");
            return response;
        }

        public async Task<bool> DisplayThisChoice(string message)
        {
            var response = await DisplayAlert("Alert", message, "OK", "Cancel");
            return response;
        }
    }
}

