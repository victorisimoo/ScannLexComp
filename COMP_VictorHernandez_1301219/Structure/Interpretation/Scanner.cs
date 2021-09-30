/*
   @author: Victor N. Hernandez
   @version: 1.0.0
 */
using COMP_VictorHernandez_1301219.Structure.TokenConstruction;
using System;

namespace COMP_VictorHernandez_1301219.Structure.Interpretation {

    /// <summary>
    /// Method for scanning the tokens entered
    /// </summary>
    public class Scanner {

        private string regexp = "";
        private int index = 0;

        /// <summary>
        ///  Constructor of the class, which initializes the expression
        /// </summary>
        /// <param name="regexp"></param>
        public Scanner(string regexp) {
            this.regexp = regexp + (char)TokenType.EOF;
            index = 0;
        }

        /// <summary>
        /// Method for token construction
        /// </summary>
        public Token GetToken() {
            
            Token result = new Token() { Value = (char)0 };
            bool tokenFound = false;

            while (!tokenFound) {
                while (string.IsNullOrWhiteSpace(new string(regexp[index], 1))) {
                    index = index + 1;
                }

                char peek = regexp[index];

                switch (peek) {
                    case (char)TokenType.Plus:
                    case (char)TokenType.Minus:
                    case (char)TokenType.Multipli:
                    case (char)TokenType.Division:
                    case (char)TokenType.LParen:
                    case (char)TokenType.RParen:
                    case (char)TokenType.EOF:
                        tokenFound = true;
                        result.Tag = (TokenType)peek;
                        break;
                    case (char)48:
                    case (char)49:
                    case (char)50:
                    case (char)51:
                    case (char)52:
                    case (char)53:
                    case (char)54:
                    case (char)55:
                    case (char)56:
                    case (char)57:
                        tokenFound = true;
                        result.Tag = TokenType.Number;
                        result.Value = peek;
                        break;
                    default:
                        Console.WriteLine("----- | Error: A lexical error has been encountered! | -----");
                        break;
                } // End switch peek
                index = index + 1;
            } // End while !tokenFound
            return result;
        }// End GetToken method
    }
}
