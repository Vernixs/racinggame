using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;

public class Leaderboard1 : MonoBehaviour
{
    [SerializeField]
    private List<TextMeshProUGUI> names;
    [SerializeField]
    private List<TextMeshProUGUI> times;

    private string publicLeaderboardKey = "45afae0c88c66e694c35abd8231f5a372bbfc67cfc108622774fa737a0945e79";

    public void GetLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, ((msg) =>
        {
            for (int i = 0; i < names.Count; ++i)
            {
                names[i].text = msg[i].Username;
                times[i].text = msg[i].Score.ToString();
            }
        }));
    }

    public void SetLeaderboardEntry()
}
