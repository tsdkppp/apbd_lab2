using System;
using System.Collections.Generic;
using System.Data;

namespace APBD_tutorial2
{
    class Program
    {
        static void Main(string[] args)
        {
            ContainerShip ship1 = new ContainerShip(5, 50_000);
            ContainerShip ship2 = new ContainerShip(5, 50_000);
            
            GasContainer gasContainer = new GasContainer(10, 200, 3000, 100, 10_000);
            LiquidContainer liquidContainer = new LiquidContainer(true, 200, 2500, 100, 8000);
            RefrigeratedContainer refrigeratedContainer = new RefrigeratedContainer("Fish", 5, 200, 4000, 100, 12_000);
            
            Console.WriteLine("===========");
            Console.WriteLine("All information about all containers we have:");
            gasContainer.PrintInformationAboutContainer();
            liquidContainer.PrintInformationAboutContainer();
            refrigeratedContainer.PrintInformationAboutContainer();
            Console.WriteLine("===========\n");
            
            
            Console.WriteLine("===========");
            try
            {
                gasContainer.LoadContainer(5000);
                liquidContainer.LoadContainer(3000);
                refrigeratedContainer.LoadContainer(8000);
            }
            catch (OverfillException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            Console.WriteLine("Containers loaded successfully");
            Console.WriteLine("===========\n");
            
            
            Console.WriteLine("===========");
            try
            {
                ship1.AddContainerToShip(gasContainer);
                ship1.AddContainerToShip(liquidContainer);
                ship1.AddContainerToShip(refrigeratedContainer);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            Console.WriteLine("Containers added to the ship1 successfully");
            Console.WriteLine("===========\n");
            
            Console.WriteLine("===========");
            Console.WriteLine("All information about the ship are:");
            ship1.PrintShipInformation();
            Console.WriteLine("===========\n");
            
            Console.WriteLine("===========");
            Console.WriteLine("Before unloading gas container:");
            gasContainer.PrintInformationAboutContainer();
            Console.WriteLine("After unloading gas container:");
            gasContainer.EmptyCargo();
            gasContainer.PrintInformationAboutContainer();
            Console.WriteLine("===========\n");
            
            Console.WriteLine("===========");
            ship1.RemoveContainerFromShip(liquidContainer);
            Console.WriteLine("After removing a liquid container from the ship:\nShip Information:");
            ship1.PrintShipInformation();
            Console.WriteLine("===========\n");
            
            Console.WriteLine("===========");
            RefrigeratedContainer newRefrigeratedContainer = new RefrigeratedContainer("Cheese", 7.2, 200, 3500, 100, 9000);
            try
            {
                ship1.ReplaceContainer(refrigeratedContainer, newRefrigeratedContainer);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            Console.WriteLine("Containers replaced successfully");
            Console.WriteLine("===========\n");
            
            Console.WriteLine("===========");
            Console.WriteLine("All information about the ship are:");
            ship1.PrintShipInformation();
            Console.WriteLine("===========\n");
            
            Console.WriteLine("===========");
            try
            {
                ship1.TransferContainerBetweenTwoShips(gasContainer, ship1, ship2);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            Console.WriteLine("After transferring gas container to ship2:\nShip Information:");
            ship2.PrintShipInformation();
            Console.WriteLine("===========\n");
            
            Console.WriteLine("===========");
            Console.WriteLine("Testing hazard notifications:");
            gasContainer.SendNotification();
            liquidContainer.SendNotification();
            Console.WriteLine("===========\n");
            
        }
    }
}