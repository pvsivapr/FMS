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
                Text = "Alert",
                FontSize = 15,
                MinimumHeightRequest = (screenHeight * 20) / 100,
                FontAttributes = FontAttributes.Bold,
                //BackgroundColor = Color.Maroon,
                //HorizontalOptions = LayoutOptions.FillAndExpand,
                //VerticalOptions = LayoutOptions.CenterAndExpand
            };
            lblErrorMsg = new Label()
            {
                Text = "",
                FontSize = 13,
                MinimumHeightRequest = (screenHeight * 20) / 100,
                //HorizontalOptions = LayoutOptions.CenterAndExpand,
                //VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Button btnAcceptMSG = new Button()
            {
                Text = "OK",
                //HeightRequest = (screenHeight * 10) / 100
            };
            btnAcceptMSG.Clicked += CloseMsgDisplay;

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
                    //new ColumnDefinition{ Width=new GridLength(0.2, GridUnitType.Star)},
                    new ColumnDefinition{ Width=new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition{ Width=new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition{ Width=new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition{ Width=new GridLength(1, GridUnitType.Star)},
                    //new ColumnDefinition{ Width=new GridLength(0.2, GridUnitType.Star)}
                },
                RowSpacing = 0,
                //Padding = new Thickness(0, 0, 0, 0),
                //BackgroundColor = Color.Green,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            //gridErrorMsgHolder.Children.Add(frameBackground, 0, 6, 0, 3);
            gridErrorMsgHolder.Children.Add(lblErrorTitle, 0, 4, 0, 1);
            gridErrorMsgHolder.Children.Add(lblErrorMsg, 0, 4, 1, 2);

            Frame frameBackground = new Frame()
            {
                HasShadow = false,
                BindingContext = gridErrorMsgHolder,
                BackgroundColor = Color.White,
                OutlineColor = Color.White,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };


            Grid gridHolder = new Grid()
            {
                RowDefinitions =
                {
                    //new RowDefinition{ Height = GridLength.Auto}
                    new RowDefinition{ Height = new GridLength(1, GridUnitType.Star)}
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star)},
                },
                RowSpacing = 0,
                //BackgroundColor = Color.Yellow,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            gridHolder.Children.Add(frameBackground, 0, 0);
            gridHolder.Children.Add(gridErrorMsgHolder, 0, 0);

            stackDisplayHolder = new StackLayout()
            {
                Children = { gridHolder },
                IsVisible = true,
                //BackgroundColor = AppGlobalVariables.Transparent,
                //Padding = new Thickness((screenWidth * 10) / 100, (screenHeight * 10) / 100, (screenWidth * 10) / 100, (screenHeight * 10) / 100)
            };

            if (Device.OS == TargetPlatform.iOS)
            {
                gridHolder.WidthRequest = (screenWidth * 70) / 100;
                gridHolder.Padding = new Thickness((screenWidth * 5) / 100, 0, (screenWidth * 5) / 100, 0);
                frameBackground.CornerRadius = 10;
                frameBackground.BackgroundColor = AppGlobalVariables.iOSAlertBg;
                frameBackground.WidthRequest = (screenWidth * 70) / 100;
                gridErrorMsgHolder.WidthRequest = (screenWidth * 70) / 100;
                gridErrorMsgHolder.Padding = new Thickness((screenWidth * 5) / 100, (screenWidth * 5) / 100, (screenWidth * 5) / 100, (screenWidth * 0) / 100);
                lblErrorTitle.HorizontalTextAlignment = TextAlignment.Center;
                lblErrorTitle.VerticalTextAlignment = TextAlignment.Center;
                lblErrorTitle.HorizontalOptions = LayoutOptions.CenterAndExpand;
                lblErrorTitle.VerticalOptions = LayoutOptions.CenterAndExpand;
                lblErrorMsg.HorizontalTextAlignment = TextAlignment.Center;
                lblErrorMsg.VerticalTextAlignment = TextAlignment.Center;
                lblErrorMsg.HorizontalOptions = LayoutOptions.FillAndExpand;
                lblErrorMsg.VerticalOptions = LayoutOptions.CenterAndExpand;
                stackDisplayHolder.BackgroundColor = Color.FromHex("#25000000");
                btnAcceptMSG.HeightRequest = (screenHeight * 6) / 100;
                btnAcceptMSG.BackgroundColor = AppGlobalVariables.Transparent;
                btnAcceptMSG.TextColor = AppGlobalVariables.iOSAlertBtnText;
                btnAcceptMSG.HorizontalOptions = LayoutOptions.FillAndExpand;
                btnAcceptMSG.VerticalOptions = LayoutOptions.CenterAndExpand;
                gridErrorMsgHolder.Children.Add(btnAcceptMSG, 0, 4, 2, 3);
            }
            else if (Device.OS == TargetPlatform.Android)
            {
                gridHolder.WidthRequest = (screenWidth * 90) / 100;
                gridHolder.Padding = new Thickness((screenWidth * 3) / 100, 0, (screenWidth * 3) / 100, 0);
                frameBackground.CornerRadius = 3;
                frameBackground.BackgroundColor = AppGlobalVariables.DroidAlertBg;
                frameBackground.WidthRequest = (screenWidth * 90) / 100;
                gridErrorMsgHolder.WidthRequest = (screenWidth * 90) / 100;
                gridErrorMsgHolder.Padding = new Thickness((screenWidth * 5) / 100, (screenWidth * 5) / 100, (screenWidth * 5) / 100, (screenWidth * 2) / 100);
                lblErrorTitle.HorizontalTextAlignment = TextAlignment.Start;
                lblErrorTitle.VerticalTextAlignment = TextAlignment.Center;
                lblErrorTitle.HorizontalOptions = LayoutOptions.StartAndExpand;
                lblErrorTitle.VerticalOptions = LayoutOptions.CenterAndExpand;
                lblErrorMsg.HorizontalTextAlignment = TextAlignment.Start;
                lblErrorMsg.VerticalTextAlignment = TextAlignment.Center;
                lblErrorMsg.HorizontalOptions = LayoutOptions.StartAndExpand;
                lblErrorMsg.VerticalOptions = LayoutOptions.CenterAndExpand;
                stackDisplayHolder.BackgroundColor = Color.FromHex("#30000000");
                btnAcceptMSG.HeightRequest = (screenHeight * 8) / 100;
                btnAcceptMSG.BackgroundColor = AppGlobalVariables.DroidAlertBtnBg;
                btnAcceptMSG.TextColor = AppGlobalVariables.DroidAlertBtnText;
                btnAcceptMSG.HorizontalOptions = LayoutOptions.End;
                btnAcceptMSG.VerticalOptions = LayoutOptions.Center;
                gridErrorMsgHolder.Children.Add(btnAcceptMSG, 3, 4, 2, 3);
            }
            else
            {
            }
            //frameBackground.SetBinding(Frame.HeightRequestProperty, new Binding("HeightRequest"));
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