using System;
using System.Collections.Generic;

namespace Knight_Dialer
{
  // Great explanantion  - https://leetcode.com/problems/knight-dialer/discuss/190787/How-to-solve-this-problem-explained-for-noobs!!!
  class Program
  {
    static void Main(string[] args)
    {
      Solution s = new Solution();
      var answer = s.KnightDialer(3);
      Console.Write(answer);
    }
  }

  public class Solution
  {
    public int KnightDialer(int n)
    {
      int mod = 1000000007;
      Dictionary<string, long> visited = new Dictionary<string, long>();
      var directions = new int[8][] { new int[] { -2, 1 }, new int[] { -2, -1 }, new int[] { -1, 2 }, new int[] { -1, -2 }, new int[] { 1, 2 }, new int[] { 1, -2 }, new int[] { 2, 1 }, new int[] { 2, -1 } };
      // phone dialer is 4*3 matrix
      long res = 0;
      for (int i = 0; i < 4; i++)
      {
        for (int j = 0; j < 3; j++)
        {
          res = (res + Backtrack(i, j, n)) % mod;
        }
      }

      long Backtrack(int i, int j, int n)
      {
        if (i < 0 || j < 0 || i > 3 || j > 2 || (i == 3 && j != 1)) return 0;
        if (n == 1) return 1;
        string key = i + "_" + j + "_" + n;
        if (visited.ContainsKey(key)) return visited[key];
        long res = 0;
        for (int k = 0; k < directions.Length; k++)
        {
          res += Backtrack(i + directions[k][0], j + directions[k][1], n - 1) % mod;
        }

        visited.Add(key, res);
        return res;
      }

      return (int)res;
    }
  }
}
