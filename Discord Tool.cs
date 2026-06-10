using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace dctool
{
	internal class Program
	{
		static void Main(string[] args)
		{
			while (true) 
			{
							Console.Clear();
							Console.Title = "CodeRat";
							Banner();
							Menu();
							
							ConsoleKeyInfo input = Console.ReadKey();
							char option = input.KeyChar;
							Console.WriteLine(option);
							switch (option) 
							{
								case '1':
									webhookMessage();
									break;
								case '4':
									return;
							}			

			}
			
		}
		
		static void Banner()
		{

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(@"
 ________  ________ _________  ________  ________  ___          
|\   ___ \|\   ____\\___   ___\\   __  \|\   __  \|\  \         
\ \  \_|\ \ \  \___\|___ \  \_\ \  \|\  \ \  \|\  \ \  \        
 \ \  \ \\ \ \  \       \ \  \ \ \  \\\  \ \  \\\  \ \  \       
  \ \  \_\\ \ \  \____   \ \  \ \ \  \\\  \ \  \\\  \ \  \____  
   \ \_______\ \_______\  \ \__\ \ \_______\ \_______\ \_______\
    \|_______|\|_______|   \|__|  \|_______|\|_______|\|_______|


                                   dctool ~ spannynoob
");
		Console.ResetColor();
		
		}
		
		static void Menu()
		{
			Console.WriteLine("\n1. Send Webhook Message");
			Console.WriteLine("2. Check Member Status");
			Console.WriteLine("3. View Guild Info");
			Console.WriteLine("4. Exit ");
		}
		
		static async Task webhookMessage()
		{
			Console.Clear();
			Console.Write("Webhook URL: ");
			string webhook = Console.ReadLine();
			
			Console.Write("Message: ");
			string message = Console.ReadLine();
			
			string json = $"{{\"content\":\"{message}\"}}";
			
			using (HttpClient client = new HttpClient()) {
				HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
				await client.PostAsync(webhook, content);
			}
		}
	}
