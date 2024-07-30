using System;

public class Solution {
    public int[] solution(int[] sequence, int k) {
        int[] answer = new int[2];

        int start = 0;
        int end = 0;
        int curSum = sequence[0];
        int minLength = 0;

        while (start < sequence.Length)
        {
            if(curSum < k)
            {
                end++;
                if(end == sequence.Length)
                    break;

                curSum += sequence[end];
            }
            else if(curSum == k)
            {
                int curLength = end - start + 1;
                
                if (minLength == 0 || curLength < minLength) // <= 이 아닌 <을 통해 앞순서를 지킬 수 있음
                {
                    minLength = curLength;
                    answer[0] = start;
                    answer[1] = end;
                }

                //다른 숫자 조합을 위함
                curSum -= sequence[start];
                ++start;
            }
            else
            {
                curSum -= sequence[start];
                ++start;
            }
        }

        return answer;
    }
}