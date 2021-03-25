using System;
using System.Collections.Generic;
using System.IO;

namespace SMSproggy
{
    class Beolvas
    {
        public int incora;
        public int incperc;
        public int teloszam;
        public string szoveg;
        public Beolvas(string szam, string uzi)
        {
            string[] bonto = szam.Split();
            incora = Convert.ToInt32(bonto[0]);
            incperc = Convert.ToInt32(bonto[1]);
            teloszam = Convert.ToInt32(bonto[2]);
            szoveg = uzi;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //1. feladat
            StreamReader be = new StreamReader("sms.txt");
            List<Beolvas> lista = new List<Beolvas>();
            int uzszam = Convert.ToInt32(be.ReadLine());
            for (int i = 0; i<uzszam; i++)
            {
                lista.Add(new Beolvas(be.ReadLine(), be.ReadLine()));
            }
            //2. feladat
            Console.WriteLine($"2. feladat: Utolsó üzenet előtti üzenet: {lista[lista.Count-2].szoveg}");
            //3. feladat
            int legrovidebb = 100;
            int leghosszabb = 0;
            foreach(var i in lista)
            {
                if(i.szoveg.Length <= legrovidebb)
                {
                    legrovidebb = i.szoveg.Length;
                }
                if (i.szoveg.Length > leghosszabb)
                {
                    leghosszabb = i.szoveg.Length;
                }
            }
            Console.WriteLine("3. feladat:");
            foreach(var i in lista)
            {
                if(i.szoveg.Length == leghosszabb)
                {
                    Console.WriteLine($"Leghosszabb üzenet adatai: {i.incora} óra {i.incperc} perckor {i.teloszam} telefonszámról érkezett '{i.szoveg}' üzenet.");
                }
                if (i.szoveg.Length == legrovidebb)
                {
                    Console.WriteLine($"Legrövidebb üzenet adatai: {i.incora} óra {i.incperc} perckor {i.teloszam} telefonszámról érkezett '{i.szoveg}' üzenet.");
                }
            }
            //4. feladat
            int egy = 0;
            int ketto = 0;
            int harom = 0;
            int negy = 0;
            int ot = 0;
            foreach(var i in lista)
            {
                if (i.szoveg.Length < 21)
                {
                    egy++;
                }
                if(i.szoveg.Length<41 && i.szoveg.Length > 20)
                {
                    ketto++;
                }
                if (i.szoveg.Length < 61 && i.szoveg.Length > 40)
                {
                    harom++;
                }
                if (i.szoveg.Length < 81 && i.szoveg.Length > 60)
                {
                    negy++;
                }
                if (i.szoveg.Length < 101 && i.szoveg.Length > 80)
                {
                    ot++;
                }
            }
            Console.WriteLine("4. feladat: ");
            Console.WriteLine($"1-20 karakterig: {egy}");
            Console.WriteLine($"21-40 karakterig: {ketto}");
            Console.WriteLine($"41-60 karakterig: {harom}");
            Console.WriteLine($"61-80 karakterig: {negy}");
            Console.WriteLine($"81-100 karakterig: {ot}");
            //5. feladat
            
            //6. feladat
            int elozoora = 0;
            int elozoperc = 0;
            int orakulonbseg;
            int perckulonbseg;
            int orakulonbsegmax = 0;
            int perckulonbsegmax = 0;
            int seged = 1;
            foreach(var i in lista)
            {
                if(i.teloszam == 123456789)
                {
                    elozoora = i.incora;
                    elozoperc = i.incperc;
                    break;
                }
            }
            foreach (var i in lista)
            {
                if(i.teloszam == 123456789)
                {
                    orakulonbseg = i.incora - elozoora;
                    perckulonbseg = i.incperc - elozoperc;
                    if(orakulonbseg > orakulonbsegmax)
                    {
                        orakulonbsegmax = orakulonbseg;
                    }
                    if (perckulonbseg > perckulonbsegmax)
                    {
                        perckulonbsegmax = perckulonbseg;
                    }
                    elozoora = i.incora;
                    elozoperc = i.incperc;
                    seged++;
                }
            }
            if (seged <= 1)
            {
                Console.WriteLine("Nincs elegendő üzenet.");
            }
            else {Console.WriteLine($"6. feladat: Leghosszabb idő két üzenet között: {orakulonbsegmax} óra {perckulonbsegmax} perc."); }
            //7. feladat
            Console.WriteLine("7. feladat: Kérem írja be az SMS adatait(beérkezés órája, beérkezés perce, telefonszám[9 számjegy]). Például: 9 11 123456789");
            string hetesseged = Console.ReadLine();
            Console.WriteLine("Most kérem adja meg az üzenetet: ");
            string hetesuzi = Console.ReadLine();
            lista.Add(new Beolvas(hetesseged, hetesuzi));
            Console.WriteLine(lista[lista.Count - 1].szoveg);
        }
    }
}
