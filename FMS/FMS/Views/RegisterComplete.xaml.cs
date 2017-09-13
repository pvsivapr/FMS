using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FMS
{
	public partial class RegisterComplete : BaseContentPage
	{
		public RegisterComplete()
		{
			InitializeComponent();

			#region for local variables

			int height = (BaseContentPage.screenHeight * 1) / 100;
			int width = (BaseContentPage.screenWidth * 1) / 100;

			#endregion


			#region for header

			var imgMenu = new Image
			{
				Source = "Menu.png",
				HorizontalOptions = LayoutOptions.StartAndExpand,
				VerticalOptions = LayoutOptions.Center
			};
			var imgTitle = new Image
			{
				Source = "Title.png",
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.Center
			};
			var imgTruck = new Image
			{
				Source = "Truck.png",
				HorizontalOptions = LayoutOptions.EndAndExpand,
				VerticalOptions = LayoutOptions.Center
			};
			var stackHeader = new StackLayout
			{
				Spacing = 0,
				Children =
				{
					new StackLayout
					{
						Orientation = StackOrientation.Horizontal,
						Padding = new Thickness(10, 0, 10, 0),
						HeightRequest=height*10,
						Children =
						{
						  imgMenu,imgTitle,imgTruck
						}
					},
					new BoxView{HeightRequest=1,BackgroundColor=Color.Black,HorizontalOptions=LayoutOptions.FillAndExpand}
				}
			};

			#endregion

			var lblRegComplete = new Label
			{
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				FontAttributes = FontAttributes.Bold,
				Text = "Registration Completion",
				FontSize = height * 3
			};

			var lblRegisterdDes = new Label
			{
				Text = " [You are now registered as [LOREM] \nand have access to [LOREM,LOREM\n                        and LOREM]",
				HorizontalOptions = LayoutOptions.CenterAndExpand

			};
			var lblOR = new Label
			{
				Text = "OR",
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};
			var lblRegProDes = new Label
			{
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Text = "[Your registration is being processed.\n      Lorem ipsum dolor sitat amet.]"
			};

			var stackInnerBox = new StackLayout
			{
				Padding = new Thickness(10, 0, 10, 0),
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.White,
				Children =
				{
					new StackLayout
				{
					Spacing = height * 4.2,
					Padding = new Thickness(height * 5, height * 7.5, height * 5, height * 7.5),
					Children =
					{
						new Label
						{
						Text = "[Learn more about driving\n              for Ryder]",
						FontAttributes = FontAttributes.Bold,
						HorizontalOptions = LayoutOptions.CenterAndExpand
						},
						new Label
						{
							Text="     Lorem ipsum contact Ryder\n555-555-5555. Lorem ipsum dolor\n                            sitat",
							HorizontalOptions=LayoutOptions.CenterAndExpand
						}
					}
					}
				}
			};

			var stackBox = new StackLayout
			{
				BackgroundColor = Color.Gray,
				Padding = new Thickness(1, 1, 1, 1),
				Children =
				{
				 stackInnerBox
				}
			};
			var lblHome = new Label
			{
				Text = "take me home",
				FontSize = height * 2.5,
				TextColor = AppGlobalVariables.White,
				HeightRequest = height * 7,
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalTextAlignment = TextAlignment.Center,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			var stackBtnHome = new StackLayout
			{
				Children = { lblHome },
				BackgroundColor = AppGlobalVariables.Gray,
				HeightRequest = height * 7,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Center
			};

			var stackDes = new StackLayout
			{
				Spacing = height * 4,
				Padding = new Thickness(0, height * 3, 0, 0),
				Children =
				{
				   lblRegComplete,lblRegisterdDes,lblOR,lblRegProDes,
					new ContentView
					{
						Padding = new Thickness(10, 10, 10, 0),
						Content=stackBox
					},
					new ContentView
					{
						Padding = new Thickness(10, 0, 10, height*5),
						Content=stackBtnHome
					}

				}
			};
			var stackBody = new StackLayout
			{
				Padding = new Thickness(0, Device.OnPlatform(0, 0, 0), 0, 0),
				Children =
				{
					 stackHeader,stackDes
				}
			};
			PageControlsStackLayout.Children.Add(stackBody);
		}
	}
}
