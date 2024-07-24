using System;
using System.Collections.Generic;

public class Solution {
    public int solution(string[] board) {
        int answer = 0;
        bool isStartPoint = false;
        
        //보드의 행과 열 개수
        int rows = board.Length; //행
        int cols = board[0].Length; //열
        
        //상,하,좌,우 이동할 수 있는 방향 
        int[] dr = new int[] { -1, 1, 0, 0 }; 
        int[] dc = new int[] { 0, 0, -1, 1 };
        
        //현재 위치(가로, 세로), 이동횟수
        Queue<(int r, int c, int moves)> queue = new Queue<(int, int, int)>();
        
        //그 위치를 방문했는 지 여부 확인 
        bool[,] visited = new bool[rows, cols];
        
        // 로봇의 시작 위치 찾기
        for (int r = 0; r < rows; r++)
        {
            if (isStartPoint)
                break;
            
            for (int c = 0; c < cols; c++)
            {
                if (board[r][c] == 'R')
                {
                    queue.Enqueue((r, c, 0));
                    visited[r, c] = true;
                    isStartPoint = true;
                    break;
                }
            }
        }
            
         while (queue.Count > 0)
        {
            var (r, c, moves) = queue.Dequeue();
            
            // 목표 지점 도달 시 이동 횟수 반환
            if (board[r][c] == 'G')
            {
                answer = moves;
                return answer;
            }
                
            
            // 상, 하, 좌, 우 방향으로 이동
            for (int i = 0; i < 4; i++)
            {
                int nr = r, nc = c;
                
                // 장애물이나 보드 끝에 부딪힐 때까지 이동
                while (true)
                {
                    int tr = nr + dr[i];
                    int tc = nc + dc[i];
                    if (tr < 0 || tr >= rows || tc < 0 || tc >= cols || board[tr][tc] == 'D') break;
                    nr = tr; //상,하로 계속 이동해봄
                    nc = tc; //좌,우로 계속 이동해봄
                }

                // 새로운 위치가 유효하고 방문하지 않은 경우 큐에 추가
                if (!visited[nr, nc])
                {
                    queue.Enqueue((nr, nc, moves + 1));
                    visited[nr, nc] = true;
                }
            }
        }

        // 목표 지점에 도달할 수 없는 경우
        return -1;
    }
}