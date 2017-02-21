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

        ////Houses
        static Houses GetHouse(string id)
        {

            var house = client.GetAsync($"houses/{id}/").Result;
            return house.Content.ReadAsAsync<Houses>().Result;

        }
        static List<Houses> GetHouses(int page)
        {
            var housePage = client.GetAsync($"houses?page={page}").Result;
            List<Houses> HousePages = housePage.Content.ReadAsAsync<List<Houses>>().Result;
            return HousePages;

        }
        ////Houses

        ////Characters
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
        ////Characters

        ////Books
        static List<Books> GetBooks(int page)
        {
            var bookPage = client.GetAsync($"books?page={page}").Result;
            List<Books> BookPages = bookPage.Content.ReadAsAsync<List<Books>>().Result;
            return BookPages;

        }
        static Books GetBook(string id)
        {

            var book = client.GetAsync($"books/{id}/").Result;
            return book.Content.ReadAsAsync<Books>().Result;

        }
        ////Books

        static void Main(string[] args)
        {
            SetUpClient();
            Index();

        }

        private static void Index()
        {
           
            Console.WriteLine("Welcome To Game Of Thrones Search");
            Console.WriteLine("");
            Console.WriteLine("1) Characters");
            Console.WriteLine("");
            Console.WriteLine("2) Books");
            Console.WriteLine("");
            Console.WriteLine("3) Houses");
            Console.WriteLine("");
            int choice = int.Parse(Read("> "));
            Console.WriteLine("");
            switch (choice)
            {
                case 1:
                    GetCharacterPages();
                    break;
                case 2:
                    GetBookPages();
                    break;
                case 3:
                    GetHousePages();
                    break;
                default:
                    break;
            }
        }

        //BookStart
        private static void GetBookPages()
        {
            for (int i = 1; i < 4;)
            {
                if (i >= 3)
                {
                    i = 1;
                }
                var bookPages = GetBooks(i);
                foreach (var book in bookPages)
                {
                    string path = book.url.ToString();
                    string pos = path.Split('/').Last();
                    Console.WriteLine(pos + " " + book.name);
                }
                Console.WriteLine("");
                Console.WriteLine("1) Next Page");
                Console.WriteLine("");
                Console.WriteLine("2) Previous Page");
                Console.WriteLine("");
                Console.WriteLine("3) Select Book Number");
                Console.WriteLine("");
                Console.WriteLine("4) Back");
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
                        Console.WriteLine("");
                        GetaBook();
                        Console.WriteLine("");
                        break;
                    case 4:
                        Console.Clear();
                        i = 0;
                        Index();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void GetaBook()
        {
            Console.WriteLine("Enter Book Number");
            string bookId = (Read("> "));
            var bookPage = GetBook(bookId);
            Console.WriteLine($"Name: {bookPage.name}");
            Console.WriteLine($"Publisher: {bookPage.publisher}");
            Console.WriteLine($"Number Of Pages: {bookPage.numberOfPages}");
            Console.WriteLine($"Released: {bookPage.released}");
            Console.WriteLine($"Url: {bookPage.url}");
        }
        //Book end

        //Character Start
        private static void GetCharacterPages()
        {
            for (int i = 1; i < 61;)
            {
                if (i >= 60)
                {
                    i = 1;
                }
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
                Console.WriteLine("4) Back");
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
                        Console.WriteLine("");
                        GetCharacter();
                        Console.WriteLine("");
                        break;
                    case 4:
                        Console.Clear();
                        i = 0;
                        Index();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void GetCharacter()
        {
            Console.WriteLine("Enter Character Number");
            string charId = (Read("> "));
            var characterPage = GetCharacter(charId);
            Console.WriteLine($"Name: {characterPage.name}");
            Console.WriteLine($"Gender: {characterPage.gender}");
            Console.WriteLine($"Culture: {characterPage.culture}");
            Console.WriteLine($"Born: {characterPage.born}");
            Console.WriteLine($"Died: {characterPage.died}");
            Console.WriteLine($"Url: {characterPage.Url}");
        }
        //Character End.

        //Houses Start.
        private static void GetHousePages()
        {
            for (int i = 1; i < 40;)
            {
                if (i >= 39)
                {
                    i = 1;
                }
                var housePages = GetHouses(i);
                foreach (var house in housePages)
                {
                    string path = house.url.ToString();
                    string pos = path.Split('/').Last();
                    Console.WriteLine(pos + " " + house.name);

                }
                Console.WriteLine("");
                Console.WriteLine("1) Next Page");
                Console.WriteLine("");
                Console.WriteLine("2) Previous Page");
                Console.WriteLine("");
                Console.WriteLine("3) Select House Number");
                Console.WriteLine("");
                Console.WriteLine("4) Back");
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
                        Console.WriteLine("");
                        GetaHouse();
                        Console.WriteLine("");
                        break;
                    case 4:
                        Console.Clear();
                        i = 0;
                        Index();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void GetaHouse()
        {
            Console.WriteLine("Enter House Number");
            string houseId = (Read("> "));
            var housePage = GetHouse(houseId);
            Console.WriteLine($"Name: {housePage.name}");
            Console.WriteLine($"Region: {housePage.region}");
            Console.WriteLine($"Coat Of Arms: {housePage.coatOfArms}");
            Console.WriteLine($"Current Lord: {housePage.currentLord}");
            Console.WriteLine($"Url: {housePage.url}");
        }
        //Houses End.
    }
}

