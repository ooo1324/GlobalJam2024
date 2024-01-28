using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KSY
{
    public class Sensor : MonoBehaviour
    {
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy") || collision.CompareTag("EnemyBoss"))
            {
                //collision.gameObject.SetActive(false);
                GameManager.Instance.SpawnerMove(collision.gameObject);
            }
        }
    }

}