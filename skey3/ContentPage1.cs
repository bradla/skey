using System;
using Xamarin.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace skey3
{
	public class ContentPage1 : ContentPage
	{
		Button button = new Button
		{
			Text = "Generate One Time Password",
			Font = Font.SystemFontOfSize(NamedSize.Medium),
			BorderWidth = 1,
			HorizontalOptions = LayoutOptions.Center,
			VerticalOptions = LayoutOptions.CenterAndExpand
		};

		Switch switcherMD5 = new Switch{};
		Switch switcherSHA1 = new Switch{};				
		Switch switcherRMD160 = new Switch{};
				
		void switcher_Toggled_MD5(object sender, ToggledEventArgs e)
		{
			if (e.Value == true) {
				button.Text = String.Format ("Generate One Time Password MD5");
				switcherSHA1.IsToggled = false;
				switcherRMD160.IsToggled = false;
			}
		}

		void switcher_Toggled_SHA1(object sender, ToggledEventArgs e)
		{
			if (e.Value == true) {
				button.Text = String.Format ("Generate One Time Password SHA1");
				switcherMD5.IsToggled = false;
				switcherRMD160.IsToggled = false;
			}
		}

		void switcher_Toggled_RMD160(object sender, ToggledEventArgs e)
		{
			if (e.Value == true) {
				button.Text = String.Format ("Generate One Time Password RMD160");
				switcherMD5.IsToggled = false;
				switcherSHA1.IsToggled = false;
			}
		}

		public ContentPage1 ()
		{
//			var label1 = new Label {
//				Text = "key ",
//				IsEnabled = true,
//				Opacity = 0.75,
//				XAlign = TextAlignment.Center,
//				VerticalOptions = LayoutOptions.CenterAndExpand,
//				TextColor = Color.Blue,
//				BackgroundColor = Color.FromRgb(255, 128, 128),
//				FontSize = Device.GetNamedSize(NamedSize.Large, new Label()),
//				FontAttributes = FontAttributes.Bold | FontAttributes.Italic
//			};

			Picker picker = new Picker
			{
				Title = "Hash",
				VerticalOptions = LayoutOptions.Start,
				HorizontalOptions = LayoutOptions.Start,
				WidthRequest = 100,
				IsEnabled = true,
				HeightRequest = 30
			};

			picker.Items.Add ("SHA1");
			picker.Items.Add ("MD5");
			picker.Items.Add ("RMD160");
			string colorName = "";

			picker.SelectedIndexChanged += (sender, args) =>
			{
				colorName = picker.Items[picker.SelectedIndex];
			};

			var number = new Entry {
				Placeholder = "Number",
				VerticalOptions = LayoutOptions.Start,
				HorizontalOptions = LayoutOptions.Start,
				WidthRequest = 150,
				HeightRequest = 30
			};

			var seed = new Entry {
				Placeholder = "Seed",
				VerticalOptions = LayoutOptions.Start,
				HorizontalOptions = LayoutOptions.Start,
				WidthRequest = 150,
				HeightRequest = 30
			};

			var passwd = new Entry {
				Placeholder = "Password",
				IsPassword = true,
				VerticalOptions = LayoutOptions.Start,
				HorizontalOptions = LayoutOptions.Start,
				WidthRequest = 150,
				HeightRequest = 30
			};

			var otpText = new Entry {
				Placeholder = "",
				Text = "",
				IsEnabled = false
			};

			switcherMD5.IsToggled = true;
			if (switcherMD5.IsToggled == true) {
				button.Text = "Generate One Time Password MD5";
			}
			switcherMD5.Toggled += switcher_Toggled_MD5;
			switcherSHA1.Toggled += switcher_Toggled_SHA1;
			switcherRMD160.Toggled += switcher_Toggled_RMD160;

			int seq=0;
			var seed2="";
			var passphrase="";

			//  set our initial selection on the label  || seed?.Text || passwd?.Text
			button.Clicked += delegate {
				if ( number.Text == null ) DisplayAlert ("Alert", "Number is empty", "OK");
				if ( seed.Text == null ) DisplayAlert ("Alert", "Seed is empty", "OK");
				if ( passwd.Text == null ) DisplayAlert ("Alert", "Password is empty", "OK");
				else
				{
					if (switcherMD5.IsToggled == true || switcherMD5.IsToggled == false) {
						seq = Convert.ToInt32(number.Text);
						seed2 = seed.Text;
						passphrase = passwd.Text;
						otp otpwd = new otp();
						otpwd.otp1(seq, seed2, passphrase);
						otpwd.calcmd5();
						otpText.Text = otpwd.toString();
					}
					if (switcherSHA1.IsToggled == true ) {
						seq = Convert.ToInt32(number.Text);
						seed2 = seed.Text;
						passphrase = passwd.Text;
						otp otpwd = new otp();
						otpwd.otp1(seq, seed2, passphrase);
						otpwd.calcsha1();
						otpText.Text = otpwd.toString();
					}
				}

			};
				
			// Accomodate iPhone status bar.
			Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

			Label md5label = new Label {
				Text = "MD5",
				TextColor = Xamarin.Forms.Color.Green,
			};

			Label sha1label = new Label {
				Text = "SHA1"
			};

			Label rmd160label = new Label {
				Text = "RMD160",
					TextColor = Xamarin.Forms.Color.Green
			};
					
			RelativeLayout relativeLayout = new RelativeLayout ();

			relativeLayout.Children.Add (md5label, Constraint.RelativeToParent ((parent) => {
				return 0;
			}));

			relativeLayout.Children.Add (switcherMD5,
				Constraint.RelativeToParent ((parent) => {
					return (parent.Width * .15) ;
				}),

				Constraint.RelativeToParent ((parent) => {
					return parent.Height / 99;
			}));
			/*
			relativeLayout.Children.Add (sha1label,
				Constraint.RelativeToParent ((parent) => {
					return (parent.Width * .35);
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height / 99;
			}));
		
			relativeLayout.Children.Add (switcherSHA1,
				Constraint.RelativeToParent ((parent) => {
					return (parent.Width * .50);
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height / 99;
			}));

			relativeLayout.Children.Add (rmd160label,
				Constraint.RelativeToParent ((parent) => {
					return (parent.Width * .68);
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height / 99;
				}));
			
			relativeLayout.Children.Add (switcherRMD160,
				Constraint.RelativeToParent ((parent) => {
					return (parent.Width * .87);
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height / 99;
			}));
	*/
			Content = new StackLayout {
				//Padding= new Thickness (5, 20, 5, 5),
				//Padding = 5,
				//Spacing = 1,
				Children = { 
					//picker,
					number,
					seed, 
					passwd, 
					otpText,
					relativeLayout,
					button
				}
			}; 

		}
	}
}

