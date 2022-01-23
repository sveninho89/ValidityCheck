using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;


namespace ValidityCheck
{

    //Applikation skapad av Johan Svensson

    public class Program
    {


        static void Main(string[] args)
        {
            //metod för att nå klassen Properties
            Properties pr = new Properties();



            //instruktionstext till användare
            Console.WriteLine("ValidityCheck by Johan Svensson");
            Console.WriteLine("Detta programkontrollerar om ett orgnr/samordningsnr/personnr är korrekt.");
            Console.WriteLine("Skriv in nummer du vill kontrollera: ");



            //Skapar en metod för att skriva till loggningsfil, lagrar även historik
            StreamWriter wr = new StreamWriter(Loggningsfil.FELAKTIGTNRFIL, true);

            

            //läser av inmatat personnummer och lagrar i en sträng.
            pr.personnummer = Console.ReadLine();

            //kontrollerar att tillräckligt många tecken som krävs är ifyllda
            while(pr.personnummer.Length < 10)
            {
                Console.WriteLine("För kort nummer");
                Console.WriteLine("Vänligen fyll i nummer igen");
                pr.personnummer = Console.ReadLine();
            }

            //lagrar inmatat personnummer som ett original i denna sträng
            string inmatatpersonnr = pr.personnummer;





            Metoder metoder = new Metoder();
            //metod för att ta bort århundrande
            pr.personnummer = metoder.Change12to10(pr.personnummer);

            //metod för att ta bort + och - tecken i sträng
           // pr.personnummer = metoder.RemoveChars(pr.personnummer);

            //metod för att rensa alla tecken förutom siffror (denna metod trumfar RemoveChars-metoden)
            pr.personnummer = metoder.RemoveAllChars(pr.personnummer);
         


            //metod för Luhns algoritm.
            pr.kontrollsiffra = metoder.LuhnsAlgoritm(pr.personnummer);

            //metod för att få fram sista siffran i personnummer som användare matat in.
            pr.sistasiffra = metoder.KontrolleraSiffra(pr.personnummer);
            





            //metod som kontrollerar ifall det är ett korrekt nummer
            if(pr.sistasiffra == pr.kontrollsiffra)
            {
                

                //metod för att kontrollera om nummer är samordningsnummer
                string kontrollsam = metoder.KontrolleraSamordning(pr.personnummer);
                //metod för att kotnrollera om nummer är orgnr
                string kontrollorg = metoder.KontrolleraOrgnr(pr.personnummer);

                //metod ifall det är samordningsnummer som matats in
                if (kontrollsam == "sant") {
                    Console.Clear();
                    Console.WriteLine("Samordningsnr: "+inmatatpersonnr+" är godkänt");
                    Console.WriteLine("");
                    Console.WriteLine("Approved by ValidityCheck");
                }
                
                //metod ifall orgnr matats in
               else if(kontrollorg == "sant")
                {
                    Console.Clear();
                    Console.WriteLine("Orgnr: "+inmatatpersonnr+ " är godkänt");
                    Console.WriteLine("");
                    Console.WriteLine("Approved by ValidityCheck");
                }

                //metod ifall personnummer matats in
                else {
                    Console.Clear();
                    Console.WriteLine("Personummer: "+inmatatpersonnr+" är godkänt.");
                    Console.WriteLine("");
                    Console.WriteLine("Approved by ValidityCheck");
                }

                ;

            }

            //else-sats ifall nummer inte är korrekt enligt Luhms algoritm
            else
            {
                Console.WriteLine("Nummer: "+ inmatatpersonnr+" är EJ godkänt");
                Console.WriteLine("Loggfil över ärendet har skapats och loggat felaktigt nummer");

                //skriver till loggfil och datum-märker ärendet
                wr.WriteLine(DateTime.Now.ToString("yyy-MM-dd") + ", nummer: " +inmatatpersonnr);
            }


            //stänger writer
            wr.Close();




        


    }
    }
}
