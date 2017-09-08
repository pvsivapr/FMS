using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace FMS
{
    public partial class RegisterStepOne : BaseContentPage
    {
        public RegisterStepOne()
        {
            #region for local variables
            int height = (screenHeight * 1) / 100;
            int width = (screenWidth * 1) / 100;
            List<string> listMobileType = new List<string>()
            {
                "Mobile", "Land Line", "Office"
            };
            #endregion

            InitializeComponent();

            #region for Custom Style

            #region for Entry styles
            Resources = new ResourceDictionary();

            var styleEntryInput = new Style(typeof(CustomEntry))
            {
                Setters = {
                    //new Setter { Property = CustomEntry.FontSizeProperty, Value = Device.OnPlatform(height * 1.5, height * 1.8, height * 1.9) },
                    new Setter { Property = CustomEntry.PlaceholderColorProperty, Value = AppGlobalVariables.Black  },
                    new Setter { Property = CustomEntry.TextColorProperty, Value = AppGlobalVariables.Black  },
                    new Setter { Property = CustomEntry.BackgroundColorProperty, Value = Color.White  },
					//new Setter { Property = CustomEntry.WidthRequestProperty, Value = width * 70 },
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
                Margin = new Thickness(0, Device.OnPlatform(height * 0, height * 2.5, height * 2.5), 0, 0),
                FontSize = Device.OnPlatform(height * 2.3, height * 2.5, height * 2.5),
                TextColor = AppGlobalVariables.Black,
                BackgroundColor = Color.Transparent,
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Label lblTitle = new Label()
            {
                Text = "Create New Profile",
                HeightRequest = height * 8,
                BackgroundColor = Color.Transparent,
                FontSize = Device.OnPlatform(height * 3, height * 3, height * 3),
                TextColor = AppGlobalVariables.Black,
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            //var fsText = new FormattedString();
            //fsText.Spans.Add(new Span { Text="" });
            CustomUlineLabel lblNote = new CustomUlineLabel()
            {
                Text = "NOTE: If you have a Ryder account you can login using your Ryder login credentials",
                FontSize = Device.OnPlatform(height * 2.5, height * 3, height * 3),
                StartIndex = 65,
                NoOfChar = 17,
                EndIndex = 82,
                ShallUnderLine = true,
                Margin = new Thickness(10, 10, 10, 0),
                TextColor = AppGlobalVariables.Black,
                BackgroundColor = AppGlobalVariables.Transparent,
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            BoxView boxNote = new BoxView()
            {
                Color = AppGlobalVariables.Gray,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            Grid gridHeader = new Grid()
            {
                RowDefinitions =
                {
                    new RowDefinition{ Height = new GridLength(0.8, GridUnitType.Star)},
                    new RowDefinition{ Height = new GridLength(1, GridUnitType.Star)}
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition{ Width=new GridLength(0.5, GridUnitType.Star)},
                    new ColumnDefinition{ Width=new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition{ Width=new GridLength(5, GridUnitType.Star)},
                    new ColumnDefinition{ Width=new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition{ Width=new GridLength(0.5, GridUnitType.Star)}
                },
                RowSpacing = 0,
                Padding = new Thickness(0, 0, 0, 0),
                HeightRequest = height * 20,
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start
            };
            //gridHeader.Children.Add(lblBackArrow, 0, 0);
            gridHeader.Children.Add(lblBackBtn, 1, 0);
            gridHeader.Children.Add(lblTitle, 2, 0);
            gridHeader.Children.Add(boxNote, 0, 5, 1, 2);
            gridHeader.Children.Add(lblNote, 0, 5, 1, 2);

            #endregion

            #region for Social Media Logins

            Image imgFB = new Image()
            {
                Source = ImageSource.FromFile(""),
                //BackgroundColor = Color.Maroon,
                HeightRequest = height * 8,
                WidthRequest = width * 8,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Label lblFB = new Label()
            {
                Text = "Sign in with Facebook",
                TextColor = AppGlobalVariables.White,
                //BackgroundColor = Color.Green,
                HeightRequest = height * 8,
                FontSize = Device.OnPlatform(height * 2.5, height * 2.5, height * 2.5),
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            StackLayout stackFB = new StackLayout()
            {
                Children = { imgFB, lblFB },
                Orientation = StackOrientation.Horizontal,
                BackgroundColor = AppGlobalVariables.FBColor,
                HeightRequest = height * 10,
                WidthRequest = width * 90,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Image imgLinkedin = new Image()
            {
                Source = ImageSource.FromFile(""),
                HeightRequest = height * 8,
                WidthRequest = width * 8,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Label lblLinkedin = new Label()
            {
                Text = "Sign in with Linkedin",
                HeightRequest = height * 8,
                TextColor = AppGlobalVariables.White,
                FontSize = Device.OnPlatform(height * 2.5, height * 2.5, height * 2.5),
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            StackLayout stackLinkedin = new StackLayout()
            {
                Children = { imgLinkedin, lblLinkedin },
                Orientation = StackOrientation.Horizontal,
                BackgroundColor = AppGlobalVariables.LinkedinColor,
                HeightRequest = height * 10,
                WidthRequest = width * 90,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Grid gridSocialMedia = new Grid()
            {
                RowDefinitions =
                {
                    new RowDefinition{ Height = new GridLength(0.8, GridUnitType.Star)},
                    new RowDefinition{ Height = GridLength.Auto},
                    new RowDefinition{ Height = GridLength.Auto}
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition{ Width=new GridLength(1, GridUnitType.Star)}
                },
                RowSpacing = height * 3,
                Padding = new Thickness(0, 0, 0, 0),
                HeightRequest = height * 25,
                WidthRequest = width * 80,
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start
            };
            gridSocialMedia.Children.Add(stackFB, 0, 1);
            gridSocialMedia.Children.Add(stackLinkedin, 0, 2);
            #endregion

            #region for Registration Body
            CustomEntry entryUFirstName = new CustomEntry()
            {
                Placeholder = "[FIRST NAME]",
                Style = (Style)Resources["styleEntryInput"]
            };
            CustomEntry entryULastName = new CustomEntry()
            {
                Placeholder = "[LAST NAME]",
                Style = (Style)Resources["styleEntryInput"]
            };
            CustomEntry entryUEmail = new CustomEntry()
            {
                Placeholder = "[EMAIL ADDRESS]",
                Style = (Style)Resources["styleEntryInput"]
            };
            CustomEntry entryUPhone = new CustomEntry()
            {
                Placeholder = "[PHONE NUMBER]",
                Style = (Style)Resources["styleEntryInput"]
            };
            CustomPicker PickerUMobile = new CustomPicker()
            {
                Title = "MOBILE",
                ItemsSource = listMobileType,
                TextColor = AppGlobalVariables.Black,
                BackgroundColor = Color.LightGray,
                HeightRequest = height * 8,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start
            };
            PickerUMobile.SelectedItem = "MOBILE";
            CustomEntry entryUBusiness = new CustomEntry()
            {
                Placeholder = "[BUSINESS NAME]",
                Style = (Style)Resources["styleEntryInput"]
            };
            CustomEntry entryUZIP = new CustomEntry()
            {
                Placeholder = "[ZIP]",
                Style = (Style)Resources["styleEntryInput"]
            };

            #region for fuel preferences
            Label lblFuelTitle = new Label()
            {
                Text = "Fuel Preference",
                TextColor = AppGlobalVariables.Black,
                BackgroundColor = Color.Transparent,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start
            };
            Image imgCheckDiesel = new Image()
            {
                Source = { },
                HeightRequest = height * 5,
                WidthRequest = height * 5,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center
            };
            Label lblDiesel = new Label()
            {
                Text = "Diesel",
                FontSize = height * 2.5,
                TextColor = AppGlobalVariables.Black,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center
            };
            StackLayout stackDiesel = new StackLayout()
            {
                Children = { imgCheckDiesel, lblDiesel },
                BackgroundColor = Color.Transparent,
                Orientation = StackOrientation.Horizontal,
                HeightRequest = height * 8,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center
            };

            Image imgCheckUnleaded = new Image()
            {
                Source = { },
                HeightRequest = height * 5,
                WidthRequest = height * 5,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center
            };
            Label lblUnleaded = new Label()
            {
                Text = "UnLeaded",
                FontSize = height * 2.5,
                TextColor = AppGlobalVariables.Black,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center
            };
            StackLayout stackUnleaded = new StackLayout()
            {
                Children = { imgCheckUnleaded, lblUnleaded },
                BackgroundColor = Color.Transparent,
                Orientation = StackOrientation.Horizontal,
                HeightRequest = height * 8,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center
            };

            Image imgCheckCNG = new Image()
            {
                Source = { },
                HeightRequest = height * 5,
                WidthRequest = height * 5,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center
            };
            Label lblCNG = new Label()
            {
                Text = "CNG",
                FontSize = height * 2.5,
                TextColor = AppGlobalVariables.Black,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center
            };
            StackLayout stackCNG = new StackLayout()
            {
                Children = { imgCheckCNG, lblCNG },
                BackgroundColor = Color.Transparent,
                Orientation = StackOrientation.Horizontal,
                HeightRequest = height * 8,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center
            };

            Switch switchT_C = new Switch()
            {
                IsToggled = true,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            Label lblT_C = new Label()
            {
                Text = "I'll like to receive communications\nfrom Ryder",
                FontSize = height * 3,
                TextColor = AppGlobalVariables.Black,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center
            };
            StackLayout stackT_C = new StackLayout()
            {
                Children = { switchT_C, lblT_C },
                Orientation = StackOrientation.Horizontal,
                BackgroundColor = Color.Transparent,
                HeightRequest = height * 10,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center
            };

            Label lblNext = new Label()
            {
                Text = "next",
                FontSize = height * 2.5,
                TextColor = AppGlobalVariables.White,
                //BackgroundColor = AppGlobalVariables.Gray,
                HeightRequest = height * 7,
                ////WidthRequest = height * 5,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            StackLayout stackNext = new StackLayout()
            {
                Children = { lblNext },
                BackgroundColor = AppGlobalVariables.Gray,
                HeightRequest = height * 7,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center
            };
            BoxView boxNext = new BoxView()
            {
                Color = AppGlobalVariables.Transparent,
                HeightRequest = height * 7,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center
            };

            Grid gridFuelPreference = new Grid()
            {
                RowDefinitions =
                {
                    new RowDefinition{ Height = GridLength.Auto},
                    new RowDefinition{ Height = GridLength.Auto},
                    new RowDefinition{ Height = GridLength.Auto},
                    new RowDefinition{ Height = GridLength.Auto}
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition{ Width=new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition{ Width=new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition{ Width=new GridLength(1, GridUnitType.Star)}
                },
                RowSpacing = height * 2,
                //ColumnSpacing = width*2,
                WidthRequest = width * 98,
                Padding = new Thickness(0, 0, 0, 0),
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start
            };
            gridFuelPreference.Children.Add(lblFuelTitle, 0, 3, 0, 1);
            gridFuelPreference.Children.Add(stackDiesel, 0, 1);
            gridFuelPreference.Children.Add(stackUnleaded, 1, 1);
            gridFuelPreference.Children.Add(stackCNG, 2, 1);
            gridFuelPreference.Children.Add(stackT_C, 0, 3, 2, 3);
            gridFuelPreference.Children.Add(stackNext, 0, 3, 3, 4);
            gridFuelPreference.Children.Add(boxNext, 0, 3, 3, 4);
            //gridFuelPreference.Children.Add(stackDiesel, 0, 1);
            #endregion

            Grid gridProfileInfo = new Grid()
            {
                RowDefinitions =
                {
                    new RowDefinition{ Height = GridLength.Auto},
                    new RowDefinition{ Height = GridLength.Auto},
                    new RowDefinition{ Height = GridLength.Auto},
                    new RowDefinition{ Height = GridLength.Auto},
                    new RowDefinition{ Height = GridLength.Auto},
                    new RowDefinition{ Height = GridLength.Auto},
                    new RowDefinition{ Height = GridLength.Auto},
                    new RowDefinition{ Height = GridLength.Auto}
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star)}
                },
                RowSpacing = height * 3,
                Padding = new Thickness(10, 15, 10, 0),
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start
                //RowSpacing = height*3,
                //Padding = new Thickness(0, 0, 0, 0),
                ////WidthRequest = width * 98,
                //BackgroundColor = Color.Red,
                //HorizontalOptions = LayoutOptions.FillAndExpand,
                //VerticalOptions = LayoutOptions.Start
            };
            gridProfileInfo.Children.Add(entryUFirstName, 0, 0);
            gridProfileInfo.Children.Add(entryULastName, 0, 1);
            gridProfileInfo.Children.Add(entryUEmail, 0, 2);
            gridProfileInfo.Children.Add(entryUPhone, 0, 3);
            gridProfileInfo.Children.Add(PickerUMobile, 0, 4);
            gridProfileInfo.Children.Add(entryUBusiness, 0, 5);
            gridProfileInfo.Children.Add(entryUZIP, 0, 6);
            gridProfileInfo.Children.Add(gridFuelPreference, 0, 7);

            StackLayout stackProfileInfo = new StackLayout()
            {
                //Children = { entryUFirstName,  entryULastName, entryUEmail, entryUPhone, PickerUMobile, entryUBusiness, entryUZIP, gridFuelPreference },
                Spacing = height * 3,
                Padding = new Thickness(10, 15, 10, 0),
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start
            };
            #endregion

            #region for Container
            StackLayout stackHolder = new StackLayout()
            {
                Children = { gridHeader, gridSocialMedia, gridProfileInfo },
                Spacing = 5,
                Padding = new Thickness(0, 0, 0, 10),
                BackgroundColor = Color.White,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            ScrollView scrollHolder = new ScrollView()
            {
                Content = stackHolder,
                Padding = new Thickness(0, 0, 0, 0),
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            StackLayout stackContainer = new StackLayout()
            {
                //Children = { gridHeader, scrollHolder },
                Children = { scrollHolder },
                Padding = new Thickness(0, 0, 0, 0),
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            PageControlsStackLayout.Children.Add(stackContainer);
            #endregion

            #region for events and handlers

            #region for Mobile Number Text Entry
            entryUPhone.TextChanged += (object sender, TextChangedEventArgs e) =>
            {
                try
                {
                    if (entryUPhone.Text.Length > 10)
                    {
                        entryUPhone.Text = entryUPhone.Text.Remove(entryUPhone.Text.Length - 1);
                    }
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
            };
            #endregion

            #region for Next Button
            entryUZIP.TextChanged += (object sender, TextChangedEventArgs e) =>             {                 try                 {                     if (entryUZIP.Text.Length > 6)                     {                         entryUZIP.Text = entryUZIP.Text.Remove(entryUZIP.Text.Length - 1);                     }                 }                 catch (Exception ex)                 {                     var msg = ex.Message;                 }             };
            #endregion

            #region for Next Button 
            #endregion
            #region for Next Button EventHandler
            TapGestureRecognizer nextBtnTapped = new TapGestureRecognizer();
            nextBtnTapped.NumberOfTapsRequired = 1;
            nextBtnTapped.Tapped += async (object sender, EventArgs e) =>
            {
                try
                {
                    if (string.IsNullOrEmpty(entryUFirstName.Text))
                    {
                        DisplayThisAlert("User first name Cannot be empty");
                    }
                    else if (string.IsNullOrEmpty(entryULastName.Text))
                    {
                        DisplayThisAlert("User last name Cannot be empty");
                    }
                    else if (string.IsNullOrEmpty(entryUEmail.Text))
                    {
                        DisplayThisAlert("User email Cannot be empty");
                    }
                    else if (!Regex.IsMatch(entryUEmail.Text.Trim(), @"^([a-zA-Z_])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$"))
                    {
                        DisplayThisAlert("Enter a valid email id");
                    }
                    else if (string.IsNullOrEmpty(entryUPhone.Text))
                    {
                        DisplayThisAlert("User mobile number Cannot be empty");
                    }
                    else if (entryUPhone.Text.Length != 10)
                    {
                        DisplayThisAlert("Enter a valid mobile number");
                    }
                    else if (!Regex.IsMatch(entryUPhone.Text, @"^([1-9])([0-9]*)$"))
                    {
                        DisplayThisAlert("Enter a valid mobile number");
                    }
                    else if (string.IsNullOrEmpty(entryUBusiness.Text))
                    {
                        DisplayThisAlert("User business name cannot be empty");
                    }
                    else if (string.IsNullOrEmpty(entryUZIP.Text))
                    {
                        DisplayThisAlert("ZIP code cannot be empty");
                    }
                    else if (entryUZIP.Text.Length != 6)
                    {
                        DisplayThisAlert("Enter a valid ZIP code");
                    }
                    else if (!Regex.IsMatch(entryUZIP.Text, @"^([1-9])([0-9]*)$"))
                    {
                        DisplayThisAlert("Enter a valid ZIP code");
                    }
                    else
                    {
                        if (switchT_C.IsToggled == false)
                        {
                            var resp = await DisplayThisChoice("are you sure that you did not want to receive communications from ryder");
                            if (resp)
                            {

                            }
                            else
                            {
                                switchT_C.IsToggled = true;
                            }
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
            };
            boxNext.GestureRecognizers.Add(nextBtnTapped);
            #endregion

            #endregion
        }
    }
}