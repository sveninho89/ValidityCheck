using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValidityCheck
{
    public class Metoder
    {


        public Metoder() { }

        //metod för att ta bort århundrande i personnummer sträng där det existerar
        public string Change12to10(string personnummer)
        {
            string result;
            //kontrollerar om personnummer är 12tecken eller mer och raderar 2 första tecknen i strängen
            if (personnummer.Length > 11)
            {
                result = personnummer.Remove(0, 2);
            }
            else result = personnummer;

            return result;
        }

        //metod för att ta bort tecknen - och + i strängen.
        public string RemoveChars(string personnummer)
        {
            //ersätter + och minus med inget.
            personnummer = personnummer.Replace("-", "");
            personnummer = personnummer.Replace("+", "");

            return personnummer;
        }

        //Metod för att ta bort alla tecken utom siffror
        public string RemoveAllChars(string personnummer)
        {
            
            personnummer = Regex.Replace(personnummer, @"[^\d]", "");           

            return personnummer;
        }


        //Metod för att lösa Luhns algoritm och returnera den korrekta kontrollsiffran
        public string LuhnsAlgoritm(string persnr)
        {
            //metod för att dela upp alla enskilda siffror i personnummer till olika char.
            char siffra1 = persnr[0];
            char siffra2 = persnr[1];
            char siffra3 = persnr[2];
            char siffra4 = persnr[3];
            char siffra5 = persnr[4];
            char siffra6 = persnr[5];
            char siffra7 = persnr[6];
            char siffra8 = persnr[7];
            char siffra9 = persnr[8];
            //char siffra10 = persnr[9];

            //metod för att konvertera alla char till int
            int nummer1 = int.Parse(siffra1.ToString());
            int nummer2 = int.Parse(siffra2.ToString());
            int nummer3 = int.Parse(siffra3.ToString());
            int nummer4 = int.Parse(siffra4.ToString());
            int nummer5 = int.Parse(siffra5.ToString());
            int nummer6 = int.Parse(siffra6.ToString());
            int nummer7 = int.Parse(siffra7.ToString());
            int nummer8 = int.Parse(siffra8.ToString());
            int nummer9 = int.Parse(siffra9.ToString());
            //int nummer10 = int.Parse(siffra10.ToString());

            //2 x multiplikation av varannat tal enligt Luhns algoritm
            nummer1 = nummer1 * 2;
            nummer3 = nummer3 * 2;
            nummer5 = nummer5 * 2;
            nummer7 = nummer7 * 2;
            nummer9 = nummer9 * 2;

            //metod för att hantera siffror vars produkt efter multiplikation är 10 eller större
            if (nummer1 > 9)
            {
                string siffra = nummer1.ToString();
                char ett = siffra[0];
                char tva = siffra[1];
                int ettan = int.Parse(ett.ToString());
                int tvan = int.Parse(tva.ToString());
                nummer1 = ettan + tvan;
            }
            if (nummer3 > 9)
            {
                string siffra = nummer3.ToString();
                char ett = siffra[0];
                char tva = siffra[1];
                int ettan = int.Parse(ett.ToString());
                int tvan = int.Parse(tva.ToString());
                nummer3 = ettan + tvan;
            }
            if (nummer5 > 9)
            {
                string siffra = nummer5.ToString();
                char ett = siffra[0];
                char tva = siffra[1];
                int ettan = int.Parse(ett.ToString());
                int tvan = int.Parse(tva.ToString());
                nummer5 = ettan + tvan;
            }
            if (nummer7 > 9)
            {
                string siffra = nummer7.ToString();
                char ett = siffra[0];
                char tva = siffra[1];
                int ettan = int.Parse(ett.ToString());
                int tvan = int.Parse(tva.ToString());
                nummer7 = ettan + tvan;
            }
            if (nummer9 > 9)
            {
                string siffra = nummer9.ToString();
                char ett = siffra[0];
                char tva = siffra[1];
                int ettan = int.Parse(ett.ToString());
                int tvan = int.Parse(tva.ToString());
                nummer9 = ettan + tvan;
            }

            //metod för summera siffersumman enligt Luhns algoritm.
            int siffersumma = nummer1 + nummer2 + nummer3 + nummer4 + nummer5 + nummer6 + nummer7 + nummer8 + nummer9;

            //metod för att räkna ut kontrollsiffrans korrekta värde
            int kontrollsiffra = (10 - (siffersumma % 10)) % 10;
            persnr = kontrollsiffra.ToString();
            return persnr;
        }


        //metod för att dela upp personnummer-strängen och endast nypa den sista tionde siffran
        public string KontrolleraSiffra(string result)
        {
            char sistasiffra = result[9];
            result = sistasiffra.ToString();

            return result;
        }

        public string KontrolleraSamordning(string result)
        {
            char siffra1 = result[4];
            char siffra2 = result[5];
            string tal = siffra1.ToString() + siffra2.ToString();
            int nummer = int.Parse(tal);

            if (92 > nummer && nummer > 60)
            {
                result = "sant";
            }
            else { result = "falskt"; }

            return result;
        }

        public string KontrolleraOrgnr(string result)
        {
            char siffra1 = result[2];
            char siffra2 = result[3];
            string tal = siffra1.ToString() + siffra2.ToString();
            int nummer = int.Parse(tal);

            if(nummer > 19)
            {
                result = "sant";
            }else { result = "falskt"; }

            return result;
        }
    }
}
