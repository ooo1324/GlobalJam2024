using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private float health;
    public float Health
    {
        get { return health; }
        set
        {
            health = value;
            CheckGirlImg();
        }
    }

    [SerializeField]
    private float maxHealth;

    [SerializeField]
    List<Sprite> girlSprites;

    [SerializeField]
    private Image uiImage;


    private void CheckGirlImg()
    {
        float percent = health / maxHealth * 100f;

        if (0 >= percent)
        {
            uiImage.sprite = girlSprites[0];
        }
        else if (20 >= percent)
        {
            uiImage.sprite = girlSprites[1];
        }
        else if (40 >= percent)
        {
            uiImage.sprite = girlSprites[2];
        }
        else if (60 >= percent)
        {
            uiImage.sprite = girlSprites[3];
        }
        else if (80 >= percent)
        {
            uiImage.sprite = girlSprites[4];
        }
        else
        {
            uiImage.sprite = girlSprites[5];
        }
    }
}
