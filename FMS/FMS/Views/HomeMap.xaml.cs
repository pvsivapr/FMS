using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace FMS
{
    public partial class HomeMap : ContentPage
    {
        #region for global variables
        CustomMap map;
        #endregion
        public HomeMap()
        {
            InitializeComponent();

            int height = (BaseContentPage.screenHeight * 1) / 100;
            int width = (BaseContentPage.screenWidth * 1) / 100;
            int iconHeight = height * 10;

            #region for Body

            map = new CustomMap()
            {
                IsShowingUser = true,
                MapType = MapType.Street,
                HeightRequest = 100,
                WidthRequest = 960,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(17.436670, 78.401258), Distance.FromMiles(3)));
            StackLayout stackBody = new StackLayout()
            {
                Children = { map },
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            Image imgNaviMenu = new Image()
            {
                Source = ImageSource.FromFile("Test1.png"),
                HeightRequest = iconHeight,
                WidthRequest = iconHeight,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand
            };

            Image imgCall = new Image()
            {
                Source = ImageSource.FromFile("Test1.png"),
                HeightRequest = iconHeight,
                WidthRequest = iconHeight,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand
            };

            Image imgMaintenance = new Image()
            {
                Source = ImageSource.FromFile("Test3.png"),
                HeightRequest = iconHeight,
                WidthRequest = iconHeight,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand
            };
            Label lblMaintenance = new Label()
            {
                Text = "Maintenance",
                FontSize = height * 2,
                TextColor = AppGlobalVariables.Black,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand
            };
            StackLayout stackMaintenance = new StackLayout()
            {
                Children = { imgMaintenance, lblMaintenance },
                Spacing = 0,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            Image imgFleetMgmt = new Image()
            {
                Source = ImageSource.FromFile("Test3.png"),
                HeightRequest = iconHeight,
                WidthRequest = iconHeight,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand
            };
            Label lblFleetMgmt = new Label()
            {
                Text = "Fleet \n Management",
                FontSize = height * 2,
                TextColor = AppGlobalVariables.Black,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand
            };
            StackLayout stackFleetMgmt = new StackLayout()
            {
                Children = { imgFleetMgmt, lblFleetMgmt },
                Spacing = 0,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            Image imgFuelRecpt = new Image()
            {
                Source = ImageSource.FromFile("Test3.png"),
                HeightRequest = iconHeight,
                WidthRequest = iconHeight,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand
            };
            Label lblFuelRecpt = new Label()
            {
                Text = "Fuel Receipts",
                FontSize = height * 2,
                TextColor = AppGlobalVariables.Black,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand
            };
            StackLayout stackFuelRecpt = new StackLayout()
            {
                Children = { imgFuelRecpt, lblFuelRecpt },
                Spacing = 0,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            //StackLayout stackOptionsHolder = new StackLayout()
            //{
            //	Children = { imgMaintenance, imgFleetMgmt, imgFuelRecpt },
            //	BackgroundColor = Color.Aqua,
            //	HorizontalOptions = LayoutOptions.FillAndExpand,
            //	VerticalOptions = LayoutOptions.FillAndExpand
            //};
            Grid gridOptionsHolder = new Grid()
            {
                RowDefinitions =
                {
                    new RowDefinition{ Height=new GridLength(1, GridUnitType.Star)},
                    new RowDefinition{ Height=new GridLength(0.03, GridUnitType.Star)},
                    new RowDefinition{ Height=new GridLength(1, GridUnitType.Star)},
                    new RowDefinition{ Height=new GridLength(0.04, GridUnitType.Star)},
                    new RowDefinition{ Height=new GridLength(1, GridUnitType.Star)},
					//new RowDefinition{ Height=new GridLength(0.5, GridUnitType.Star)}
					//new RowDefinition{ Height = GridLength.Auto},
					//new RowDefinition{ Height = GridLength.Auto},
					//new RowDefinition{ Height = GridLength.Auto},
					//new RowDefinition{ Height = GridLength.Auto},
					//new RowDefinition{ Height = GridLength.Auto},
					//new RowDefinition{ Height = GridLength.Auto}
				},
                ColumnDefinitions =
                {
                    new ColumnDefinition{ Width=new GridLength(1, GridUnitType.Star)}
                },
                RowSpacing = 0,//height*3,
                Padding = new Thickness(0, 0, 0, 0),
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            //gridOptionsHolder.Children.Add(imgMaintenance, 0,0);
            //gridOptionsHolder.Children.Add(lblMaintenance, 0, 1);
            //gridOptionsHolder.Children.Add(imgFleetMgmt, 0, 2);
            //gridOptionsHolder.Children.Add(lblFleetMgmt, 0, 3);
            //gridOptionsHolder.Children.Add(imgFuelRecpt, 0, 4);
            //gridOptionsHolder.Children.Add(lblFuelRecpt, 0, 5);
            gridOptionsHolder.Children.Add(stackMaintenance, 0, 0);
            gridOptionsHolder.Children.Add(stackFleetMgmt, 0, 2);
            gridOptionsHolder.Children.Add(stackFuelRecpt, 0, 4);
            #endregion

            #region for popup

            Image imgOptionsMenu = new Image()
            {
                Source = ImageSource.FromFile("Test2.png"),
                HeightRequest = iconHeight,
                WidthRequest = iconHeight,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Label lblOptionsMenu = new Label()
            {
                Text = " ",
                FontSize = height * 2,
                TextColor = AppGlobalVariables.Black,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            StackLayout stackOptionsMenu = new StackLayout()
            {
                Children = { lblOptionsMenu, imgOptionsMenu },
                Spacing = 0,
                IsVisible = true,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Image imgServices = new Image()
            {
                Source = ImageSource.FromFile("Test2.png"),
                HeightRequest = iconHeight,
                WidthRequest = iconHeight,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Label lblServices = new Label()
            {
                Text = "Services",
                FontSize = height * 2,
                TextColor = AppGlobalVariables.Black,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            StackLayout stackServices = new StackLayout()
            {
                Children = { lblServices, imgServices },
                Spacing = 0,
                IsVisible = false,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Image imgFuel = new Image()
            {
                Source = ImageSource.FromFile("Test2.png"),
                HeightRequest = iconHeight,
                WidthRequest = iconHeight,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Label lblFuel = new Label()
            {
                Text = "Fuel",
                FontSize = height * 2,
                TextColor = AppGlobalVariables.Black,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            StackLayout stackFuel = new StackLayout()
            {
                Children = { lblFuel, imgFuel },
                Spacing = 0,
                IsVisible = false,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Image imgFuelRegular = new Image()
            {
                Source = ImageSource.FromFile("Test2.png"),
                HeightRequest = iconHeight,
                WidthRequest = iconHeight,
                IsVisible = false,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Image imgFuelNaturalGas = new Image()
            {
                Source = ImageSource.FromFile("Test2.png"),
                HeightRequest = iconHeight,
                WidthRequest = iconHeight,
                IsVisible = false,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Image imgFuelDiesel = new Image()
            {
                Source = ImageSource.FromFile("Test2.png"),
                HeightRequest = iconHeight,
                WidthRequest = iconHeight,
                IsVisible = false,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };


            Image imgRentals = new Image()
            {
                Source = ImageSource.FromFile("Test2.png"),
                HeightRequest = iconHeight,
                WidthRequest = iconHeight,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Label lblRentals = new Label()
            {
                Text = "Rentals",
                FontSize = height * 2,
                TextColor = AppGlobalVariables.Black,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            StackLayout stackRentals = new StackLayout()
            {
                Children = { lblRentals, imgRentals },
                Spacing = 0,
                IsVisible = false,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Image imgUsedTrucks = new Image()
            {
                Source = ImageSource.FromFile("Test2.png"),
                HeightRequest = iconHeight,
                WidthRequest = iconHeight,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Label lblUsedTrucks = new Label()
            {
                Text = "Used Trucks",
                FontSize = height * 2,
                TextColor = AppGlobalVariables.Black,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            StackLayout stackUsedTrucks = new StackLayout()
            {
                Children = { lblUsedTrucks, imgUsedTrucks },
                Spacing = 0,
                IsVisible = false,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };


            CustomEntry entryLocation = new CustomEntry()
            {
                Placeholder = "Enter Address To Find Location",
                PlaceholderColor = Color.FromHex("#60000000"),
                TextColor = AppGlobalVariables.Black,
                WidthRequest = width * 93,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                BackgroundColor = Color.White,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            double x = 0, y = 0, xx = 0, yy = 0;
            TapGestureRecognizer imgFuelTapped = new TapGestureRecognizer();
            imgFuelTapped.NumberOfTapsRequired = 1;
            imgFuelTapped.Tapped += async (sender, e) =>
            {
                //imgFuelRegular.IsVisible = true;
                //imgFuelNaturalGas.IsVisible = true;
                //imgFuelDiesel.IsVisible = true;


                //entryLocation.LayoutTo(new Rectangle((x * 4), y, xx, yy), 250, Easing.Linear);

                //await Task.Delay(1000);

                //entryLocation.LayoutTo(new Rectangle((x * 4), y, xx, yy), 250, Easing.Linear);
                //imgFuelRegular.LayoutTo(new Rectangle((imgFuelRegular.X), ((imgFuelRegular.Y) - (stackFuel.Height)), (imgFuelRegular.Width), (imgFuelRegular.Height)), 250, Easing.Linear);
                //imgFuelNaturalGas.LayoutTo(new Rectangle((imgFuelNaturalGas.X), ((imgFuelNaturalGas.Y) - ((stackFuel.Height) + height * 3)), (imgFuelNaturalGas.Width), (imgFuelNaturalGas.Height)), 250, Easing.Linear);
                //imgFuelDiesel.LayoutTo(new Rectangle((imgFuelDiesel.X), ((imgFuelDiesel.Y) - (imgFuelDiesel.Height)), (imgFuelDiesel.Width), (imgFuelRegular.Height)), 250, Easing.Linear);

                //stackServices.IsVisible = false;
                //stackRentals.IsVisible = false;
            };
            imgFuel.GestureRecognizers.Add(imgFuelTapped);

            int i = 0;
            TapGestureRecognizer optnsMenuClicked = new TapGestureRecognizer();
            optnsMenuClicked.NumberOfTapsRequired = 1;

            optnsMenuClicked.Tapped += (sender, e) =>
            {
                if (i == 0)
                {
                    x = entryLocation.X;
                    y = entryLocation.Y;
                    xx = entryLocation.Width;
                    yy = entryLocation.Height;

                    entryLocation.LayoutTo(new Rectangle((x * 4), y, xx, yy), 250, Easing.Linear);
                    stackServices.IsVisible = true;
                    stackFuel.IsVisible = true;
                    stackRentals.IsVisible = true;
                    stackUsedTrucks.IsVisible = true;
                    stackMaintenance.IsVisible = true;
                    stackFleetMgmt.IsVisible = true;
                    stackFuelRecpt.IsVisible = true;
                }
                if (i % 2 == 0)
                {
                    //entryLocation.IsEnabled = false;
                    entryLocation.LayoutTo(new Rectangle((x * 4), y, xx, yy), 250, Easing.Linear);

                    stackServices.IsVisible = true;
                    stackFuel.IsVisible = true;
                    stackRentals.IsVisible = true;
                    stackUsedTrucks.IsVisible = true;
                    imgFuelRegular.IsVisible = false;
                    imgFuelNaturalGas.IsVisible = false;
                    imgFuelDiesel.IsVisible = false;
                    stackMaintenance.IsVisible = false;
                    stackFleetMgmt.IsVisible = false;
                    stackFuelRecpt.IsVisible = false;

                }
                else
                {
                    entryLocation.LayoutTo(new Rectangle(x, y, xx, yy), 250, Easing.Linear);

                    stackServices.IsVisible = false;
                    stackFuel.IsVisible = false;
                    stackRentals.IsVisible = false;
                    stackUsedTrucks.IsVisible = false;
                    imgFuelRegular.IsVisible = false;
                    imgFuelNaturalGas.IsVisible = false;
                    imgFuelDiesel.IsVisible = false;
                    stackMaintenance.IsVisible = true;
                    stackFleetMgmt.IsVisible = true;
                    stackFuelRecpt.IsVisible = true;
                }
                i++;
            };
            imgOptionsMenu.GestureRecognizers.Add(optnsMenuClicked);

            StackLayout stackFooter = new StackLayout()
            {
                //Children = { imgOptionsMenu, entryLocation },
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(10, 0, 10, 0),
                Spacing = width * 1,
                IsVisible = true,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Label btnLocation = new Label()
            {
                Text = "LOCATIONS LIST",
                BackgroundColor = Color.Transparent,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            StackLayout stackBtnFooter = new StackLayout()
            {
                Children = { btnLocation },
                Padding = new Thickness(0, 0, 0, 0),
                Spacing = width * 1,
                IsVisible = false,
                BackgroundColor = Color.Aqua,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            Grid gridFooter = new Grid()
            {
                RowDefinitions =
                {
                    new RowDefinition{ Height=new GridLength(1, GridUnitType.Star)},
                    new RowDefinition{ Height=new GridLength(1, GridUnitType.Star)},
					//new RowDefinition{ Height=new GridLength(1, GridUnitType.Star)},
					////new RowDefinition{ Height=new GridLength(1, GridUnitType.Star)},
					//new RowDefinition{ Height=new GridLength(1, GridUnitType.Star)}
				},
                ColumnDefinitions =
                {
                    new ColumnDefinition{ Width=new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition{ Width=new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition{ Width=new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition{ Width=new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition{ Width=new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition{ Width=new GridLength(0.7, GridUnitType.Star)}
                },
                RowSpacing = 0,//height*3,
                Padding = new Thickness((height * 5), 0, 0, 0),
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            gridFooter.Children.Add(imgFuelRegular, 1, 1);
            gridFooter.Children.Add(imgFuelNaturalGas, 2, 1);
            gridFooter.Children.Add(imgFuelDiesel, 3, 1);

            gridFooter.Children.Add(stackOptionsMenu, 0, 1);
            gridFooter.Children.Add(stackServices, 1, 1);
            gridFooter.Children.Add(stackFuel, 2, 1);
            gridFooter.Children.Add(stackRentals, 3, 1);
            gridFooter.Children.Add(stackUsedTrucks, 4, 1);
            gridFooter.Children.Add(entryLocation, 1, 6, 1, 2);

            //gridFooter.Children.Add(imgOptionsMenu, 0, 0);
            //gridFooter.Children.Add(imgOptionsMenu, 0, 0);
            //gridFooter.Children.Add(btnLocation, 0, 0);
            //gridFooter.Children.Add(stackFooter, 0, 0);
            #endregion

            #region for container

            AbsoluteLayout absContainer = new AbsoluteLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            AbsoluteLayout.SetLayoutFlags(stackBody, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(stackBody, new Rectangle(0, 0, 1, 1));
            absContainer.Children.Add(stackBody);

            AbsoluteLayout.SetLayoutFlags(imgNaviMenu, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(imgNaviMenu, new Rectangle(0.06, 0.05, iconHeight, iconHeight));
            absContainer.Children.Add(imgNaviMenu);
            AbsoluteLayout.SetLayoutFlags(imgCall, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(imgCall, new Rectangle(0.95, 0.05, iconHeight, iconHeight));
            absContainer.Children.Add(imgCall);
            AbsoluteLayout.SetLayoutFlags(gridOptionsHolder, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(gridOptionsHolder, new Rectangle(0.05, 0.3, 0.17, 0.40));
            absContainer.Children.Add(gridOptionsHolder);

            //AbsoluteLayout.SetLayoutFlags(imgOptionsMenu, AbsoluteLayoutFlags.PositionProportional);
            //AbsoluteLayout.SetLayoutBounds(imgOptionsMenu, new Rectangle(0.06, 0.95, iconHeight, iconHeight));
            //absContainer.Children.Add(imgOptionsMenu);
            //AbsoluteLayout.SetLayoutFlags(entryLocation, AbsoluteLayoutFlags.PositionProportional);
            //AbsoluteLayout.SetLayoutBounds(entryLocation, new Rectangle(1, 1, ((width * 100) - iconHeight), iconHeight));
            //absContainer.Children.Add(entryLocation);
            //AbsoluteLayout.SetLayoutFlags(stackFooter, AbsoluteLayoutFlags.All);
            //AbsoluteLayout.SetLayoutBounds(stackFooter, new Rectangle(0, 1, 1, 0.1));
            //absContainer.Children.Add(stackFooter);
            AbsoluteLayout.SetLayoutFlags(gridFooter, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(gridFooter, new Rectangle(0, 1, 1, 0.3));//new Rectangle(0, 1, 1, 0.15)
            absContainer.Children.Add(gridFooter);
            AbsoluteLayout.SetLayoutFlags(stackBtnFooter, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(stackBtnFooter, new Rectangle(0, 1, 1, 0.07));
            absContainer.Children.Add(stackBtnFooter);


            Content = absContainer;
            #endregion
        }
    }
}
