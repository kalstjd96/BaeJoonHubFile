using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(string[] friends, string[] gifts) 
    {
        Dictionary<string, Dictionary<string, int>> giftRecords 
            = new Dictionary<string, Dictionary<string, int>>();
    Dictionary<string, int> giftIndex 
        = new Dictionary<string, int>();
    Dictionary<string, int> giftCount 
        = new Dictionary<string, int>();

        
        foreach (var friend in friends)
        {
            giftRecords[friend] = new Dictionary<string, int>();
            giftIndex[friend] = 0;
            giftCount[friend] = 0;

            foreach (var other in friends)
            {
                if (friend != other)
                {
                    giftRecords[friend][other] = 0;
                }
            }
        }

        foreach (var gift in gifts)
        {
            var parts = gift.Split(' ');
            var giver = parts[0];
            var receiver = parts[1];
            giftRecords[giver][receiver]++;
        }

        foreach (var giver in friends)
        {
            foreach (var receiver in friends)
            {
                if (giver != receiver)
                {
                    giftIndex[giver] += giftRecords[giver][receiver];
                    giftIndex[receiver] -= giftRecords[giver][receiver];
                }
            }
        }

        // Calculate next month's gifts
        for (int i = 0; i < friends.Length; i++)
        {
            for (int j = i + 1; j < friends.Length; j++)
            {
                var friendA = friends[i];
                var friendB = friends[j];
                int giftsAB = giftRecords[friendA][friendB];
                int giftsBA = giftRecords[friendB][friendA];

                if (giftsAB > giftsBA)
                {
                    giftCount[friendA]++;
                }
                else if (giftsAB < giftsBA)
                {
                    giftCount[friendB]++;
                }
                else
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

        // Find the friends who will receive the most gifts
        int maxGifts = giftCount.Values.Max();
        var maxGiftFriends = giftCount.Where(x => x.Value == maxGifts).Select(x => x.Key).ToList();

        return maxGifts;
    }
}

