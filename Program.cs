using System;
using System.Linq;

namespace WordsA
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new Words())
            {
                bool decisionA = true;
                bool decisionStart = true;
                var datadzis=DateTime.Now;
                Console.WriteLine("Cześć Pokurcze! Jak tam? Zaczynamy?");
                Console.ReadLine();
                while (decisionStart == true)
                {

                    Console.WriteLine("Wybierz rodzaj operacji:");
                    Console.WriteLine("1. Jeśli chcesz wprowadzać nowe słowa wpisz: nowe");
                    Console.WriteLine("2. Jeśli chcesz zobaczyć swój słownik wprowadz: slowa");
                    Console.WriteLine("3. Jeśli chces się sprawdzić wpisz: test");
                    Console.WriteLine("4. Jeśli chcesz skasować jakąś pozycję ze słownika, poproś kogoś kto się na tym zna!:)");
                    Console.WriteLine("5. Jeśli chcesz zakończyć wpisz: end");
                    string decisionC = Console.ReadLine();

                    if (decisionC == "nowe")
                    {
                        decisionA = true;
                        while (decisionA == true)
                        {
                            Console.WriteLine("Wpisz angielskie słowo");
                            string slowoA = Console.ReadLine();
                            Console.WriteLine("Podaj polskie tłumaczenie");
                            string slowoB = Console.ReadLine();
                            db.Slownik.Add(
                                new Tabela
                                {
                                    WordEng = slowoA,
                                    WordPol = slowoB
                                }

                            );
                            db.SaveChanges();
                            Console.WriteLine("Chcesz wprowadzić kolejne słowo? t/n");
                            string decisionB = Console.ReadLine();
                            if (decisionB == "n")
                            {
                                decisionA = false;
                            }
                        }
                    }
                    if (decisionC == "slowa")
                    {
                        Colorgreen();
                        Console.WriteLine("======================================");
                        Colorgrey();
                        Console.WriteLine("Slownik Franka");
                        var slowa = db.Slownik.ToList();
                        foreach (var n in slowa)
                        {
                            Console.WriteLine($"{n.WordEng}--{n.WordPol}");
                        }
                        Colorgreen();
                        Console.WriteLine("=======================================");
                        Colorgrey();
                    }
                    if (decisionC == "kas")
                    {
                        bool decisionKas = true;
                        while (decisionKas == true)
                        {
                            Console.WriteLine("Podaj Id słowa które chcesz skasować");
                            string slowoKas = Console.ReadLine();
                            int slowoKasInt = Convert.ToInt32(slowoKas);
                            var singleWord = db.Slownik
                            .Single(b => b.TabelaId == slowoKasInt);
                            Console.WriteLine($"Uswam słowo {singleWord.WordEng}");
                            db.Slownik.Remove(singleWord);
                            db.SaveChanges();
                            Console.WriteLine("Chcesz usunąć kolejne słowo? t/n");
                            string decisionD = Console.ReadLine();
                            if (decisionD == "n")
                            {
                                decisionKas = false;

                            }

                        }
                    }
                    if (decisionC == "test")
                    {
                        int dobrzeA = 0;
                        Console.WriteLine("Podaj liczbę przykładów.");
                        string examples = Console.ReadLine();
                        int examplesInt = Convert.ToInt32(examples);
                        for (int n = 1; n <= examplesInt; n++)
                        {
                            var testA = db.Slownik.ToList();
                            var rand = new Random();
                            int testnum = rand.Next(testA.Count);
                            //int testnum=rand.Next(4);
                            Console.WriteLine(testnum);
                            var singleTest = testA.ElementAt(testnum);
                            //var singleTest = db.Slownik
                            //.Single(b => b.TabelaId == testnum);
                            Console.Write(singleTest.WordPol + "-");
                            string answer = Console.ReadLine();
                            if (answer == singleTest.WordEng)
                            {
                                Colorgreen();
                                Console.WriteLine("Brawo! Prawidłowa odpowiedź.");
                                Colorgrey();
                                dobrzeA++;


                            }
                            else
                            {
                                Colorred();
                                Console.WriteLine($"Nistety nieprawdiłowa odpowiedź. Poprawne tłumaczenie to: {singleTest.WordEng}");
                                Colorgrey();
                            }


                        }
                        db.Efekty.Add(
                                new Grade
                                {
                                    Good_Answers = dobrzeA,
                                    NumberOf = examplesInt,
                                    Ocena=datadzis.ToString()
                                }
                                         );
                        db.SaveChanges();
                    }
                    if (decisionC == "end")
                    {
                        decisionStart = false;
                    }

                }
            }
            static void Colorgreen()
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            static void Colorgrey()
            {
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            static void Colorred()
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
        }
    }
}

