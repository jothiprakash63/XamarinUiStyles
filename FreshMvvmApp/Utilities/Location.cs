﻿using KantimeEvv.Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamarinForms.LocationService.Services
{
    public class Location
    {
		readonly bool stopping = false;
		public Location()
		{
		}

		public async Task Run(CancellationToken token)
		{
			await Task.Run(async () => {
				while (!stopping)
				{
					token.ThrowIfCancellationRequested();
					try
					{
						await Task.Delay(2000);

						var request = new GeolocationRequest(GeolocationAccuracy.High);
						var location = await Geolocation.GetLocationAsync(request);
						if (location != null)
						{
							var message = new locationMessageModel
							{
								Latitude = location.Latitude,
								Longitude = location.Longitude
							};

							Device.BeginInvokeOnMainThread(() =>
							{
								MessagingCenter.Send<locationMessageModel>(message, "Location");
							});
						}
					}
					catch (Exception ex)
					{
						Device.BeginInvokeOnMainThread(() =>
						{
							var errormessage = new LocationErrorMessage();
							MessagingCenter.Send<LocationErrorMessage>(errormessage, "LocationError");
						});
					}
				}
				return;
			}, token);
		}
	}
}
