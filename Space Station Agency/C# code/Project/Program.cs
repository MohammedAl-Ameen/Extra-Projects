using System;
using System.Threading;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Admin admin = Admin.GetAdmin();
            Account_Factory factory = new Account_Factory();
            Account obj;
            Tourists tourists = new Tourists();
            Astronauts Astronauts = new Astronauts();
            Scientist scientist = new Scientist();
            bool flag;
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("**************************TheMainPage***************************");
                Console.WriteLine("1. login. \n2. Signup. \n3. Exit  ");
                Console.WriteLine("****************************************************************");
                Console.WriteLine();
                Console.Write("Your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {

                    case 1:
                        Console.WriteLine();
                        Console.WriteLine("**************************Login***************************");
                        Console.Write("Enter your ID please: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter your Password please: ");
                        string password = Console.ReadLine();
                        if (id == 404 && password == "404")
                        {
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("Hello Admin ...");
                            Thread.Sleep(2000);
                            Console.WriteLine("I hope you have a nice day :)");
                            Thread.Sleep(2000);
                            flag = false;
                            while (true)
                            {
                                
                                if (flag) { break; }
                                
                                Console.WriteLine();
                                Console.WriteLine("**************************Admin_Page***************************");
                                Console.WriteLine("1.Add spaceship. \n2.Add a Trip. \n3.Remove a spaceship \n4.Remove a trip \n5.remove account\n6.Show all the trips \n7.See all users \n8.Exit  ");
                                Console.WriteLine("****************************************************************");
                                Console.WriteLine();
                                Console.Write("Your choice: ");
                                int choice2 = Convert.ToInt32(Console.ReadLine());
                                Trip temp = new Trip();
                                switch (choice2)
                                {


                                    case 1:
                                        admin.AddSpaceShip();
                                        break;

                                    case 2:
                                        admin.AddTrip();
                                        break;

                                    case 3:
                                        admin.RemoveSpaceShip();
                                        break;

                                    case 4:
                                    
                                        temp.TripInfo();
                                        
                                        admin.TripRemove();
                                        break;

                                    case 5:
                                        admin.RemoveAccount();
                                        break;

                                    case 6:
                                        temp.TripInfo();
                                        break;

                                    case 7:
                                        admin.PrintUsers();
                                        break;
                                    case 8:
                                        flag = true;
                                        break;
                                        

                                }
                            }
                        } else {
                            obj = tourists.login(id, password);
                            if (obj != null) {
                                if ((id > 0) && (id <= 100))
                                {
                                    


                                    Console.WriteLine("Hello  {0}", obj.Name);
                                    Thread.Sleep(2000);
                                    flag = false;
                                    while (true)
                                    {
                                        if (flag) { break; }
                                        Console.WriteLine();
                                        Console.WriteLine("**************************Tourists_Page***************************");
                                        Console.WriteLine("1.Book a trip. \n2.Cancel a trip. \n3.Change a trip \n4.Insert money in your account \n5.See the trip schedule \n6.My schedule\n7.Exit  ");
                                        Console.WriteLine("******************************************************************");
                                        Console.WriteLine();
                                        Console.Write("Your choice: ");
                                        int choice3 = Convert.ToInt32(Console.ReadLine());

                                        switch (choice3)
                                        {


                                            case 1:

                                                Console.WriteLine("Enter the number of the trip");
                                                int num = Convert.ToInt32(Console.ReadLine());
                                                obj.BookTrip(num, obj);
                                                break;

                                            case 2:
                                                obj.CancelTrip(obj);
                                                break;

                                            case 3:
                                                Console.WriteLine("Enter the trip your wish to change into");
                                                int num2 = Convert.ToInt32(Console.ReadLine());
                                                obj.ChangeTrip(num2, obj);
                                                break;

                                            case 4:

                                                Console.WriteLine("How many do you wish to enter");
                                                double num3 = Convert.ToInt32(Console.ReadLine());
                                                obj.amount += num3;
                                                break;

                                            case 5:
                                                Trip temp2 = new Trip();
                                                temp2.TripInfo();
                                                break;
                                            case 6:
                                                Trip temp3 = new Trip();
                                                temp3 = tourists.Mytrip();
                                                temp3.info();
                                                break;

                                            case 7:
                                                flag = true;
                                                break;


                                        }


                                    }
                                }
                                else if (id > 100 && id <= 200) {
                                   
                                    flag = false;
                                    Console.WriteLine("Hello  {0}", obj.Name);
                                    Thread.Sleep(2000);
                                    while (true) {


                                        if (flag) { break; }
                                        Console.WriteLine();
                                        Console.WriteLine("**************************Scientist_Page***************************");
                                        Console.WriteLine("1.Book a trip. \n2.Cancel a trip. \n3.Change a trip \n4.Insert money in your account \n5.See the trip schedule \n6.My schedule");
                                        Console.Write("7.Add research \n8.Add data \n9.Show data\n10.Show research \n11.RemoveData \n12.RemoveReserch \n13.Exit\n");
                                        Console.WriteLine("******************************************************************");
                                        Console.WriteLine();
                                        Console.Write("Your choice: ");
                                        int choice4 = Convert.ToInt32(Console.ReadLine());
                                        switch (choice4) {

                                            case 1:

                                                Console.WriteLine("Enter the number of the trip");
                                                int num = Convert.ToInt32(Console.ReadLine());
                                                obj.BookTrip(num, obj);
                                                break;

                                            case 2:
                                                obj.CancelTrip(obj);
                                                break;

                                            case 3:
                                                Console.WriteLine("Enter the trip your wish to change into");
                                                int num2 = Convert.ToInt32(Console.ReadLine());
                                                obj.ChangeTrip(num2, obj);
                                                break;

                                            case 4:

                                                Console.WriteLine("How many do you wish to enter");
                                                double num3 = Convert.ToInt32(Console.ReadLine());
                                                obj.amount += num3;
                                                break;

                                            case 5:
                                                Trip temp2 = new Trip();
                                                temp2.TripInfo();
                                                break;
                                            case 6:
                                                Trip temp3 = new Trip();
                                                temp3 = scientist.Mytrip();
                                                temp3.info();
                                                break;


                                            case 7:
                                                scientist.AddResearch();
                                                break;

                                            case 8:
                                                scientist.AddData();
                                                break;

                                            case 9:
                                                scientist.ShowData();
                                                break;

                                            case 10:
                                                scientist.ShowResearch();
                                                break;

                                            case 11:
                                                Console.WriteLine("Please enter the id of the data");
                                                int num4 = Convert.ToInt32(Console.ReadLine());
                                                scientist.RemoveData(num4);
                                                break;

                                            case 12:
                                                scientist.RemoveRes();
                                                break;


                                            case 13:
                                                flag = true;
                                                break;



                                        }




                                    }

                                } else if ( id > 200 && id <= 300) {
                                    Console.WriteLine("Hello  {0}", obj.Name);
                                    Thread.Sleep(2000);
                                    flag = false;
                                    while (true)
                                    {
                                        if (flag) { break; }
                                        Console.WriteLine();
                                        Console.WriteLine("**************************Scientist_Page***************************");
                                        Console.WriteLine("1.Book a trip. \n2.Cancel a trip. \n3.Change a trip \n4.Insert money in your account \n5.See the trip schedule \n6.My schedule");
                                        Console.WriteLine("7.All ships info. \n8.One ship info. \n9.Rate a crew member \n10.See the trips schedule \n11.Exit");
                                        Console.WriteLine("******************************************************************");
                                        Console.WriteLine();
                                        Console.Write("Your choice: ");
                                        int choice5 = Convert.ToInt32(Console.ReadLine());
                                        switch (choice5) {
                                            case 1:

                                                Console.WriteLine("Enter the number of the trip");
                                                int num = Convert.ToInt32(Console.ReadLine());
                                                obj.BookTrip(num, obj);
                                                break;

                                            case 2:
                                                obj.CancelTrip(obj);
                                                break;

                                            case 3:
                                                Console.WriteLine("Enter the trip your wish to change into");
                                                int num2 = Convert.ToInt32(Console.ReadLine());
                                                obj.ChangeTrip(num2, obj);
                                                break;

                                            case 4:

                                                Console.WriteLine("How many do you wish to enter");
                                                double num3 = Convert.ToInt32(Console.ReadLine());
                                                obj.amount += num3;
                                                break;

                                            case 5:
                                                Trip temp2 = new Trip();
                                                temp2.TripInfo();
                                                break;
                                            case 6:
                                                Trip temp3 = new Trip();
                                                temp3 = Astronauts.Mytrip();
                                                temp3.info();
                                                break;


                                            case 7:
                                                Astronauts.ShipInfo();
                                                break;

                                            case 8:
                                                Console.WriteLine("Enter the id of the ship");
                                                int num6 = Convert.ToInt32(Console.ReadLine());
                                                Astronauts.ShipInfo(num6);
                                                break;

                                            case 9:
                                                Console.WriteLine("Enter the name of the crew member");
                                                string num7 = Console.ReadLine();
                                                Astronauts.AddRate(num7);
                                                break;

                                            case 10:
                                                Trip tr = new Trip();
                                                tr.TripInfo();
                                                break;

                                            case 11:
                                                flag = true;
                                                break;


                                        }
                                    }


                                }
                          
                            
                            } }break;

                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("**************************Signup***************************");
                        Console.WriteLine("1.Tourists \n2.Scientist \n3.Astronauts \n4.Back to the main page");
                        Console.WriteLine("***********************************************************");
                        Console.Write("Your choice: ");
                        int choice1 = Convert.ToInt32(Console.ReadLine());
                        switch (choice1) {
                            case 1:
                                obj = factory.GetAccount(1);
                                admin.AddAcount(obj);
                                break;

                            case 2:
                                obj = factory.GetAccount(2);
                                admin.AddAcount(obj);
                                break;

                            case 3:
                                obj = factory.GetAccount(3);
                                admin.AddAcount(obj);
                                break;

                            case 4:
                                break;

                        
                        
                        }
                        break;
                    case 3:
                        Tourists exit = new Tourists();
                        exit.logout();
                        Environment.Exit(1);
                        break;


                }
            }

            

        }
    }
}
