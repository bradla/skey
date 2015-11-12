using System;
using Xamarin.Forms;

namespace skey3
{
	public class CustomSwitchCell : ViewCell
	{
		public event EventHandler <EventArgs> SwitchTapped;

		public CustomSwitchCell ()
		{
			var stack = new StackLayout () 
			{
				Orientation = StackOrientation.Horizontal,
				Padding = new Thickness (10, 5, 10, 5),
				Spacing = 0
			};

			var NameLabel = new Label (); 
			NameLabel.HorizontalOptions = LayoutOptions.Fill;
			NameLabel.FontSize = Device.GetNamedSize (NamedSize.Default, typeof(Label));
			//NameLabel.LineBreakMode = LineBreakMode.NoWrap;
			NameLabel.TextColor = Color.Black;
			NameLabel.SetBinding (Label.TextProperty, "Name");
			stack.Children.Add (NameLabel);

			var ToggleSwitch = new Switch ();
			ToggleSwitch.HorizontalOptions = LayoutOptions.End;
			ToggleSwitch.SetBinding (Switch.IsToggledProperty, "IsSelected");
			stack.Children.Add (ToggleSwitch);

			View = stack;
		}
	}
}

