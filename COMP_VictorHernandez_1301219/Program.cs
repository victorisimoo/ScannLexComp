/*
   @author: Victor N. Hernandez
   @version: 1.0.0
 */
using COMP_VictorHernandez_1301219.Structure.Interpretation;
using System;
using System.Reflection;

namespace COMP_VictorHernandez_1301219 {
    /// <summary>
    /// Main method that allows the execution of the program.
    /// </summary>
    class Program {
        static void Main(string [] args ) {
            Parser parserobj = new Parser();

            Console.WriteLine(" --------- | EXPRESSION ANALYZER | ----------");
            Console.Write("> Enter the expression: ");
            string expression = Console.ReadLine();
            if (expression != null) {
                Console.WriteLine("> Result: " + parserobj.ParserExpression(expression));
            }else {
                Console.WriteLine("----- | Error: The expression is empty! | -----");
                Console.ReadLine();
            }


        }
    }
    
}
