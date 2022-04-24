using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project

{
    abstract class Account
    {
        public string Name;
        public string Password;
        public int ID;
        public string Type;
        public double amount;
       

      
        public abstract int IdGenerate();

        public abstract Account login(int id, string Password);

        public abstract void logout();

        public abstract void BookTrip(int TripNum, Account obj2);

        public abstract void CancelTrip(Account obj2);

        public abstract void ChangeTrip(int TripNum ,  Account obj2);

        public abstract Trip Mytrip();
    }

    class Tourists : Account
    {
        
        public Tourists()
        {

            Name = "No name was entered";
            Password = "";
            ID = 0;
            Type = "Tourists";
            amount = 1000;



        }

        //public void InsertMoney(double amount) {

        //    amount += amount;


        //}

        public void pay(double amount)
        {

            this.amount -= amount;


        }



        public override int IdGenerate()
        {

            Console.WriteLine("Your ID is , {0}", ++ID);
            return ID;

        }



        public override Account login(int id, string Password)
        {
            Admin admin = Admin.GetAdmin();
            foreach (Account obj in admin.ListAccount)
            {
                if (id == obj.ID && Password == obj.Password)
                {

                    return obj;
                }

            }
            Console.WriteLine("Invalid Password or an ID ");
            return null;


        }

        public override void logout()
        {
            Console.WriteLine();
            Console.WriteLine("Thank you for using our agency");
            Console.WriteLine();
        }

        public override void BookTrip(int TripNum, Account obj2)
        {
            Admin admin = Admin.GetAdmin();
            bool flag = true;
            foreach (Trip obj in admin.ListTrip)
            {
                if (obj.ID == TripNum)
                {
                    if (this.amount >= obj.cost)
                    {

                        obj.AddPasenger(obj2, obj);
                        pay(obj.cost);
                        Console.WriteLine("The passenger was added succusfully \n"); flag = false;
                        break;
                    }
                    else {
                        Console.WriteLine("There is no enough money in the account");

                    } }
            }
            if (flag)
            {
                Console.WriteLine("The trip was not found \n");
            }



        }

        public override void CancelTrip(Account obj2)
        {
            Admin admin = Admin.GetAdmin();
            bool flag = true;
            foreach (Trip obj in admin.ListTrip)
            {
                if (obj.ID == obj2.ID)
                {
                    obj.DeletePassenger(obj, obj2);
                    Console.WriteLine("The passenger was deleted succusfully \n"); flag = false;
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("The trip was not found \n");
            }


        }

        public override void ChangeTrip(int TripNum, Account obj2)
        {
            Admin admin = Admin.GetAdmin();

            foreach (Trip t in admin.ListTrip) {
                foreach (Account a in t.Passengers) {
                    if (a.ID == obj2.ID) {
                        t.DeletePassenger(t, obj2);
                        obj2.BookTrip(TripNum, obj2);

                    }
                }
            }






        }

        public override Trip Mytrip (){
            Admin admin = Admin.GetAdmin();

            foreach (Trip t in admin.ListTrip) {
                foreach (Account a in t.Passengers) {
                    if (a.ID == ID) {

                        return t;
                    }
                
                }
            
            }
                       return null;
        
        
        }



    }

    class Scientist : Account
    {



        public Scientist()
        {

            Name = "";
            Password = "";
            ID = 100;
            Type = "Scientist";
            amount = 1000;


        }
        public override int IdGenerate()
        {

            Console.WriteLine("Your ID is , {0}", ++ID);
            return ID;

        }



        public override Account login(int id, string Password)
        {
            Admin admin = Admin.GetAdmin();
            foreach (Account obj in admin.ListAccount)
            {
                if (id == obj.ID && Password == obj.Password)
                {

                    return obj;
                }

            }
            Console.WriteLine("Invalid Password or an ID ");
            return null;


        }

        public override void logout()
        {
            Console.WriteLine();
            Console.WriteLine("Thank you for using our agency");
            Console.WriteLine();
        }

        public override void BookTrip(int TripNum, Account obj2)
        {
            Admin admin = Admin.GetAdmin();
            bool flag = true;
            foreach (Trip obj in admin.ListTrip)
            {
                if (obj.ID == TripNum)
                {
                    obj.AddPasenger(obj2, obj);
                    Console.WriteLine("The passenger was added succusfully \n"); flag = false;
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("The trip was not found \n");
            }



        }

        public override void CancelTrip(Account obj2)
        {
            Admin admin = Admin.GetAdmin();
            bool flag = true;
            foreach (Trip obj in admin.ListTrip)
            {
                if (obj.ID == obj2.ID)
                {
                    obj.DeletePassenger(obj, obj2);
                    Console.WriteLine("The passenger was deleted succusfully \n"); flag = false;
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("The trip was not found \n");
            }


        }

        public override void ChangeTrip(int TripNum, Account obj2)
        {
            Admin admin = Admin.GetAdmin();

            foreach (Trip t in admin.ListTrip)
            {
                foreach (Account a in t.Passengers)
                {
                    if (a.ID == obj2.ID)
                    {
                        t.DeletePassenger(t, obj2);
                        obj2.BookTrip(TripNum, obj2);

                    }
                }
            }

        }


        public void AddResearch()
        {
            Admin admin = Admin.GetAdmin();
            Research r = new Research();
            Scientist s = new Scientist();
            Console.WriteLine("Please enter the Research name: ");
            r.name = Console.ReadLine();
            Console.WriteLine("Please enter the Research ID: ");
            r.ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the Scientist name: ");
            s.Name = Console.ReadLine();
            Console.WriteLine("Please enter the Scientist ID: ");
            s.ID = Convert.ToInt32(Console.ReadLine());
            r.ResponsebleScientis = s;
            admin.ListResearch.Add(r);
            //admin.ListResearch.Remove(r);

        }


        public void ShowResearch()
        {
            Admin admin = Admin.GetAdmin();

            foreach (Research e in admin.ListResearch)
                Console.WriteLine("{0}     {1}     {2}     {3} ", e.name, e.ID, e.ResponsebleScientis.Name, e.ResponsebleScientis.ID);




        }

        public void RemoveRes()
        {
            Admin admin = Admin.GetAdmin();
            Console.WriteLine("Please enter the id of the Research: ");
            int id = Convert.ToInt32(Console.ReadLine());



            foreach (Research r in admin.ListResearch)
            {


                if (id == r.ID)
                {


                    admin.ListResearch.Remove(r);
                    Console.WriteLine("The research was deleted.");
                    break;


                }

            }






        }

        public void AddData() {
            Admin admin = Admin.GetAdmin();
            Data data = new Data();
            Console.WriteLine("Enter the ID of the data to be added");
            data.ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the INFO of the data to be added");
            data.info = Console.ReadLine();
            admin.ListData.Add(data);



        }

        public void RemoveData(int ID) {
            Admin admin = Admin.GetAdmin();
            foreach (Data d in admin.ListData) {
                if (d.ID == ID) {
                    admin.ListData.Remove(d);
                    Console.WriteLine("The Data was deleted \n ");
                    break;
                }
            
            }

        }

        public void ShowData()
        {
            Admin admin = Admin.GetAdmin();
            foreach (Data data in admin.ListData) {
                Console.WriteLine("{0}  {1}" , data.ID , data.info);
            }
        }

        public override Trip Mytrip()
        {
            Admin admin = Admin.GetAdmin();

            foreach (Trip t in admin.ListTrip)
            {
                foreach (Account a in t.Passengers)
                {
                    if (a.ID == ID)
                    {

                        return t;
                    }

                }

            }
            return null;


        }

    }

    class Astronauts : Account
    {
       public double Rate;
        public double NumOfRate = 1;
        public Astronauts()
        {

            Name = "";
            Password = "";
            ID = 200;
            Type = "Astronauts";
            amount = 1000;


        }
        public override int IdGenerate()
        {

            Console.WriteLine("Your ID is , {0}", ++ID);
            return ID;

        }



        public override Account login(int id, string Password)
        {
            Admin admin = Admin.GetAdmin();
            foreach (Account obj in admin.ListAccount)
            {
                if (id == obj.ID && Password == obj.Password)
                {

                    return obj;
                }

            }
            Console.WriteLine("Invalid Password or an ID ");
            return null;


        }

        public override void logout()
        {
            Console.WriteLine();
            Console.WriteLine("Thank you for using our agency");
            Console.WriteLine();
        }

        public override void BookTrip(int TripNum, Account obj2)
        {
            Admin admin = Admin.GetAdmin();
            bool flag = true;
            foreach (Trip obj in admin.ListTrip)
            {
                if (obj.ID == TripNum)
                {
                    obj.AddPasenger(obj2, obj);
                    Console.WriteLine("The passenger was added succusfully \n"); flag = false;
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("The trip was not found \n");
            }



        }

        public override void CancelTrip( Account obj2)
        {
            Admin admin = Admin.GetAdmin();
            bool flag = true;
            foreach (Trip obj in admin.ListTrip)
            {
                if (obj.ID == obj2.ID)
                {
                    obj.DeletePassenger(obj, obj2);
                    Console.WriteLine("The passenger was added succusfully \n"); flag = false;
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("The trip was not found \n");
            }


        }

        public override void ChangeTrip(int TripNum, Account obj2)
        {
            Admin admin = Admin.GetAdmin();

            foreach (Trip t in admin.ListTrip)
            {
                foreach (Account a in t.Passengers)
                {
                    if (a.ID == obj2.ID)
                    {
                        t.DeletePassenger(t, obj2);
                        obj2.BookTrip(TripNum, obj2);

                    }
                }
            }






        }

        public void AddRate(string name) {
            Admin admin = Admin.GetAdmin();
            Console.WriteLine("Please add the rate you have from 0 to 5");
            double rate = Convert.ToDouble(Console.ReadLine());
            foreach (Astronauts a in admin.ListAstronauts) {
                if (name == a.Name) {
                    a.Rate = a.Rate + rate;
                    a.Rate = a.Rate / a.NumOfRate;
                    a.NumOfRate++;
                
                }
            
            }
        
        
        
        }

        public void ShipInfo(int ID) {
            Admin admin = Admin.GetAdmin();
            foreach (SpaceShip s in admin.ListSpaceShip) {
                if(ID == s.ID)
                Console.WriteLine("{0}      {1}        ", s.ID , s.model);
                foreach (int num in s.CrewID)
                {
                    Console.Write("         {0}", num);


                }
                Console.WriteLine();


            }
        
        
        }

        public void ShipInfo()
        {
            Admin admin = Admin.GetAdmin();
            foreach (SpaceShip s in admin.ListSpaceShip)
            {
                    Console.Write("{0}      {1}         ", s.ID, s.model);
                
                foreach(int num in s.CrewID) {
                    Console.Write("         {0}", num);
                
                
                }
                Console.WriteLine();

            }


        }


        public override Trip Mytrip()
        {
            Admin admin = Admin.GetAdmin();

            foreach (Trip t in admin.ListTrip)
            {
                foreach (Account a in t.Passengers)
                {
                    if (a.ID == ID)
                    {

                        return t;
                    }

                }

            }
            return null;


        }




    }

    class Account_Factory
    {public Account GetAccount(int ID)
        {
            if (ID == 1) { return new Tourists(); }
            if (ID == 2) { return new Scientist(); }
            else if (ID == 3) { return new Astronauts(); }
            else return null;



        }}

    class Trip
    {
        public double cost;
        public int ID;
        DateTime date;
        Astronauts Caption;
        string Distination;
        SpaceShip ship;
        public  List<Account> Passengers = new List<Account>();

        public void AddTrip()
        {
            Admin admin = Admin.GetAdmin();
            Trip t = new Trip();
            Astronauts a = new Astronauts();
            SpaceShip s = new SpaceShip();
            int id;
            Console.WriteLine("Please add the ID of the trip: ");
            t.ID=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please add the cost of the trip: ");
            t.cost = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please add the Date of the trip: ");
            t.date = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Please add the Distination of the trip: ");
            t.Distination= Console.ReadLine();
            Console.WriteLine("Please add the Name of the Caption: ");
            a.Name = Console.ReadLine();
            Console.WriteLine("Please add the ID of the Caption: ");
            a.ID = Convert.ToInt32(Console.ReadLine());
            t.Caption = a;
            Console.WriteLine("Please add the ID of the ship: ");
            s.ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please add the model of the ship: ");
            s.model = Console.ReadLine();
            Console.WriteLine("Please enter the number of the crew and the ID of all of them: ");
            int index = Convert.ToInt32(Console.ReadLine());
            for (; index > 0; index--) {
                id = Convert.ToInt32(Console.ReadLine());
                s.CrewID.Add(id);
            }
            t.ship = s;
            
            admin.ListTrip.Add(t);

        }


        public void TripInfo()
        {
            Admin admin = Admin.GetAdmin();
            foreach (Trip t in admin.ListTrip) {
                Console.WriteLine("{0}      {1}         {2}     {3}         {4}", t.ID, t.date, t.Distination, t.Caption.Name, t.ship.model);
                    // Console.WriteLine(t);
            }


        }

        public void info() {

            Console.WriteLine("{0}      {1}         {2}     {3}         {4}", ID, date, Distination, Caption.Name, ship.model);



        }

     

        public void AddPasenger(Account passenger , Trip t) {
            Admin admin = Admin.GetAdmin();

             t.Passengers.Add(passenger);

            foreach (Trip tri in admin.ListTrip) {
                if (tri.ID == t.ID) {
                    admin.ListTrip.Remove(tri);
                    admin.ListTrip.Add(t);
                    Console.WriteLine("The process was done \n");
                    break;
                
                }
            }

                


        }

        public void DeletePassenger(Trip t , Account passenger) {
            Admin admin = Admin.GetAdmin();

            t.Passengers.Remove(passenger);

            foreach (Trip tri in admin.ListTrip)
            {
                if (tri.ID == t.ID)
                {
                    admin.ListTrip.Remove(tri);
                    admin.ListTrip.Add(t);
                    Console.WriteLine("The process was done \n");
                    break;

                }
            }


        }




    }

    class Research
    {   public string name;
        public int ID;
        public Scientist ResponsebleScientis;
    }
    
    
    class Data
    {
       public string info;
       public int ID;

    }

    class SpaceShip
    {
       
        public int ID;
        public string model;
        public List<int> CrewID = new List<int>();
       

    }
}
