using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FMS
{
    public partial class RegisterStepThree : BaseContentPage
    {
        int intPassMinLength = 6;
        public RegisterStepThree()
        {
            #region for local variables
            int height = (screenHeight * 1) / 100;
            int width = (screenWidth * 1) / 100;
            if (!string.IsNullOrEmpty(RegisterStepOne.rso.userP.employeeNumber) || RegisterStepOne.rso.userE.FIS_Rental.Count > 0 || RegisterStepOne.rso.userE.lessee.Count > 0)
            {
                intPassMinLength = 8;
            }
            else
            {
                intPassMinLength = 6;
            }
            #endregion
            InitializeComponent();

            #region for Custom Style

            #region for Entry styles
            Resources = new ResourceDictionary();

            var styleEntryInput = new Style(typeof(CustomEntry))
            {
                Setters = {
                    new Setter { Property = CustomEntry.PlaceholderColorProperty, Value = AppGlobalVariables.black  },
                    new Setter { Property = CustomEntry.TextColorProperty, Value = AppGlobalVariables.black  },
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
                //Margin = new Thickness(0, Device.OnPlatform(height * 0, height * 1.5, height * 2.5), 0, 0),
                FontSize = Device.OnPlatform(height * 2.3, height * 2.5, height * 2.5),
                TextColor = AppGlobalVariables.black,
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
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.OnPlatform(height * 3, height * 3, height * 3),
                TextColor = AppGlobalVariables.black,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            var lblPageTitle = new Label
            {
                Text = "Create a password",
                TextColor = AppGlobalVariables.black,
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
                TextColor = AppGlobalVariables.black,
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
                BorderColors = AppGlobalVariables.entryBorderColor,
                Style = (Style)Resources["styleEntryInput"]
            };
            CustomEntry entryUConfirlPassword = new CustomEntry()
            {
                Placeholder = "[CONFIRM PASSWORD]*",
                IsCustomPassword = true,
                BorderColors = AppGlobalVariables.entryBorderColor,
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
                TextColor = AppGlobalVariables.white,
                HeightRequest = height * 7,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            BoxView boxNext = new BoxView()
            {
                Color = AppGlobalVariables.gray,
                HeightRequest = height * 7,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center
            };
            BoxView boxNextGesture = new BoxView()
            {
                Color = AppGlobalVariables.transparent,
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
            pageControlsStackLayout.Children.Add(stackMain);
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
            nextBtnTapped.Tapped += async (object sender, EventArgs e) =>
            {
                try
                {
                    if (string.IsNullOrEmpty(entryUPassword.Text))
                    {
                        entryUPassword.BorderColors = AppGlobalVariables.entryBorderErrorColor;
                        entryUPassword.Text = entryUPassword.Text + " ";
                        entryUPassword.Text = entryUPassword.Text.Remove(entryUPassword.Text.Length - 1);

                        DisplayThisAlert("Password Cannot be empty");
                    }
                    //else if (!Regex.IsMatch(entryUPassword.Text, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$"))
                    //{
                    //    entryUPassword.BorderColors = AppGlobalVariables.entryBorderErrorColor;
                    //    entryUPassword.Text = entryUPassword.Text + " ";
                    //    entryUPassword.Text = entryUPassword.Text.Remove(entryUPassword.Text.Length - 1);
                    //    DisplayThisAlert("“Must contain lowercase/uppercase, numbers and possibly special characters");
                    //}
                    else if (string.IsNullOrEmpty(entryUConfirlPassword.Text))
                    {
                        entryUConfirlPassword.BorderColors = AppGlobalVariables.entryBorderErrorColor;
                        entryUConfirlPassword.Text = entryUConfirlPassword.Text + " ";
                        entryUConfirlPassword.Text = entryUConfirlPassword.Text.Remove(entryUConfirlPassword.Text.Length - 1);

                        DisplayThisAlert("Confirm password Cannot be empty");
                    }
                    //else if (!Regex.IsMatch(entryUConfirlPassword.Text, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$"))
                    //{
                    //    entryUConfirlPassword.BorderColors = AppGlobalVariables.entryBorderErrorColor;
                    //    entryUConfirlPassword.Text = entryUConfirlPassword.Text + " ";
                    //    entryUConfirlPassword.Text = entryUConfirlPassword.Text.Remove(entryUConfirlPassword.Text.Length - 1);
                    //    DisplayThisAlert("The last name Cannot be empty");
                    //}
                    else if (!(entryUPassword.Text == entryUConfirlPassword.Text))
                    {
                        entryUPassword.BorderColors = AppGlobalVariables.entryBorderErrorColor;
                        entryUPassword.Text = entryUPassword.Text + " ";
                        entryUPassword.Text = entryUPassword.Text.Remove(entryUPassword.Text.Length - 1);
                        entryUConfirlPassword.BorderColors = AppGlobalVariables.entryBorderErrorColor;
                        entryUConfirlPassword.Text = entryUConfirlPassword.Text + " ";
                        entryUConfirlPassword.Text = entryUConfirlPassword.Text.Remove(entryUConfirlPassword.Text.Length - 1);

                        DisplayThisAlert("Passwords did not match");
                    }
                    else
                    {
                        var response = await validatePassword(entryUPassword.Text);
                        if (response == true)
                        {
                            RegisterStepOne.rso.userP.password = entryUPassword.Text;
                            RegisterStepOne.rso.userP.confirmPassword = entryUConfirlPassword.Text;
                            RegisterStepOne.rso.userP.forcePasswordReset = "false";

                            UserRegister();
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
                owner.BorderColors = AppGlobalVariables.entryBorderColor;
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
            pageLoading.IsVisible = true;
            try
            {
                using (IUserRegistrationBAL userRegisterService = new UserRegistrationBAL())
                {
                    var response = await userRegisterService.UserRegistration(RegisterStepOne.rso.userRR);
                    if (response != null)
                    {
                        if (response.statusCode[0] == "201")
                        {
                            await DisplayThisChoice(response.statusDescription);
                            Navigation.PushModalAsync(new RegisterComplete());
                        }
                        else
                        {
                            string strMessage = response.statusDescription;
                            foreach (var msgs in response.messages)
                            {
                                strMessage += msgs;
                            }
                            DisplayThisAlert(strMessage);
                        }
                    }
                    else
                    {
                        await DisplayThisChoice("Server error");
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                await DisplayThisChoice("Server/Network error");
            }
            pageLoading.IsVisible = false;
        }
        #endregion

        #region for password validation
        public async Task<bool> validatePassword(string strPass)
        {
            bool isValid = false;
            FormattedString fsError = new FormattedString();
            fsError.Spans.Clear();
            try
            {
                int intPassStrength = 0;
                string strPassStrength = "";
                bool hasCapiAlpha = false, hasSmallAlpha = false, hasNumeric = false, hasSpecialChar = false, hasEnoughLength = false, isrepitative = false;
                var charArrPass = strPass.ToCharArray();
                if (strPass.Length >= intPassMinLength && strPass.Length <= 15)
                {
                    hasEnoughLength = true;
                    foreach (var str in charArrPass)
                    {
                        if (Regex.IsMatch(str.ToString(), @"^([a-z])$"))
                        {

                            hasSmallAlpha = true;
                        }
                        else if (Regex.IsMatch(str.ToString(), @"^([A-Z])$"))
                        {
                            hasCapiAlpha = true;
                        }
                        else if (Regex.IsMatch(str.ToString(), @"^(\d)$"))
                        {
                            hasNumeric = true;
                        }
                        else if (Regex.IsMatch(str.ToString(), @"^([^\da-zA-Z])$"))
                        {
                            hasSpecialChar = true;
                        }
                        if (Regex.IsMatch(str.ToString(), @"^(?!.*([A-Za-z0-9])\1{2})$"))
                        {
                            isrepitative = true;
                        }
                        else
                        {

                        }
                    }
                    intPassStrength += 3;
                    if (hasSmallAlpha == true && hasCapiAlpha == true && hasSpecialChar == true)
                    {
                        intPassStrength += 5;
                    }
                    if (hasSpecialChar == true)
                    {
                        intPassStrength += 2;
                    }
                }
                else
                {
                    hasEnoughLength = false;
                }

                if (intPassStrength < 5)
                {
                    strPassStrength = "\"Too Weak. \"";
                }
                else if (intPassStrength < 8)
                {
                    strPassStrength = "\"Weak. \"";
                }
                else if (intPassStrength < 10)
                {
                    strPassStrength = "\"Acceptable.However. \"";
                }
                else
                {
                    strPassStrength = "\"Good. \"";
                }

                if (hasEnoughLength == false)
                {
                    isValid = false;
                    fsError.Spans.Add(new Span { Text = strPassStrength, ForegroundColor = Color.Black });
                    fsError.Spans.Add(new Span { Text = "Text length should be from " + intPassMinLength + " - 15 characters", ForegroundColor = Color.Black });
                    DisplayCustomAlert("Alert", fsError);
                }
                else if (hasSmallAlpha == false)
                {
                    isValid = false;
                    fsError.Spans.Add(new Span { Text = strPassStrength, ForegroundColor = Color.Black });
                    fsError.Spans.Add(new Span { Text = "Must contain ", ForegroundColor = Color.Black });
                    fsError.Spans.Add(new Span() { Text = "lowercase", ForegroundColor = AppGlobalVariables.orange });
                    fsError.Spans.Add(new Span { Text = "/uppercase, numbers and possibly special characters", ForegroundColor = Color.Black });
                    DisplayCustomAlert("Alert", fsError);
                }
                else if (hasCapiAlpha == false)
                {
                    isValid = false;
                    fsError.Spans.Add(new Span { Text = strPassStrength, ForegroundColor = Color.Black });
                    fsError.Spans.Add(new Span { Text = "Must contain lowercase/", ForegroundColor = Color.Black });
                    fsError.Spans.Add(new Span() { Text = "uppercase", ForegroundColor = AppGlobalVariables.orange });
                    fsError.Spans.Add(new Span { Text = ", numbers and possibly special characters", ForegroundColor = Color.Black });
                    DisplayCustomAlert("Alert", fsError);
                }
                else if (hasNumeric == false)
                {
                    isValid = false;
                    fsError.Spans.Add(new Span { Text = strPassStrength, ForegroundColor = Color.Black });
                    fsError.Spans.Add(new Span { Text = "Must contain lowercase/uppercase, ", ForegroundColor = Color.Black });
                    fsError.Spans.Add(new Span() { Text = "numbers", ForegroundColor = AppGlobalVariables.orange });
                    fsError.Spans.Add(new Span { Text = " and possibly special characters", ForegroundColor = Color.Black });
                    DisplayCustomAlert("Alert", fsError);
                }
                else if (hasSpecialChar == false)
                {
                    isValid = false;
                    fsError.Spans.Add(new Span { Text = strPassStrength, ForegroundColor = Color.Black });
                    fsError.Spans.Add(new Span { Text = "Must contain lowercase/uppercase, numbers and possibly ", ForegroundColor = Color.Black });
                    fsError.Spans.Add(new Span() { Text = "special characters", ForegroundColor = AppGlobalVariables.orange });
                    DisplayCustomAlert("Alert", fsError);
                }
                else if (isrepitative == true)
                {
                    isValid = false;
                    fsError.Spans.Add(new Span { Text = strPassStrength, ForegroundColor = Color.Black });
                    fsError.Spans.Add(new Span { Text = "No character must repeat more than 2 times", ForegroundColor = Color.Black });
                    DisplayCustomAlert("Alert", fsError);
                }
                else
                {
                    isValid = true;
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return isValid;
        }
        #endregion

    }
}