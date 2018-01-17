using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MapDemoApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            UpdateMap();
		}

         private async Task<bool> UpdateMap()
        {
            try
            {
                var positions = (await (new Geocoder()).GetPositionsForAddressAsync("somnath,gujrat,india")).ToList<Position>();
                if (positions.Any()) { 
                    MyMap.IsVisible = true;
                    MyMap.MoveToRegion(
                        MapSpan.FromCenterAndRadius(
                            positions.First(), Distance.FromMiles(0.2)));
                }
                else
                {
                    MyMap.IsVisible = false;
                    return false;
                }
            }
            catch (Exception exc)
            {
                MyMap.IsVisible = false;
                return false;
            }
            return true;
        }
	}
}
