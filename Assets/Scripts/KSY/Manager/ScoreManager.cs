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
    List<Sprite> girlSprites;

    [SerializeField]
    private Image uiImage;


    private void CheckGirlImg()
    {
        if (0 >= health)
        {
            uiImage.sprite = girlSprites[0];
        }
        else if (20 >= health)
        {
            uiImage.sprite = girlSprites[1];
        }
        else if (40 >= health)
        {
            uiImage.sprite = girlSprites[2];
        }
        else if (60 >= health)
        {
            uiImage.sprite = girlSprites[3];
        }
        else if (80 >= health)
        {
            uiImage.sprite = girlSprites[4];
        }
        else
        {
            uiImage.sprite = girlSprites[5];
        }
    }
}
