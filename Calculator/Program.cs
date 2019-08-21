using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{

    enum ArgumentType
    {
        String,
        Number,
        DateTime,
        TimeSpan
    }

    enum OperatorType
    {
        Unknown,
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Calculator App");
           
            string argument1 = GetArgument("First argument: ");
            string argument2 = GetArgument("Second argument: ");

            ArgumentType argument1Type = GetArgumentType(argument1);
            ArgumentType argument2Type = GetArgumentType(argument2);


            //Console.Write("{0}:{1}", argument1Type, argument2Type);

            OperatorType operatorType = GetOperatorType("What is your operator: ");

            if ((argument1Type == ArgumentType.Number) && (argument2Type == ArgumentType.Number))
            {
                double number1 = double.Parse(argument1);
                double number2 = double.Parse(argument2);
                if (operatorType == OperatorType.Addition)
                {
                    Console.Write(number1 + number2);
                } else if (operatorType == OperatorType.Subtraction)
                {
                    Console.Write(number1 - number2);
                } else if (operatorType == OperatorType.Multiplication)
                {
                    Console.Write(number1 * number2);
                } else
                {
                    Console.Write(number1 / number2);
                }
            } else if((argument1Type == ArgumentType.String && argument2Type == ArgumentType.String) && (operatorType == OperatorType.Addition || operatorType == OperatorType.Subtraction))
            {
                if(operatorType == OperatorType.Addition)
                {
                    Console.Write(argument1 + argument2);
                } else
                {
                    char[] letters = argument1.ToCharArray();
                    var letterList = new List<char>(letters);

                    for(int i = 0; i < letters.Length; ++i)
                    {
                        if(argument2.Contains(letters[i]))
                        {
                            letterList.Remove(letters[i]);
                        }
                    }

                    letters = letterList.ToArray();
                    string result = new string(letters);

                    Console.Write(result);
                }
            } else if((argument1Type == ArgumentType.DateTime && argument2Type == ArgumentType.DateTime) && operatorType == OperatorType.Subtraction)  
            {
                DateTimeOffset date1 = DateTimeOffset.Parse(argument1);
                DateTimeOffset date2 = DateTimeOffset.Parse(argument2);

                Console.Write(date1 - date2);
            } else if((argument1Type == ArgumentType.DateTime && argument2Type == ArgumentType.TimeSpan) && (operatorType == OperatorType.Subtraction || operatorType == OperatorType.Addition))
            {
                DateTimeOffset date1 = DateTimeOffset.Parse(argument1);
                TimeSpan time = TimeSpan.Parse(argument2); 

                if(operatorType == OperatorType.Addition)
                {
                    Console.Write(date1 + time);
                } else
                {
                    Console.Write(date1 - time);
                }
            } else if ((argument1Type == ArgumentType.String && argument2Type == ArgumentType.Number) && operatorType == OperatorType.Multiplication)
            {
                int multiplier = int.Parse(argument2);
                string result = "";

                for(int i = 0; i < multiplier; i++)
                {
                    result += argument1;
                }

                Console.Write(result);
            } else
            {
                Console.Write("Sorry this is not supported.");
            }
           // Console.Write(operatorType);
            Console.ReadKey();


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        static string GetArgument(string message)
        {
            string input = "";

            while(String.IsNullOrEmpty(input))
            {
                Console.Write(message);
                input = Console.ReadLine();
            } 

            return input;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="argument"></param>
        /// <returns></returns>
        static ArgumentType GetArgumentType(string argument)
        {
            ArgumentType argumentType = ArgumentType.String;
            double num;
            DateTimeOffset time;
            TimeSpan span;

            if(double.TryParse(argument, out num))
            {
                argumentType = ArgumentType.Number;
            } else if(DateTimeOffset.TryParse(argument, out time))
            {
                argumentType = ArgumentType.DateTime;
            } else if(TimeSpan.TryParse(argument, out span))
            {
                argumentType = ArgumentType.TimeSpan;
            } 

            return argumentType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static OperatorType GetOperatorType(string message)
        {
            OperatorType operation = OperatorType.Unknown;
            
            string input = "";

            Console.Write(message);
         
            input = Console.ReadLine();

            while(true)
            {
                if (input == "+")
                {
                    operation = OperatorType.Addition;
                    break;
                }
                else if (input == "-")
                {
                    operation = OperatorType.Subtraction;
                    break;
                }
                else if (input == "*")
                {
                    operation = OperatorType.Multiplication;
                    break;
                }
                else if (input == "/")
                {
                    operation = OperatorType.Division;
                    break;
                }
                else
                {
                    Console.Write("This operation is not valid, try again: ");
                    input = Console.ReadLine();
                }
            }
            
            

            return operation;
        }
    }

}
