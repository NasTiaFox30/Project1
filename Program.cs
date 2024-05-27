//Projekt numer 1
//Anastasiia Bzova

using System.Xml;

Console.WriteLine("Rozwiązanie równania kwadratowego typu: ax^2+bx+c=0");
Console.WriteLine("Naciśnij cokolwiek dla kontynuacji");
Console.ReadKey();

                    //ZMIENNE

double aba, abb, abc; //argumenty

int abindex_of_xto2, abindex_of_x, abindex_of_0, abindex_of_równ; //indeksy

string abtemp1; //tymczasowe wyrażenie


for (short abi = 1; abi <= 3; abi++)  //wykona 3 razy program
{
    Console.Clear();
    Console.WriteLine("Wyraz numer " + abi);


                    //WYZNACZENIE ARGUMENTÓW:

    //SPOSÓB 1 (wyraz można wpisać w jednej linji):
    // początek sposobu 1

    string abwyrażenie;
    do
    {
        Console.WriteLine("Proszę napisać równanie w postaci:\nax^2+bx+c=0 lub bx+c=0\n");

        abwyrażenie = Console.ReadLine(); //Użytkownik podaje wyrażenie
        //formatowanie tekstu:
        abwyrażenie = abwyrażenie.ToUpper();
        abwyrażenie = abwyrażenie.Replace(" ", "");
    } 
    while (abwyrażenie == "");
    abindex_of_równ = abwyrażenie.IndexOf("=");
    abindex_of_0 = abwyrażenie.IndexOf("=0");
    if (abindex_of_równ != -1) { if (abindex_of_0 == -1) { abwyrażenie += '0'; } }
    else if (abindex_of_równ == -1) { abwyrażenie += "=0"; }

    Console.WriteLine("Twoje równanie: " + abwyrażenie);



    int ablength1; //zmienna dla konwertowania 

    abindex_of_xto2 = abwyrażenie.IndexOf("X^2"); //index of x^2

    if (abindex_of_xto2 != -1) //znaleziono x^2
    {
        //Console.WriteLine("\nWyrażenie jest kwadratowe. ");

        abtemp1 = abwyrażenie.Remove(0, abindex_of_xto2+3); //wyczyszcza (...x^2)


                    //Konwertowanie argumentów:
        ablength1 = abwyrażenie.Length; //długość wyrażenia
        int ablength2 = abtemp1.Length; //długość pozostawej części (oprócz x^2)

        //argument a
        ablength1 -= abindex_of_xto2;

        string abtemp_aba = abwyrażenie.Remove(abindex_of_xto2, ablength1);
        if (abtemp_aba == "-")
        { aba = -1; }
        else 
        { aba = double.TryParse(abtemp_aba, out double abFail1) ? abFail1 : 1; }


        //argument b
        abindex_of_x = abtemp1.IndexOf('X'); //index of x
        if (abindex_of_x != -1) //znaleziono x
        {
            ablength2 -= abindex_of_x;
            string abtemp_abb = abtemp1.Remove(abindex_of_x, ablength2);
            if (abtemp_abb == "-")
            { abb = -1; }
            else
            { abb = double.TryParse(abtemp_abb, out double abFail2) ? abFail2 : 1; }
        }
        else //jeśli nie znaleziono x
        { abb = 0; }


        //argument c
        string abliczba3 = abtemp1.Remove(0, ++abindex_of_x);
        abc = double.TryParse(abliczba3.Replace("=0", ""), out double abFail3) ? abFail3 : 0;

    }
    else //jeśli nie znaleziono x^2 lub a=0 
    {
        //Console.WriteLine("\nWyrażenie nie jest kwadratowe.");

        aba = 0;
        abindex_of_x = abwyrażenie.IndexOf('X');
        //Jeśli nie znaleziono X
        while (abindex_of_x == -1) 
        {
            Console.WriteLine("Nie ma x!");
            Console.WriteLine("Proszę napisać równanie w postaci: bx+c=0!");

            abwyrażenie = Console.ReadLine(); //Użytkownik podaje wyrażenie
            //formatowanie tekstu:                                         
            abwyrażenie = abwyrażenie.ToUpper(); 
            abwyrażenie = abwyrażenie.Replace(" ", "");
            abindex_of_0 = abwyrażenie.IndexOf("=0");
            if (abindex_of_0 == -1) { abwyrażenie += "=0"; }
            Console.WriteLine("Twoje równanie: " + abwyrażenie);


            abindex_of_x = abwyrażenie.IndexOf('X');
        }


                    //Konwertowanie argumentów:
        ablength1 = abwyrażenie.Length;
        ablength1 -= abindex_of_x;

        //argument b
        abb = double.TryParse(abwyrażenie.Remove(abindex_of_x, ablength1), out double abFail2) ? abFail2 : 1; 
        
        //argument c
        string liczba3 = abwyrażenie.Remove(0, ++abindex_of_x);
        abc = double.TryParse(liczba3.Replace("=0", ""), out double Fail3) ? Fail3 : 0; 
    }

    // koniec sposobu 1

    
    //SPOSÓB 2 (podanie każdego argumenta osobno):
    /*
    Console.WriteLine("Wpisz argument a:");
    aba = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("Argument b:");
    abb = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("Argument c:");
    abc = Convert.ToDouble(Console.ReadLine());
    */


                //Wyświetlenie argumentów:
    Console.WriteLine("Argument A: " + aba);
    Console.WriteLine("Argument B: " + abb);
    Console.WriteLine("Argument C: " + abc);
    Console.WriteLine("Naciśnij cokolwiek dla kontynuacji\n");
        Console.ReadKey();
  


                    //ROZWIĄZANIE:

    double abdelta; //delta (Δ)
    double abpierwiastek_1, abpierwiastek_2; //rozwiązki (pierwiastki) (x1;x2)

    //KWADRATOWE  RÓWNANIE:
    if (aba != 0) 
    {
        Console.WriteLine("Równania jest kwadratowe:");

        //Rozwiązek kwadratowego równania
        //Delta - Δ=b2−4ac
        abdelta = (abb * abb) - (4 * aba * abc);
        Console.WriteLine("Delta = " + abdelta);

        //Pierwiastki
        if (abdelta > 0) //Jeśli Δ>0, to są 2 rozwiązania
        {
            Console.WriteLine("Są 2 rozwiązania");
            //pierwiastek_1 oraz pierwiastek_2
            abpierwiastek_1 = ((-(abb) - (Math.Sqrt(abdelta))) / (2 * aba));
            abpierwiastek_2 = ((-(abb) + (Math.Sqrt(abdelta))) / (2 * aba));

            Console.WriteLine("Rozwiązki: x1 = {0}, x2 = {1}", abpierwiastek_1, abpierwiastek_2);
            Console.ReadKey();
        }
        else if (abdelta == 0) //Jeśli Δ=0, to jest 1 rozwiązanie 
        {
            Console.WriteLine("Jest 1 rozwiązanie");

            abpierwiastek_1 = -(abb) / (2 * aba);
            if (abpierwiastek_1 == -0) { abpierwiastek_1 = 0; }
            Console.WriteLine("Rozwiązek: x = " + abpierwiastek_1);
            Console.ReadKey();
        }
        else //Jeśli Δ<0, to równanie kwadratowe nie ma rozwiązań
        {
            Console.WriteLine("Równanie kwadratowe nie ma rozwiązań");
            Console.ReadKey();
        }
    }

    //lINIOWE RÓWNANIE:
    else if (aba == 0 && abb != 0)
    {
        //Rozwiązek liniowego równania
        abc = -(abc);
        abpierwiastek_1 = abc / abb;  //x = c/b
        if (abpierwiastek_1 == -0) { abpierwiastek_1 = 0; }

        Console.WriteLine("Rozwiązek: x = " + abpierwiastek_1);
        Console.ReadKey();
    }
    
}

Console.WriteLine("Koniec programu.");
Console.ReadLine();


