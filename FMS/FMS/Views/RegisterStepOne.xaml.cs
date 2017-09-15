using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace FMS
{
    public partial class RegisterStepOne : BaseContentPage
    {
        public static RegisterStepOne rso;
        public UserRegistrationRequest userRR;
        public UserProfile userP;
        public Entitlements userE;
        public List<string> fleetData, truckData, otherData;
        public RegisterStepOne()
        {
            #region for local variables
            int height = (screenHeight * 1) / 100;
            int width = (screenWidth * 1) / 100;
            List<string> listMobileType = new List<string>()
            {
                "Mobile", "Home", "Work"
            };
            string mobileType = "Mobile", fuelPref = "Diesel";
            userRR = new UserRegistrationRequest();
            userP = new UserProfile();
            userE = new Entitlements();
            truckData = new List<string>();
            fleetData = new List<string>();
            otherData = new List<string>();
            #endregion

            //InitializeComponent();
            rso = this;

            #region for Custom Style

            #region for Entry styles
            Resources = new ResourceDictionary();

            var styleEntryInput = new Style(typeof(CustomEntry))
            {
                Setters = {
                    new Setter { Property = CustomEntry.PlaceholderColorProperty, Value = AppGlobalVariables.black  },
                    new Setter { Property = CustomEntry.TextColorProperty, Value = AppGlobalVariables.black  },
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
                TextColor = AppGlobalVariables.black,
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            Label lblTitle = new Label()
            {
                Text = "Create New Profile",
                HeightRequest = height * 8,
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.OnPlatform(height * 3, height * 3, height * 3),
                TextColor = AppGlobalVariables.black,
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            CustomUlineLabel lblSkip = new CustomUlineLabel()
            {
                Text = "SKIP",
                //StartIndex = 1,
                //NoOfChar = 4,
                //EndIndex = 5,
                ShallUnderLine = true,
                HeightRequest = height * 8,
                Margin = new Thickness(0, Device.OnPlatform(height * 0, height * 1.5, height * 2.5), 0, 0),
                FontSize = Device.OnPlatform(height * 2.3, height * 2.5, height * 2.5),
                TextColor = AppGlobalVariables.black,
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                VerticalOptions = LayoutOptions.EndAndExpand
            };
            CustomUlineLabel lblNote = new CustomUlineLabel()
            {
                Text = "NOTE: If you have a Ryder account you can login using your Ryder login credentials",
                FontSize = Device.OnPlatform(height * 2.5, height * 2.6, height * 3),
                StartIndex = 65,
                NoOfChar = 17,
                EndIndex = 82,
                ShallUnderLine = true,
                Margin = new Thickness(10, Device.OnPlatform(0, height * 3, height * 1), 0, Device.OnPlatform(0, 10, 10)),
                HeightRequest = height * 12,
                TextColor = AppGlobalVariables.white,
                BackgroundColor = AppGlobalVariables.transparent,
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            //CustomUlineLabel lblNote = new CustomUlineLabel()
            //{
            //  Text = "NOTE: If you have a Ryder account you can login using your Ryder login credentials",
            //  FontSize = Device.OnPlatform(height * 2.5, height * 3, height * 3),
            //  StartIndex = 65,
            //  NoOfChar = 17,
            //  EndIndex = 82,
            //  ShallUnderLine = true,
            //  Margin = new Thickness(10, 10, 10, 0),
            //  TextColor = AppGlobalVariables.black,
            //  BackgroundColor = AppGlobalVariables.transparent,
            //  HorizontalTextAlignment = TextAlignment.Start,
            //  VerticalTextAlignment = TextAlignment.Center,
            //  HorizontalOptions = LayoutOptions.FillAndExpand,
            //  VerticalOptions = LayoutOptions.CenterAndExpand
            //};
            StackLayout stackNote = new StackLayout()
            {
                Children = { lblNote },
                HeightRequest = height * 15,
                BackgroundColor = AppGlobalVariables.lightGray,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            //BoxView boxNote = new BoxView()
            //{
            //  Color = AppGlobalVariables.gray,
            //  HorizontalOptions = LayoutOptions.FillAndExpand,
            //  VerticalOptions = LayoutOptions.FillAndExpand
            //};

            Grid gridHeader = new Grid()
            {
                RowDefinitions =
                {
                    new RowDefinition{ Height = new GridLength(1, GridUnitType.Star)}
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
                HeightRequest = height * 10,
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start
            };
            gridHeader.Children.Add(lblBackBtn, 1, 0);
            gridHeader.Children.Add(lblTitle, 2, 0);
            gridHeader.Children.Add(lblSkip, 3, 0);

            #endregion

            #region for Social Media Logins

            Image imgFB = new Image()
            {
                Source = ImageSource.FromFile("FBIcon.png"),
                HeightRequest = height * 8,
                WidthRequest = width * 8,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Label lblFB = new Label()
            {
                Text = "Sign in with Facebook",
                TextColor = AppGlobalVariables.white,
                BackgroundColor = AppGlobalVariables.fBColor,
                HeightRequest = height * 8,
                FontSize = Device.OnPlatform(height * 2.5, height * 2.5, height * 2.5),
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            Image imgLinkedin = new Image()
            {
                Source = ImageSource.FromFile("LNIcon.png"),
                HeightRequest = height * 8,
                WidthRequest = width * 8,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Label lblLinkedin = new Label()
            {
                Text = "Sign in with Linkedin",
                HeightRequest = height * 8,
                TextColor = AppGlobalVariables.white,
                BackgroundColor = AppGlobalVariables.linkedinColor,
                FontSize = Device.OnPlatform(height * 2.5, height * 2.5, height * 2.5),
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
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
                    new ColumnDefinition{ Width=new GridLength(0.3, GridUnitType.Star)},
                    new ColumnDefinition{ Width=new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition{ Width=new GridLength(4.7, GridUnitType.Star)}
                },
                RowSpacing = height * 3,
                Padding = new Thickness(0, 0, 0, 0),
                HeightRequest = height * 25,
                WidthRequest = width * 80,
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Start
            };
            gridSocialMedia.Children.Add(lblFB, 0, 3, 1, 2);
            gridSocialMedia.Children.Add(imgFB, 1, 1);
            gridSocialMedia.Children.Add(lblLinkedin, 0, 3, 2, 3);
            gridSocialMedia.Children.Add(imgLinkedin, 1, 2);
            #endregion

            #region for Registration Body

            #region for input entries
            CustomEntry entryUFirstName = new CustomEntry()
            {
                Placeholder = "[FIRST NAME]*",
                Keyboard = Keyboard.Chat,
                PlaceholderColor = AppGlobalVariables.gray,
                BorderColors = AppGlobalVariables.entryBorderColor,
                Style = (Style)Resources["styleEntryInput"]
            };
            CustomEntry entryULastName = new CustomEntry()
            {
                Placeholder = "[LAST NAME]*",
                PlaceholderColor = AppGlobalVariables.gray,
                BorderColors = AppGlobalVariables.entryBorderColor,
                Style = (Style)Resources["styleEntryInput"]
            };
            CustomEntry entryUEmail = new CustomEntry()
            {
                Placeholder = "[EMAIL ADDRESS]*",
                PlaceholderColor = AppGlobalVariables.gray,
                BorderColors = AppGlobalVariables.entryBorderColor,
                Keyboard = Keyboard.Email,
                IsEmail = true,
                Style = (Style)Resources["styleEntryInput"]
            };
            CustomEntry entryUPhone = new CustomEntry()
            {
                Placeholder = "[PHONE NUMBER]*",
                PlaceholderColor = AppGlobalVariables.gray,
                BorderColors = AppGlobalVariables.entryBorderColor,
                Keyboard = Keyboard.Numeric,
                IsPhoneNumber = true,
                Style = (Style)Resources["styleEntryInput"]
            };
            Image imgDropDown = new Image()
            {
                Source = ImageSource.FromFile("DropDownIcon.png"),
                Margin = new Thickness(0, 10, 0, 10),
                HeightRequest = height * 5,
                WidthRequest = width * 5,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            CustomPicker PickerUMobile = new CustomPicker()
            {
                //Title = "",
                ItemsSource = listMobileType,
                TextColor = AppGlobalVariables.black,
                BackgroundColor = AppGlobalVariables.lightGray,
                HeightRequest = height * 8,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start
            };
            PickerUMobile.SelectedItem = listMobileType[0];
            //PickerUMobile.SelectedIndex = 1;
            CustomEntry entryUBusiness = new CustomEntry()
            {
                Placeholder = "[BUSINESS NAME]",
                PlaceholderColor = AppGlobalVariables.gray,
                BorderColors = AppGlobalVariables.entryBorderColor,
                Style = (Style)Resources["styleEntryInput"]
            };
            CustomEntry entryUZIP = new CustomEntry()
            {
                Placeholder = "[ZIP]",
                PlaceholderColor = AppGlobalVariables.gray,
                BorderColors = AppGlobalVariables.entryBorderColor,
                Keyboard = Keyboard.Numeric,
                IsNumeric = true,
                Style = (Style)Resources["styleEntryInput"]
            };

            #endregion

            #region for fuel preferences
            Label lblFuelTitle = new Label()
            {
                Text = "Fuel Preference",
                TextColor = AppGlobalVariables.black,
                BackgroundColor = Color.Transparent,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start
            };
            Image imgCheckDiesel = new Image()
            {
                Source = ImageSource.FromFile("imgRadioYes.png"),
                HeightRequest = height * 5,
                WidthRequest = height * 5,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center
            };
            Label lblDiesel = new Label()
            {
                Text = "Diesel",
                FontSize = height * 2.5,
                TextColor = AppGlobalVariables.black,
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
                Source = ImageSource.FromFile("imgRadioNo.png"),
                HeightRequest = height * 5,
                WidthRequest = height * 5,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center
            };
            Label lblUnleaded = new Label()
            {
                Text = "Unleaded",
                FontSize = height * 2.5,
                TextColor = AppGlobalVariables.black,
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
                Source = ImageSource.FromFile("imgRadioNo.png"),
                HeightRequest = height * 5,
                WidthRequest = height * 5,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center
            };
            Label lblCNG = new Label()
            {
                Text = "CNG",
                FontSize = height * 2.5,
                TextColor = AppGlobalVariables.black,
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

            Switch switchCommunications = new Switch()
            {
                IsToggled = true,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            Label lblCommunications = new Label()
            {
                Text = "I'd like to receive communications from Ryder.",
                FontSize = height * 2.9,
                TextColor = AppGlobalVariables.black,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center
            };
            StackLayout stackCommunications = new StackLayout()
            {
                Children = { switchCommunications, lblCommunications },
                Orientation = StackOrientation.Horizontal,
                BackgroundColor = Color.Transparent,
                HeightRequest = height * 10,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center
            };

            Image imgTandC = new Image()
            {
                Source = ImageSource.FromFile("Unchecked.png"),
                HeightRequest = height * 5,
                WidthRequest = height * 5,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Label lblTandC = new Label()
            {
                Text = "Use of this site constitutes your agreement to",
                // HorizontalOptions = LayoutOptions.CenterAndExpand
                //  FontSize = Device.OnPlatform(height * 2, height * 2.5, height * 3),
                TextColor = AppGlobalVariables.black,
                ////  HeightRequest = height * 6,
                ////  Margin = new Thickness(0, Device.OnPlatform(height * 0, height * 1.25, height * 2), 0, 0),
                //  VerticalTextAlignment = TextAlignment.Center,
                //  HorizontalOptions = LayoutOptions.StartAndExpand,
                //  //VerticalOptions = LayoutOptions.StartAndExpand
            };
            CustomUlineLabel lblTandCLink = new CustomUlineLabel()
            {
                Text = "terms of use",
                FontSize = Device.OnPlatform(height * 2, height * 2.5, height * 3),
                //StartIndex = 47,
                //EndIndex = 59,
                //NoOfChar = 12,
                ShallUnderLine = true,
                TextColor = AppGlobalVariables.black,
                HeightRequest = height * 6,
                Margin = new Thickness(0, Device.OnPlatform(height * 0, height * 1.25, height * 2), 0, 0),
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            var tapLblTandCLink = new TapGestureRecognizer();
            tapLblTandCLink.Tapped += (s, e) =>
            {
                Device.OpenUri(new Uri("https://ryder.com/terms-of-use"));
            };
            lblTandCLink.GestureRecognizers.Add(tapLblTandCLink);
            StackLayout stackTandC = new StackLayout()
            {
                Children = { imgTandC, lblTandC },
                Orientation = StackOrientation.Horizontal,
                BackgroundColor = Color.Transparent,
                HeightRequest = height * 10,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center
            };
            StackLayout stackTandCLink = new StackLayout()
            {
                Children = { lblTandCLink },
                Orientation = StackOrientation.Horizontal,
                BackgroundColor = Color.Transparent,
                HeightRequest = height * 10,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.StartAndExpand
            };

            Label lblNext = new Label()
            {
                Text = "next",
                FontSize = height * 2.5,
                TextColor = AppGlobalVariables.white,
                HeightRequest = height * 7,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            StackLayout stackNext = new StackLayout()
            {
                Children = { lblNext },
                BackgroundColor = AppGlobalVariables.gray,
                HeightRequest = height * 7,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center
            };
            BoxView boxNext = new BoxView()
            {
                Color = AppGlobalVariables.transparent,
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
            gridFuelPreference.Children.Add(stackCommunications, 0, 3, 2, 3);
            gridFuelPreference.Children.Add(stackTandC, 0, 3, 3, 4);
            gridFuelPreference.Children.Add(stackTandCLink, 0, 2, 3, 4);
            gridFuelPreference.Children.Add(stackNext, 0, 3, 4, 5);
            gridFuelPreference.Children.Add(boxNext, 0, 3, 4, 5);
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
                    new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition{ Width = new GridLength(0.1, GridUnitType.Star)},
                    new ColumnDefinition{ Width = new GridLength(0.1, GridUnitType.Star)}
                },
                RowSpacing = height * 3,
                Padding = new Thickness(10, 15, 10, 0),
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start
            };
            gridProfileInfo.Children.Add(entryUFirstName, 0, 3, 0, 1);
            gridProfileInfo.Children.Add(entryULastName, 0, 3, 1, 2);
            gridProfileInfo.Children.Add(entryUEmail, 0, 3, 2, 3);
            gridProfileInfo.Children.Add(entryUPhone, 0, 3, 3, 4);
            gridProfileInfo.Children.Add(PickerUMobile, 0, 3, 4, 5);
            gridProfileInfo.Children.Add(imgDropDown, 1, 2, 4, 5);
            gridProfileInfo.Children.Add(entryUBusiness, 0, 3, 5, 6);
            gridProfileInfo.Children.Add(entryUZIP, 0, 3, 6, 7);
            gridProfileInfo.Children.Add(gridFuelPreference, 0, 3, 7, 8);

            #endregion

            #region for Container
            StackLayout stackHolder = new StackLayout()
            {
                Children = { stackNote, gridSocialMedia, gridProfileInfo },
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
                Children = { gridHeader, scrollHolder },
                Padding = new Thickness(0, 0, 0, 0),
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            pageControlsStackLayout.Children.Add(stackContainer);
            #endregion

            #region for events and handlers

            #region for entry focus events
            entryUFirstName.Focused += SelectedEntry;
            entryULastName.Focused += SelectedEntry;
            entryUEmail.Focused += SelectedEntry;
            entryUBusiness.Focused += SelectedEntry;
            entryUZIP.Focused += SelectedEntry;
            #endregion

            #region for Mobile Number Text Entry
            int strng = 0;
            bool isRemoved = false;
            entryUPhone.TextChanged += (object sender, TextChangedEventArgs e) =>
            {
                try
                {
                    if (entryUPhone.IsFocused == true && entryUPhone.Text.Length < 3)
                    {
                        entryUPhone.Text = "+1 ";
                    }

                    if (entryUPhone.Text.Length > 15)
                    {
                        entryUPhone.Text = entryUPhone.Text.Remove(entryUPhone.Text.Length - 1);
                    }
                    else
                    {
                /*
                if (entryUPhone.Text.Length > 3)
                {
                    string splace = entryUPhone.Text.Substring(0, 3);
                    if (entryUPhone.IsFocused == true && !(entryUPhone.Text.Substring(0, 3) == "+1 "))
                    {
                        if (!(entryUPhone.Text.Substring(0, 1) == "+"))
                        {
                            entryUPhone.Text = "+" + entryUPhone.Text;
                        }
                        if (!(entryUPhone.Text.Substring(1, 1) == "1"))
                        {
                            entryUPhone.Text = "1" + entryUPhone.Text;
                        }
                        if (!(entryUPhone.Text.Substring(2, 1) == " "))
                        {
                            entryUPhone.Text = " " + entryUPhone.Text;
                        }
                    }
                }
                */
                        if (strng < entryUPhone.Text.Length)
                        {
                            if (isRemoved == false)
                            {
                                if (entryUPhone.Text.Length == 6)
                                {
                                    entryUPhone.Text = entryUPhone.Text + "-";
                                }
                                else if (entryUPhone.Text.Length == 7)
                                {
                                    string splace = entryUPhone.Text.Substring(6, 1);
                                    if (!(splace == "-"))
                                    {
                                        string num = entryUPhone.Text.Remove(6, 1);
                                        entryUPhone.Text = num + "-" + splace;
                                    }
                                }
                                else if (entryUPhone.Text.Length == 10)
                                {
                                    entryUPhone.Text = entryUPhone.Text + "-";
                                }
                                else if (entryUPhone.Text.Length == 11)
                                {
                                    string splace = entryUPhone.Text.Substring(10, 1);
                                    if (!(splace == "-"))
                                    {
                                        string num = entryUPhone.Text.Remove(10, 1);
                                        entryUPhone.Text = num + "-" + splace;
                                    }
                                }
                                else
                                {
                                }
                            }
                        }
                /*
                else if (strng > owner.Text.Length)
                {
                    if (entryUPhone.Text.Length == 7)
                    {
                        string splace = entryUPhone.Text.Substring(6, 1);
                        if (!(splace == "-"))
                        {
                            string num = entryUPhone.Text.Remove(6, 1);
                            entryUPhone.Text = num + "-" + splace;
                        }
                    }
                    else if (entryUPhone.Text.Length == 11)
                    {
                        string splace = entryUPhone.Text.Substring(10, 1);
                        if (!(splace == "-"))
                        {
                            string num = entryUPhone.Text.Remove(10, 1);
                            entryUPhone.Text = num + "-" + splace;
                        }
                    }
                    else
                    {
                    }

                }
                */
                //if (!Regex.IsMatch(entryUPhone.Text, @"^((+|\d)+(\s|\x2D))?\d{3}-\d{3}-\d{4}$"))
                //{
                //  entryUPhone.Text = entryUPhone.Text.Remove(entryUPhone.Text.Length - 1);
                //}
                strng = entryUPhone.Text.Length;
                    }
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
            };
            entryUPhone.Focused += (object sender, FocusEventArgs e) =>
            {
                try
                {
                    entryUPhone.BorderColors = AppGlobalVariables.entryBorderColor;
                    if (string.IsNullOrEmpty(entryUPhone.Text))
                    {
                        entryUPhone.Text = "+1 ";
                    }
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
            };
            entryUPhone.Unfocused += (object sender, FocusEventArgs e) =>
            {
                try
                {
                    var owner = (CustomEntry)sender;

            //owner.BorderColors = AppGlobalVariables.entryBorderColor;
            if ((entryUPhone.Text == "+1 ") || (entryUPhone.Text == "+1"))
                    {
                        entryUPhone.Text = string.Empty;
                    }
                    if ((entryUPhone.Text.Length == 1) || (entryUPhone.Text == "+1"))
                    {
                        entryUPhone.Text = string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
            };
            #endregion

            #region for First Name Text Entry
            entryUFirstName.TextChanged += (object sender, TextChangedEventArgs e) =>
            {
                try
                {
                    if (entryUFirstName.Text.Length > 30)
                    {
                        entryUFirstName.Text = entryUFirstName.Text.Remove(entryUFirstName.Text.Length - 1);
                    }

                    if (!Regex.IsMatch(entryUFirstName.Text, @"^[a-z|A-Z]*$"))
                    {
                        entryUFirstName.Text = entryUFirstName.Text.Remove(entryUFirstName.Text.Length - 1);
                    }
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
            };
            #endregion

            #region for Last Name Text Entry
            entryULastName.TextChanged += (object sender, TextChangedEventArgs e) =>
            {
                try
                {
                    if (entryULastName.Text.Length > 30)
                    {
                        entryULastName.Text = entryULastName.Text.Remove(entryULastName.Text.Length - 1);
                    }
                    if (!Regex.IsMatch(entryULastName.Text, @"^[a-z|A-Z]*$"))
                    {
                        entryULastName.Text = entryULastName.Text.Remove(entryULastName.Text.Length - 1);
                    }
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
            };
            #endregion

            #region for Email Text Entry
            entryUEmail.TextChanged += (object sender, TextChangedEventArgs e) =>
            {
                try
                {
                    if (entryUEmail.Text.Length > 50)
                    {
                        entryUEmail.Text = entryUEmail.Text.Remove(entryUEmail.Text.Length - 1);
                    }
            //if (!Regex.IsMatch(entryUEmail.Text, @"^/W*$"))
            //{
            //  entryUEmail.Text = entryUEmail.Text.Remove(entryUEmail.Text.Length - 1);
            //}
        }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
            };
            #endregion

            #region for picker Selection Event
            PickerUMobile.SelectedIndexChanged += (object sender, EventArgs e) =>
            {
                try
                {
                    if (PickerUMobile.SelectedIndex != -1)
                    {
                        mobileType = (string)PickerUMobile.SelectedItem;
                    }
                    else
                    {
                    }
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
            };
            #endregion

            #region for ZIP code Entry
            entryUZIP.TextChanged += (object sender, TextChangedEventArgs e) =>
            {
                try
                {
            //if (entryUZIP.Text.Length > 5)
            //{
            //  entryUZIP.Text = entryUZIP.Text.Remove(entryUZIP.Text.Length - 1);
            //}
            if (!Regex.IsMatch(entryUZIP.Text, @"^\d{0,5}$"))
                    {
                        entryUZIP.Text = entryUZIP.Text.Remove(entryUZIP.Text.Length - 1);
                    }
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
            };
            #endregion

            #region for Terms and conditions
            bool boolTandC = false;
            TapGestureRecognizer tapAcceptTandC = new TapGestureRecognizer();
            tapAcceptTandC.NumberOfTapsRequired = 1;
            tapAcceptTandC.Tapped += (object sender, EventArgs e) =>
            {
                if (boolTandC)
                {
                    imgTandC.Source = ImageSource.FromFile("Unchecked.png");
                    boolTandC = false;
                }
                else
                {
                    imgTandC.Source = ImageSource.FromFile("Checked.png");
                    boolTandC = true;
                }
            };
            imgTandC.GestureRecognizers.Add(tapAcceptTandC);
            #endregion

            #region for Fuel radio Check
            TapGestureRecognizer fuelSelectEvent = new TapGestureRecognizer();
            fuelSelectEvent.NumberOfTapsRequired = 1;
            fuelSelectEvent.Tapped += (object sender, EventArgs e) =>
            {
                var owner = ((Image)sender);
                if (imgCheckDiesel == owner)
                {
                    imgCheckDiesel.Source = ImageSource.FromFile("imgRadioYes.png");
                    imgCheckUnleaded.Source = ImageSource.FromFile("imgRadioNo.png");
                    imgCheckCNG.Source = ImageSource.FromFile("imgRadioNo.png");
                    fuelPref = "Diesel";
                }
                else if (imgCheckUnleaded == owner)
                {
                    imgCheckDiesel.Source = ImageSource.FromFile("imgRadioNo.png");
                    imgCheckUnleaded.Source = ImageSource.FromFile("imgRadioYes.png");
                    imgCheckCNG.Source = ImageSource.FromFile("imgRadioNo.png");
                    fuelPref = "Unleaded";
                }
                else if (imgCheckCNG == owner)
                {
                    imgCheckDiesel.Source = ImageSource.FromFile("imgRadioNo.png");
                    imgCheckUnleaded.Source = ImageSource.FromFile("imgRadioNo.png");
                    imgCheckCNG.Source = ImageSource.FromFile("imgRadioYes.png");
                    fuelPref = "CNG";
                }
                else
                {
                    imgCheckDiesel.Source = ImageSource.FromFile("imgRadioYes.png");
                    imgCheckUnleaded.Source = ImageSource.FromFile("imgRadioNo.png");
                    imgCheckCNG.Source = ImageSource.FromFile("imgRadioNo.png");
                }
            };
            imgCheckDiesel.GestureRecognizers.Add(fuelSelectEvent);
            imgCheckUnleaded.GestureRecognizers.Add(fuelSelectEvent);
            imgCheckCNG.GestureRecognizers.Add(fuelSelectEvent);
            #endregion

            #region for Next Button EventHandler
            TapGestureRecognizer nextBtnTapped = new TapGestureRecognizer();
            nextBtnTapped.NumberOfTapsRequired = 1;
            nextBtnTapped.Tapped += (object sender, EventArgs e) =>
            {
                try
                {
                    if (string.IsNullOrEmpty(entryUFirstName.Text))
                    {
                        entryUFirstName.BorderColors = AppGlobalVariables.entryBorderErrorColor;
                        scrollHolder.ScrollToAsync(entryUFirstName, ScrollToPosition.Center, true);
                        DisplayThisAlert("First name cannot be empty.");
                        entryUFirstName.Text = entryUFirstName.Text + " ";
                //entryUFirstName.Text = entryUFirstName.Text.Remove(entryUFirstName.Text.Length - 1);
            }
                    else if (entryUFirstName.Text.Length > 30)
                    {
                        entryUFirstName.BorderColors = AppGlobalVariables.entryBorderErrorColor;

                        scrollHolder.ScrollToAsync(entryUFirstName, ScrollToPosition.Center, true);
                        DisplayThisAlert("First name should be all alphabets. No special characters (except space) or numbers, Max characters are 30.");
                        entryUFirstName.Text = entryUFirstName.Text + " ";
                //entryUFirstName.Text = entryUFirstName.Text.Remove(entryUFirstName.Text.Length - 1);
            }
                    else if (!Regex.IsMatch(entryUFirstName.Text, @"^[a-zA-Z\s]{1,}$"))
                    {
                        entryUFirstName.BorderColors = AppGlobalVariables.entryBorderErrorColor;
                        scrollHolder.ScrollToAsync(entryUFirstName, ScrollToPosition.Center, true);
                        DisplayThisAlert("First name should be all alphabets. No special characters (except space) or numbers, Max characters are 30.");
                        entryUFirstName.Text = entryUFirstName.Text + " ";
                        entryUFirstName.Text = entryUFirstName.Text.Remove(entryUFirstName.Text.Length - 1);
                    }
                    else if (string.IsNullOrEmpty(entryULastName.Text))
                    {
                        entryULastName.BorderColors = AppGlobalVariables.entryBorderErrorColor;
                        scrollHolder.ScrollToAsync(entryULastName, ScrollToPosition.Center, true);
                        DisplayThisAlert("Last name cannot be empty.");
                        entryULastName.Text = entryULastName.Text + " ";
                //entryULastName.Text = entryULastName.Text.Remove(entryULastName.Text.Length - 1);
            }
                    else if (entryULastName.Text.Length > 30)
                    {
                        entryULastName.BorderColors = AppGlobalVariables.entryBorderErrorColor;

                        scrollHolder.ScrollToAsync(entryULastName, ScrollToPosition.Center, true);
                        DisplayThisAlert("Last name should be all alphabets. No special characters (except space) or numbers, Max characters are 30.");
                        entryULastName.Text = entryULastName.Text + " ";
                //entryULastName.Text = entryULastName.Text.Remove(entryULastName.Text.Length - 1);
            }
                    else if (!Regex.IsMatch(entryULastName.Text, @"^^[a-zA-Z\s]{1,}$"))
                    {
                        entryULastName.BorderColors = AppGlobalVariables.entryBorderErrorColor;
                        scrollHolder.ScrollToAsync(entryULastName, ScrollToPosition.Center, true);
                        DisplayThisAlert("Last name should be all alphabets. No special characters (except space) or numbers, Max characters are 50.");
                        entryULastName.Text = entryULastName.Text + " ";
                //entryULastName.Text = entryULastName.Text.Remove(entryULastName.Text.Length - 1);
            }
                    else if (string.IsNullOrEmpty(entryUEmail.Text))
                    {
                        entryUEmail.BorderColors = AppGlobalVariables.entryBorderErrorColor;
                        scrollHolder.ScrollToAsync(entryUEmail, ScrollToPosition.Center, true);
                        DisplayThisAlert("Email address cannot be empty.");
                        entryUEmail.Text = entryUEmail.Text + " ";
                //entryUEmail.Text = entryUEmail.Text.Remove(entryUEmail.Text.Length - 1);
            }
                    else if (entryUEmail.Text.Length > 50)
                    {
                        entryUEmail.BorderColors = AppGlobalVariables.entryBorderErrorColor;
                        scrollHolder.ScrollToAsync(entryUEmail, ScrollToPosition.Center, true);
                        DisplayThisAlert("Email address text length should not be more than 50 characters.");
                        entryUEmail.Text = entryUEmail.Text + " ";
                        entryUEmail.Text = entryUEmail.Text.Remove(entryUEmail.Text.Length - 1);
                    }
                    else if (!Regex.IsMatch(entryUEmail.Text.Trim(), @"^([a-zA-Z_])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$"))
                    {

                        entryUEmail.BorderColors = AppGlobalVariables.entryBorderErrorColor;
                        scrollHolder.ScrollToAsync(entryUEmail, ScrollToPosition.Center, true);
                        DisplayThisAlert("Enter a valid email address.");
                        entryUEmail.Text = entryUEmail.Text + " ";
                        entryUEmail.Text = entryUEmail.Text.Remove(entryUEmail.Text.Length - 1);
                    }
                    else if (string.IsNullOrEmpty(entryUPhone.Text))
                    {
                        entryUPhone.BorderColors = AppGlobalVariables.entryBorderErrorColor;
                        entryUPhone.Text = entryUPhone.Text + " ";
                        DisplayThisAlert("Phone number cannot be empty.");
                        if (entryUPhone.Text.Length < 15)
                        {
                            entryUPhone.Text = entryUPhone.Text.Remove(entryUPhone.Text.Length - 1);
                        }
                        else if (entryUPhone.Text.Substring(14, 1) == " ")
                        {
                            entryUPhone.Text = entryUPhone.Text.Remove(entryUPhone.Text.Length - 1);
                        }
                        scrollHolder.ScrollToAsync(entryUPhone, ScrollToPosition.Center, true);
                    }
            //else if (!Regex.IsMatch(entryUPhone.Text, @"^((+|\d)+(\s|\x2D))?\d{3}-\d{3}-\d{4}$"))
            //{
            //    entryUPhone.BorderColors = AppGlobalVariables.entryBorderErrorColor;
            //    entryUPhone.Text = entryUPhone.Text + " ";
            //    DisplayThisAlert("Mobile number format: +1 XXX-XXX-XXXX.");
            //    if (entryUPhone.Text.Length < 15)
            //    {
            //        entryUPhone.Text = entryUPhone.Text.Remove(entryUPhone.Text.Length - 1);
            //    }
            //    else if (entryUPhone.Text.Substring(14, 1) == " ")
            //    {
            //        entryUPhone.Text = entryUPhone.Text.Remove(entryUPhone.Text.Length - 1);
            //    }
            //    scrollHolder.ScrollToAsync(entryUPhone, ScrollToPosition.Center, true);
            //}
            else if ((!string.IsNullOrEmpty(entryUZIP.Text)) && (entryUZIP.Text.Length != 5))
                    {
                        entryUZIP.BorderColors = AppGlobalVariables.entryBorderErrorColor;
                        entryUZIP.Text = entryUZIP.Text + " ";
                        DisplayThisAlert("Enter a valid ZIP code.");
                        if (entryUZIP.Text.Length < 5)
                        {
                            entryUZIP.Text = entryUZIP.Text.Remove(entryUZIP.Text.Length - 1);
                        }
                        else if (entryUZIP.Text.Substring(4, 1) == " ")
                        {
                            entryUZIP.Text = entryUZIP.Text.Remove(entryUZIP.Text.Length - 1);
                        }
                        scrollHolder.ScrollToAsync(entryUZIP, ScrollToPosition.Center, true);

                    }
                    else if ((!string.IsNullOrEmpty(entryUZIP.Text)) && (!Regex.IsMatch(entryUZIP.Text, @"^([1-9])([0-9]*)$")))
                    {
                        entryUZIP.BorderColors = AppGlobalVariables.entryBorderErrorColor;
                        entryUZIP.Text = entryUZIP.Text + " ";
                        DisplayThisAlert("Enter a valid ZIP code.");
                        if (entryUZIP.Text.Length < 5)
                        {
                            entryUZIP.Text = entryUZIP.Text.Remove(entryUZIP.Text.Length - 1);
                        }
                        else if (entryUZIP.Text.Substring(4, 1) == " ")
                        {
                            entryUZIP.Text = entryUZIP.Text.Remove(entryUZIP.Text.Length - 1);
                        }
                        scrollHolder.ScrollToAsync(entryUZIP, ScrollToPosition.Center, true);

                    }
                    else if (boolTandC == false)
                    {
                        DisplayThisAlert("You must accept the terms and conditions.");
                    }
                    else
                    {
                        Constants.apiurlExtendedUserId = WebUtility.UrlEncode(entryUEmail.Text);

                        userP.application = "mobFleetApp";
                        userP.givenName = entryUFirstName.Text;
                        userP.sn = entryULastName.Text;
                        userP.mail = entryUEmail.Text;
                        switch (mobileType)
                        {
                            case "Mobile":
                                userP.mobile = entryUPhone.Text;
                                userP.homePhoneNumber = "";
                                userP.telephoneNumber = "";
                                break;
                            case "Home":
                                userP.mobile = "";
                                userP.homePhoneNumber = entryUPhone.Text;
                                userP.telephoneNumber = "";
                                break;
                            case "Work":
                                userP.mobile = "";
                                userP.homePhoneNumber = "";
                                userP.telephoneNumber = entryUPhone.Text;
                                break;
                            default:
                                userP.mobile = entryUPhone.Text;
                                userP.homePhoneNumber = "";
                                userP.telephoneNumber = "";
                                break;
                        }
                        userP.Company_entered_byUser = entryUBusiness.Text ?? "";
                        userP.Company_Zip = entryUZIP.Text ?? "";
                        userP.Fuel_Preference = fuelPref;
                        userP.Receive_Ryder_Communication = (switchCommunications.IsToggled) ? "1" : "0";

                        userE.MobFleetApp = "1";
                        userE.FIS_Rental = truckData;
                        userE.lessee = fleetData;

                        userRR.UserProfile = userP;
                        userRR.Entitlements = userE;
                        Navigation.PushModalAsync(new RegisterStepTwo());
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

        #region for entry focus after validation
        void SelectedEntry(object sender, FocusEventArgs e)
        {
            try
            {
                var owner = (CustomEntry)sender;
                owner.BorderColors = AppGlobalVariables.entryBorderColor;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
        #endregion
    }
}