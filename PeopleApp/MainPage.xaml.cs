using PeopleApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace PeopleApp
{	
	public partial class MainPage : ContentPage
	{	
		public MainPage ()
		{
			InitializeComponent ();
		}

		public async void OnNewButtonClicked(object sender, EventArgs args)
		{
			statusMessage.Text = "";

			await App.PersonRepository.AddNewPersonAsync(newPerson.Text);
			statusMessage.Text = App.PersonRepository.StatusMessage;
		}

		public async void OnGetButtonClicked(object sender, EventArgs args)
		{
			statusMessage.Text = "";

			var listOfPeople = await App.PersonRepository.GetAllPeopleAsync();
			ObservableCollection<Person> peopleCollection = new ObservableCollection<Person>(listOfPeople);
			peopleList.ItemsSource = peopleCollection;
		}

	}
}

