using System;
using System.Collections.Generic;
using System.Net.WebSockets;

class Program
{
    class Todo
    {
        public string Aufgabe { get; set; }
        public string Beschreibung { get; set; }
    }

    static List<Todo> aufgabenliste = new List<Todo>();

    static void Main(string[] args)
    {
        bool weiterhinAusführen = true;

        while (weiterhinAusführen)
        {
            Console.WriteLine("Hauptmenü:");
            Console.WriteLine("1. Aufgabe/Beschreibung hinzufügen");
            Console.WriteLine("2. Aufgabe bearbeiten");
            Console.WriteLine("3. Aufgabenliste anzeigen");
            Console.WriteLine("4. Aufgabe löschen");
            Console.WriteLine("5. Programm beenden");
            Console.Write("Wählen Sie eine Option: ");

            string eingabe = Console.ReadLine();

            switch (eingabe)
            {
                case "1":
                    AufgabeAnlegen();
                    break;
                case "2":
                    AufgabeBearbeiten();
                    break;
                case "3":
                    if(aufgabenliste.Count == 0)
                    {
                    Console.WriteLine("Die Liste ist leer.");
                    break;
                    } else { 
                    AlleAufgabenAnzeigen();
                    break;
                    }
                case "4":
                    AufgabeLöschen();
                    break;
                case "5":
                    weiterhinAusführen = false;
                    break;
                default:
                    Console.WriteLine("Ungültige Eingabe. Bitte wählen Sie eine Option aus dem Menü.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void AufgabeAnlegen()
    {
        Console.WriteLine("Neue Aufgabe anlegen:");

        Todo NeueAufgabe = new Todo();

        Console.Write("Aufgabe: ");
        NeueAufgabe.Aufgabe = Console.ReadLine();
        Console.WriteLine("Beschreibung:");
        NeueAufgabe.Beschreibung = Console.ReadLine();

        aufgabenliste.Add(NeueAufgabe);

        Console.WriteLine("Aufgabe erfolgreich angelegt.");
    }

 
    static void AufgabeBearbeiten()
    {
        Console.WriteLine("Geben Sie die Position der zu bearbeitenden Aufgabe ein:");
        int IDbearbeiten;
        if (int.TryParse(Console.ReadLine(), out IDbearbeiten) && IDbearbeiten >= 0 && IDbearbeiten < aufgabenliste.Count)
        {
            Console.Write("Neuer Aufgabentext: ");
            aufgabenliste[IDbearbeiten].Aufgabe = Console.ReadLine();
            Console.WriteLine("Aufgabe erfolgreich bearbeitet.");
            Console.Write("Neuer Beschreibungstext: ");
            aufgabenliste[IDbearbeiten].Beschreibung = Console.ReadLine();
            Console.WriteLine("Beschreibung erfolgreich bearbeitet.");
        }
        else
        {
            Console.WriteLine("Ungültige ID. Die Aufgabe konnte nicht gefunden werden.");
        }
    }

    static void AlleAufgabenAnzeigen()
    {
        Console.WriteLine("Alle Einträge:");

        for (int i = 0; i < aufgabenliste.Count; i++)
        {
            Console.WriteLine($"Aufgabe {i}: {aufgabenliste[i].Aufgabe}");
            Console.WriteLine($"Beschreibung {i}: {aufgabenliste[i].Beschreibung}");
        }
    }

    static void AufgabeLöschen()
    {
        Console.WriteLine("Geben Sie die Position der zu löschenden Aufgabe ein:");
        int IDlöschen;
        if (int.TryParse(Console.ReadLine(), out IDlöschen) && IDlöschen >= 0 && IDlöschen < aufgabenliste.Count)
        {
            aufgabenliste.RemoveAt(IDlöschen);
            Console.WriteLine("Aufgabe erfolgreich gelöscht.");
        }
        else
        {
            Console.WriteLine("Ungültige ID. Die Aufgabe konnte nicht gefunden werden.");
        }
    }
}
