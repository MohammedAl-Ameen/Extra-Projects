using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Admin
    {
        static Admin admin = new Admin();
        public List<Research> ListResearch;
        public List<Scientist> ListScientists;
        public List<Trip> ListTrip;
        public List<Account> ListAccount;

        public List<Data> ListData;
        public List<Astronauts> ListAstronauts;
        public List<SpaceShip> ListSpaceShip;


        Admin()
        {
            ListResearch = new List<Research>();
            ListAccount = new List<Account>();
            ListScientists = new List<Scientist>();
            ListData = new List<Data>();
            ListTrip = new List<Trip>();
            ListAstronauts = new List<Astronauts>();
            ListSpaceShip = new List<SpaceShip>();
        }

        public static Admin GetAdmin()
        {
            return admin;
        }

        public void AddAcount(Account A)
        {
            Console.WriteLine("Please enter your name");
            A.Name = Console.ReadLine();
            Console.WriteLine("Please enter your password");
            A.Password = Console.ReadLine();
            A.ID = A.IdGenerate();
            ListAccount.Add(A);
        }


        public void TripRemove()
        {
            Console.WriteLine("Please enter the id of the trip \n");
            int id = Convert.ToInt32(Console.ReadLine());

            foreach (Trip t in ListTrip)
            {
                if (t.ID == id)
                {
                    ListTrip.Remove(t);
                    break;
                }

            }

        }

        public void AddTrip()
        {

            Trip Trip = new Trip();
            Trip.AddTrip();

        }


        public void AddSpaceShip()
        {
            SpaceShip space = new SpaceShip();
            Console.WriteLine("Enter the ID of the space ship ");
            space.ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Model of the space ship ");
            space.model = Console.ReadLine();
            Console.WriteLine("Enter the number of the crew member and then enter the ID of all of them. ");
            int id;
            int index = Convert.ToInt32(Console.ReadLine());
            for (; index > 0; index--)
            {
                id = Convert.ToInt32(Console.ReadLine());
                space.CrewID.Add(id);
            }

            ListSpaceShip.Add(space);



        }

        public void RemoveSpaceShip()
        {
            Console.WriteLine("Please enter the id of the space ship");
            int index = Convert.ToInt32(Console.ReadLine());
            foreach (SpaceShip s in ListSpaceShip)
            {
                if (index == s.ID)
                {
                    ListSpaceShip.Remove(s);
                    break;




                }


            }



        }

        public void RemoveAccount() {
            Console.WriteLine("Please enter the id of the account you wish to delete ");
            int index = Convert.ToInt32(Console.ReadLine());
            foreach (Account a in ListAccount) {
                if (index == a.ID) {
                    ListAccount.Remove(a);
                    break;
                }
            
            }



        }


        public void PrintUsers() {
            foreach (Account a in ListAccount) {
          
                
                   
                    Console.WriteLine("**************************");
                    Console.WriteLine("Name         ID          Password            Type          ");
                    Console.WriteLine("{0}          {1}           {2}                {3}          ", a.Name , a.ID , a.Password , a.Type);
                    Console.WriteLine("**************************");
              
                
            } Console.WriteLine();
        
        
        }


    }
}
