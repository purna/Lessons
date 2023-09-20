using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;
using static Cinemachine.CinemachineOrbitalTransposer;
using System.Drawing;


public enum RainbowColors
{
    DarkRed,
    Red,
    Magenta,
    Yellow,
    Green,
    Blue,
    Cyan
}


public class RainbowColorsExample : MonoBehaviour
{
    void Start()
    {


        // Declare the consoleColor Variable.
        ConsoleColor consoleColor = ConsoleColor.White;

        callHeading("Enum Colors 1");
        callF1(consoleColor);

        callHeading("Enum Colors 2");
        callF2(consoleColor);

        callHeading("String Colors");
        callF3(consoleColor);

        callHeading("IEnumerable Colors");
        callF4(consoleColor);


        static void callHeading(string heading)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("   ");
            Console.WriteLine(heading);
            Console.WriteLine("   ");

            Debug.Log(heading % Colorize.Gold % FontFormat.Bold);
        }

        static void callF1(ConsoleColor consoleColor)
        {
            // Get the values of the RainbowColors enum
            RainbowColors[] rainbowColors = (RainbowColors[])Enum.GetValues(typeof(RainbowColors));


            // Use a foreach loop to iterate through the enum values
            foreach (RainbowColors color in rainbowColors)
            {

                Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color.ToString(), true);
                Console.WriteLine(color);

                Debug.Log(color);
            }
        }

        static void callF2(ConsoleColor consoleColor)
        {
            // Get the values of the RainbowColors enum
            RainbowColors[] rainbowColors = (RainbowColors[])Enum.GetValues(typeof(RainbowColors));

            // Use a foreach loop to iterate through the enum values
            foreach (RainbowColors color in rainbowColors)
            {
                // Convert RainbowColors enum to ConsoleColor
                consoleColor = GetConsoleColor(color);
                Console.ForegroundColor = consoleColor;

                Console.WriteLine(color);

                Debug.Log(color);
            }
        }

        static void callF3( ConsoleColor consoleColor)
        {
            // Define the colors of the rainbow.
            string[] colors = { "DarkRed", "Red", "Magenta", "Yellow", "Green", "Blue", "Cyan" };

            // Iterate over the colors and print them to the console.
            for (int i = 0; i < colors.Length; i++)
            {
                // Convert string color to ConsoleColor
                if (Enum.TryParse<ConsoleColor>(colors[i], true, out consoleColor))
                {
                    Console.ForegroundColor = consoleColor;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White; // Default to white for unknown colors.
                }

                Console.WriteLine(colors[i]);

                Debug.Log(colors[i]);
            }
        }


        static void callF4(ConsoleColor consoleColor)
        {

            // Define the colors of the rainbow.
            string[] colors = { "DarkRed", "Red", "Magenta", "Yellow", "Green", "Blue", "Cyan" };

            // Get an IEnumerator from the string array
            IEnumerator<string> enumerator = ((IEnumerable<string>)colors).GetEnumerator();

            // Use the enumerator to iterate through the array
            while (enumerator.MoveNext())
            {
                string currentColor = enumerator.Current;

                if (Enum.TryParse<ConsoleColor>(currentColor, true, out consoleColor))
                {
                    Console.ForegroundColor = consoleColor;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White; // Default to white for unknown colors.
                }

                Console.WriteLine(currentColor);
                Debug.Log(currentColor);
            }

            // Dispose of the enumerator (optional but good practice)
            enumerator.Dispose();
        }


    }

    // Map RainbowColors enum values to ConsoleColor
    static ConsoleColor GetConsoleColor(RainbowColors color)
    {
        switch (color)
        {
            case RainbowColors.DarkRed:
                return ConsoleColor.DarkRed;
            case RainbowColors.Red:
                return ConsoleColor.Red;
            case RainbowColors.Magenta:
                return ConsoleColor.Magenta;
            case RainbowColors.Yellow:
                return ConsoleColor.Yellow;
            case RainbowColors.Green:
                return ConsoleColor.Green;
            case RainbowColors.Blue:
                return ConsoleColor.Blue;
            case RainbowColors.Cyan:
                return ConsoleColor.Cyan;
            default:
                return ConsoleColor.White; // Default to white for unknown colors.
        }


    }

}


public class ColorsEnumerator : IEnumerator<RainbowColors>
{
    private RainbowColors[] _colors;
    private int _index;

    public ColorsEnumerator(RainbowColors[] colors)
    {
        _colors = colors;
        _index = -1;
    }

    public bool MoveNext()
    {
        _index++;
        return _index < _colors.Length;
    }

    public RainbowColors Current => _colors[_index];

    object IEnumerator.Current => _colors[_index];

    public void Reset()
    {
        _index = -1;
    }

    public void Dispose()
    {
        // Dispose implementation (if needed)
    }
}