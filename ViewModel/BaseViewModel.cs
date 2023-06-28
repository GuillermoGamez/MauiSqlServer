using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiSqlServer.ViewModel
{
	public class BaseViewModel : ObservableObject
	{
		public BaseViewModel()
		{
		}

		public string Title { get; set; }
		public bool IsBusy { get; set; }
	}
}

