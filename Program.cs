﻿using System;
using System.IO;
using System.Xml.Linq;

class Program
{
    static string[] lines;

    static void Main()
    {
        string filePath = "input.csv";
        lines = File.ReadAllLines(filePath);

        while (true)

        {
            Console.WriteLine("---------------"); 
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Display Characters");
            Console.WriteLine("2. Add Character");
            Console.WriteLine("3. Level Up Character");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            Console.WriteLine("---------------");

            switch (choice)
            {
                case "1":
                    DisplayAllCharacters(lines);
                    break;
                case "2":
                    AddCharacter(ref lines);
                    break;
                case "3":
                    LevelUpCharacter(lines);
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void DisplayAllCharacters(string[] lines)
    {
        // Skip the header row
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];

            string name;
            int commaIndex;

            // Check if the name is quoted
            if (line.StartsWith("\""))
            {
                // TODO: Find the closing quote and the comma right after it
                // TODO: Remove quotes from the name if present and parse the name
                // name = ...
                commaIndex = line.IndexOf("\",") + 1;
                name = line.Substring(1, commaIndex - 2);
            }
            else
            {
                // TODO: Name is not quoted, so store the name up to the first comma
                // name =
                commaIndex = line.IndexOf(",");
                name = line.Substring(0, commaIndex);
            }

            // TODO: Parse characterClass, level, hitPoints, and equipment
            // string characterClass = ...
            // int level = ...
            // int hitPoints = ...
            string[] fields = line.Substring(commaIndex + 1).Split(',');
            string characterClass = fields[0];
            int level = int.Parse(fields[1]);
            int hitPoints = int.Parse(fields[2]);

            // TODO: Parse equipment noting that it contains multiple items separated by '|'
            // string[] equipment = ...
            string[] equipment = fields[3].Split('|');

            // Display character information
            Console.WriteLine($"Name: {name}, Class: {characterClass}, Level: {level}, HP: {hitPoints}, Equipment: {string.Join(", ", equipment)}");
        }
    }

    static void AddCharacter(ref string[] lines)
    {
        // TODO: Implement logic to add a new character
        // Prompt for character details (name, class, level, hit points, equipment)
        // DO NOT just ask the user to enter a new line of CSV data or enter the pipe-separated equipment string
        // Append the new character to the lines array

        Console.Write("Enter character name: ");
        string name = Console.ReadLine();

        Console.Write("Enter character class: ");
        string characterClass = Console.ReadLine();

        Console.Write("Enter character level: ");
        int level = int.Parse(Console.ReadLine());

        Console.Write("Enter character hit points: ");
        int hitPoints = int.Parse(Console.ReadLine());

        var equipmentList = new List<string>();
        while (true)
        {
            Console.Write("Enter an equipment item (or 'done' to finish): ");
            string equipmentItem = Console.ReadLine();
            if (equipmentItem.ToLower() == "done")
            {
                break;
            }
            equipmentList.Add(equipmentItem);
        }
        string equipment = string.Join('|', equipmentList);

        string newCharacter = $"{name},{characterClass},{level},{hitPoints},{equipment}";
        Array.Resize(ref lines, lines.Length + 1);
        lines[^1] = newCharacter;

        string filePath = "input.csv";

        // Rewrite the file with the updated lines
        File.WriteAllLines(filePath, lines);
    }

    static void LevelUpCharacter(string[] lines)
    {
        Console.Write("Enter the name of the character to level up: ");
        string nameToLevelUp = Console.ReadLine();

        // Loop through characters to find the one to level up
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];

             
            // TODO: Check if the name matches the one to level up
            // Do not worry about case sensitivity at this point
            if (line.Contains(nameToLevelUp))
            {
                string name;
                int commaIndex;

                if (line.StartsWith("\""))
                {
                    commaIndex = line.IndexOf("\",") + 1;
                    name = line.Substring(1, commaIndex - 2);
                }
                else
                {
                    commaIndex = line.IndexOf(",");
                    name = line.Substring(0, commaIndex);
                }

                // TODO: Split the rest of the fields locating the level field
                // string[] fields = ...
                // int level = ...

                string[] fields = line.Substring(commaIndex + 1).Split(',');
                string characterClass = fields[0];
                int level = int.Parse(fields[1]);
                int hitPoints = int.Parse(fields[2]);
                string equipment = fields[3];



                // TODO: Level up the character
                // level++;
                // Console.WriteLine($"Character {name} leveled up to level {level}!");

                level++;
                Console.WriteLine($"Character {name} leveled up to level {level}!");


                // TODO: Update the line with the new level
                // lines[i] = ...
                lines[i] = $"{name},{characterClass},{level},{hitPoints},{equipment}";

                string filePath = "input.csv";

                // Rewrite the file with the updated lines
                File.WriteAllLines(filePath, lines);


                break;
            }
        }
    }
}