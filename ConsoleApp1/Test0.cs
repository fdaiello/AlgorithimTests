using System;
class Solution
{
    public int solution(int[] A)
    {
       int min = 1;

        if (A.Length == 0)
            return min;

        Array.Sort(A);

        if (A[0] > 1)
            return min;

        if (A[A.Length-1] <= 0)
            return min;

        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] == min)
            {
                min++;
            }
        }

        return min;
    }
}
