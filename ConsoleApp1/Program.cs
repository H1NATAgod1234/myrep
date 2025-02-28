using System;

class Program
{

    static int MinPartsForSubarray(int[] segments, int s)
    {
        int parts = 0;
        int currentLength = 0;
        
        foreach (var segment in segments)
        {
            currentLength += segment;
            if (currentLength > s)
            {
                parts++; 
                currentLength = segment;  
            }
        }

        if (currentLength > 0)
        {
            parts++;
        }

        return parts;
    }

    static int Solve(int n, int s, int[] segments)
    {
        int totalParts = 0;

      
        for (int l = 0; l < n; l++)
        {
            for (int r = l; r < n; r++)
            {
           
                int[] subarray = new int[r - l + 1];
                Array.Copy(segments, l, subarray, 0, r - l + 1);

              
                totalParts += MinPartsForSubarray(subarray, s);
            }
        }

        return totalParts;
    }

    static void Main()
    {
  
        string[] input = Console.ReadLine().Split();
        int n = int.Parse(input[0]);
        int s = int.Parse(input[1]);
        int[] segments = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

      
        int result = Solve(n, s, segments);
        Console.WriteLine(result);
    }
}
