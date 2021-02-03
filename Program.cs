using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace API_Template
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test");
            var client = new RestClient("https://api.nobelprize.org/2.0/laureates?_ga=2.36666979.2114374858.1612259065-1946553270.1612259065");
            var request = new RestRequest("/", Method.GET);
            IRestResponse response = client.Execute(request);
            String content = response.Content;
            Root root = JsonConvert.DeserializeObject<Root>(content);

            Console.WriteLine(root.laureates[0].fullName.en);
            //Jag vill använda api:n  på ett sättså jag förstår hur de
            //funkar och vad koden över betyder. Min första ide är att
            //göra en räknare som kan räkna u hur många gånger högre
            //värde en valuta har änn en annan.
        }
    }

    public class KnownName
    {
        public string en { get; set; }
        public string se { get; set; }
    }

    public class GivenName
    {
        public string en { get; set; }
        public string se { get; set; }
    }

    public class FamilyName
    {
        public string en { get; set; }
        public string se { get; set; }
    }

    public class FullName
    {
        public string en { get; set; }
        public string se { get; set; }
    }

    public class City
    {
        public string en { get; set; }
        public string no { get; set; }
        public string se { get; set; }
    }

    public class Country
    {
        public string en { get; set; }
        public string no { get; set; }
        public string se { get; set; }
    }

    public class CityNow
    {
        public string en { get; set; }
        public string no { get; set; }
        public string se { get; set; }
    }

    public class CountryNow
    {
        public string en { get; set; }
        public string no { get; set; }
        public string se { get; set; }
    }

    public class Continent
    {
        public string en { get; set; }
    }

    public class LocationString
    {
        public string en { get; set; }
        public string no { get; set; }
        public string se { get; set; }
    }

    public class Place
    {
        public City city { get; set; }
        public Country country { get; set; }
        public CityNow cityNow { get; set; }
        public CountryNow countryNow { get; set; }
        public Continent continent { get; set; }
        public LocationString locationString { get; set; }
    }

    public class Birth
    {
        public string date { get; set; }
        public Place place { get; set; }
    }

    public class Links
    {
        public string rel { get; set; }
        public string href { get; set; }
        public string action { get; set; }
        public string types { get; set; }
        public string first { get; set; }
        public string self { get; set; }
        public string next { get; set; }
        public string last { get; set; }
    }

    public class Category
    {
        public string en { get; set; }
        public string no { get; set; }
        public string se { get; set; }
    }

    public class CategoryFullName
    {
        public string en { get; set; }
        public string no { get; set; }
        public string se { get; set; }
    }

    public class Motivation
    {
        public string en { get; set; }
        public string se { get; set; }
        public string no { get; set; }
    }

    public class Name
    {
        public string en { get; set; }
        public string no { get; set; }
        public string se { get; set; }
    }

    public class NameNow
    {
        public string en { get; set; }
    }

    public class Affiliation
    {
        public Name name { get; set; }
        public NameNow nameNow { get; set; }
        public City city { get; set; }
        public Country country { get; set; }
        public CityNow cityNow { get; set; }
        public CountryNow countryNow { get; set; }
        public LocationString locationString { get; set; }
    }

    public class Residence
    {
        public Country country { get; set; }
        public CountryNow countryNow { get; set; }
        public LocationString locationString { get; set; }
    }

    public class NobelPrize
    {
        public string awardYear { get; set; }
        public Category category { get; set; }
        public CategoryFullName categoryFullName { get; set; }
        public string sortOrder { get; set; }
        public string portion { get; set; }
        public string dateAwarded { get; set; }
        public string prizeStatus { get; set; }
        public Motivation motivation { get; set; }
        public int prizeAmount { get; set; }
        public int prizeAmountAdjusted { get; set; }
        public List<Affiliation> affiliations { get; set; }
        public Links links { get; set; }
        public List<Residence> residences { get; set; }
    }

    public class Death
    {
        public string date { get; set; }
        public Place place { get; set; }
    }

    public class Laureate
    {
        public string id { get; set; }
        public KnownName knownName { get; set; }
        public GivenName givenName { get; set; }
        public FamilyName familyName { get; set; }
        public FullName fullName { get; set; }
        public string gender { get; set; }
        public Birth birth { get; set; }
        public Links links { get; set; }
        public List<NobelPrize> nobelPrizes { get; set; }
        public Death death { get; set; }
    }

    public class Meta
    {
        public int offset { get; set; }
        public int limit { get; set; }
        public int count { get; set; }
    }

    public class Root
    {
        public List<Laureate> laureates { get; set; }
        public Meta meta { get; set; }
        public Links links { get; set; }
    }

}
