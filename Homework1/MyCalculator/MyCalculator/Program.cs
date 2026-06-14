using System;
using System.Collections.Generic;

class MyCalculator {
    static void Main() {

        List<double> numbers = new List<double>();

        int option;
        double number;
        double result;
        string answer;
        bool exit = false;

        while (!exit) {

            Console.Clear();

            Console.WriteLine("\n===== JOSE DI VALERIO 2025-1887 =====");

            Console.WriteLine("\n===== MY CALCULATOR =====");
            Console.WriteLine("\n1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Check Note (Approved or Failed)");
            Console.WriteLine("6. Exit");
            Console.Write("\nSelect an option: ");

            int.TryParse(Console.ReadLine(), out option);

            // INGRESOS DE LOS NUMEROS

            if (option >= 1 && option <= 4) {
                numbers.Clear();

                // PRIMER NUMERO
                Console.Write("\nEnter first number: ");

                while (!double.TryParse(Console.ReadLine(), out number))
                {
                    Console.Write("\nInvalid number! Please try again: ");
                }

                numbers.Add(number);

                // SEGUNDO NUMERO
                Console.Write("\nEnter second number: ");

                while (!double.TryParse(Console.ReadLine(), out number))
                {
                    Console.Write("\nInvalid number! Please try again: ");
                }

                numbers.Add(number);

                // SEGUIR AGREGANDO NUMEROS
                while (true)
                {
                    Console.Write("\nDo you want to add another number? (Y/N): ");
                    answer = Console.ReadLine().ToUpper();

                    while (answer != "Y" && answer != "N") {
                        Console.Write("\nInvalid option. Enter Y or N: ");
                        answer = Console.ReadLine().ToUpper();
                    }

                    if (answer == "N") {
                        break;
                    }

                    Console.Write("\nEnter another number: ");

                    while (!double.TryParse(Console.ReadLine(), out number)) {
                        Console.Write("\nInvalid number! Please try again: ");
                    }

                    numbers.Add(number);
                }
            }

            switch (option) {

                case 1:
                    Console.WriteLine("\nADDITION.");

                    result = 0;
                    
                    foreach (double num in numbers) {
                        result += num;
                    }

                    Console.WriteLine("The result is: " + result);
                    break;

                case 2:
                    Console.WriteLine("\nSUBTRACTION.");

                    result = numbers[0];

                    for (int i = 1; i < numbers.Count; i++) {
                        result -= numbers[i];
                    }

                    Console.WriteLine("The result is: " + result);
                    break;

                case 3:
                    Console.WriteLine("\nMULTIPLICATION.");

                    result = 1;

                    foreach (double num in numbers) {
                        result *= num;
                    }

                    Console.WriteLine("The result is: " + result);
                    break;

                case 4:
                    Console.WriteLine("\nDIVISION.");
                    bool error = false;
                    result = numbers[0];

                    for (int i = 1; i < numbers.Count; i++) {
                        
                        if (numbers[i] == 0) {
                            error = true;
                            break;
                        }

                        result /= numbers[i];
                    }

                    if (error) {
                        Console.WriteLine("ERROR! Division by 0.");
                    } else {
                        Console.WriteLine("The result is: " + result);
                    }

                    break;

                case 5:
                    Console.WriteLine("\nCHECK NOTE.");
                    
                    Console.Write("\nEnter note obtained: ");

                    while (!double.TryParse(Console.ReadLine(), out number) || number < 0 || number > 100) {
                        Console.Write("\nInvalid note! Please enter again: ");
                    }

                    if (number >= 70) {
                        Console.WriteLine("\nSubject APPROVED!");
                        Console.WriteLine("Note obtained: " + number);

                    } else {
                        Console.WriteLine("\nSubject FAILED!");
                        Console.WriteLine("Note obtained: " + number);
                    }
                    break;

                case 6:
                    exit = true;
                    Console.WriteLine("\nProgram completed.");
                    break;

                default:
                    Console.WriteLine("\nInvalid option.");
                    break;
            }

            if (!exit) {

                Console.WriteLine("\nDo you wish to perform another operation? Y/N: ");    
                string opcion2 = Console.ReadLine().ToUpper();

                while (opcion2 != "Y" && opcion2 != "N") {
                    Console.Write("\nInvalid option! Enter Y or N: ");
                    opcion2 = Console.ReadLine().ToUpper();
                }

                if (opcion2 == "N") {
                    exit = true;
                }
            }
        }

        Console.ReadKey();
    }
}