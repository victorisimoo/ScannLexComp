/*
   @author: Victor N. Hernandez
   @version: 1.0.0
 */
using COMP_VictorHernandez_1301219.Structure.TokenConstruction;
using System;

namespace COMP_VictorHernandez_1301219.Structure.Interpretation {

    /// <summary>
    /// Method to parse the entered expression
    /// </summary>
    public class Parser {
        Scanner scanner;
        Token token;

        /// <summary>
        /// Method for parsing the expression
        /// </summary>
        /// <param name="regexp"></param>
        /// <returns> Return result expression </returns>
        public double ParserExpression(string regexp) {
            scanner = new Scanner(regexp + (char)TokenType.EOF);
            token = scanner.GetToken();

            double result = 0;

            switch (token.Tag) {
                case TokenType.Minus:
                case TokenType.LParen:
                case TokenType.Number:
                    result = E();
                    break;
                default:
                    break;
            }
            MatchExpression(TokenType.EOF);
            return result;
        }

        /// <summary>
        /// Method that returns the numerical expression
        /// </summary>
        /// <returns>Return the number obtaining</returns>
        private string GetNumber () {
            var tokenValueResult = new string(token.Value, 1);
            MatchExpression(TokenType.Number);
            var numberObtaining = R();
            return tokenValueResult + numberObtaining;
        }

        /// <summary>
        /// Method that analyzes the coincidence of the expressions
        /// </summary>
        /// <param name="tag"></param>
        private void MatchExpression(TokenType tag) {
            if (token.Tag == tag) {
                token = scanner.GetToken();
            } else {
                throw new Exception("----- | Error: A syntax error has been encountered! | -----");
            }
        }

        /// <summary>
        /// Method that is part of grammar
        /// </summary>
        /// <returns>Return de expresion</returns>
        private double E() {
            switch (token.Tag) {
                case TokenType.Minus:
                case TokenType.LParen:
                case TokenType.Number:
                    return M() + EP();
                default:
                    throw new Exception("----- | Error: A syntax error has been encountered! | -----");
            }
        }

        /// <summary>
        /// Method that is part of grammar
        /// </summary>
        /// <returns>Return de expresion</returns>
        private double M() {
            switch (token.Tag) {
                case TokenType.Minus:
                case TokenType.LParen:
                case TokenType.Number:
                    return A() * TP();
                default:
                    throw new Exception("----- | Error: A syntax error has been encountered! | -----");
            }
        }

        /// <summary>
        /// Method that is part of grammar
        /// </summary>
        /// <returns>Return de expresion</returns>
        private double A() {
            switch (token.Tag) {
                case TokenType.Minus:
                    MatchExpression(TokenType.Minus);
                    return -A();
                case TokenType.LParen:
                case TokenType.Number:
                    return K();
                default:
                    throw new Exception("----- | Error: A syntax error has been encountered! | -----");
            }
        }

        /// <summary>
        /// Method that is part of grammar
        /// </summary>
        /// <returns>Return de expresion</returns>
        private double K() {
            switch (token.Tag) {
                case TokenType.LParen:
                    MatchExpression(TokenType.LParen);
                    var result = E();
                    MatchExpression(TokenType.RParen);
                    return result;
                case TokenType.Number:
                    return Convert.ToInt32(GetNumber());
                default:
                    throw new Exception("----- | Error: A syntax error has been encountered! | -----");
            }
        }

        /// <summary>
        /// Method that is part of grammar
        /// </summary>
        /// <returns>Return de expresion</returns>
        private string R() {
            switch (token.Tag) {
                case TokenType.Number:
                    return GetNumber();
                default:
                    return "";
            }
        }

        /// <summary>
        /// Method which is a primary part of grammar
        /// </summary>
        /// <returns>Return de expresion</returns>
        private double EP() {

            switch (token.Tag) {
                case TokenType.Plus:
                    MatchExpression(TokenType.Plus);
                    return M() + EP();
                case TokenType.Minus:
                    MatchExpression(TokenType.Minus);
                    return -M() + EP();
                default:
                    return 0;
            }
        }

        /// <summary>
        /// Method which is a primary part of grammar
        /// </summary>
        /// <returns>Return de expresion</returns>
        private double TP () {
            switch (token.Tag) {
                case TokenType.Multipli:
                    MatchExpression(TokenType.Multipli);
                    return A() * TP();
                case TokenType.Division:
                    MatchExpression(TokenType.Division);
                    return 1 / A() * TP();
                default:
                    return 1;
            }
        }
    }
}
