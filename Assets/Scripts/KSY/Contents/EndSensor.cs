using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KSY
{
    public class EndSensor : MonoBehaviour
    {


        private void OnTriggerExit2D(Collider2D collision)
        {
            //if (collision.CompareTag("Enemy"))
            //{
            //    Managers.Events.MinusEnemyInvoke();
            //    GameManager.Instance.RemoveEnemyObj(collision.gameObject);
            //}
        }
    } 
}
