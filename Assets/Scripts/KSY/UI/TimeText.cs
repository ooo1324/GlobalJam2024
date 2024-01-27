using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeText : MonoBehaviour
{
    private TextMeshProUGUI timeUI;

    private float time;
    public float Time
    {
        get { return time; }
        set
        {
            time = value;
            if(timeUI != null)
                timeUI.text = time.ToString("F0");
        }
    }

    private void Start()
    {
        timeUI = gameObject.GetComponent<TextMeshProUGUI>();
    }
}
