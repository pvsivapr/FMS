using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FMS
{
    public partial class RegisterStepTwo : ContentPage
    {

        bool testIsActive = true;
        StackLayout stackRentChildren, stackFleetChildren, stackOtherChildren;

        public RegisterStepTwo()
        {
            //InitializeComponent();

            #region for local variables
            int height = (BaseContentPage.screenHeight * 1) / 100;
            int width = (BaseContentPage.screenWidth * 1) / 100;
            bool isEditRent = false, isEditFleet = false, isEditOther = false;
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
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            var stakBack = new StackLayout
            {
                Padding = new Thickness(0, 5, 0, 5),
                Children =
                {
lblBackBtn
                }
            };
            Label lblTitle = new Label()
            {
                Text = "STEP 2:",
                HeightRequest = height * 8,
                //BackgroundColor = Color.Green,
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.OnPlatform(height * 3, height * 3, height * 3),
                TextColor = AppGlobalVariables.black,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            var lblBack = new CustomUlineLabel
            {
                Text = "<back",
                HorizontalOptions = LayoutOptions.Start,
                ShallUnderLine = true
            };
            var lblTellme = new Label
            {
                Text = "Tell us about yourself",
                FontAttributes = FontAttributes.Bold,
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start
            };
            var lblDes = new Label
            {
                Text = "Telling us about yourself will help us tailor the app to your needs.",
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            Grid gridHeader = new Grid()
            {
                RowDefinitions =
                {
                    new RowDefinition{ Height = new GridLength(1, GridUnitType.Star)},
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
            gridHeader.Children.Add(stakBack, 1, 0);
            gridHeader.Children.Add(lblTitle, 2, 0);
            //gridHeader.Children.Add(lblTellme, 0, 5, 1, 2);

            #endregion

            #region for Drive

            var imgDriveCheck = new Image
            {
                Source = "Unchecked.png",
                HeightRequest = 25,
                WidthRequest = 25,
            };
            var lbldriveRyder = new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                Text = "Do you drive for Ryder?*",
                TextColor = AppGlobalVariables.black,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(CustomEntry)),
            };
            var lblYes = new Label
            {
                Text = "Yes",
                TextColor = AppGlobalVariables.black,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(CustomEntry)),
            };

            var imgYes = new Image
            {
                Source = "imgRadioNo.png",
                HeightRequest = 30,
                WidthRequest = 30
            };
            var genderTest = "Yes";

            var stackYes = new StackLayout
            {
                Spacing = 3,
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Children = { imgYes, lblYes }
            };


            var lblNo = new Label
            {
                Text = "No",
                TextColor = AppGlobalVariables.black,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(CustomEntry)),
            };

            var imgNo = new Image
            {
                Source = "imgRadioNo.png",
                HeightRequest = 30,
                WidthRequest = 30
            };

            var stackNo = new StackLayout
            {
                Spacing = 3,
                Orientation = StackOrientation.Horizontal,
                Children = { imgNo, lblNo },
                HorizontalOptions = LayoutOptions.EndAndExpand,
            };

            var stackYes1 = new StackLayout
            {
                Spacing = 5,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Orientation = StackOrientation.Horizontal,
                Children = { stackYes, stackNo }
            };

            var stackIDrive = new StackLayout
            {
                IsVisible = false,
                Padding = new Thickness(30, 0, 0, 0),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Children = { lbldriveRyder, stackYes1 }
            };

            var frameEdior = new CustomEditor
            {
                IsVisible = false,
                Placeholder = " [ENTER SAP NUMBER]",
                //HeightRequest = height * 10,
                HeightRequest = Device.OnPlatform(height * 7, height * 10, height * 7),
            };
            var btnSubmit = new Button
            {
                Text = "SUBMIT",
                IsVisible = false,
                TextColor = Color.Black,
                Margin = new Thickness(60, 0, 60, 0),
                BackgroundColor = Color.FromRgb(212, 212, 212)
            };
            var stackbtnSbumit = new StackLayout
            {
                Spacing = 12,
                //Padding = new Thickness(0, 20, 0, 0),
                Children = { frameEdior, btnSubmit }
            };
            var lblRederSapNum = new Label
            {
                Text = "Ryder SAP number.",
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            var lblsapNo = new Label
            {
                HorizontalOptions = LayoutOptions.StartAndExpand
            };
            var imgSapEdit = new Image
            {
                HorizontalOptions = LayoutOptions.EndAndExpand,
                Source = "imgEdit"
            };

            var entryEditSapNo = new CustomEntry
            {
                HeightRequest = Device.OnPlatform(height * 7, height * 10, height * 7),
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            var imgTick = new Image
            {
                Source = "tick.png"
            };
            var imgClose = new Image
            {
                Source = "imgClose.png"
            };
            var stackEditSapNo = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                IsVisible = false,
                Children =
                {
                  entryEditSapNo,imgTick,imgClose
                }
            };
            var stackimgEdit = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                        {
                            lblsapNo,imgSapEdit
                        }
            };
            var stackSap = new StackLayout
            {
                Padding = new Thickness(30, 0, 20, 0),
                IsVisible = false,
                Children =
                {
                   lblRederSapNum,
                   stackimgEdit,
                   stackEditSapNo
                }
            };

            var imgDriveCheckTap = new TapGestureRecognizer();
            imgDriveCheckTap.Tapped += (s, e) =>
                                            {
                                                if (testIsActive == true)
                                                {
                                                    imgDriveCheck.Source = "Checked.png";
                                                    testIsActive = false;
                                                    stackIDrive.IsVisible = true;
                                                    //frameEdior.Text = " [ENTER SAP NUMBER]";
                                                }
                                                else
                                                {
                                                    imgDriveCheck.Source = "Unchecked.png";
                                                    imgYes.Source = "imgRadioNo.png";
                                                    imgNo.Source = "imgRadioNo.png";
                                                    testIsActive = true;
                                                    stackIDrive.IsVisible = false;
                                                    stackbtnSbumit.IsVisible = false;
                                                    stackSap.IsVisible = false;

                                                }
                                            };

            imgDriveCheck.GestureRecognizers.Add(imgDriveCheckTap);


            var imgYesTap = new TapGestureRecognizer();
            imgYesTap.Tapped += (s, e) =>
                                    {
                                        imgNo.Source = "imgRadioNo.png";
                                        imgYes.Source = "imgRadioYes.png";
                                        genderTest = "Yes";
                                        //stackIDrive.IsVisible = true;
                                        btnSubmit.IsVisible = true;
                                        frameEdior.IsVisible = true;
                                        stackbtnSbumit.IsVisible = true;

                                    };

            imgYes.GestureRecognizers.Add(imgYesTap);


            var imgNoTap = new TapGestureRecognizer();
            imgNoTap.Tapped += (s, e) =>
                                    {
                                        imgYes.Source = "imgRadioNo.png";
                                        imgNo.Source = "imgRadioYes.png";
                                        genderTest = "Yes";

                                        stackIDrive.IsVisible = true;
                                        btnSubmit.IsVisible = false;
                                        frameEdior.IsVisible = false;

                                    };

            imgNo.GestureRecognizers.Add(imgNoTap);



            var lblDriveTruck = new Label
            {
                Text = "I drive a truck",
                FontAttributes = FontAttributes.Bold
            };

            #endregion

            #region for Rent trucks


            var lblRentTrucks = new Label
            {
                Text = "I rent trucks",
                FontAttributes = FontAttributes.Bold
            };
            var lblRentYes = new Label
            {
                Text = "Yes",
                TextColor = AppGlobalVariables.black,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(CustomEntry)),
                //CustomFontFamily = AppGlobalVariables.fontFamily45
            };

            var imgRentYes = new Image
            {
                Source = "imgRadioNo.png",
                HeightRequest = 30,
                WidthRequest = 30
            };
            var RentTest = "Yes";

            var stackRentYes = new StackLayout
            {
                Spacing = 3,
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Children = { imgRentYes, lblRentYes }
            };


            var lblRentNo = new Label
            {
                Text = "No",
                TextColor = AppGlobalVariables.black,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(CustomEntry)),
                //CustomFontFamily = AppGlobalVariables.fontFamily45
            };

            var imgRentNo = new Image
            {
                Source = "imgRadioNo.png",
                HeightRequest = 30,
                WidthRequest = 30
            };



            var stackRentNo = new StackLayout
            {
                Spacing = 3,
                Orientation = StackOrientation.Horizontal,
                Children = { imgRentNo, lblRentNo },
                HorizontalOptions = LayoutOptions.EndAndExpand,
            };


            var stackRentYes1 = new StackLayout
            {
                Spacing = 5,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Orientation = StackOrientation.Horizontal,
                Children = { stackRentYes, stackRentNo }
            };
            var lblRentRyder = new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                Text = "Do you rent from Ryder?*",
                TextColor = AppGlobalVariables.black,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(CustomEntry)),
            };


            var stackRentDrive = new StackLayout
            {
                IsVisible = false,
                Padding = new Thickness(30, 0, 0, 0),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Children = { lblRentRyder, stackRentYes1 }
            };

            var frameRentEdior = new CustomEditor
            {
                IsVisible = false,
                Placeholder = " [ENTER ACCOUNT NUMBER]",
                HeightRequest = Device.OnPlatform(height * 7, height * 10, height * 7),

            };

            var btnRentSubmit = new Button
            {
                Text = "SUBMIT",
                IsVisible = false,
                Margin = new Thickness(60, 0, 60, 0),
                BackgroundColor = Color.FromRgb(212, 212, 212),
                TextColor = Color.Black,
            };

            var imgRentCheck = new Image
            {
                Source = "Unchecked.png",
                HeightRequest = 25,
                WidthRequest = 25,
            };


            var stackbtnRentSbumit = new StackLayout
            {
                Spacing = 12,
                Children = { frameRentEdior, btnRentSubmit }
            };



            var lblRederAccountNum = new Label
            {
                Text = "Ryder account number.",
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            var lblRentAddMore = new CustomUlineLabel
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Text = "ADD ANOTHER ACCOUNT #",
                ShallUnderLine = true,
            };
            var stackRentAdd = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 6,
                Children =
                {
                    new Image
                    {
                        Source="imgAdd"

                    },
                    lblRentAddMore

                }
            };

            stackRentChildren = new StackLayout { };
            var stackAcnt = new StackLayout
            {
                Padding = new Thickness(30, 0, 20, 0),
                Spacing = 10,
                IsVisible = false,
                Children =
                {
                   lblRederAccountNum,
                   stackRentChildren,
                   stackRentAdd
                }
            };



            var imgRentCheckTap = new TapGestureRecognizer();
            imgRentCheckTap.Tapped += (s, e) =>
                                                                                {
                                                                                    if (testIsActive == true)
                                                                                    {
                                                                                        imgRentCheck.Source = "Checked.png";
                                                                                        testIsActive = false;
                                                                                        stackRentDrive.IsVisible = true;
                                                                                        //isActiveCheck = "true";
                                                                                        //frameRentEdior.Text = " [ENTER ACCOUNT NUMBER]";
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        imgRentCheck.Source = "Unchecked.png";
                                                                                        imgRentYes.Source = "imgRadioNo.png";
                                                                                        imgRentNo.Source = "imgRadioNo.png";
                                                                                        testIsActive = true;
                                                                                        stackRentDrive.IsVisible = false;
                                                                                        stackbtnRentSbumit.IsVisible = false;
                                                                                        stackAcnt.IsVisible = false;
                                                                                    }
                                                                                };

            imgRentCheck.GestureRecognizers.Add(imgRentCheckTap);


            var imgRentYesTap = new TapGestureRecognizer();
            imgRentYesTap.Tapped += (s, e) =>
                                                                        {
                                                                            imgRentNo.Source = "imgRadioNo.png";
                                                                            imgRentYes.Source = "imgRadioYes.png";
                                                                            RentTest = "Yes";
                                                                            btnRentSubmit.IsVisible = true;
                                                                            frameRentEdior.IsVisible = true;
                                                                            stackbtnRentSbumit.IsVisible = true;
                                                                        };

            imgRentYes.GestureRecognizers.Add(imgRentYesTap);


            var imgRentNoTap = new TapGestureRecognizer();
            imgRentNoTap.Tapped += (s, e) =>
                                                                        {
                                                                            imgRentYes.Source = "imgRadioNo.png";
                                                                            imgRentNo.Source = "imgRadioYes.png";
                                                                            RentTest = "Yes";
                                                                            stackRentDrive.IsVisible = true;
                                                                            btnRentSubmit.IsVisible = false;
                                                                            frameRentEdior.IsVisible = false;
                                                                        };

            imgRentNo.GestureRecognizers.Add(imgRentNoTap);



            var stackRent = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { imgRentCheck, lblRentTrucks }
            };

            #endregion

            #region for Fleet


            var imgFleetCheck = new Image
            {
                Source = "Unchecked.png",
                HeightRequest = 25,
                WidthRequest = 25,
            };
            var imgOtherCheck = new Image
            {
                Source = "Unchecked.png",
                HeightRequest = 25,
                WidthRequest = 25,
            };
            var lblFleet = new Label
            {
                Text = "I have a fleet",
                FontAttributes = FontAttributes.Bold
            };

            var lblFleetYes = new Label
            {
                Text = "Yes",
                TextColor = AppGlobalVariables.black,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(CustomEntry)),
                //CustomFontFamily = AppGlobalVariables.fontFamily45
            };

            var imgFleetYes = new Image
            {
                Source = "imgRadioNo.png",
                HeightRequest = 30,
                WidthRequest = 30
            };
            var FleetTest = "Yes";

            var stackFleetYes = new StackLayout
            {
                Spacing = 3,
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Children = { imgFleetYes, lblFleetYes }
            };


            var lblFleetNo = new Label
            {
                Text = "No",
                TextColor = AppGlobalVariables.black,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(CustomEntry)),
                //CustomFontFamily = AppGlobalVariables.fontFamily45
            };

            var imgFleetNo = new Image
            {
                Source = "imgRadioNo.png",
                HeightRequest = 30,
                WidthRequest = 30
            };



            var stackFleetNo = new StackLayout
            {
                Spacing = 3,
                Orientation = StackOrientation.Horizontal,
                Children = { imgFleetNo, lblFleetNo },
                HorizontalOptions = LayoutOptions.EndAndExpand,
            };


            var stackFleetYes1 = new StackLayout
            {
                Spacing = 5,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Orientation = StackOrientation.Horizontal,
                Children = { stackFleetYes, stackFleetNo }
            };
            var lblFleetRyder = new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                Text = "Do you use Ryder to manage \nfleet?*",
                TextColor = AppGlobalVariables.black,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(CustomEntry)),
            };


            var stackFleetDrive = new StackLayout
            {
                IsVisible = false,
                Padding = new Thickness(30, 0, 0, 0),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Children = { lblFleetRyder, stackFleetYes1 }
            };

            var frameFleetEdior = new CustomEditor
            {
                IsVisible = false,
                Placeholder = " [ENTER LESSEE NUMBER]",
                HeightRequest = Device.OnPlatform(height * 7, height * 10, height * 7),

            };

            var btnFleetSubmit = new Button
            {
                Text = "SUBMIT",
                TextColor = Color.Black,
                IsVisible = false,
                Margin = new Thickness(60, 0, 60, 0),
                BackgroundColor = Color.FromRgb(212, 212, 212)
            };
            var stackbtnFleetSbumit = new StackLayout
            {
                Spacing = 12,
                Children = { frameFleetEdior, btnFleetSubmit }
            };

            var frameFleetBNameEdior = new CustomEditor
            {
                Placeholder = " [ENTER BUSINESS NAME]",
                HeightRequest = Device.OnPlatform(height * 7, height * 10, height * 7),

            };
            var frameFleetBZipEdior = new CustomEditor
            {
                Placeholder = " [BUSINESS ZIP]",
                HeightRequest = Device.OnPlatform(height * 7, height * 10, height * 7)

            };
            var btnFleetBusinessSubmit = new Button
            {
                Text = "SUBMIT",
                TextColor = Color.Black,
                Margin = new Thickness(60, 0, 60, 0),
                BackgroundColor = Color.FromRgb(212, 212, 212)
            };

            var stackFleetBusiness = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                IsVisible = false,
                Spacing = 10,
                Children =
                {
                   frameFleetBNameEdior,frameFleetBZipEdior,btnFleetBusinessSubmit
                }
            };



            var lblRederFleetLesseNum = new Label
            {
                Text = "Ryder lessee number.",
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            stackFleetChildren = new StackLayout()
            {
            };
            var lblFleetLesseAddMore = new CustomUlineLabel
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Text = "ADD ANOTHER LESSEE #",
                ShallUnderLine = true
            };

            var stackFleetAdd = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 6,
                Children =
                {
                    new Image
                    {
                        Source="imgAdd"
                    },
                  lblFleetLesseAddMore

                }
            };


            var stackFleetLessee = new StackLayout
            {
                Padding = new Thickness(30, 0, 20, 0),
                Spacing = 10,
                IsVisible = false,
                Children =
                {
                   lblRederFleetLesseNum,
                    stackFleetChildren,

                   stackFleetAdd
                        }
            };





            var imgFleetCheckTap = new TapGestureRecognizer();
            imgFleetCheckTap.Tapped += (s, e) =>
                                                                                            {
                                                                                                if (testIsActive == true)
                                                                                                {
                                                                                                    imgFleetCheck.Source = "Checked.png";
                                                                                                    testIsActive = false;
                                                                                                    stackFleetDrive.IsVisible = true;
                                                                                                    //isActiveCheck = "true";
                                                                                                    //frameFleetEdior.Text = " [ENTER LESSEE NUMBER]";
                                                                                                    stackFleetBusiness.IsVisible = false;
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    imgFleetCheck.Source = "Unchecked.png";
                                                                                                    imgFleetYes.Source = "imgRadioNo.png";
                                                                                                    imgFleetNo.Source = "imgRadioNo.png";
                                                                                                    testIsActive = true;
                                                                                                    stackFleetDrive.IsVisible = false;
                                                                                                    stackbtnFleetSbumit.IsVisible = false;
                                                                                                    stackFleetLessee.IsVisible = false;
                                                                                                    stackFleetBusiness.IsVisible = false;

                                                                                                }
                                                                                            };

            imgFleetCheck.GestureRecognizers.Add(imgFleetCheckTap);


            var imgFleetYesTap = new TapGestureRecognizer();
            imgFleetYesTap.Tapped += (s, e) =>
                                                                                                {
                                                                                                    imgFleetNo.Source = "imgRadioNo.png";
                                                                                                    imgFleetYes.Source = "imgRadioYes.png";
                                                                                                    FleetTest = "Yes";
                                                                                                    //stackFleetDrive.IsVisible = true;
                                                                                                    stackbtnFleetSbumit.IsVisible = true;
                                                                                                    btnFleetSubmit.IsVisible = true;
                                                                                                    frameFleetEdior.IsVisible = true;
                                                                                                    stackFleetBusiness.IsVisible = false;
                                                                                                };

            imgFleetYes.GestureRecognizers.Add(imgFleetYesTap);


            var imgFleetNoTap = new TapGestureRecognizer();
            imgFleetNoTap.Tapped += (s, e) =>
                                                                                                {
                                                                                                    imgFleetYes.Source = "imgRadioNo.png";
                                                                                                    imgFleetNo.Source = "imgRadioYes.png";
                                                                                                    FleetTest = "Yes";
                                                                                                    stackFleetDrive.IsVisible = true;
                                                                                                    btnFleetSubmit.IsVisible = false;
                                                                                                    frameFleetEdior.IsVisible = false;
                                                                                                    stackFleetBusiness.IsVisible = true;
                                                                                                    //stackFleetChildren.IsVisible = false;

                                                                                                };

            imgFleetNo.GestureRecognizers.Add(imgFleetNoTap);



            var stackFleet = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { imgFleetCheck, lblFleet }
            };

            #endregion

            #region for Others

            var lblOther = new Label();
            var fs = new FormattedString();
            fs.Spans.Add(new Span { Text = "Other ", FontAttributes = FontAttributes.Bold });
            fs.Spans.Add(new Span { Text = " (Accounting,\n" + " Administrative ,etc.) " });
            lblOther.FormattedText = fs;

            var lblOtherYes = new Label
            {
                Text = "Yes",
                TextColor = AppGlobalVariables.black,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(CustomEntry)),
                //CustomFontFamily = AppGlobalVariables.fontFamily45
            };

            var imgOtherYes = new Image
            {
                Source = "imgRadioNo.png",
                HeightRequest = 30,
                WidthRequest = 30
            };
            var OtherTest = "Yes";

            var stackOtherYes = new StackLayout
            {
                Spacing = 3,
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Children = { imgOtherYes, lblOtherYes }
            };


            var lblOtherNo = new Label
            {
                Text = "No",
                TextColor = AppGlobalVariables.black,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(CustomEntry)),
                //CustomFontFamily = AppGlobalVariables.fontFamily45
            };

            var imgOtherNo = new Image
            {
                Source = "imgRadioNo.png",
                HeightRequest = 30,
                WidthRequest = 30
            };



            var stackOtherNo = new StackLayout
            {
                Spacing = 3,
                Orientation = StackOrientation.Horizontal,
                Children = { imgOtherNo, lblOtherNo },
                HorizontalOptions = LayoutOptions.EndAndExpand,
            };


            var stackOtherYes1 = new StackLayout
            {
                Spacing = 5,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Orientation = StackOrientation.Horizontal,
                Children = { stackOtherYes, stackOtherNo }
            };
            var lblOtherRyder = new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                Text = "Do you use Ryder to manage \nfleet?*",
                TextColor = AppGlobalVariables.black,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(CustomEntry)),
            };


            var stackOtherDrive = new StackLayout
            {
                IsVisible = false,
                Padding = new Thickness(30, 0, 0, 0),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Children = { lblOtherRyder, stackOtherYes1 }
            };

            var frameOtherEdior = new CustomEditor
            {
                IsVisible = false,
                Placeholder = " [ENTER LESSEE NUMBER]",
                HeightRequest = Device.OnPlatform(height * 7, height * 10, height * 7),

            };

            var btnOtherSubmit = new Button
            {
                Text = "SUBMIT",
                IsVisible = false,
                TextColor = Color.Black,
                Margin = new Thickness(60, 0, 60, 0),
                BackgroundColor = Color.FromRgb(212, 212, 212)
            };
            var frameOtherBNameEdior = new CustomEditor
            {
                Placeholder = " [ENTER BUSINESS NAME]",
                HeightRequest = Device.OnPlatform(height * 7, height * 10, height * 7),

            };
            var frameOtherBZipEdior = new CustomEditor
            {
                Placeholder = " [BUSINESS ZIP]",
                HeightRequest = Device.OnPlatform(height * 7, height * 10, height * 7)

            };
            var btnOtherBusinessSubmit = new Button
            {
                Text = "SUBMIT",
                Margin = new Thickness(60, 0, 60, 0),
                BackgroundColor = Color.FromRgb(212, 212, 212),
                TextColor = Color.Black,
            };

            var stackOtherBusiness = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                IsVisible = false,
                Spacing = 10,
                Children =
                {
                 frameOtherBNameEdior,frameOtherBZipEdior,btnOtherBusinessSubmit
                }
            };
            var stackbtnOtherSbumit = new StackLayout
            {
                Spacing = 12,
                Children = { frameOtherEdior, btnOtherSubmit }
            };

            var lblRederOtherLesseNum = new Label
            {
                Text = "Ryder lessee number.",
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            var lblOtherLesseNo = new Label
            {
                HorizontalOptions = LayoutOptions.StartAndExpand
            };
            var imgOtherLesseEdit = new Image
            {
                HorizontalOptions = LayoutOptions.EndAndExpand
            };
            var lblOtherAddMore = new CustomUlineLabel
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Text = "ADD ANOTHER LESSEE #",
                ShallUnderLine = true
            };
            stackOtherChildren = new StackLayout()
            {
            };

            var stackOtherAdd = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 6,
                Children =
                {
                    new Image
                    {
                        Source="imgAdd"
                    },
                lblOtherAddMore

                }
            };
            var stackOtherLessee = new StackLayout
            {
                Padding = new Thickness(30, 0, 20, 0),
                Spacing = 10,
                IsVisible = false,
                Children =
                {
                   lblRederOtherLesseNum,
                   stackOtherChildren,
                    stackOtherAdd
                        }
            };





            var imgOtherCheckTap = new TapGestureRecognizer();
            imgOtherCheckTap.Tapped += (s, e) =>
                                                                                                        {
                                                                                                            if (testIsActive == true)
                                                                                                            {
                                                                                                                imgOtherCheck.Source = "Checked.png";
                                                                                                                testIsActive = false;
                                                                                                                stackOtherDrive.IsVisible = true;
                                                                                                                stackOtherBusiness.IsVisible = false;

                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                imgOtherCheck.Source = "Unchecked.png";
                                                                                                                imgOtherYes.Source = "imgRadioNo.png";
                                                                                                                imgOtherNo.Source = "imgRadioNo.png";
                                                                                                                testIsActive = true;
                                                                                                                stackOtherDrive.IsVisible = false;
                                                                                                                stackbtnOtherSbumit.IsVisible = false;
                                                                                                                stackOtherBusiness.IsVisible = false;
                                                                                                                stackOtherLessee.IsVisible = false;
                                                                                                            }
                                                                                                        };

            imgOtherCheck.GestureRecognizers.Add(imgOtherCheckTap);


            var imgOtherYesTap = new TapGestureRecognizer();
            imgOtherYesTap.Tapped += (s, e) =>
                                                                                                            {
                                                                                                                imgOtherNo.Source = "imgRadioNo.png";
                                                                                                                imgOtherYes.Source = "imgRadioYes.png";
                                                                                                                FleetTest = "Yes";
                                                                                                                btnOtherSubmit.IsVisible = true;
                                                                                                                frameOtherEdior.IsVisible = true;
                                                                                                                stackbtnOtherSbumit.IsVisible = true;
                                                                                                                stackOtherBusiness.IsVisible = false;

                                                                                                            };

            imgOtherYes.GestureRecognizers.Add(imgOtherYesTap);


            var imgOtherNoTap = new TapGestureRecognizer();
            imgOtherNoTap.Tapped += (s, e) =>
                                                                                                            {
                                                                                                                imgOtherYes.Source = "imgRadioNo.png";
                                                                                                                imgOtherNo.Source = "imgRadioYes.png";
                                                                                                                FleetTest = "Yes";
                                                                                                                stackOtherDrive.IsVisible = true;
                                                                                                                btnOtherSubmit.IsVisible = false;
                                                                                                                frameOtherEdior.IsVisible = false;
                                                                                                                stackOtherBusiness.IsVisible = true;
                                                                                                            };

            imgOtherNo.GestureRecognizers.Add(imgOtherNoTap);

            var stackOther = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { imgOtherCheck, lblOther }
            };

            #endregion

            #region for Body

            var stackTruck = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { imgDriveCheck, lblDriveTruck }
            };

            var stackIDriveMain = new StackLayout
            {
                Padding = new Thickness(0, 0, 0, 0),
                Spacing = 6,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Children = { stackTruck, stackIDrive, stackSap, stackbtnSbumit }
            };
            var stackRentMain = new StackLayout

            {
                Padding = new Thickness(0, 0, 0, 0),
                Spacing = 6,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Children = { stackRent, stackRentDrive, stackAcnt, stackbtnRentSbumit }
            };

            var stackFleetMain = new StackLayout

            {
                Padding = new Thickness(0, 0, 0, 0),
                Spacing = 6,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Children = { stackFleet, stackFleetDrive, stackFleetLessee, stackbtnFleetSbumit, stackFleetBusiness }
            };

            var stackOtherMain = new StackLayout

            {
                Padding = new Thickness(0, 0, 0, 0),
                Spacing = 6,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Children = { stackOther, stackOtherDrive, stackOtherLessee, stackbtnOtherSbumit, stackOtherBusiness }
            };


            var lblNext = new Label
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
            var stackNext = new StackLayout
            {
                Children = { lblNext },
                BackgroundColor = AppGlobalVariables.gray,
                HeightRequest = height * 7,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center
            };

            var stackBody = new StackLayout
            {
                Padding = new Thickness(10, 50, 10, 0),
                Spacing = 40,
                Children = { stackIDriveMain, stackRentMain, stackFleetMain, stackOtherMain }
            };

            var stackScrollBody = new StackLayout
            {
                Children =
                {
                    new StackLayout
                    {
                        Spacing=0,
                        Children=
                        {
                            new ContentView
                            {
                                Padding=new Thickness(10,15,0,0),
                                Content=lblDes
                            }

                        }
                    },
                     stackBody,

                    new ContentView
                    {
                        Padding = new Thickness(10, height*19, 10, 30),
                        Content= stackNext
                    }
                }
            };

            var stackMain = new StackLayout
            {
                Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0),
                Children = {
                    new StackLayout
                    {
                        Spacing=0,
                        Children=
                        {
                            gridHeader,
                            lblTellme,
                        }
                    },
                    new ScrollView
                    {
                        Content=stackScrollBody
                    }

                }
            };


            #endregion

            // Events  and methods

            btnSubmit.Clicked += async delegate
            {
                if (frameEdior.Text == null || frameEdior.Text == "" || frameEdior.Text == " [ENTER SAP NUMBER]")
                {
                    await DisplayAlert("Error", "Please enter SAP number.", "Cancel");
                }
                else
                {
                    stackSap.IsVisible = true;
                    lblsapNo.Text = frameEdior.Text.ToString();
                    stackbtnSbumit.IsVisible = false;
                    stackIDrive.IsVisible = false;
                    RegisterStepOne.rso.userP.employeeNumber = frameEdior.Text.ToString();
                }
            };

            btnRentSubmit.Clicked += delegate
                        {
                            if (frameRentEdior.Text == null || frameRentEdior.Text == "" || frameRentEdior.Text == " [ENTER ACCOUNT NUMBER]")
                            {
                                DisplayAlert("Error", "Please enter account number.", "Cancel");
                            }
                            else
                            {
                                bool isDuplicate = false;
                                if (RegisterStepOne.rso.truckData.Count != 0)
                                {
                                    foreach (var item in RegisterStepOne.rso.truckData)
                                    {
                                        if (item == frameRentEdior.Text)
                                        {
                                            isDuplicate = true;
                                        }
                                    }
                                }
                                if (isDuplicate == true)
                                {
                                    DisplayAlert("Alert", "Account number already exist.", "Cancel");
                                }
                                else
                                {

                                    //RentTruck(frameRentEdior.Text.ToString());
                                    stackAcnt.IsVisible = true;
                                    stackbtnRentSbumit.IsVisible = false;
                                    stackRentDrive.IsVisible = false;
                                    stackRentAdd.IsVisible = true;

                                    var lblAcntNo = new Label
                                    {
                                        Text = frameRentEdior.Text.ToString(),
                                        HorizontalOptions = LayoutOptions.StartAndExpand
                                    };
                                    var imgAcntEdit = new Image
                                    {
                                        Source = ImageSource.FromFile("imgEdit.png"),
                                        HorizontalOptions = LayoutOptions.EndAndExpand
                                    };

                                    var stackAcc = new StackLayout
                                    {
                                        Orientation = StackOrientation.Horizontal,
                                        Children = { lblAcntNo, imgAcntEdit }
                                    };



                                    var entryEditRent = new CustomEntry
                                    {
                                        HeightRequest = Device.OnPlatform(height * 7, height * 10, height * 7),
                                        HorizontalOptions = LayoutOptions.FillAndExpand,
                                    };
                                    var imgRentTick = new Image
                                    {
                                        Source = "tick.png"
                                    };
                                    var imgRentClose = new Image
                                    {
                                        Source = "imgClose.png"
                                    };
                                    var stackEditRent = new StackLayout
                                    {
                                        Orientation = StackOrientation.Horizontal,
                                        HorizontalOptions = LayoutOptions.FillAndExpand,
                                        IsVisible = false,
                                        Children =
                                         {
                                            entryEditRent,imgRentTick,imgRentClose
                                            }
                                    };
                                    stackRentChildren.Children.Add(stackAcc);
                                    stackRentChildren.Children.Add(stackEditRent);

                                    stackAcnt.IsVisible = true;
                                    stackbtnRentSbumit.IsVisible = false;
                                    stackRentDrive.IsVisible = false;
                                    stackRentAdd.IsVisible = true;
                                    RegisterStepOne.rso.truckData.Add(frameRentEdior.Text.ToString());

                                    string strEditRent = "";
                                    TapGestureRecognizer gestures = new TapGestureRecognizer();
                                    gestures.Tapped += (sender, e) =>
                                                                     {


                                                                         if (isEditRent == false)
                                                                         {
                                                                             strEditRent = lblAcntNo.Text;
                                                                             isEditRent = true;
                                                                             stackEditRent.IsVisible = true;
                                                                             stackAcc.IsVisible = false;
                                                                             entryEditRent.Text = lblAcntNo.Text;
                                                                         }
                                                                         else
                                                                         {
                                                                             DisplayAlert("Alert", "You can edit only one item at a time", "OK");

                                                                         }

                                                                     };
                                    imgAcntEdit.GestureRecognizers.Add(gestures);

                                    TapGestureRecognizer gesturesRentTick = new TapGestureRecognizer();
                                    gesturesRentTick.Tapped += (sender, e) =>
                                                                                 {
                                                                                     bool isDuplicateTick = false;
                                                                                     if (RegisterStepOne.rso.truckData.Count != 0)
                                                                                     {
                                                                                         foreach (var item in RegisterStepOne.rso.truckData)
                                                                                         {
                                                                                             if (item == entryEditRent.Text)
                                                                                             {
                                                                                                 isDuplicateTick = true;
                                                                                             }
                                                                                         }
                                                                                     }
                                                                                     if (isDuplicateTick == true)
                                                                                     {
                                                                                         DisplayAlert("Alert", "Account number already exist.", "Cancel");
                                                                                     }
                                                                                     else
                                                                                     {

                                                                                         stackEditRent.IsVisible = false;
                                                                                         stackAcc.IsVisible = true;
                                                                                         lblAcntNo.Text = entryEditRent.Text;

                                                                                         int index = RegisterStepOne.rso.truckData.IndexOf(frameRentEdior.Text.ToString());
                                                                                         RegisterStepOne.rso.truckData.RemoveAt(index);
                                                                                         RegisterStepOne.rso.truckData.Add(lblAcntNo.Text.ToString());
                                                                                         isEditRent = false;
                                                                                     }
                                                                                 };
                                    imgRentTick.GestureRecognizers.Add(gesturesRentTick);


                                    TapGestureRecognizer gesturesRentClose = new TapGestureRecognizer();
                                    gesturesRentClose.Tapped += (sender, e) =>
                                                                    {
                                                                        stackEditRent.IsVisible = false;
                                                                        stackAcc.IsVisible = true;
                                                                        isEditRent = false;
                                                                        //lblAcntNo.Text = entryEditRent.Text;
                                                                    };
                                    imgRentClose.GestureRecognizers.Add(gesturesRentClose);



                                }
                            }
                        };

            btnFleetSubmit.Clicked += delegate
                       {
                           if (frameFleetEdior.Text == null || frameFleetEdior.Text == "" || frameFleetEdior.Text == " [ENTER LESSEE NUMBER]")
                           {
                               DisplayAlert("Error", "Please enter lessee number.", "Cancel");
                           }
                           else
                           {
                               var lblAcntNo = new Label
                               {
                                   Text = frameFleetEdior.Text.ToString(),
                                   HorizontalOptions = LayoutOptions.StartAndExpand
                               };
                               var imgAcntEdit = new Image
                               {
                                   Source = ImageSource.FromFile("imgEdit.png"),
                                   HorizontalOptions = LayoutOptions.EndAndExpand
                               };

                               var stackAcc = new StackLayout
                               {
                                   Orientation = StackOrientation.Horizontal,
                                   Children = { lblAcntNo, imgAcntEdit }
                               };
                               var entryEditFleet = new CustomEntry
                               {
                                   HeightRequest = Device.OnPlatform(height * 7, height * 10, height * 7),
                                   HorizontalOptions = LayoutOptions.FillAndExpand,
                               };
                               var imgFleetTick = new Image
                               {
                                   Source = "tick.png"
                               };
                               var imgFleetClose = new Image
                               {
                                   Source = "imgClose.png"
                               };
                               var stackEditFleet = new StackLayout
                               {
                                   Orientation = StackOrientation.Horizontal,
                                   HorizontalOptions = LayoutOptions.FillAndExpand,
                                   IsVisible = false,
                                   Children =
                                         {
                                            entryEditFleet,imgFleetTick,imgFleetClose
                                          }
                               };

                               TapGestureRecognizer gestures = new TapGestureRecognizer();
                               gestures.Tapped += (sender, e) =>
                                           {
                                               if (isEditFleet == false)
                                               {

                                                   isEditFleet = true;
                                                   stackEditFleet.IsVisible = true;
                                                   stackAcc.IsVisible = false;
                                                   entryEditFleet.Text = lblAcntNo.Text;
                                               }
                                               else
                                               {
                                                   DisplayAlert("Alert", "You can edit only one item at a time", "OK");

                                               }
                                           };
                               imgAcntEdit.GestureRecognizers.Add(gestures);

                               TapGestureRecognizer gesturesFleetTick = new TapGestureRecognizer();
                               gesturesFleetTick.Tapped += (sender, e) =>
                                                    {
                                                        stackEditFleet.IsVisible = false;
                                                        stackAcc.IsVisible = true;
                                                        lblAcntNo.Text = entryEditFleet.Text;
                                                        RegisterStepOne.rso.fleetData.Add(lblAcntNo.Text.ToString());
                                                        isEditFleet = false;
                                                    };
                               imgFleetTick.GestureRecognizers.Add(gesturesFleetTick);


                               TapGestureRecognizer gesturesFleetClose = new TapGestureRecognizer();
                               gesturesFleetClose.Tapped += (sender, e) =>
                                                   {
                                                       stackEditFleet.IsVisible = false;
                                                       stackAcc.IsVisible = true;
                                                       isEditFleet = false;

                                                   };
                               imgFleetClose.GestureRecognizers.Add(gesturesFleetClose);

                               stackFleetChildren.Children.Add(stackAcc);
                               stackFleetChildren.Children.Add(stackEditFleet);
                               stackFleetLessee.IsVisible = true;
                               stackbtnFleetSbumit.IsVisible = false;
                               stackFleetDrive.IsVisible = false;
                               stackFleetAdd.IsVisible = true;
                               RegisterStepOne.rso.fleetData.Add(frameFleetEdior.Text.ToString());
                           }
                       };

            btnOtherSubmit.Clicked += delegate
                       {
                           if (frameOtherEdior.Text == null || frameOtherEdior.Text == "" || frameOtherEdior.Text == " [ENTER LESSEE NUMBER]")
                           {
                               DisplayAlert("Error", "Please enter lessee number.", "Cancel");
                           }
                           else
                           {

                               var lblAcntNo = new Label
                               {
                                   Text = frameOtherEdior.Text.ToString(),
                                   HorizontalOptions = LayoutOptions.StartAndExpand
                               };
                               var imgAcntEdit = new Image
                               {
                                   Source = ImageSource.FromFile("imgEdit.png"),
                                   HorizontalOptions = LayoutOptions.EndAndExpand
                               };

                               var stackAcc = new StackLayout
                               {
                                   Orientation = StackOrientation.Horizontal,
                                   Children = { lblAcntNo, imgAcntEdit }
                               };
                               var entryEditOther = new CustomEntry
                               {
                                   HeightRequest = Device.OnPlatform(height * 7, height * 10, height * 7),
                                   HorizontalOptions = LayoutOptions.FillAndExpand
                               };
                               var imgOtherTick = new Image
                               {
                                   Source = "tick.png"
                               };
                               var imgOtherClose = new Image
                               {
                                   Source = "imgClose.png"
                               };
                               var stackEditOther = new StackLayout
                               {
                                   Orientation = StackOrientation.Horizontal,
                                   HorizontalOptions = LayoutOptions.FillAndExpand,
                                   IsVisible = false,
                                   Children =
                                         {
                                            entryEditOther,imgOtherTick,imgOtherClose
                                          }
                               };

                               TapGestureRecognizer gestures = new TapGestureRecognizer();
                               gestures.Tapped += (sender, e) =>
                                                  {
                                                      if (isEditOther == false)
                                                      {

                                                          isEditOther = true;
                                                          stackEditOther.IsVisible = true;
                                                          stackAcc.IsVisible = false;
                                                          entryEditOther.Text = lblAcntNo.Text;
                                                      }
                                                      else
                                                      {
                                                          DisplayAlert("Alert", "You can edit only one item at a time", "OK");

                                                      }
                                                  };
                               imgAcntEdit.GestureRecognizers.Add(gestures);

                               TapGestureRecognizer gesturesimgOtherTick = new TapGestureRecognizer();
                               gesturesimgOtherTick.Tapped += (sender, e) =>
                                                  {
                                                      stackEditOther.IsVisible = false;
                                                      stackAcc.IsVisible = true;
                                                      lblAcntNo.Text = entryEditOther.Text;
                                                      RegisterStepOne.rso.otherData.Add(lblAcntNo.Text.ToString());
                                                      isEditOther = false;
                                                  };
                               imgOtherTick.GestureRecognizers.Add(gesturesimgOtherTick);


                               TapGestureRecognizer gesturesimgOtherClose = new TapGestureRecognizer();
                               gesturesimgOtherClose.Tapped += (sender, e) =>
                                                                             {
                                                                                 stackEditOther.IsVisible = false;
                                                                                 stackAcc.IsVisible = true;
                                                                                 isEditOther = false;
                                                                             };
                               imgOtherClose.GestureRecognizers.Add(gesturesimgOtherClose);



                               stackOtherChildren.Children.Add(stackAcc);
                               stackOtherChildren.Children.Add(stackEditOther);
                               stackOtherLessee.IsVisible = true;
                               stackbtnOtherSbumit.IsVisible = false;
                               stackOtherDrive.IsVisible = false;
                               stackOtherAdd.IsVisible = true;
                               RegisterStepOne.rso.otherData.Add(frameOtherEdior.Text.ToString());
                           }
                       };

            var lblRentAddMoreTap = new TapGestureRecognizer();
            lblRentAddMoreTap.Tapped += (s, e) =>
                {
                    btnRentSubmit.IsVisible = true;
                    frameRentEdior.IsVisible = true;
                    stackbtnRentSbumit.IsVisible = true;
                    frameRentEdior.Text = string.Empty;
                    stackRentAdd.IsVisible = false;
                    frameRentEdior.Placeholder = "njabhcfx";

                };
            stackRentAdd.GestureRecognizers.Add(lblRentAddMoreTap);

            var lblFleetLesseAddMoreTap = new TapGestureRecognizer();
            lblFleetLesseAddMoreTap.Tapped += (s, e) =>
                                        {
                                            btnFleetSubmit.IsVisible = true;
                                            frameFleetEdior.IsVisible = true;
                                            stackbtnFleetSbumit.IsVisible = true;
                                            frameFleetEdior.Text = string.Empty;
                                            stackFleetAdd.IsVisible = false;

                                        };
            stackFleetAdd.GestureRecognizers.Add(lblFleetLesseAddMoreTap);

            var lblOtherAddMoreTap = new TapGestureRecognizer();
            lblOtherAddMoreTap.Tapped += (s, e) =>
                                                    {
                                                        btnOtherSubmit.IsVisible = true;
                                                        frameOtherEdior.IsVisible = true;
                                                        stackbtnOtherSbumit.IsVisible = true;
                                                        frameOtherEdior.Text = string.Empty;
                                                        stackOtherAdd.IsVisible = false;

                                                    };
            stackOtherAdd.GestureRecognizers.Add(lblOtherAddMoreTap);

            var lblBackTap = new TapGestureRecognizer();
            lblBackTap.Tapped += (s, e) =>
                                                    {
                                                        Navigation.PopModalAsync();

                                                    };
            lblBackBtn.GestureRecognizers.Add(lblBackTap);

            var stackNextTap = new TapGestureRecognizer();
            stackNextTap.Tapped += (s, e) =>
                                        {
                                            Navigation.PushModalAsync(new RegisterStepThree());
                                        };
            stackNext.GestureRecognizers.Add(stackNextTap);

            var imgSapEditTap = new TapGestureRecognizer();
            imgSapEditTap.Tapped += (s, e) =>
                            {
                                stackimgEdit.IsVisible = false;
                                stackEditSapNo.IsVisible = true;
                                entryEditSapNo.Text = lblsapNo.Text;
                            };
            imgSapEdit.GestureRecognizers.Add(imgSapEditTap);

            var imgTickTap = new TapGestureRecognizer();
            imgTickTap.Tapped += (s, e) =>
                                        {
                                            stackimgEdit.IsVisible = true;
                                            stackEditSapNo.IsVisible = false;
                                            lblsapNo.Text = entryEditSapNo.Text;
                                            RegisterStepOne.rso.userP.employeeNumber = lblsapNo.Text.ToString();
                                        };
            imgTick.GestureRecognizers.Add(imgTickTap);

            var imgCloseTap = new TapGestureRecognizer();
            imgCloseTap.Tapped += (s, e) =>
                                                                {
                                                                    stackimgEdit.IsVisible = true;
                                                                    stackEditSapNo.IsVisible = false;
                                                                    //    RegisterStepOne.rso.userP.employeeNumber = lblsapNo.Text.ToString();
                                                                };
            imgClose.GestureRecognizers.Add(imgCloseTap);


            #region for dynamic data loading
            if (!string.IsNullOrEmpty(RegisterStepOne.rso.userP.employeeNumber))
            {
                imgDriveCheck.Source = ImageSource.FromFile("Checked.png");
                stackSap.IsVisible = true;
                lblsapNo.Text = RegisterStepOne.rso.userP.employeeNumber;
                stackbtnSbumit.IsVisible = false;
                stackIDrive.IsVisible = false;
            }

            if (RegisterStepOne.rso.truckData.Count != 0)
            {
                foreach (var item in RegisterStepOne.rso.truckData)
                {
                    //RentTruck(item.ToString());
                    var lblAcntNo = new Label
                    {
                        Text = item,
                        HorizontalOptions = LayoutOptions.StartAndExpand
                    };
                    var imgAcntEdit = new Image
                    {
                        Source = ImageSource.FromFile("imgEdit.png"),
                        HorizontalOptions = LayoutOptions.EndAndExpand
                    };
                    var stackAcc = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Children = { lblAcntNo, imgAcntEdit }
                    };
                    stackRentChildren.Children.Add(stackAcc);
                    var entryEditRent = new CustomEntry
                    {
                        HeightRequest = Device.OnPlatform(height * 7, height * 10, height * 7),
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                    };
                    var imgRentTick = new Image
                    {
                        Source = "tick.png"
                    };
                    var imgRentClose = new Image
                    {
                        Source = "imgClose.png"
                    };
                    var stackEditRent = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        IsVisible = false,
                        Children =
                                     {
                                        entryEditRent,imgRentTick,imgRentClose
                                        }
                    };
                    stackRentChildren.Children.Add(stackEditRent);
                    TapGestureRecognizer gestures = new TapGestureRecognizer();
                    gestures.Tapped += (sender, e) =>
                                         {

                                             if (isEditRent == false)
                                             {
                                                 isEditRent = true;
                                                 stackEditRent.IsVisible = true;
                                                 stackAcc.IsVisible = false;
                                                 entryEditRent.Text = lblAcntNo.Text; ;
                                             }
                                             else
                                             {
                                                 DisplayAlert("Alert", "You can edit only one item at a time", "OK");

                                             }


                                         };
                    imgAcntEdit.GestureRecognizers.Add(gestures);
                    TapGestureRecognizer gesturesRentTick = new TapGestureRecognizer();
                    gesturesRentTick.Tapped += (sender, e) =>
                                                         {
                                                             bool isDuplicate = false;
                                                             if (RegisterStepOne.rso.truckData.Count != 0)
                                                             {
                                                                 foreach (var item1 in RegisterStepOne.rso.truckData)
                                                                 {
                                                                     if (item1 == entryEditRent.Text)
                                                                     {
                                                                         isDuplicate = true;
                                                                     }
                                                                 }
                                                             }
                                                             if (isDuplicate == true)
                                                             {
                                                                 DisplayAlert("Alert", "Account number already exist.", "Cancel");
                                                             }
                                                             else
                                                             {
                                                                 stackEditRent.IsVisible = false;
                                                                 stackAcc.IsVisible = true;
                                                                 lblAcntNo.Text = entryEditRent.Text;
                                                                 // RegisterStepOne.rso.truckData.Add(lblAcntNo.Text.ToString());
                                                                 int index = RegisterStepOne.rso.truckData.IndexOf(frameRentEdior.Text.ToString());
                                                                 RegisterStepOne.rso.truckData.RemoveAt(index);
                                                                 RegisterStepOne.rso.truckData.Add(lblAcntNo.Text.ToString());
                                                                 isEditRent = false;
                                                             }

                                                         };
                    imgRentTick.GestureRecognizers.Add(gesturesRentTick);


                    TapGestureRecognizer gesturesRentClose = new TapGestureRecognizer();
                    gesturesRentClose.Tapped += (sender, e) =>
                                                    {
                                                        isEditRent = false;
                                                        stackEditRent.IsVisible = false;
                                                        stackAcc.IsVisible = true;
                                                    };
                    imgRentClose.GestureRecognizers.Add(gesturesRentClose);

                }
                imgRentCheck.Source = ImageSource.FromFile("Checked.png");
                stackAcnt.IsVisible = true;
                stackbtnRentSbumit.IsVisible = false;
                stackRentDrive.IsVisible = false;
                stackRentAdd.IsVisible = true;
            }
            if (RegisterStepOne.rso.fleetData.Count != 0)
            {
                foreach (var item in RegisterStepOne.rso.fleetData)
                {
                    var lblAcntNo = new Label
                    {
                        Text = item,
                        HorizontalOptions = LayoutOptions.StartAndExpand
                    };
                    var imgAcntEdit = new Image
                    {
                        Source = ImageSource.FromFile("imgEdit.png"),
                        HorizontalOptions = LayoutOptions.EndAndExpand
                    };
                    var stackAcc = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Children = { lblAcntNo, imgAcntEdit }
                    };
                    var entryEditFleet = new CustomEntry
                    {
                        HeightRequest = Device.OnPlatform(height * 7, height * 10, height * 7),
                        HorizontalOptions = LayoutOptions.FillAndExpand
                    };
                    var imgFleetTick = new Image
                    {
                        Source = "tick.png"
                    };
                    var imgFleetClose = new Image
                    {
                        Source = "imgClose.png"
                    };
                    var stackEditFleet = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        IsVisible = false,
                        Children =
                                         {
                                            entryEditFleet,imgFleetTick,imgFleetClose
                                          }
                    };

                    TapGestureRecognizer gestures = new TapGestureRecognizer();
                    gestures.Tapped += (sender, e) =>
                                                               {
                                                                   if (isEditFleet == false)
                                                                   {

                                                                       isEditFleet = true;
                                                                       stackEditFleet.IsVisible = true;
                                                                       stackAcc.IsVisible = false;
                                                                       entryEditFleet.Text = lblAcntNo.Text;
                                                                   }
                                                                   else
                                                                   {
                                                                       DisplayAlert("Alert", "You can edit only one item at a time", "OK");

                                                                   }
                                                               };
                    imgAcntEdit.GestureRecognizers.Add(gestures);

                    TapGestureRecognizer gesturesFleetTick = new TapGestureRecognizer();
                    gesturesFleetTick.Tapped += (sender, e) =>
                                                                        {
                                                                            stackEditFleet.IsVisible = false;
                                                                            stackAcc.IsVisible = true;
                                                                            lblAcntNo.Text = entryEditFleet.Text;
                                                                            RegisterStepOne.rso.fleetData.Add(lblAcntNo.Text.ToString());
                                                                            isEditFleet = false;
                                                                        };
                    imgFleetTick.GestureRecognizers.Add(gesturesFleetTick);


                    TapGestureRecognizer gesturesFleetClose = new TapGestureRecognizer();
                    gesturesFleetClose.Tapped += (sender, e) =>
                                                                       {
                                                                           stackEditFleet.IsVisible = false;
                                                                           stackAcc.IsVisible = true;
                                                                           isEditFleet = false;

                                                                       };
                    imgFleetClose.GestureRecognizers.Add(gesturesFleetClose);



                    stackFleetChildren.Children.Add(stackAcc);
                    stackFleetChildren.Children.Add(stackEditFleet);
                }
                imgFleetCheck.Source = ImageSource.FromFile("Checked.png");
                stackFleetLessee.IsVisible = true;
                stackbtnFleetSbumit.IsVisible = false;
                stackFleetDrive.IsVisible = false;
                stackFleetAdd.IsVisible = true;
            }

            if (RegisterStepOne.rso.otherData.Count != 0)
            {
                foreach (var item in RegisterStepOne.rso.otherData)
                {
                    var lblAcntNo = new Label
                    {
                        Text = item,
                        HorizontalOptions = LayoutOptions.StartAndExpand
                    };
                    var imgAcntEdit = new Image
                    {
                        Source = ImageSource.FromFile("imgEdit.png"),
                        HorizontalOptions = LayoutOptions.EndAndExpand
                    };

                    var stackAcc = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Children = { lblAcntNo, imgAcntEdit }
                    };
                    var entryEditOther = new CustomEntry
                    {
                        HeightRequest = Device.OnPlatform(height * 7, height * 10, height * 7),
                        HorizontalOptions = LayoutOptions.FillAndExpand
                    };
                    var imgOtherTick = new Image
                    {
                        Source = "tick.png"
                    };
                    var imgOtherClose = new Image
                    {
                        Source = "imgClose.png"
                    };
                    var stackEditOther = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        IsVisible = false,
                        Children =
                                         {
                                            entryEditOther,imgOtherTick,imgOtherClose
                                          }
                    };

                    TapGestureRecognizer gestures = new TapGestureRecognizer();
                    gestures.Tapped += (sender, e) =>
                                                                      {
                                                                          if (isEditOther == false)
                                                                          {

                                                                              isEditOther = true;
                                                                              stackEditOther.IsVisible = true;
                                                                              stackAcc.IsVisible = false;
                                                                              entryEditOther.Text = lblAcntNo.Text;
                                                                          }
                                                                          else
                                                                          {
                                                                              DisplayAlert("Alert", "You can edit only one item at a time", "OK");

                                                                          }
                                                                      };
                    imgAcntEdit.GestureRecognizers.Add(gestures);

                    TapGestureRecognizer gesturesimgOtherTick = new TapGestureRecognizer();
                    gesturesimgOtherTick.Tapped += (sender, e) =>
                                                                      {
                                                                          stackEditOther.IsVisible = false;
                                                                          stackAcc.IsVisible = true;
                                                                          lblAcntNo.Text = entryEditOther.Text;
                                                                          RegisterStepOne.rso.otherData.Add(lblAcntNo.Text.ToString());
                                                                          isEditOther = false;
                                                                      };
                    imgOtherTick.GestureRecognizers.Add(gesturesimgOtherTick);


                    TapGestureRecognizer gesturesimgOtherClose = new TapGestureRecognizer();
                    gesturesimgOtherClose.Tapped += (sender, e) =>
                                                                                                 {
                                                                                                     stackEditOther.IsVisible = false;
                                                                                                     stackAcc.IsVisible = true;
                                                                                                     isEditOther = false;
                                                                                                 };
                    imgOtherClose.GestureRecognizers.Add(gesturesimgOtherClose);

                    stackFleetChildren.Children.Add(stackEditOther);
                    stackOtherChildren.Children.Add(stackAcc);
                }
                stackOtherLessee.IsVisible = true;
                stackbtnOtherSbumit.IsVisible = false;
                stackOtherDrive.IsVisible = false;
                stackOtherAdd.IsVisible = true;
                imgOtherCheck.Source = ImageSource.FromFile("Checked.png");
            }
            #endregion



            Content = stackMain;
        }

        public void RentTruck(string strAccNo)
        {
            int height = (BaseContentPage.screenHeight * 1) / 100;
            var lblAcntNo = new Label
            {
                Text = strAccNo,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };
            var imgAcntEdit = new Image
            {
                Source = ImageSource.FromFile("imgEdit.png"),
                HorizontalOptions = LayoutOptions.EndAndExpand
            };

            var stackAcc = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { lblAcntNo, imgAcntEdit }
            };



            var entryEditRent = new CustomEntry
            {
                HeightRequest = Device.OnPlatform(height * 7, height * 10, height * 7),
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            var imgRentTick = new Image
            {
                Source = "tick.png"
            };
            var imgRentClose = new Image
            {
                Source = "imgClose.png"
            };
            var stackEditRent = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                IsVisible = false,
                Children =
                                     {
                                        entryEditRent,imgRentTick,imgRentClose
                                        }
            };

            var stackFinal = new StackLayout
            {
                Children =
                                        {
                                           stackAcc,stackEditRent
                                         }
            };

            stackRentChildren.Children.Add(stackAcc);

            stackRentChildren.Children.Add(stackEditRent);


            RegisterStepOne.rso.truckData.Add(strAccNo);

            TapGestureRecognizer gestures = new TapGestureRecognizer();
            gestures.Tapped += (sender, e) =>
                                                                             {
                                                                                 stackEditRent.IsVisible = true;
                                                                                 stackAcc.IsVisible = false;
                                                                                 entryEditRent.Text = lblAcntNo.Text;
                                                                             };
            imgAcntEdit.GestureRecognizers.Add(gestures);

            TapGestureRecognizer gesturesRentTick = new TapGestureRecognizer();
            gesturesRentTick.Tapped += (sender, e) =>
                                                                                         {
                                                                                             stackEditRent.IsVisible = false;
                                                                                             stackAcc.IsVisible = true;
                                                                                             lblAcntNo.Text = entryEditRent.Text;
                                                                                             RegisterStepOne.rso.truckData.Add(lblAcntNo.Text.ToString());

                                                                                         };
            imgRentTick.GestureRecognizers.Add(gesturesRentTick);


            TapGestureRecognizer gesturesRentClose = new TapGestureRecognizer();
            gesturesRentClose.Tapped += (sender, e) =>
                                                                            {
                                                                                stackEditRent.IsVisible = false;
                                                                                stackAcc.IsVisible = true;
                                                                                //lblAcntNo.Text = entryEditRent.Text;
                                                                            };
            imgRentClose.GestureRecognizers.Add(gesturesRentClose);


            var imgRentCloseTap = new TapGestureRecognizer();


        }
    }

}