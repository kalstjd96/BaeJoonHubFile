using System;
using System.Collections.Generic;

public class Solution {
    public string[] solution(string[] players, string[] callings) {
       
        Dictionary<string, int> playerPositions = new Dictionary<string, int>();
        
        for (int i = 0; i < players.Length; i++) 
        {
            playerPositions[players[i]] = i;
        }

        for (int i = 0; i < callings.Length; i++) 
        {
            string call = callings[i];
            
            int index = playerPositions[call];
            if (index > 0) 
            {
                string previousPlayer = players[index - 1];
                
                players[index - 1] = call;
                players[index] = previousPlayer;
                
                playerPositions[call] = index - 1;
                playerPositions[previousPlayer] = index;
            }
        }
        
        return players;
    }
}