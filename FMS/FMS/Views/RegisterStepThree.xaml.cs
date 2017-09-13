using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FMS
{
    public partial class RegisterStepThree : BaseContentPage
    {
        public RegisterStepThree()
        {
            #region for local variables
            int height = (screenHeight * 1) / 100;
            int width = (screenWidth * 1) / 100;
            #endregion
            InitializeComponent();

            #region for Custom Style

            #region for Entry styles
            Resources = new ResourceDictionary();

            var styleEntryInput = new Style(typeof(CustomEntry))
            {
                Setters = {
                    new Setter { Property = CustomEntry.PlaceholderColorProperty, Value = AppGlobalVariables.Black  },
                    new Setter { Property = CustomEntry.TextColorProperty, Value = AppGlobalVariables.Black  },
                    new Setter { Property = CustomEntry.IsPasswordProperty, Value = true  },
                    new Setter { Property = CustomEntry.BackgroundColorProperty, Value = Color.White  },
                    new Setter { Property = CustomEntry.HeightRequestProperty, Value = height * 8  },
                    new Setter { Property = CustomEntry.HorizontalOptionsProperty, Value = LayoutOptions.FillAndExpand  },
                    new Setter { Property = CustomEntry.VerticalOptionsProperty, Value = LayoutOptions.Start  }
                }
            };
            Resources.Add("styleEntryInput", styleEntryInput);
            #endregion

            #endregion

            #region for Header
            CustomUlineLabel lblBackBtn = new CustomUlineLabel()
            {
                Text = "<back",
                StartIndex = 1,
                NoOfChar = 4,
                EndIndex = 5,
                ShallUnderLine = true,
                HeightRequest = height * 8,
                Margin = new Thickness(0, Device.OnPlatform(height * 0, height * 1.5, height * 2.5), 0, 0),
                FontSize = Device.OnPlatform(height * 2.3, height * 2.5, height * 2.5),
                TextColor = AppGlobalVariables.Black,
                //BackgroundColor = Color.Yellow,
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            var stakBack = new StackLayout
            {
                Children = { lblBackBtn },
                Padding = new Thickness(0, 5, 0, 5)
            };
            Label lblStepNo = new Label()
            {
                Text = "STEP 3:",
                HeightRequest = height * 8,
                //BackgroundColor = Color.Green,
                FontAttributes = FontAttributes.Bold,
                //BackgroundColor = Color.Green,
                FontSize = Device.OnPlatform(height * 3, height * 3, height * 3),
                TextColor = AppGlobalVariables.Black,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            var lblPageTitle = new Label
            {
                Text = "Create a password",
                TextColor = AppGlobalVariables.Black,
                //BackgroundColor = Color.Maroon,
                FontAttributes = FontAttributes.Bold,
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start
            };

            Grid gridHeader = new Grid()
            {
                RowDefinitions =
                {
                    new RowDefinition{ Height = new GridLength(1, GridUnitType.Star)},
                    new RowDefinition{ Height = new GridLength(0.8, GridUnitType.Star)}
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition{ Width=new GridLength(0.2, GridUnitType.Star)},
                    new ColumnDefinition{ Width=new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition{ Width=new GridLength(5, GridUnitType.Star)},
                    new ColumnDefinition{ Width=new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition{ Width=new GridLength(0.5, GridUnitType.Star)}
                },
                RowSpacing = 0,
                Padding = new Thickness(0, 0, 0, 0),
                HeightRequest = height * 18,
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start
            };
            gridHeader.Children.Add(stakBack, 1, 0);
            gridHeader.Children.Add(lblStepNo, 2, 0);
            gridHeader.Children.Add(lblPageTitle, 0, 5, 1, 2);
            #endregion

            #region for body
            var lblPageInfo = new Label
            {
                Text = "Your password must be lorem ipsum\ndolor siat amet",
                TextColor = AppGlobalVariables.Black,
                FontSize = Device.OnPlatform(height * 2.5, height * 2.8, height * 2.8),
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            CustomEntry entryUPassword = new CustomEntry()
            {
                Placeholder = "[PASSWORD]*",
                IsCustomPassword = true,
                BorderColors = AppGlobalVariables.EntryBorderColor,
                Style = (Style)Resources["styleEntryInput"]
            };
            CustomEntry entryUConfirlPassword = new CustomEntry()
            {
                Placeholder = "[CONFIRM PASSWORD]*",
                IsCustomPassword = true,
                BorderColors = AppGlobalVariables.EntryBorderColor,
                Style = (Style)Resources["styleEntryInput"]
            };

            StackLayout stackScrollBody = new StackLayout()
            {
                Children = { lblPageInfo, entryUPassword, entryUConfirlPassword },
                Spacing = height * 2,
                Padding = new Thickness(10, 0, 10, 0),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start
            };
            Label lblNext = new Label()
            {
                Text = "next",
                FontSize = height * 2.5,
                TextColor = AppGlobalVariables.White,
                HeightRequest = height * 7,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            BoxView boxNext = new BoxView()
            {
                Color = AppGlobalVariables.Gray,
                HeightRequest = height * 7,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center
            };
            BoxView boxNextGesture = new BoxView()
            {
                Color = AppGlobalVariables.Transparent,
                HeightRequest = height * 7,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center
            };

            Grid gridBtnNext = new Grid()
            {
                RowDefinitions =
                {
                    new RowDefinition{ Height = GridLength.Auto}
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition{ Width=new GridLength(1, GridUnitType.Star)},
                },
                RowSpacing = height * 2,
                WidthRequest = width * 98,
                Padding = new Thickness(10, 0, 10, 0),
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.EndAndExpand
            };
            gridBtnNext.Children.Add(boxNext, 0, 1);
            gridBtnNext.Children.Add(lblNext, 0, 1);
            gridBtnNext.Children.Add(boxNextGesture, 0, 1);
            #endregion

            #region for Container
            var stackMain = new StackLayout
            {
                Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 10),
                Children = {
                    new StackLayout
                    {
                        Spacing=0,
                        Children=
                        {
                            gridHeader,
                            //lblPageTitle,
                        }
                    },
                    new ScrollView
                    {
                        Content=stackScrollBody
                    },
                    gridBtnNext

                },
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            PageControlsStackLayout.Children.Add(stackMain);
            #endregion

            #region for data filling

            if (!string.IsNullOrEmpty(RegisterStepOne.rso.userP.password))
            {
                entryUPassword.Text = RegisterStepOne.rso.userP.password;
            }
            if (!string.IsNullOrEmpty(RegisterStepOne.rso.userP.confirmPassword))
            {
                entryUConfirlPassword.Text = RegisterStepOne.rso.userP.confirmPassword;
            }

            #endregion

            #region for validations and events

            #region for text changes in entries
            entryUPassword.TextChanged += (object sender, TextChangedEventArgs e) =>
            {
                RegisterStepOne.rso.userP.password = entryUPassword.Text;
            };
            entryUConfirlPassword.TextChanged += (object sender, TextChangedEventArgs e) =>
            {
                RegisterStepOne.rso.userP.confirmPassword = entryUConfirlPassword.Text;
            };
            #endregion

            #region for back button clicked
            TapGestureRecognizer lblBackTap = new TapGestureRecognizer();
            lblBackTap.Tapped += (s, e) =>
            {
                Navigation.PopModalAsync();
            };
            lblBackBtn.GestureRecognizers.Add(lblBackTap);
            #endregion

            #region for entry focus events
            entryUPassword.Focused += SelectedEntry;
            entryUConfirlPassword.Focused += SelectedEntry;
            #endregion

            #region for Next Button EventHandler
            TapGestureRecognizer nextBtnTapped = new TapGestureRecognizer();
            nextBtnTapped.NumberOfTapsRequired = 1;
            nextBtnTapped.Tapped += (object sender, EventArgs e) =>
            {
                try
                {
                    if (string.IsNullOrEmpty(entryUPassword.Text))
                    {
                        entryUPassword.BorderColors = AppGlobalVariables.EntryBorderErrorColor;
                        entryUPassword.Text = entryUPassword.Text + " ";
                        entryUPassword.Text = entryUPassword.Text.Remove(entryUPassword.Text.Length - 1);
                        DisplayThisAlert("The first name Cannot be empty");
                    }
                    else if (string.IsNullOrEmpty(entryUConfirlPassword.Text))
                    {
                        entryUConfirlPassword.BorderColors = AppGlobalVariables.EntryBorderErrorColor;
                        entryUConfirlPassword.Text = entryUConfirlPassword.Text + " ";
                        entryUConfirlPassword.Text = entryUConfirlPassword.Text.Remove(entryUConfirlPassword.Text.Length - 1);
                        DisplayThisAlert("The last name Cannot be empty");
                    }
                    else if (!(entryUPassword.Text == entryUConfirlPassword.Text))
                    {
                        entryUPassword.BorderColors = AppGlobalVariables.EntryBorderErrorColor;
                        entryUPassword.Text = entryUPassword.Text + " ";
                        entryUPassword.Text = entryUPassword.Text.Remove(entryUPassword.Text.Length - 1);
                        entryUConfirlPassword.BorderColors = AppGlobalVariables.EntryBorderErrorColor;
                        entryUConfirlPassword.Text = entryUConfirlPassword.Text + " ";
                        entryUConfirlPassword.Text = entryUConfirlPassword.Text.Remove(entryUConfirlPassword.Text.Length - 1);
                        DisplayThisAlert("Passwords did not match");
                    }
                    else
                    {
                        RegisterStepOne.rso.userP.password = entryUPassword.Text;
                        RegisterStepOne.rso.userP.confirmPassword = entryUConfirlPassword.Text;
                        RegisterStepOne.rso.userP.forcePasswordReset = "false";

                        UserRegister();
                        //Navigation.PushModalAsync(new RegisterComplete());
                    }
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
            };
            boxNextGesture.GestureRecognizers.Add(nextBtnTapped);
            #endregion

            #endregion
        }


        #region for entry focus after validation
        void SelectedEntry(object sender, FocusEventArgs e)
        {
            try
            {
                var owner = (CustomEntry)sender;
                owner.BorderColors = AppGlobalVariables.EntryBorderColor;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
        #endregion

        #region for User registration service
        public async void UserRegister()
        {
            PageLoading.IsVisible = true;
            try
            {
                using (IUserRegistrationBAL userRegisterService = new UserRegistrationBAL())
                {
                    var response = await userRegisterService.UserRegistration(RegisterStepOne.rso.userRR);
                    //Navigation.PushModalAsync(new RegisterComplete());
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            PageLoading.IsVisible = false;
        }
        #endregion
    }
}
