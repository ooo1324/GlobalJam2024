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

    [SerializeField]
    private Animator girlAnim;


    private void CheckGirlImg()
    {
        float percent = health / maxHealth * 100f;
        int animSt;
        if (0 >= percent)
        {
            uiImage.sprite = girlSprites[0];
            animSt = 0;
        }
        else if (20 >= percent)
        {
            uiImage.sprite = girlSprites[1];
            animSt = 20;
        }
        else if (40 >= percent)
        {
            uiImage.sprite = girlSprites[2];
            animSt = 40;
        }
        else if (60 >= percent)
        {
            uiImage.sprite = girlSprites[3];
            animSt = 60;
        }
        else if (80 >= percent)
        {
            uiImage.sprite = girlSprites[4];
            animSt = 80;
        }
        else
        {
            uiImage.sprite = girlSprites[5];
            animSt = 100;
        }

        girlAnim.Play($"{animSt}%Face");
    }
}
