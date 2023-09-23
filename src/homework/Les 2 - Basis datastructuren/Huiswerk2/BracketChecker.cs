using System;
using System.Collections.Generic;
using System.Linq;

namespace AD
{
    public static class BracketChecker
    {

        /// <summary>
        ///    Run over all characters in a string, push all '(' characters
        ///    found on a stack. When ')' is found, it should match a '(' on
        ///    the stack, which is then popped.
        ///
        ///    If ')' is found when no '(' is on the stack, this method will
        ///    terminate prematurely, no further inspection is needed.
        /// </summary>
        /// <param name="s">The string to check</param>
        /// <returns>Returns True if all '(' are matched by ')'.
        /// Returns False otherwise.</returns>
        public static bool CheckBrackets(string s)
        {
            var stack = new MyStack<Char>();
            foreach (char c in s)
            {
                if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    if (stack.IsEmpty()) return false;
                    stack.Pop();
                }
            }
            return stack.IsEmpty();
        }


        /// <summary>
        ///    Run over all characters in a string, when an opening bracket is
		///    found the closing counterpart from closeChar is pushed on a Stack
        ///    When an closing bracket is found, it should match the top character
		///    from this stack.
		///    
        ///    This method will terminate prematurely if a wrong or missmatched
        ///    closing bracket is found and no further inspection is needed.
		/// </summary>
		/// <param name="s">The string to check</param>
		/// <returns>Returns True if all opening brackets are matched by
		/// it's correct counterpart in a correct order.
        /// Returns False otherwise.</returns>
        public static bool CheckBrackets2(string s)
        {
            var stack = new MyStack<Char>();
            var pairs= new Dictionary<char, char>
            {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' }
            };

            foreach (char c in s)
            {
                if (pairs.ContainsKey(c))
                {
                    stack.Push(c);
                }
                else if (pairs.ContainsValue(c))
                {
                    if (stack.IsEmpty()) return false;
                    if( pairs[stack.Top()] != c) return false;
                    
                    stack.Pop();
                }
            }
            return stack.IsEmpty();
        }

    }

    class BracketCheckerInvalidInputException : Exception
    {
    }

}
