using System;

public class Solution {
    public int solution(int[] diffs, int[] times, long limit)
    {
        int left = 1, right = 100000;

        while (left < right)
        {
            int mid = (left + right) / 2;
            long total = 0;

            for (int i = 0; i < diffs.Length; i++)
            {
                if (diffs[i] <= mid)
                {
                    total += times[i];
                }
                else
                {
                    int count = diffs[i] - mid;
                    long time_pre = i > 0 ? times[i - 1] : 0;
                    total += (count * (time_pre + times[i])) + times[i];
                }

                if (total > limit)
                {
                    break;
                }
            }

            if (total > limit)
            {
                left = mid + 1; 
            }
            else
            {
                right = mid; 
            }
        }

        return left;
    }

}