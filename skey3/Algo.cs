using System;

namespace skey3
{
	public class Algo
	{
		public event EventHandler<EventArgs> OnToggled = delegate {};

		public string Name { get; set; }
		public bool IsSelected 
		{ 
			get { return _isSelected.Value; }
			set 
			{
				if (_isSelected.HasValue == true && _isSelected.Value != value)
				{
					_isSelected = value;
					OnToggled (this, new EventArgs ());
				}
				else
				{
					_isSelected = value;
				}
				//	System.Diagnostics.Debug.WriteLine ("IsSelected for {0} updated to {1}", Name, value);
			}
		}
		private bool? _isSelected = null;

		public Algo(string name, bool isSelected)
		{
			this.Name = name;
			this.IsSelected = isSelected;
		}
	}
}

