/*
 * Dieses Programm ist ein kleines Wort-Ratespiel
 * 
 * Der Benutzer kann ein zu erratendes Wort eingeben,
 * worauf der Spieler das Wort durch Einsetzen der enthaltenen
 * Buchstaben erraten kann. Nach einigen Fehlversuchen 
 * ist die Raterunde beendet..
 * 
 * 
 * TODO:
 * 
 * - Die Eingabe des zu erratenden Wortes sollte geheim ( "*****..") erfolgen.
 * - Der erste und der letzte Buchstabe des geheimen Wortes sollte Angezeigt werden
 * - die Auswertung der Eingabe sollte modularisiert werden (z.B: Prozedur "auswerten(..)")
 * 
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangMan
{
    class Program
    {
        static void Main(string[] args)
        {

            do
            {
                // **********************************************************************
                // ************************* Programm Start *****************************
                // **********************************************************************

                Console.Clear();
                Console.Write("Gib das Lösungswort ein:\n\n> ");
                string eingabe = Console.ReadLine().ToUpper();
                Console.Clear();
                string loesungswort="";
                char[] loesung = new char[eingabe.Length];
                for (int i = 0; i < eingabe.Length; i++)
                    loesung[i] = '_';
                
                bool richtig = false;
                int fehler = 0;
                bool sieg = false;
                int cursorx, cursory;
                int pic_x = Console.CursorLeft;
                int pic_y = Console.CursorTop;
                              
                zeichne(0);
                loesungswort = string.Join(" ", loesung);
                int loesungswort_x = Console.CursorLeft;
                int loesungswort_y = Console.CursorTop;
                Console.Write("\n" + loesungswort + "\n");
                
                Console.Write("\nGib einen Buchstaben ein:\n\n>");

                while (fehler < 5)
                {
                    Console.Write(" ");
                    char zeichen = ' ';
                    try
                    {
                        zeichen = Convert.ToChar(Console.ReadKey().Key.ToString().ToUpper());
                    }
                    catch
                    {

                    }

                    for (int i = 0; i < eingabe.Length; i++)
                    {
                        if (zeichen == eingabe[i])
                        {
                            loesung[i] = zeichen;
                            richtig = true;
                        }
                    }

                    // ..schreibt das aktuelle Loesungswort an die vorgegebe Position..
                    cursorx = Console.CursorLeft;
                    cursory = Console.CursorTop;
                    Console.SetCursorPosition(loesungswort_x, loesungswort_y);
                    loesungswort = string.Join(" ", loesung);
                    Console.Write("\n" + loesungswort + "\n");
                    Console.SetCursorPosition(cursorx, cursory);

                    if (!richtig)
                    {
                        fehler++;
                        cursorx = Console.CursorLeft;
                        cursory = Console.CursorTop;
                        Console.SetCursorPosition(pic_x, pic_y);
                        zeichne(fehler);
                        Console.SetCursorPosition(cursorx, cursory);
                    }
                    richtig = false;

                    loesungswort = string.Join("", loesung);

                    if (loesungswort.Equals(eingabe))
                    {
                        sieg = true;
                        break;
                    }
                }

                if (sieg)
                {
                    Console.WriteLine("\n\n*********** GRATULIERE!!! **************");
                }
                else
                {
                    Console.Write("\n\n Schade.. \n\n");                                        
                }
                

                
                
                // **********************************************************************
                // ************************* Programm Ende ******************************
                // **********************************************************************

                Console.WriteLine("\nWiederholen? (ESC=Abbrechen)");                                
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);            
        }

        static void zeichne(int fehler)
        {
            Console.BackgroundColor = Console.ForegroundColor; //System.ConsoleColor.White;
            Console.ForegroundColor = System.ConsoleColor.Black;

            switch (fehler)
            {
                case 0:
                    Console.WriteLine(@"                    ");
                    Console.WriteLine(@"                    ");
                    Console.WriteLine(@"                    ");
                    Console.WriteLine(@"                    ");
                    Console.WriteLine(@"                    ");
                    Console.WriteLine(@"                    ");
                    Console.WriteLine(@"                    ");
                    Console.WriteLine(@"                    ");
                    Console.WriteLine(@"                    ");
                    break;
                case 1:
                    Console.WriteLine(@"                    ");
                    Console.WriteLine(@"                    ");
                    Console.WriteLine(@"                    ");
                    Console.WriteLine(@"                    ");
                    Console.WriteLine(@"                    ");
                    Console.WriteLine(@"                    ");
                    Console.WriteLine(@"                    ");
                    Console.WriteLine(@"     _________      ");
                    Console.WriteLine(@"    /         \     ");
                    break;
                case 2:
                    Console.WriteLine(@"                    ");
                    Console.WriteLine(@"                    ");
                    Console.WriteLine(@"         |          ");
                    Console.WriteLine(@"         |          ");
                    Console.WriteLine(@"         |          ");
                    Console.WriteLine(@"         |          ");
                    Console.WriteLine(@"         |          ");
                    Console.WriteLine(@"     ____|____      ");
                    Console.WriteLine(@"    /         \     ");
                    break;
                case 3:
                    Console.WriteLine(@"                    ");
                    Console.WriteLine(@"         _____      ");
                    Console.WriteLine(@"         |          ");
                    Console.WriteLine(@"         |          ");
                    Console.WriteLine(@"         |          ");
                    Console.WriteLine(@"         |          ");
                    Console.WriteLine(@"         |          ");
                    Console.WriteLine(@"     ____|____      ");
                    Console.WriteLine(@"    /         \     ");
                    break;
                case 4:
                    Console.WriteLine(@"                    ");
                    Console.WriteLine(@"         _____      ");
                    Console.WriteLine(@"         |   |      ");
                    Console.WriteLine(@"         |          ");
                    Console.WriteLine(@"         |          ");
                    Console.WriteLine(@"         |          ");
                    Console.WriteLine(@"         |          ");
                    Console.WriteLine(@"     ____|____      ");
                    Console.WriteLine(@"    /         \     ");
                    break;
                case 5:
                    Console.WriteLine(@"                    ");
                    Console.WriteLine(@"         _____      ");
                    Console.WriteLine(@"         |   |      ");
                    Console.WriteLine("         |  (\")    ");
                    Console.WriteLine(@"         |  /|\     ");
                    Console.WriteLine(@"         |   |      ");
                    Console.WriteLine(@"         |  / \     ");
                    Console.WriteLine(@"     ____|____      ");
                    Console.WriteLine(@"    /         \     ");
                    break;
            }
            Console.ForegroundColor = Console.BackgroundColor; //System.ConsoleColor.White;
            Console.BackgroundColor = System.ConsoleColor.Black;

        }

    }
}
