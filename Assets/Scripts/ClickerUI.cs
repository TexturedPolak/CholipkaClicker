using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI counterText;
    public void UpdateUI(double cholipki, double cholipkiToK, double cholipkiToM)
    {
        if (cholipkiToM != 0)
        {
            
            cholipkiToK = 0;
            cholipkiToM = Math.Round(cholipkiToM, 2);
            counterText.text = $"Cholipki: {cholipkiToM}M";
        }
        if (cholipkiToK == 0 && cholipkiToM == 0)
        {
            counterText.text = $"Cholipki: {cholipki}";
        }
        if(cholipkiToK != 0 && cholipkiToM == 0)
        {
            cholipkiToK = Math.Round(cholipkiToK, 2);
            counterText.text = $"Cholipki: {cholipkiToK}K";
        }
        
    }
}
