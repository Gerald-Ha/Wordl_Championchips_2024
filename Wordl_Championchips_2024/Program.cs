using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    private static void Main()
    {
        // Text titel
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\t\t\t\t\tWillkommen bei Wordl Meme Championchips 2024");
        Console.ResetColor();
        Console.WriteLine("\n\n\n\n");

        string[] words = { "hallo", "hauch", "opfer", "riese", "kugel", "lanze", "komet" }; // Random wörter die ausgewählt werden

        Random random = new Random();
        string targetWord = words[random.Next(words.Length)]; // wähle ein zufälliges Wort aus der Liste
        char[] maskedWord = new char[targetWord.Length];
        List<string> previousAttempts = new List<string>(); // Erzeuge eine Liste zur Speicherung vorheriger Versuche
        int attemptsLeft = 6; // die anzahl der versuche

        HashSet<int> unmaskedIndices = new HashSet<int>(); // erzeuge ein HashSet damit keine duplikate vorkommen
        while (unmaskedIndices.Count < 3) // 3 von 5 wörtern werden angezeigt
        {
            unmaskedIndices.Add(random.Next(targetWord.Length)); // random text wird eingefügt
        }

        for (int i = 0; i < targetWord.Length; i++)
        {
            maskedWord[i] = unmaskedIndices.Contains(i) ? targetWord[i] : '_'; // beliebiges symbol/wort/zahl für maskierung
        }
        //--------------------------------------------------------------
        while (attemptsLeft > 0) // while schleife
        {
            Console.WriteLine("Zu erratendes Wort: " + new string(maskedWord)); // Gibt das maskierte Wort aus
            Console.WriteLine($"Versuch {7 - attemptsLeft} von 6:"); // anzahl der versuche die übrig bleiben
            string guess = Console.ReadLine().ToLower();

            if (guess == targetWord) // überprüft die eingabe
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Herzlichen Glückwunsch! Du hast das Wort erraten!"); // gib eine Erfolgsmeldung aus
                Console.ResetColor();
                break; // beendet die Schleife
            }
            //--------------------------------------------------------------
            previousAttempts.Add(guess); // fügt die eingabe dem zähler hinzu

            for (int i = 0; i < targetWord.Length; i++)
            {
                if (guess.Contains(targetWord[i])) // zeigt an wenn der buchstabe im zielwort enthalten ist
                {
                    if (guess.IndexOf(targetWord[i]) == i) // zeigt an, falls der geratene Buchstabe an der richtigen Stelle im Wort steht
                    {
                        maskedWord[i] = targetWord[i]; // entmaskiert den Buchstaben im maskierten Wort
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(targetWord[i]); // gibt den Buchstaben aus
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(maskedWord[i]); // hier war der fehler
                        Console.ResetColor();
                    }
                }
                else // falls der Buchstabe nicht enthalten ist
                {
                    Console.Write(maskedWord[i]); // gib den maskierten Buchstaben aus
                }
            }

            Console.WriteLine();

            attemptsLeft--; // verringert die Anzahl der verbleibenden Versuche um 1

            if (attemptsLeft == 1) // Falls nur noch ein Versuch übrig ist
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Das ist dein letzter Versuch!");
                Console.ResetColor();
            }
        }

        if (attemptsLeft == 0) // falls keine Versuche mehr übrig sind
        {
            Console.WriteLine($"Das gesuchte Wort war: {targetWord}");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Das Spiel ist vorbei. Deine Intelligenz gleicht dem eines 13-Jährigen, bitte bilde dich weiter fort!");
            Console.ResetColor();
        }

        Console.WriteLine("Möchtest du nochmal spielen? (J)a / (N)ein");
        ConsoleKeyInfo keyInfo = Console.ReadKey(); // wartet auf die eingabe der taste

        if (keyInfo.Key == ConsoleKey.J) // if schleifen auf J und N gesetzt
        {
            Console.Clear();
            Main();
        }
        else if (keyInfo.Key == ConsoleKey.N)
        {
            Console.WriteLine();
            Console.WriteLine("Auf Wiedersehen!");
        }
        else // Andernfalls
        {
            Console.WriteLine();
            Console.WriteLine("Ungültige Eingabe. Das Spiel wird beendet.");
        }
    }
}