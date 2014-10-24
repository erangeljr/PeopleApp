using System;
using SQLite.Net.Attributes;

namespace PeopleApp.Models
{
	[Table("people")]
	public class Person
	{
		[PrimaryKey,AutoIncrement]
		public int Id {get; set;}
		[MaxLength(250),Unique]
		public string Name {get;set;}

		public Person()
		{
	
		}
	}
}

