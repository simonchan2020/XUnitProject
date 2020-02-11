using System;
using System.Collections.Generic;

namespace xUnitTestProject
{
    /// <summary>
    /// This class is used to process any given file and to determine whether the file is well-formed or not
    /// Criteria on well-formed document
    /// Must start with an open tag, and end with a close tag, and must be properly nested
    /// For example: Input:  <This is a [well] formed {document}>   output: True
    ///              Input:  >This is a not<well>formed</well>> document    output: False
    /// </summary>
    public static class DocumentProcessing
    {
        public static bool IsBalanced(string doc)
        {
            //For demo purpose, i just used the the following three open and close tags
            char[] openTags = new char[] { '{', '<', '[' };
            char[] closedTags = new char[] { '}', '>', ']' };

            //use stack to hold the value of open and close tags
            Stack<int> stackItems = new Stack<int>();

            //loop through the file by character
            foreach(char c in doc)
            {
                int idx = Array.IndexOf(openTags, c);

                //push the open tag to stack if it matches
                if(idx != -1)
                {
                    stackItems.Push(idx);
                }

                idx = Array.IndexOf(closedTags, c);

                //pop the value from stack and return false if it's empty or the close tag being closed are not opened previously
                if(idx != -1)
                {
                    if(stackItems.Count == 0 || stackItems.Pop() != idx)
                    {
                        return false;
                    }
                }                
            }

            return (stackItems.Count == 0);
        }
    }
}
