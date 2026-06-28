namespace Leetcode.LeetCode_75.Queue;

public class Dota2_Senate
{
    public string PredictPartyVictory(string senate) {
        var n = senate.Length;
        var radiant = new Queue<int>();
        var dire = new Queue<int>();
        
        for (int i = 0; i < n; i++) {
            if (senate[i] == 'R')
                radiant.Enqueue(i);
            else
                dire.Enqueue(i);
        }
        
        while (radiant.Count > 0 && dire.Count > 0) {
            var rIndex = radiant.Dequeue();
            var dIndex = dire.Dequeue();
            
            if (rIndex < dIndex)
                radiant.Enqueue(rIndex + n);
            else
                dire.Enqueue(dIndex + n);
        }
        
        return radiant.Count > 0 ? "Radiant" : "Dire";
    }
}