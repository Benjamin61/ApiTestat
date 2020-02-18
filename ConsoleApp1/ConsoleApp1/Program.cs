using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace Apis
{
	class Program
	{
		static void Main(string[] args)
		{


			RestClient client = new RestClient("https://swapi.co/api/");


			int answer = 0; //Gör 1 int där spelarens parsade input lagras
			bool success = false;
			while (success == false)
			{
				Console.WriteLine("Skriv in en person mellan 1-88");
				string inputNum = Console.ReadLine(); //spelares input laras

				success = int.TryParse(inputNum, out answer); //Försöker göra om spelares input till 1 int

				if (success && answer < 1 || answer > 89) //Om parsen lyckas och svaret är under 1 eller över 89 så får man skriva in svaret igen
				{
					Console.WriteLine("Försök igen");
					success = false;
				}
			}
			List<string> Name = new List<string>();
			List<string> Gender = new List<string>();
			RestRequest request = new RestRequest("people/" + answer + "/");

			IRestResponse response = client.Get(request);

			StarWars people = JsonConvert.DeserializeObject<StarWars>(response.Content);
			Console.WriteLine("Namn: " + people.name);
			Name.Add(people.name);
			Gender.Add(people.gender);
			Console.WriteLine("111111111111111111111111111111111111111");
			Console.WriteLine(Name);
			Console.WriteLine(Gender);
			Console.WriteLine("Kön: " + people.gender);


			/*" Massa: [" + people.mass + "] " + 
			" Hårfärg: [" + people.hair_color + "] " + 
			" Kön: [" + people.gender + "] ");*/



			//Console.WriteLine(response.Content);

			Console.ReadLine();
		}
	}
}
