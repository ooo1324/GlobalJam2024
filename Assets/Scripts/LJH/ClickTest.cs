using System.Collections;
using System.Collections.Generic;
using LJH;
using UnityEngine;

public class ClickTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(EffectManager.Instance.mousePos, Vector2.zero, 1f);
            if(hit.collider != null){
                Debug.Log(hit.transform.name);
            }
        }
    }
}
