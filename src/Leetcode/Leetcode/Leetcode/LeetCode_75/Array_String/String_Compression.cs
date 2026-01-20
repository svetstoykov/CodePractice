namespace Leetcode.LeetCode_75.Array_String;

public class String_Compression
{
    public int Compress(char[] chars)
    {
        int read = 0;
        int write = 0;


        while (read < chars.Length)
        {
            char currentChar = chars[read];
            int count = 0;

            // Count consecutive characters
            while (read < chars.Length && currentChar == chars[read])
            {
                read++;
                count++;
            }

            // Write the character
            chars[write] = currentChar;
            write++;

            // Write the count (if > 1)
            if (count > 1)
            {
                foreach (char c in count.ToString())
                {
                    chars[write] = c;
                    write++;
                }
            }
        }

        return write;
    }
}