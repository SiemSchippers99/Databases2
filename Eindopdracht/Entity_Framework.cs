/*

RUN NIET ZONDER DE 1,000,000 TESTEN UIT TE COMMENTEN WANT DAN DUURT HET TE LANG (rij 175 tot 218)

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Eindopdracht
{
    class Entity_Framework
    {
        static void Main(string[] args)
        {
            using (var db = new NetflixContext())
            {
                Console.WriteLine("database created");
                db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Gebruiker ON");

                var gebruiker = new Gebruiker
                {
                    Email = "a",
                    Wachtwoord = "b",
                    Abonnement_type = "c",
                    Abonnement_geldig_tot = "d",
                    Wachtwoord_reset_count = 2,
                    Blocked_count = 1,
                    Blocked_tot = "e",
                    Geactiveerd = 1
                };

                //delete alles in gebruikers voor testen
                var rows = from o in db.Gebruikers
                           select o;
                foreach (var row in rows)
                {
                    db.Gebruikers.Remove(row);
                }
                db.SaveChanges();

                //Insert 1
                var sw = Stopwatch.StartNew();
                db.Gebruikers.Add(gebruiker);
                db.SaveChanges();
                sw.Stop();
                Console.WriteLine("Time elapsed for 1 insert: {0} milliseconds", sw.ElapsedMilliseconds);
                sw.Reset();

                //Select 1
                sw.Start();
                db.Gebruikers.Select(b => b.Wachtwoord == "b").Count();
                sw.Stop();
                Console.WriteLine("Time elapsed for 1 select: {0} milliseconds", sw.ElapsedMilliseconds);
                sw.Reset();

                var update = db.Gebruikers.Where(b => b.Email == "a").First();
                //Update 1
                sw.Start();
                update = db.Gebruikers.Where(b => b.Wachtwoord == "b").First();
                update.Email = "b";
                db.SaveChanges();
                sw.Stop();
                Console.WriteLine("Time elapsed for 1 update: {0} milliseconds", sw.ElapsedMilliseconds);
                sw.Reset();

                var delete = db.Gebruikers.First<Gebruiker>();
                //Delete 1
                sw.Start();
                rows = from o in db.Gebruikers
                       select o;
                foreach (var row in rows)
                {
                    db.Gebruikers.Remove(row);
                }
                db.SaveChanges();
                db.SaveChanges();
                sw.Stop();
                Console.WriteLine("Time elapsed for 1 delete: {0} milliseconds", sw.ElapsedMilliseconds);
                sw.Reset();

                //Insert 1000
                sw.Start();
                for (int i = 0; i < 1000; i++)
                {
                    db.Gebruikers.Add(gebruiker);
                    db.SaveChanges();
                }
                sw.Stop();
                Console.WriteLine("Time elapsed for 1000 inserts: {0} milliseconds", sw.ElapsedMilliseconds);
                sw.Reset();

                //Select 1000
                sw.Start();
                db.Gebruikers.Select(b => b.Wachtwoord == "b").Count();
                sw.Stop();
                Console.WriteLine("Time elapsed for 1000 selects: {0} milliseconds", sw.ElapsedMilliseconds);
                sw.Reset();

                //Update 1000
                sw.Start();
                for (int i = 0; i < 1000; i++)
                {
                    update = db.Gebruikers.Where(b => b.Wachtwoord == "b").First();
                    update.Email = "b";
                    db.SaveChanges();
                }
                sw.Stop();
                Console.WriteLine("Time elapsed for 1000 update: {0} milliseconds", sw.ElapsedMilliseconds);
                sw.Reset();

                //Delete 1000
                sw.Start();
                rows = from o in db.Gebruikers
                       select o;
                foreach (var row in rows)
                {
                    db.Gebruikers.Remove(row);
                }
                db.SaveChanges();
                db.SaveChanges();
                sw.Stop();
                Console.WriteLine("Time elapsed for 1000 deletes: {0} milliseconds", sw.ElapsedMilliseconds);
                sw.Reset();

                //Insert 100,000
                sw.Start();
                for (int i = 0; i < 100000; i++)
                {
                    db.Gebruikers.Add(gebruiker);
                    db.SaveChanges();
                }
                sw.Stop();
                Console.WriteLine("Time elapsed for 100,000 inserts: {0} milliseconds", sw.ElapsedMilliseconds);
                sw.Reset();

                //Select 100,000
                sw.Start();
                db.Gebruikers.Select(b => b.Wachtwoord == "b").Count();
                sw.Stop();
                Console.WriteLine("Time elapsed for 100,000 selects: {0} milliseconds", sw.ElapsedMilliseconds);
                sw.Reset();

                //Update 100,000
                sw.Start();
                for (int i = 0; i < 100000; i++)
                {
                    update = db.Gebruikers.Where(b => b.Wachtwoord == "b").First();
                    update.Email = "b";
                    db.SaveChanges();
                }
                sw.Stop();
                Console.WriteLine("Time elapsed for 100,000 update: {0} milliseconds", sw.ElapsedMilliseconds);
                sw.Reset();

                //Delete 100,000
                sw.Start();
                rows = from o in db.Gebruikers
                       select o;
                foreach (var row in rows)
                {
                    db.Gebruikers.Remove(row);
                }
                db.SaveChanges();
                db.SaveChanges();
                sw.Stop();
                Console.WriteLine("Time elapsed for 100,000 deletes: {0} milliseconds", sw.ElapsedMilliseconds);
                sw.Reset();

                //Insert 1,000,000
                sw.Start();
                for (int i = 0; i < 1000000; i++)
                {
                    db.Gebruikers.Add(gebruiker);
                    db.SaveChanges();
                }
                sw.Stop();
                Console.WriteLine("Time elapsed for 1,000,000 inserts: {0} milliseconds", sw.ElapsedMilliseconds);
                sw.Reset();

                //Select 1,000,000
                sw.Start();
                db.Gebruikers.Select(b => b.Wachtwoord == "b").Count();
                sw.Stop();
                Console.WriteLine("Time elapsed for 1,000,000 selects: {0} milliseconds", sw.ElapsedMilliseconds);
                sw.Reset();

                //Update 1,000,000
                sw.Start();
                for (int i = 0; i < 1000000; i++)
                {
                    update = db.Gebruikers.Where(b => b.Wachtwoord == "b").First();
                    update.Email = "b";
                    db.SaveChanges();
                }
                sw.Stop();
                Console.WriteLine("Time elapsed for 1,000,000 update: {0} milliseconds", sw.ElapsedMilliseconds);
                sw.Reset();

                //Delete 1,000,000
                sw.Start();
                rows = from o in db.Gebruikers
                       select o;
                foreach (var row in rows)
                {
                    db.Gebruikers.Remove(row);
                }
                db.SaveChanges();
                db.SaveChanges();
                sw.Stop();
                Console.WriteLine("Time elapsed for 1,000,000 deletes: {0} milliseconds", sw.ElapsedMilliseconds);
                sw.Reset();

                Console.WriteLine("done");
                Console.ReadKey();
            }
        }
    }

    //Model voor de database
    [Table("Gebruiker")]
    public class Gebruiker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Gebruiker_ID { get; set; }
        public String Email { get; set; }
        public String Wachtwoord { get; set; }
        public String Abonnement_type { get; set; }
        public String Abonnement_geldig_tot { get; set; }
        public int Wachtwoord_reset_count { get; set; }
        public int Blocked_count { get; set; }
        public String Blocked_tot { get; set; }
        public int Geactiveerd { get; set; }
        public virtual ICollection<Uitnodigingen> Uitnodigingens { get; set; }
        public virtual ICollection<Profiel> Profiels { get; set; }
    }

    [Table("Uitnodiging")]
    public class Uitnodigingen
    {
        [Key]
        public int Uitnodigingen_ID { get; set; }
        public int Gebruikt { get; set; }
        public String Uitgenodigd_email { get; set; }
        public int Gebruiker_ID { get; set; }
        public virtual Gebruiker Gebruiker { get; set; }
    }

    [Table("Taal")]
    public class Taal
    {
        [Key]
        public int Taal_ID { get; set; }
        public String TaalNaam { get; set; }
        public virtual ICollection<Profiel> Profiels { get; set; }
        public virtual ICollection<Ondertiteling> Ondertitelings { get; set; }
    }

    [Table("Ondertiteling")]
    public class Ondertiteling
    {
        [Key]
        public int Ondertiteling_ID { get; set; }
        public String Ondertiteling_path { get; set; }
        public int Gebruikt { get; set; }
        public int Taal_ID { get; set; }
        public virtual Taal Taal { get; set; }
        public virtual ICollection<Video_has_Ondertiteling> Video_Has_Ondertitelings { get; set; }
    }

    [Table("Profiel")]
    public class Profiel
    {
        [Key]
        public int Profiel_ID { get; set; }
        public String ProfielNaam { get; set; }
        public String ProfielFoto { get; set; }
        public String GeboorteDatum { get; set; }
        public int Taal_ID { get; set; }
        public int Gebruiker_ID { get; set; }
        public virtual Taal Taal { get; set; }
        public virtual ICollection<Gekeken_video> Gekeken_Videos { get; set; }
        public virtual ICollection<Kijklijst> Kijklijsts { get; set; }
        public virtual ICollection<Profiel_has_Voorkeur> Profiel_Has_Voorkeurs { get; set; }
        public virtual Gebruiker Gebruiker { get; set; }
    }

    [Table("Video")]
    public class Video
    {
        [Key]
        public int Video_ID { get; set; }
        public String Naam { get; set; }
        public int Tijdsduur { get; set; }
        public int Kwaliteit { get; set; }
        public virtual ICollection<Kijklijst> Kijklijsts { get; set; }
        public virtual ICollection<Gekeken_video> Gekeken_Videos { get; set; }
        public virtual ICollection<Video_has_Ondertiteling> Video_Has_Ondertitelings { get; set; }
        public virtual ICollection<Voorkeur_has_Video> Voorkeur_Has_Videos { get; set; }
    }

    [Table("Video_has_Ondertiteling")]
    public class Video_has_Ondertiteling
    {
        [Key]
        public int Video_Has_Ondertiteling_ID { get; set; }
        public int Video_ID { get; set; }
        public int Ondertiteling_ID { get; set; }
        public virtual Video Video { get; set; }
        public virtual Ondertiteling Ondertiteling { get; set; }
    }

    [Table("Kijklijst")]
    public class Kijklijst
    {
        [Key]
        public int Kijklijst_ID { get; set; }
        public int Profiel_ID { get; set; }
        public int Tijd_gekeken { get; set; }
        public int Video_ID { get; set; }
        public virtual Profiel Profiel { get; set; }
        public virtual Video Video { get; set; }
    }

    [Table("Gekeken_video")]
    public class Gekeken_video
    {
        [Key]
        public int Gekeken_video_ID { get; set; }
        public int Profiel_ID { get; set; }
        public int Video_ID { get; set; }
        public virtual Profiel Profiel { get; set; }
        public virtual Video Video { get; set; }
    }

    [Table("Voorkeur")]
    public class Voorkeur
    {
        [Key]
        public int Voorkeur_ID { get; set; }
        public String Beschrijving { get; set; }
        public virtual ICollection<Profiel_has_Voorkeur> Profiel_Has_Voorkeurs { get; set; }
        public virtual ICollection<Voorkeur_has_Video> Voorkeur_Has_Videos { get; set; }
    }

    [Table("Profiel_has_Voorkeur")]
    public class Profiel_has_Voorkeur
    {
        [Key]
        public int Profiel_has_Voorkeur_ID { get; set; }
        public int Profiel_ID { get; set; }
        public int Voorkeur_ID { get; set; }
        public virtual Profiel Profiel { get; set; }
        public virtual Voorkeur Voorkeur { get; set; }
    }

    [Table("Voorkeur_has_Video")]
    public class Voorkeur_has_Video
    {
        [Key]
        public int Voorkeur_has_Video_ID { get; set; }
        public int Voorkeur_ID { get; set; }
        public int Video_ID { get; set; }
        public virtual Voorkeur Voorkeur { get; set; }
        public virtual Video Video { get; set; }
    }

    public class NetflixContext : DbContext
    {
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Uitnodigingen> Uitnodigingens { get; set; }
        public DbSet<Taal> Taals { get; set; }
        public DbSet<Ondertiteling> Ondertitelings { get; set; }
        public DbSet<Profiel> Profiels { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Video_has_Ondertiteling> Video_Has_Ondertitelings { get; set; }
        public DbSet<Kijklijst> Kijklijsts { get; set; }
        public DbSet<Gekeken_video> Gekeken_Videos { get; set; }
        public DbSet<Voorkeur> Voorkeurs { get; set; }
        public DbSet<Profiel_has_Voorkeur> Profiel_Has_Voorkeurs { get; set; }
        public DbSet<Voorkeur_has_Video> Voorkeur_Has_Videos { get; set; }
    }
}
