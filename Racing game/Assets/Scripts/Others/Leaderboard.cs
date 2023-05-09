using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    Transform entryContainer;
    Transform entryTemplace;

    RacingTimer timertexts;
    private void Awake()
    {
        entryContainer = transform.Find("tt");
        entryTemplace = transform.Find("Leaderboard");

        entryTemplace.gameObject.SetActive(false);

        float templateHeight = 30f;

        for (int i = 0; i < 10; i++)
        {
            Transform entryTransform = Instantiate(entryTemplace, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);

            int rank = i + 1;
            string rankString;
            switch(rank)
                {
                default:
                    rankString = rank + "TH"; break;
                case 1: rankString = "1ST"; break;
                case 2: rankString = "2ND"; break;
                case 3: rankString = "3RD"; break;
                }

            entryTransform.Find("Placepos").GetComponent<Text>().text = rankString;

            
            entryTransform.Find("Timetext").GetComponent<Text>().text = timertexts.timerText.ToString();
            entryTransform.Find("Nametext").GetComponent<Text>().text = "";
        }
    }
}
