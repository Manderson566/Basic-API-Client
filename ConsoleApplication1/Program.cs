using BasicAPIClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BasicAPIClient
{
    class Program
    {

        static string Read(string input)
        {
            Console.Write(input.ToUpper());
            return Console.ReadLine();
        }

        public static HttpClient client = new HttpClient();

        private static void SetUpClient()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri("https://anapioficeandfire.com/api/");
        }
        static Characters GetCharacter(string id)
        {
    
            var character = client.GetAsync($"characters/{id}/").Result;
            return character.Content.ReadAsAsync<Characters>().Result;

        }
        static List<Characters> GetCharacters(int page)
        {
            var characterPage = client.GetAsync($"characters?page={page}").Result;
            List<Characters> CharPages = characterPage.Content.ReadAsAsync<List<Characters>>().Result;
            return CharPages;

        }
        static void Main(string[] args)
        {
            Console.WriteLine("");
            Console.WriteLine("1) Characters");
            Console.WriteLine("");
            Console.WriteLine("2) Books");
            Console.WriteLine("");
            Console.WriteLine("3) Select Character Number");
            Console.WriteLine("");
            int choice = int.Parse(Read("> "));
            Console.WriteLine("");
            switch (choice)
            {
                case 1:
                    GetCharacterPages();
                    break;
                case 2:
                    Console.Clear();
                    i--;
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("");
                    GetCharacter();
                    Console.WriteLine("");
                    break;
                default:
                    break;
            }
            


            }

        private static void GetBookPages()
        {
            SetUpClient();
            for (int i = 1; i < 215;)
            {
                var characterPages = GetCharacters(i);
                foreach (var character in characterPages)
                {
                    string path = character.Url.ToString();
                    string pos = path.Split('/').Last();
                    Console.WriteLine(pos + " " + character.name);
                }
                Console.WriteLine("");
                Console.WriteLine("1) Next Page");
                Console.WriteLine("");
                Console.WriteLine("2) Previous Page");
                Console.WriteLine("");
                Console.WriteLine("3) Select Character Number");
                Console.WriteLine("");
                int choice = int.Parse(Read("> "));
                Console.WriteLine("");
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        i++;
                        break;
                    case 2:
                        Console.Clear();
                        i--;
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("");
                        GetCharacter();
                        Console.WriteLine("");
                        break;
                    default:
                        break;
                }
            }
        }


        private static void GetCharacterPages()
        {
            SetUpClient();
            for (int i = 1; i < 215;)
            {
                var characterPages = GetCharacters(i);
                foreach (var character in characterPages)
                {
                    string path = character.Url.ToString();
                    string pos = path.Split('/').Last();
                    Console.WriteLine(pos + " " + character.name);

                    //Credit to Michael On this. 
                }
                Console.WriteLine("");
                Console.WriteLine("1) Next Page");
                Console.WriteLine("");
                Console.WriteLine("2) Previous Page");
                Console.WriteLine("");
                Console.WriteLine("3) Select Character Number");
                Console.WriteLine("");
                int choice = int.Parse(Read("> "));
                Console.WriteLine("");
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        i++;
                        break;
                    case 2:
                        Console.Clear();
                        i--;
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("");
                        GetCharacter();
                        Console.WriteLine("");
                        break;
                    default:
                        break;
                }
            }
        }

        private static void GetCharacter()
        {
            string charId = (Read("> "));
            var characterPage = GetCharacter(charId);
            Console.WriteLine($"Name: {characterPage.name}");
            Console.WriteLine($"Gender: {characterPage.gender}");
            Console.WriteLine($"Culture: {characterPage.culture}");
            Console.WriteLine($"Born: {characterPage.born}");
            Console.WriteLine($"Died: {characterPage.died}");
            Console.WriteLine($"Url: {characterPage.Url}");
        }
    }
}

