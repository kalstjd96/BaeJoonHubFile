using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(string[] friends, string[] gifts) 
    {
        //각 친구가 다른 친구에게 몇 번 선물을 했는 지 기록 
        // "muzi": { "ryan": 0, "frodo": 0, "neo": 0 },
        Dictionary<string, Dictionary<string, int>> giftRecords = new Dictionary<string, Dictionary<string, int>>();
        
        //각 친구의 선물 지수를 저장 (친구가 준 선물 - 받은 선물)
        // "muzi": 0,
        // "ryan": 0,
        Dictionary<string, int> giftIndex = new Dictionary<string, int>();
    
        //다음 달에 각 친구가 받을 선물의 수
        // "muzi": 0,
        // "ryan": 0,
        Dictionary<string, int> giftCount = new Dictionary<string, int>();

        
         // 각 친구에 대한 선물 기록, 선물 지수, 선물 수 초기화
        foreach (var friend in friends)
        {
            giftRecords[friend] = new Dictionary<string, int>();
            giftIndex[friend] = 0;
            giftCount[friend] = 0;

            foreach (var other in friends)
            {
                // 자기 자신과의 선물 기록은 필요 없음
                if (friend != other)
                {
                    giftRecords[friend][other] = 0;
                }
            }
        }

        //선물 기록 처리
        foreach (var gift in gifts)
        {
            var parts = gift.Split(' ');
            var giver = parts[0];
            var receiver = parts[1];

            //ex. giver : "muzi"이고 receiver : "frodo"
            // giftRecords["muzi"]["frodo"] 값을 1 증가
            giftRecords[giver][receiver]++;
        }

        //선물 지수 계산
        foreach (var giver in friends)
        {
            foreach (var receiver in friends)
            {
                if (giver != receiver)
                {
                    //giver : "muzi"
                    //receiver : "frodo" 이면서 giftRecords["muzi"]["frodo"] => 2 라면
                    //giftIndex["muzi"] => +2
                    //giftIndex["frodo"] => -2
                    giftIndex[giver] += giftRecords[giver][receiver];
                    giftIndex[receiver] -= giftRecords[giver][receiver];
                }
            }
        }

        for (int i = 0; i < friends.Length; i++)
        {
            for (int j = i + 1; j < friends.Length; j++)
            {
                var friendA = friends[i];
                var friendB = friends[j];

                //각 선물의 수를 확인
                int giftsAB = giftRecords[friendA][friendB]; //friendA가 friendB에게 준 선물의 수
                int giftsBA = giftRecords[friendB][friendA]; //friendB가 friendA에게 준 선물의 수

                if (giftsAB > giftsBA)
                {
                    giftCount[friendA]++;
                }
                else if (giftsAB < giftsBA)
                {
                    giftCount[friendB]++;
                }
                else //선물의 수가 같다면
                {
                    if (giftIndex[friendA] > giftIndex[friendB])
                    {
                        giftCount[friendA]++;
                    }
                    else if (giftIndex[friendA] < giftIndex[friendB])
                    {
                        giftCount[friendB]++;
                    }
                }
            }
        }

        //이번 달에 받을 최대 선물의 갯수
        int maxGifts = giftCount.Values.Max();

        //이번 달에 최대 선물을 받는 friend 애들
        var maxGiftFriends = giftCount.Where(x => x.Value == maxGifts).Select(x => x.Key).ToList();

        return maxGifts;
    }
}

