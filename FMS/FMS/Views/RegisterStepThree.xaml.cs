using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FMS
{
	public partial class RegisterStepThree : BaseContentPage
	{

		bool testIsActive = true;
        public RegisterStepThree()
		{
			InitializeComponent();

			Label lblBack = new Label()
			{
				Text = "<back",
				HorizontalOptions = LayoutOptions.Start
			};

			Label lblTitle = new Label()
			{
				Text = "      STEP 2:",
				FontAttributes = FontAttributes.Bold
			};

			Label lblTellme = new Label()
			{
				Text = "Tell us about yourself",
				FontAttributes = FontAttributes.Bold
			};

			StackLayout stackYourSelf = new StackLayout()
			{
				Spacing = 0,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Children = { lblTitle, lblTellme }
			};

			StackLayout stackHea = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal,
				Children = { lblBack, stackYourSelf }
			};

			Label lblDes = new Label()
			{
				Text = "Telling us about yourself  if help us tallor the\napp to your needs",
				FontAttributes = FontAttributes.Bold
			};


			StackLayout stackHeader = new StackLayout()
			{
				VerticalOptions = LayoutOptions.Start,
				Orientation = StackOrientation.Vertical,
				Children = { stackHea, lblDes }
			};

			Image imgDriveCheck = new Image()
			{
				Source = "Unchecked.png",
				HeightRequest = 25,
				WidthRequest = 25,
			};


			Label lbldriveRyder = new Label()
			{
				HorizontalOptions = LayoutOptions.Start,
				Text = "Do you drive for Ryder?",
				TextColor = AppGlobalVariables.Black,
				VerticalTextAlignment = TextAlignment.Center,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(CustomEntry)),
				//CustomFontFamily = AppGlobalVariables.fontFamily45
			};


			Label lblYes = new Label()
			{
				Text = "Yes",
				TextColor = AppGlobalVariables.Black,
				VerticalTextAlignment = TextAlignment.Center,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(CustomEntry)),
				//CustomFontFamily = AppGlobalVariables.fontFamily45
			};

			Image imgYes = new Image()
			{
				Source = "imgRadioNo.png",
				HeightRequest = 30,
				WidthRequest = 30
			};
			var genderTest = "Yes";

			StackLayout stackYes = new StackLayout()
			{
				Spacing = 3,
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Children = { imgYes, lblYes }
			};


			Label lblNo = new Label()
			{
				Text = "No",
				TextColor = AppGlobalVariables.Black,
				VerticalTextAlignment = TextAlignment.Center,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(CustomEntry)),
				//CustomFontFamily = AppGlobalVariables.fontFamily45
			};

			Image imgNo = new Image()
			{
				Source = "imgRadioNo.png",
				HeightRequest = 30,
				WidthRequest = 30
			};



			StackLayout stackNo = new StackLayout()
			{
				Spacing = 3,
				Orientation = StackOrientation.Horizontal,
				Children = { imgNo, lblNo },
				HorizontalOptions = LayoutOptions.EndAndExpand,
			};


			StackLayout stackYes1 = new StackLayout()
			{
				Spacing = 5,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Orientation = StackOrientation.Horizontal,
				Children = { stackYes, stackNo }
			};

			StackLayout stackIDrive = new StackLayout()
			{
				IsVisible = false,
				Padding = new Thickness(30, 0, 0, 0),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Vertical,
				Children = { lbldriveRyder, stackYes1 }
			};

			var frameEdior = new CustomEntry()
			{
				IsVisible = false,
				Placeholder = " [ENTER SAP NUMBER]",
				HeightRequest = 30,

			};

			Button btnSubmit = new Button()
			{
				Text = "Submit",
				IsVisible = false,
				TextColor = Color.White,
				Margin = new Thickness(60, 0, 60, 0),
				BackgroundColor = Color.Gray
			};

			StackLayout stackbtnSbumit = new StackLayout()
			{
				Spacing = 12,
				Children = { frameEdior, btnSubmit }
			};

			var imgDriveCheckTap = new TapGestureRecognizer();
			imgDriveCheckTap.Tapped += (s, e) =>
											{
												if (testIsActive == true)
												{
													imgDriveCheck.Source = "Checked.png";
													testIsActive = false;
													stackIDrive.IsVisible = true;
													//isActiveCheck = "true";
												}
												else
												{
													imgDriveCheck.Source = "Unchecked.png";
													imgYes.Source = "imgRadioNo.png";
													testIsActive = true;
													stackIDrive.IsVisible = false;
													stackbtnSbumit.IsVisible = false;


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



			Label lblDriveTruck = new Label()
			{
				Text = "I drive a truck",
				FontAttributes = FontAttributes.Bold
			};

			Label lblRentTrucks = new Label()
			{
				Text = "I rent truck",
				FontAttributes = FontAttributes.Bold
			};

			Label lblFleet = new Label()
			{
				Text = "I have a fleet",
				FontAttributes = FontAttributes.Bold
			};

			Label lblOther = new Label()
			{
				Text = "Other (a truck)",
				FontAttributes = FontAttributes.Bold
			};


			#region Rent

			Label lblRentYes = new Label()
			{
				Text = "Yes",
				TextColor = AppGlobalVariables.Black,
				VerticalTextAlignment = TextAlignment.Center,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(CustomEntry)),
				//CustomFontFamily = AppGlobalVariables.fontFamily45
			};

			Image imgRentYes = new Image()
			{
				Source = "imgRadioNo.png",
				HeightRequest = 30,
				WidthRequest = 30
			};
			var RentTest = "Yes";

			StackLayout stackRentYes = new StackLayout()
			{
				Spacing = 3,
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Children = { imgRentYes, lblRentYes }
			};


			Label lblRentNo = new Label()
			{
				Text = "No",
				TextColor = AppGlobalVariables.Black,
				VerticalTextAlignment = TextAlignment.Center,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(CustomEntry)),
				//CustomFontFamily = AppGlobalVariables.fontFamily45
			};

			Image imgRentNo = new Image()
			{
				Source = "imgRadioNo.png",
				HeightRequest = 30,
				WidthRequest = 30
			};



			StackLayout stackRentNo = new StackLayout()
			{
				Spacing = 3,
				Orientation = StackOrientation.Horizontal,
				Children = { imgRentNo, lblRentNo },
				HorizontalOptions = LayoutOptions.EndAndExpand,
			};


			StackLayout stackRentYes1 = new StackLayout()
			{
				Spacing = 5,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Orientation = StackOrientation.Horizontal,
				Children = { stackRentYes, stackRentNo }
			};
			Label lblRentRyder = new Label()
			{
				HorizontalOptions = LayoutOptions.Start,
				Text = "Do you rent for Ryder?",
				TextColor = AppGlobalVariables.Black,
				VerticalTextAlignment = TextAlignment.Center,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(CustomEntry)),
			};


			StackLayout stackRentDrive = new StackLayout()
			{
				IsVisible = false,
				Padding = new Thickness(30, 0, 0, 0),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Vertical,
				Children = { lblRentRyder, stackRentYes1 }
			};

			CustomEntry frameRentEdior = new CustomEntry()
			{
				IsVisible = false,
				Placeholder = " [ENTER SAP NUMBER]",
				HeightRequest = 30,

			};

			Button btnRentSubmit = new Button()
			{
				Text = "Submit",
				IsVisible = false,
				TextColor = Color.White,
				Margin = new Thickness(60, 0, 60, 0),
				BackgroundColor = Color.Gray
			};

			Image imgRentCheck = new Image()
			{
				Source = "Unchecked.png",
				HeightRequest = 25,
				WidthRequest = 25,
			};


			StackLayout stackbtnRentSbumit = new StackLayout()
			{
				Spacing = 12,
				Children = { frameRentEdior, btnRentSubmit }
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
																					}
																					else
																					{
																						imgRentCheck.Source = "Unchecked.png";
																						testIsActive = true;
																						stackRentDrive.IsVisible = false;
																						//stackbtnSbumit.IsVisible = false;


																					}
																				};

			imgRentCheck.GestureRecognizers.Add(imgRentCheckTap);


			var imgRentYesTap = new TapGestureRecognizer();
			imgRentYesTap.Tapped += (s, e) =>
																		{
																			imgRentNo.Source = "imgRadioNo.png";
																			imgRentYes.Source = "imgRadioYes.png";
																			RentTest = "Yes";
																			//stackRentDrive.IsVisible = true;
																			//stackIDrive.IsVisible = true;
																			btnRentSubmit.IsVisible = true;
																			frameRentEdior.IsVisible = true;

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



			StackLayout stackRent = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal,
				Children = { imgRentCheck, lblRentTrucks }
			};

			#endregion





			Image imgFleetCheck = new Image()
			{
				Source = "Unchecked.png",
				HeightRequest = 25,
				WidthRequest = 25,
			};


			//var imgFleetCheckTap = new TapGestureRecognizer();
			//imgFleetCheckTap.Tapped += (s, e) =>
			//                                      {
			//                                          if (testIsActive == true)
			//                                          {
			//                                              imgFleetCheck.Source = "Checked.png";
			//                                              testIsActive = false;
			//                                              //isActiveCheck = "true";
			//                                          }
			//                                          else
			//                                          {
			//                                              imgFleetCheck.Source = "Unchecked.png";
			//                                              testIsActive = true;
			//                                              //isActiveCheck = "false";
			//                                          }
			//                                      };

			//imgFleetCheck.GestureRecognizers.Add(imgFleetCheckTap);

			Image imgOtherCheck = new Image()
			{
				Source = "Unchecked.png",
				HeightRequest = 25,
				WidthRequest = 25,
			};


			//var imgOtherCheckTap = new TapGestureRecognizer();
			//imgOtherCheckTap.Tapped += (s, e) =>
			//                                      {
			//                                          if (testIsActive == true)
			//                                          {
			//                                              imgOtherCheck.Source = "Checked.png";
			//                                              testIsActive = false;
			//                                              //isActiveCheck = "true";
			//                                          }
			//                                          else
			//                                          {
			//                                              imgOtherCheck.Source = "Unchecked.png";
			//                                              testIsActive = true;
			//                                              //isActiveCheck = "false";
			//                                          }
			//                                      };

			//imgOtherCheck.GestureRecognizers.Add(imgOtherCheckTap);


			#region Fleet

			Label lblFleetYes = new Label()
			{
				Text = "Yes",
				TextColor = AppGlobalVariables.Black,
				VerticalTextAlignment = TextAlignment.Center,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(CustomEntry)),
				//CustomFontFamily = AppGlobalVariables.fontFamily45
			};

			Image imgFleetYes = new Image()
			{
				Source = "imgRadioNo.png",
				HeightRequest = 30,
				WidthRequest = 30
			};
			var FleetTest = "Yes";

			StackLayout stackFleetYes = new StackLayout()
			{
				Spacing = 3,
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Children = { imgFleetYes, lblFleetYes }
			};


			Label lblFleetNo = new Label()
			{
				Text = "No",
				TextColor = AppGlobalVariables.Black,
				VerticalTextAlignment = TextAlignment.Center,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(CustomEntry)),
				//CustomFontFamily = AppGlobalVariables.fontFamily45
			};

			Image imgFleetNo = new Image()
			{
				Source = "imgRadioNo.png",
				HeightRequest = 30,
				WidthRequest = 30
			};



			StackLayout stackFleetNo = new StackLayout()
			{
				Spacing = 3,
				Orientation = StackOrientation.Horizontal,
				Children = { imgFleetNo, lblFleetNo },
				HorizontalOptions = LayoutOptions.EndAndExpand,
			};


			StackLayout stackFleetYes1 = new StackLayout()
			{
				Spacing = 5,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Orientation = StackOrientation.Horizontal,
				Children = { stackFleetYes, stackFleetNo }
			};
			Label lblFleetRyder = new Label()
			{
				HorizontalOptions = LayoutOptions.Start,
				Text = "Do you fleet for Ryder?",
				TextColor = AppGlobalVariables.Black,
				VerticalTextAlignment = TextAlignment.Center,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(CustomEntry)),
			};


			StackLayout stackFleetDrive = new StackLayout()
			{
				IsVisible = false,
				Padding = new Thickness(30, 0, 0, 0),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Vertical,
				Children = { lblFleetRyder, stackFleetYes1 }
			};

			CustomEntry frameFleetEdior = new CustomEntry()
			{
				IsVisible = false,
				Placeholder = " [ENTER SAP NUMBER]",
				HeightRequest = 30,

			};

			Button btnFleetSubmit = new Button()
			{
				Text = "Submit",
				IsVisible = false,
				TextColor = Color.White,
				Margin = new Thickness(60, 0, 60, 0),
				BackgroundColor = Color.Gray
			};

			//Image imgFleetCheck = new Image()
			//{
			//  Source = "Unchecked.png",
			//  HeightRequest = 25,
			//  WidthRequest = 25,
			//};


			StackLayout stackbtnFleetSbumit = new StackLayout()
			{
				Spacing = 12,
				Children = { frameFleetEdior, btnFleetSubmit }
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
																								}
																								else
																								{
																									imgFleetCheck.Source = "Unchecked.png";
																									testIsActive = true;
																									stackFleetDrive.IsVisible = false;
																									//stackbtnSbumit.IsVisible = false;


																								}
																							};

			imgFleetCheck.GestureRecognizers.Add(imgFleetCheckTap);


			var imgFleetYesTap = new TapGestureRecognizer();
			imgFleetYesTap.Tapped += (s, e) =>
																								{
																									imgFleetNo.Source = "imgRadioNo.png";
																									imgFleetYes.Source = "imgRadioYes.png";
																									FleetTest = "Yes";
																									//stackRentDrive.IsVisible = true;
																									//stackIDrive.IsVisible = true;
																									btnFleetSubmit.IsVisible = true;
																									frameFleetEdior.IsVisible = true;

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

																								};

			imgFleetNo.GestureRecognizers.Add(imgFleetNoTap);



			StackLayout stackFleet = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal,
				Children = { imgFleetCheck, lblFleet }
			};

			#endregion






			#region Others

			Label lblOtherYes = new Label()
			{
				Text = "Yes",
				TextColor = AppGlobalVariables.Black,
				VerticalTextAlignment = TextAlignment.Center,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(CustomEntry)),
				//CustomFontFamily = AppGlobalVariables.fontFamily45
			};

			Image imgOtherYes = new Image()
			{
				Source = "imgRadioNo.png",
				HeightRequest = 30,
				WidthRequest = 30
			};
			var OtherTest = "Yes";

			StackLayout stackOtherYes = new StackLayout()
			{
				Spacing = 3,
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Children = { imgOtherYes, lblOtherYes }
			};


			Label lblOtherNo = new Label()
			{
				Text = "No",
				TextColor = AppGlobalVariables.Black,
				VerticalTextAlignment = TextAlignment.Center,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(CustomEntry)),
				//CustomFontFamily = AppGlobalVariables.fontFamily45
			};

			Image imgOtherNo = new Image()
			{
				Source = "imgRadioNo.png",
				HeightRequest = 30,
				WidthRequest = 30
			};



			StackLayout stackOtherNo = new StackLayout()
			{
				Spacing = 3,
				Orientation = StackOrientation.Horizontal,
				Children = { imgOtherNo, lblOtherNo },
				HorizontalOptions = LayoutOptions.EndAndExpand,
			};


			StackLayout stackOtherYes1 = new StackLayout()
			{
				Spacing = 5,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Orientation = StackOrientation.Horizontal,
				Children = { stackOtherYes, stackOtherNo }
			};
			Label lblOtherRyder = new Label()
			{
				HorizontalOptions = LayoutOptions.Start,
				Text = "Do you Other for Ryder?",
				TextColor = AppGlobalVariables.Black,
				VerticalTextAlignment = TextAlignment.Center,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(CustomEntry)),
			};


			StackLayout stackOtherDrive = new StackLayout()
			{
				IsVisible = false,
				Padding = new Thickness(30, 0, 0, 0),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Vertical,
				Children = { lblOtherRyder, stackOtherYes1 }
			};

			CustomEntry frameOtherEdior = new CustomEntry()
			{
				IsVisible = false,
				Placeholder = " [ENTER SAP NUMBER]",
				HeightRequest = 30,

			};

			Button btnOtherSubmit = new Button()
			{
				Text = "Submit",
				IsVisible = false,
				TextColor = Color.White,
				Margin = new Thickness(60, 0, 60, 0),
				BackgroundColor = Color.Gray
			};

			//Image imgFleetCheck = new Image()
			//{
			//  Source = "Unchecked.png",
			//  HeightRequest = 25,
			//  WidthRequest = 25,
			//};


			StackLayout stackbtnOtherSbumit = new StackLayout()
			{
				Spacing = 12,
				Children = { frameOtherEdior, btnOtherSubmit }
			};

			var imgOtherCheckTap = new TapGestureRecognizer();
			imgOtherCheckTap.Tapped += (s, e) =>
																										{
																											if (testIsActive == true)
																											{
																												imgOtherCheck.Source = "Checked.png";
																												testIsActive = false;
																												stackOtherDrive.IsVisible = true;
																												//isActiveCheck = "true";
																											}
																											else
																											{
																												imgOtherCheck.Source = "Unchecked.png";
																												testIsActive = true;
																												stackOtherDrive.IsVisible = false;
																												//stackbtnSbumit.IsVisible = false;


																											}
																										};

			imgOtherCheck.GestureRecognizers.Add(imgOtherCheckTap);


			var imgOtherYesTap = new TapGestureRecognizer();
			imgOtherYesTap.Tapped += (s, e) =>
																											{
																												imgOtherNo.Source = "imgRadioNo.png";
																												imgOtherYes.Source = "imgRadioYes.png";
																												FleetTest = "Yes";
																												//stackRentDrive.IsVisible = true;
																												//stackIDrive.IsVisible = true;
																												btnOtherSubmit.IsVisible = true;
																												frameOtherEdior.IsVisible = true;

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

																											};

			imgOtherNo.GestureRecognizers.Add(imgOtherNoTap);



			StackLayout stackOther = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal,
				Children = { imgOtherCheck, lblOther }
			};

			#endregion




			StackLayout stackTruck = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal,
				Children = { imgDriveCheck, lblDriveTruck }
			};



			StackLayout stackIDriveMain = new StackLayout()
			{
				Padding = new Thickness(0, 0, 0, 0),
				Spacing = 6,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Vertical,
				Children = { stackTruck, stackIDrive, stackbtnSbumit }
			};

			StackLayout stackRentMain = new StackLayout()

			{
				Padding = new Thickness(0, 0, 0, 0),
				Spacing = 6,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Vertical,
				Children = { stackRent, stackRentDrive, stackbtnRentSbumit }
			};


			StackLayout stackFleetMain = new StackLayout()

			{
				Padding = new Thickness(0, 0, 0, 0),
				Spacing = 6,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Vertical,
				Children = { stackFleet, stackFleetDrive, stackbtnFleetSbumit }
			};

			StackLayout stackOtherMain = new StackLayout()

			{
				Padding = new Thickness(0, 0, 0, 0),
				Spacing = 6,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Vertical,
				Children = { stackOther, stackOtherDrive, stackbtnOtherSbumit }
			};



			Button btnNext = new Button()
			{
				Text = "Next",
				TextColor = Color.White,
				VerticalOptions = LayoutOptions.EndAndExpand,
				BackgroundColor = Color.FromRgb(161, 162, 162)
			};

			StackLayout stackBody = new StackLayout()
			{
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Spacing = 40,
				Children = { stackIDriveMain, stackRentMain, stackFleetMain, stackOtherMain }
			};

			StackLayout stackMain = new StackLayout()
			{
				Padding = new Thickness(10, 30, 10, 30),
				Spacing = 30,
				Children = { stackHeader, stackBody, btnNext }
			};
			ScrollView scrollView = new ScrollView()
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Content = stackMain
			};
			Content = scrollView;
		}
	}
}