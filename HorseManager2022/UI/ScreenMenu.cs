﻿using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseManager2022.UI
{
    internal class ScreenMenu
    {
        // Properties
        public string title { get; set; }
        public List<Option> options;
        public ScreenMenu? previousScreen;
        public int selectedPosition { get; set; }

        public bool isInitialScreen
        {
            get
            {
                return this.previousScreen == null;
            }
        }

        
        // Constructor
        public ScreenMenu(string title, ScreenMenu? previousScreen = null)
        {
            this.title = title;
            options = new List<Option>();
            this.previousScreen = previousScreen;
            this.selectedPosition = 0;
        }


        public void AddOption(Option option)
        {
            options.Add(option);
        }


        public void Show()
        {
            // Variables
            Option? selectedOption = null;
            string title = this.title;
            string mark = "";
            title = title.PadLeft((38 / 2) + (title.Length / 2)).PadRight(37);

            // Wait for option
            do
            {
                // Display Title
                Console.Clear();
                Console.WriteLine("+---------------------------------------+");
                Console.WriteLine("| " + title + " |");
                Console.WriteLine("+---------------------------------------+");
                Console.WriteLine("|                                       |");

                // Display Options
                for (int i = 0; i < this.options.Count; i++)
                {
                    string text = this.options[i].text.PadRight(32, ' ');
                    mark = (i == this.selectedPosition) ? "X" : " ";
                    Console.WriteLine("| [" + mark + "] - " + text + "|");
                    Console.WriteLine("|                                       |");
                }

                // Display Back / Exit Option
                mark = (this.options.Count == this.selectedPosition) ? "X" : " ";
                if (this.isInitialScreen)
                    Console.WriteLine("| [" + mark + "] - Exit                            |");
                else
                    Console.WriteLine("| [" + mark + "] - Back                            |");
        
                // Close Menu
                Console.WriteLine("|                                       |");
                Console.WriteLine("+---------------------------------------+");

                // Get option
                selectedOption = SelectOption();

            } while (selectedOption == null);

            selectedOption.onEnter(this);

        }
        

        // Verify option selected is available
        public Option? SelectOption()
        {
            // Read key
            Console.Write("Select an option: ");
            ConsoleKeyInfo selectedOption = Console.ReadKey();

            // Check for up / down / enter keys
            switch (selectedOption.Key)
            {
                case ConsoleKey.UpArrow:
                    if (this.selectedPosition > 0)
                        this.selectedPosition--;
                    break;
                case ConsoleKey.DownArrow:
                    if (this.selectedPosition < this.options.Count)
                        this.selectedPosition++;
                    break;
                case ConsoleKey.Enter:
                    if (this.selectedPosition == this.options.Count) {
                        return Option.GetBackOption();
                    }
                    else
                        return this.options[this.selectedPosition];
                default:
                    break;
            }
            
            return null;
        }
        

    }
}
