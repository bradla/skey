using System;
using System.Collections.ObjectModel;

namespace skey3
{
	public class SwitchViewModel
	{
		public ObservableCollection<Algo> Algos { get; set; }

		public SwitchViewModel ()
		{
			Algos = new ObservableCollection<Algo> 
			{
				new Algo ("MD5", true),
				new Algo ("SHA1", false), 
				new Algo ("RMD160", false)
			};

			foreach (var Algo in Algos)
			{
				Algo.OnToggled += ToggleSelection;
			}
		}
		void ToggleSelection (object sender, EventArgs e)
		{
			var algo = sender as Algo;
			//Console.WriteLine ("{0} has been toggled to {1}", algo.Name, algo.IsSelected);
		}
	}
}

