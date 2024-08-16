using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int[] queue1, int[] queue2) {
        long q1Sum = 0;
        long q2Sum = 0;
        int n = queue1.Length;

        for (int i = 0; i < n; i++)
        {
            q1Sum += queue1[i];
            q2Sum += queue2[i];
        }

        Queue<int> q1 = new Queue<int>(queue1);
        Queue<int> q2 = new Queue<int>(queue2);

        //두 개의 합이 홀수일 경우 같을 수가 없기 때문에 
        //홀수일 경우 -1 return !!
        //문제: 두 큐에 담긴 모든 원소의 합은 30입니다.따라서, 각 큐의 합을 15로 만들어야 합니다.
        //예를 들어, 다음과 같이 2가지 방법이 있습니다. => 여기서 힌트!
        long totalSum = q1Sum + q2Sum;
        if (totalSum % 2 != 0)
            return -1;

        //목표 합
        long targetSum = totalSum / 2;

        int count = 0;

        //q1의 모든 원소를 pop/insert 하는데 n번의 작업이 필요 (q2도 마찬가지)
        //따라서 2개의 큐를 모두 사용하는 경우 최대 2n 
        //추가적인 조율을 통한 n번의 작업 
        int maxCount = 3*n; // 최대 연산 횟수

        while (count <= maxCount)
        {
            if (q1Sum == q2Sum)
            {
                if (q1Sum == targetSum)
                    return count;
            }

            if (q1Sum > q2Sum)
            {
                // queue1에서 pop하고 queue2에 insert
                if (q1.Count > 0)
                {
                    int num = q1.Dequeue();
                    q1Sum -= num;
                    q2.Enqueue(num);
                    q2Sum += num;
                }
            }
            else
            {
                // queue2에서 pop하고 queue1에 insert
                if (q2.Count > 0)
                {
                    int num = q2.Dequeue();
                    q2Sum -= num;
                    q1.Enqueue(num);
                    q1Sum += num;
                }
            }
            count++;
        }

        return -1; // 작업으로 목표를 달성할 수 없는 경우
    }
}