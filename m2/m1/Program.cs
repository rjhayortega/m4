using System;
using MongoDB.Driver;
using MongoDB.Bson;
using Newtonsoft.Json;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Net;

namespace m1
{
    class MainClass
    {
        static IMongoDatabase db;

        public static void Main(string[] args)
        {

            MongoClient dbClient = new MongoClient("mongodb+srv://teampo2:po2developers@cluster0-evnhh.mongodb.net/test?retryWrites=true");
            var dbList = dbClient.ListDatabases().ToList();


            db = dbClient.GetDatabase("babydocclub");

            if (args[0].Contains("@"))
            {
                addVisit(args[0]);

              
            }
            else
            {
                Query();
            }

            //  string json = JsonConvert.SerializeObject(items, Formatting.Indented);
            //   Console.Write(json);
        }



        public static void Query()
        {

            var things = db.GetCollection<BsonDocument>("signups");
            BsonDocument personDoc;


            //CREATE  
            personDoc = new BsonDocument();

            var resultDoc = things.Find(personDoc).ToList();
            List<Product> items = new List<Product>();
            string name = "";


            //This is my connection string i have assigned the database file address path  
            ////  string MyConnection2 = @"server=database4.lcn.com;database=tenaciousengagement_com_admin;username=LCN405272_admin;password=!devadmin0987";
            //  MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            ///   MyConn2.Open();

            //   String q = "delete from mailList where id>0";
            //MySqlCommand m = new MySqlCommand(q, MyConn2);
            //  Console.Write(m);

            List<string> emails = new List<string>();
            foreach (var itm in resultDoc)
            {

            
                string email =string.Empty;
                string child4 = string.Empty;
                string child1 = string.Empty;
                string child2 = string.Empty;
                string child3 = string.Empty;

                int Months = 0;
                string Location = string.Empty;
                string County = string.Empty;
                string is_pregnant = string.Empty;
                string pregnancy_due_date = string.Empty;
                string brand_of_nappies = string.Empty;
                string area_code = string.Empty;
                string phone_number = string.Empty;
                int visits = 0;
                string number_of_children = string.Empty;
                string jd = string.Empty;
                string source = string.Empty;

                try
                {
                    name = itm["name"].ToString();
                }
                catch
                {

                }


                try
                {
                    email = itm["email"].ToString();
                }
                catch
                {

                }


                try
                {
                    child4 = itm["Child 4"].ToString();
                }
                catch
                {

                }

                try
                {
                    Months = itm["Months"].ToInt32();
                }
                catch
                {

                }

                try
                {
                    Location = itm["location"].ToString();
                }
                catch
                {

                }

                try
                {
                    County = itm["county"].ToString();
                }
                catch
                {

                }

                try
                {

                    visits = itm["Visits"].AsBsonArray.Count;
                }
                catch
                {
                }


                try
                {
                    is_pregnant = itm["is_pregnant"].ToString();
                }

                catch
                {

                }

                try
                {
                    pregnancy_due_date = itm["pregnancy_due_date"].ToString();
                }
                catch
                {
                  
                }


                try
                {
                    number_of_children = itm["number_of_children"].ToString();
                }
                catch
                {
                  
                }


                try
                {
                    child1 = itm["child1"].ToString();
                }
                catch
                {
                 
                }


                try
                {
                    child2 = itm["child2"].ToString();
                }
                catch
                {
                   
                }


                try
                {
                    child3 = itm["child3"].ToString();
                }
                catch
                {
                   
                }

                try
                {
                    brand_of_nappies = itm["brand_of_nappies"].ToString();
                }
                catch
                {
                 
                }


                try
                {
                    area_code = itm["area_code"].ToString();
                }
                catch
                {
                  
                }

                try
                {
                    phone_number = itm["phone_number"].ToString();
                }
                catch
                {
                  
                }



                try
                {
                  jd = itm["created_date"].ToString();
                }
                catch
                {

                }

                try
                {
                    source = itm["source"].ToString();
                }
                catch
                {

                }




                if (!emails.Contains(email))
                {
                    Product p1 = new Product
                    {

                        name = name,

                        email = email,
                        location = Location,

                        county = County,
                        is_pregnant = is_pregnant,
                        pregnancy_due_date = pregnancy_due_date,
                        number_of_children = number_of_children,
                        child1 = child1,
                        child2 = child2,
                        child3 = child3,

                        Child4 = child4,

                        Months = Months,
                        brand_of_nappies = brand_of_nappies,
                        area_code = area_code,
                        phone_number = phone_number,
                        visits = visits,
                        joinedDate = jd,
                        source = source
                        //ExpiryDate = new DateTime(2000, 12, 29, 0, 0, 0, DateTimeKind.Utc),
                    };

                    emails.Add(email);
                    items.Add(p1);


                }
            }



            using (WebClient Client = new WebClient())
            {


                var Json = Newtonsoft.Json.JsonConvert.SerializeObject(items);
                Client.Headers[HttpRequestHeader.ContentType] = "application/json";
                string tmp = Client.UploadString("http://admin.consumablemedia.com/home/ins1.php", "POST", Json);
               Console.Write(tmp);
            }

            /*
            using (WebClient Client = new WebClient())
            {


                var Json = Newtonsoft.Json.JsonConvert.SerializeObject(items);
               Client.Headers[HttpRequestHeader.ContentType] = "application/json";
                string tmp = Client.UploadString("http://po2devs.a2hosted.com/projects/mdd/t3.php", "POST", Json);
              //  Console.Write(tmp);
            }

       */

        }




        public static void addVisit(string email)
        {
            var things = db.GetCollection<BsonDocument>("signups");
            BsonDocument personDoc;
            try
            {
                //CREATE  
                personDoc = new BsonDocument();
                personDoc.Add(new BsonElement("email", email));
                var resultDoc = things.Find(personDoc).ToList();

                if (resultDoc[0].Contains("Visits"))
                {
                    Console.WriteLine("THERE");
                    BsonArray ba = resultDoc[0]["Visits"].AsBsonArray;
                    //BsonDocument bd = new BsonDocument(new BsonElement("Date", DateTime.Now.ToString()));
                    ba.Add("{ Date:" + DateTime.Now.ToString() + "}");

                    resultDoc[0]["Visits"] = ba;
                }

                else
                {
                    BsonArray ba = new BsonArray();
                    //BsonDocument bd = new BsonDocument(new BsonElement("Date", DateTime.Now.ToString()));
                    ba.Add("{ Date:" + DateTime.Now.ToString() + "}");
                    resultDoc[0].Add(new BsonElement("Visits", ba));
                }


                var updateDoc = things.FindOneAndReplace(personDoc, resultDoc[0]);



            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }


        }

    }



    class Product
    {
        public string name;
        public string email;
        public string location;
        public string county;

        public string is_pregnant;
        public string pregnancy_due_date;
        public string number_of_children;
        public string child1;
        public string child2;
        public string child3;
        public string Child4;
        public int Months;
        public string brand_of_nappies;
        public string area_code;
        public string phone_number;
        public int visits;
        public string joinedDate;
        public string source;
    }



}
