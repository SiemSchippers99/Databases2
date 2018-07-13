using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Diagnostics;

namespace Eindopdracht
{
    class MongoDB
    {
        static void Main(string[] args)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var server = client.GetDatabase("Netflix");

            //testdata voor gebruiker
            GebruikerMongo gebruiker = new GebruikerMongo()
            {
                Email = "a",
                Wachtwoord = "b"
            };

            var gebruikerCollection = server.GetCollection<GebruikerMongo>("Gebruiker");

            Stopwatch sw = new Stopwatch();

            //Insert 1
            sw.Start();
            gebruikerCollection.InsertOne(gebruiker);
            sw.Stop();
            Console.WriteLine("Time elapsed for 1 insert: {0} milliseconds", sw.ElapsedMilliseconds);
            sw.Reset();

            //Select 1
            var select = Builders<GebruikerMongo>.Filter.Eq("Wachtwoord", "b");
            sw.Start();
            var selected = gebruikerCollection.Find(select);
            sw.Stop();
            Console.WriteLine("Time elapsed for 1 select: {0} milliseconds", sw.ElapsedMilliseconds);
            sw.Reset();

            //Update 1
            var update = Builders<GebruikerMongo>.Update.Set("Email", "b");
            sw.Start();
            gebruikerCollection.UpdateOne(select, update);
            sw.Stop();
            Console.WriteLine("Time elapsed for 1 update: {0} milliseconds", sw.ElapsedMilliseconds);
            sw.Reset();

            //Delete 1
            sw.Start();
            gebruikerCollection.DeleteOne(select);
            sw.Stop();
            Console.WriteLine("Time elapsed for 1 delete: {0} milliseconds", sw.ElapsedMilliseconds);
            sw.Reset();

            //Een array van duizend gebruikers zodat het gebruikt kan worden in de testen 
            GebruikerMongo[] duizendGebruikers = new GebruikerMongo[1000];
            for (int i = 0; i < 1000; i++)
            {
                duizendGebruikers[i] = new GebruikerMongo()
                {
                    Email = "a",
                    Wachtwoord = "b"
                };
            }

            //Insert 1000
            sw.Start();
            gebruikerCollection.InsertMany(duizendGebruikers);
            sw.Stop();
            Console.WriteLine("Time elapsed for 1000 Insert: {0} milliseconds", sw.ElapsedMilliseconds);
            sw.Reset();

            //Select 1000
            select = Builders<GebruikerMongo>.Filter.Eq("Wachtwoord", "b");
            sw.Start();
            selected = gebruikerCollection.Find(select);
            sw.Stop();
            Console.WriteLine("Time elapsed for 1000 select: {0} milliseconds", sw.ElapsedMilliseconds);
            sw.Reset();

            //Update 1000
            update = Builders<GebruikerMongo>.Update.Set("Email", "b");
            sw.Start();
            gebruikerCollection.UpdateMany(select, update);
            sw.Stop();
            Console.WriteLine("Time elapsed for 1000 update: {0} milliseconds", sw.ElapsedMilliseconds);
            sw.Reset();

            //Delete 1000
            sw.Start();
            gebruikerCollection.DeleteMany(select);
            sw.Stop();
            Console.WriteLine("Time elapsed for 1000 delete: {0} milliseconds", sw.ElapsedMilliseconds);
            sw.Reset();

            //Een array van honderdduizend gebruikers zodat het gebruikt kan worden tijdens testen
            GebruikerMongo[] honderdduizendGebruikers = new GebruikerMongo[100000];
            for (int i = 0; i < 100000; i++)
            {
                honderdduizendGebruikers[i] = new GebruikerMongo()
                {
                    Email = "a",
                    Wachtwoord = "b"
                };
            }

            //Insert 100,000
            sw.Start();
            gebruikerCollection.InsertMany(honderdduizendGebruikers);
            sw.Stop();
            Console.WriteLine("Time elapsed for 100,000 Insert: {0} milliseconds", sw.ElapsedMilliseconds);
            sw.Reset();

            //Select 100,000
            select = Builders<GebruikerMongo>.Filter.Eq("Wachtwoord", "b");
            sw.Start();
            selected = gebruikerCollection.Find(select);
            sw.Stop();
            Console.WriteLine("Time elapsed for 100,000 select: {0} milliseconds", sw.ElapsedMilliseconds);
            sw.Reset();

            //Update 100,000
            update = Builders<GebruikerMongo>.Update.Set("Email", "b");
            sw.Start();
            gebruikerCollection.UpdateMany(select, update);
            sw.Stop();
            Console.WriteLine("Time elapsed for 100,000 update: {0} milliseconds", sw.ElapsedMilliseconds);
            sw.Reset();

            //Delete 100,000
            sw.Start();
            gebruikerCollection.DeleteMany(select);
            sw.Stop();
            Console.WriteLine("Time elapsed for 100,000 delete: {0} milliseconds", sw.ElapsedMilliseconds);
            sw.Reset();
            
            //Een array van een miljoen gebruikers zodat het gebruikt kan worden tijdens testen
            GebruikerMongo[] miljoenGebruikers = new GebruikerMongo[1000000];
            for (int i = 0; i < 1000000; i++)
            {
                miljoenGebruikers[i] = new GebruikerMongo()
                {
                    Email = "a",
                    Wachtwoord = "b"
                };
            }

            //Insert 1,000,000
            sw.Start();
            gebruikerCollection.InsertMany(miljoenGebruikers);
            sw.Stop();
            Console.WriteLine("Time elapsed for 1,000,000 Insert: {0} milliseconds", sw.ElapsedMilliseconds);
            sw.Reset();

            //Select 1,000,000
            select = Builders<GebruikerMongo>.Filter.Eq("Wachtwoord", "b");
            sw.Start();
            selected = gebruikerCollection.Find(select);
            sw.Stop();
            Console.WriteLine("Time elapsed for 1,000,000 select: {0} milliseconds", sw.ElapsedMilliseconds);
            sw.Reset();

            //Update 1,000,000
            update = Builders<GebruikerMongo>.Update.Set("Email", "b");
            sw.Start();
            gebruikerCollection.UpdateMany(select, update);
            sw.Stop();
            Console.WriteLine("Time elapsed for 1,000,000 update: {0} milliseconds", sw.ElapsedMilliseconds);
            sw.Reset();

            //Delete 1,000,000
            sw.Start();
            gebruikerCollection.DeleteMany(select);
            sw.Stop();
            Console.WriteLine("Time elapsed for 1,000,000 delete: {0} milliseconds", sw.ElapsedMilliseconds);
            sw.Reset();

            Console.ReadKey(); Console.ReadKey(); Console.ReadKey(); Console.ReadKey();
        }
    }

    //Model voor de database
    class GebruikerMongo
    {
        public ObjectId GebruikerID { get; set; }
        public String Email { get; set; }
        public String Wachtwoord { get; set; }
    }

    class ProfielMongo
    {
        public ObjectId ProfielID { get; set; }
        public String Naam { get; set; }
        public String Email { get; set; }
        public int GebruikerID { get; set; }
    }

    class Film_gekekenMongo
    {
        public ObjectId Film_gekekenID { get; set; }
        public int ProfielID { get; set; }
        public int FilmID { get; set; }
    }

    class FilmMongo
    {
        public ObjectId FilmID { get; set; }
        public String Naam { get; set; }
        public int Tijd { get; set; }
    }
}
