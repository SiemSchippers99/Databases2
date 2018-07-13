/*

RUN NIET ZONDER DE 1,000,000 TESTEN UIT TE COMMENTEN WANT DAN DUURT HET TE LANG(rij 159 tot rij 180)

*/

using System;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Eindopdracht
{
    class Adodotnet
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=LAPTOP-3L03LVCQ;Initial Catalog = 'versie 1'; Integrated Security = True";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("connection open");

                //queries worden aangemaakt
                string insertQuery = "insert into Gebruiker (Email, Wachtwoord, wachtwoord_reset_count, blocked_count, Abonnement_type, Abonnement_geldig_tot, Aantal_uitnodigingen, Geactiveerd) values ('test@test.com', 'testwachtwoord', 0, 1, 'UHD', '5/21/2019', 8, 1);";
                SqlCommand insert = new SqlCommand(insertQuery, connection);

                string selectQuery = "SELECT * FROM Gebruiker;";
                SqlCommand select = new SqlCommand(selectQuery, connection);

                string updateQuery = "UPDATE Gebruiker SET Email = 'test2@test.com';";
                SqlCommand update = new SqlCommand(updateQuery, connection);

                string deleteQuery = "DELETE FROM Gebruiker; ";
                SqlCommand delete = new SqlCommand(deleteQuery, connection);

                string resetQuery = "DELETE FROM Gebruiker WHERE Wachtwoord = 'testwachtwoord'; ";
                SqlCommand resetCommand = new SqlCommand(resetQuery, connection);

                //alle testdata wordt verwijdert
                resetCommand.ExecuteNonQuery();

                // Insert 1 keer
                var sw = Stopwatch.StartNew();
                for (int i = 0; i < 1; i++)
                {
                    insert.ExecuteNonQuery();
                }
                sw.Stop();
                Console.WriteLine("Time elapsed for 1 insert: {0} milliseconds", sw.ElapsedMilliseconds);

                sw.Reset();

                // Select 1 keer
                sw.Start();
                select.ExecuteNonQuery();
                sw.Stop();
                Console.WriteLine("Time elapsed for 1 select: {0} milliseconds", sw.ElapsedMilliseconds);

                sw.Reset();

                //Update 1 keer
                sw.Start();
                update.ExecuteNonQuery();
                sw.Stop();
                Console.WriteLine("Time elapsed for 1 update: {0} milliseconds", sw.ElapsedMilliseconds);

                sw.Reset();

                //Delete 1 keer
                sw.Start();
                delete.ExecuteNonQuery();
                sw.Stop();
                Console.WriteLine("Time elapsed for 1 delete: {0} milliseconds", sw.ElapsedMilliseconds);

                sw.Reset();

                // Insert 1000 keer
                sw.Start();
                for (int i = 0; i < 1000; i++)
                {
                    insert.ExecuteNonQuery();
                }
                sw.Stop();
                Console.WriteLine("Time elapsed for 1000 inserts: {0} milliseconds", sw.ElapsedMilliseconds);

                sw.Reset();

                // Select 1000 keer
                sw.Start();
                select.ExecuteNonQuery();
                sw.Stop();
                Console.WriteLine("Time elapsed for 1000 selects: {0} milliseconds", sw.ElapsedMilliseconds);

                sw.Reset();

                //Update 1000 keer
                sw.Start();
                update.ExecuteNonQuery();
                sw.Stop();
                Console.WriteLine("Time elapsed for 1000 updates: {0} milliseconds", sw.ElapsedMilliseconds);

                sw.Reset();

                //Delete 1000 keer
                sw.Start();
                delete.ExecuteNonQuery();
                sw.Stop();
                Console.WriteLine("Time elapsed for 1000 deletes: {0} milliseconds", sw.ElapsedMilliseconds);

                sw.Reset();

                // Insert 100,000 keer
                sw.Start();
                for (int i = 0; i < 100000; i++)
                {
                    insert.ExecuteNonQuery();
                }
                sw.Stop();
                Console.WriteLine("Time elapsed for 100,000 inserts: {0} milliseconds", sw.ElapsedMilliseconds);

                sw.Reset();

                // Select 100,000 keer
                sw.Start();
                select.ExecuteNonQuery();
                sw.Stop();
                Console.WriteLine("Time elapsed for 100,000 selects: {0} milliseconds", sw.ElapsedMilliseconds);

                sw.Reset();

                //Update 100,000 keer
                sw.Start();
                update.ExecuteNonQuery();
                sw.Stop();
                Console.WriteLine("Time elapsed for 100,000 updates: {0} milliseconds", sw.ElapsedMilliseconds);

                sw.Reset();

                //Delete 100,000 keer
                sw.Start();
                delete.ExecuteNonQuery();
                sw.Stop();
                Console.WriteLine("Time elapsed for 100,000 deletes: {0} milliseconds", sw.ElapsedMilliseconds);

                sw.Reset();

                // Insert 1,000,000 keer
                sw.Start();
                for (int i = 0; i < 1000000; i++)
                {
                    insert.ExecuteNonQuery();
                }
                sw.Stop();
                Console.WriteLine("Time elapsed for 1,000,000 inserts: {0} milliseconds", sw.ElapsedMilliseconds);

                sw.Reset();

                // Select 1,000,000 keer
                sw.Start();
                select.ExecuteNonQuery();
                sw.Stop();
                Console.WriteLine("Time elapsed for 1,000,000 selects: {0} milliseconds", sw.ElapsedMilliseconds);

                sw.Reset();

                //Update 1,000,000 keer
                sw.Start();
                update.ExecuteNonQuery();
                sw.Stop();
                Console.WriteLine("Time elapsed for 1,000,000 updates: {0} milliseconds", sw.ElapsedMilliseconds);

                sw.Reset();

                //Delete 1,000,000 keer
                sw.Start();
                delete.ExecuteNonQuery();
                sw.Stop();
                Console.WriteLine("Time elapsed for 1,000,000 deletes: {0} milliseconds", sw.ElapsedMilliseconds);

                sw.Reset();

                //Alle data wordt verwijdert
                Console.WriteLine("Done, wait for reset.");
                resetCommand.ExecuteNonQuery();
                Console.WriteLine("Reset Done");

                //Connectie wordt gesloten en er wordt gewacht op userinput tot het programma sluit
                connection.Close();
                Console.WriteLine("Connection closed");
                Console.Read();
            }
        }
    }
}
