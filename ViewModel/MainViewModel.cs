using System;
using CommunityToolkit.Mvvm.Input;
using MauiSqlServer.Common;
using Microsoft.Data.SqlClient;

namespace MauiSqlServer.ViewModel
{
	public class MainViewModel : BaseViewModel
	{
		public MainViewModel()
		{
			Connection = new Connection();
			ConnectCommand = new RelayCommand(async () => await Connect());
		}

        public Connection Connection { get; set; }
		public string TableName { get; set; }

        public RelayCommand ConnectCommand { get; set; }

		public async Task Connect()
		{
			try
			{ 
				using var connection = new SqlConnection(Connection.GetConnection());
				connection.Open();
				string sql = $@"SELECT TOP 5 * FROM {TableName}";
				var command = new SqlCommand(sql, connection);
				var reader = command.ExecuteReader();
			
				if (reader.Read())
				{
					connection.Close();
					await Shell.Current.DisplayAlert("Success", "Connected", "Confirm");
				}
				else
				{
					connection.Close();
					await Shell.Current.DisplayAlert("Error", "Could not connect", "Confirm");
				}
				connection.Close();
			}
			catch (Exception ex)
			{
                await Shell.Current.DisplayAlert("Error", ex.Message, "Confirm");
            }
		}
	}
}