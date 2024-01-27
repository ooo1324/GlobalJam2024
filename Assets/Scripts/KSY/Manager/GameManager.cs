using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KSY
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [SerializeField]
        public EWeaponType currentWeapon;

        [SerializeField]
        public Dictionary<EWeaponType, float> weaponDamages;

        [SerializeField]
        public int currStage = 0;

        [SerializeField]
        private int currWave = 0;

        [SerializeField]
        public int spawnMaxCount = 0;

        [SerializeField]
        private Spawner spawner;

        private List<StageInfo> stageInfoList;

        private List<GameObject> enemyObjList;


        public void Awake()
        {
            Instance = this;
            currentWeapon = EWeaponType.Weapon1;
            weaponDamages = new Dictionary<EWeaponType, float>();
            enemyObjList = new List<GameObject>();

            weaponDamages.Add(EWeaponType.Weapon1, 1);
            weaponDamages.Add(EWeaponType.Weapon2, 2);
            weaponDamages.Add(EWeaponType.Weapon3, 3);

            // 스테이지 정보 입력
            stageInfoList = new List<StageInfo>();
            stageInfoList.Add(new StageInfo(new List<int> { 15, 20, 25 }));

            GameObject spawnerObj = GameObject.Find("@Spawner");

            if (spawnerObj == null)
            {
                Debug.LogError("Don't Found Spawner");
                return;
            }

            spawner = spawnerObj.GetComponent<Spawner>();
        }

        private void Start()
        {
            StartStage();
        }


        public void StartStage()
        {
            enemyObjList.Clear();
            spawner.StartSpawn(stageInfoList[currStage].SpawnMaxCount[currWave]);
        }

        public void AddEnemyObj(GameObject obj)
        {
            enemyObjList.Add(obj);
        }

        public void RemoveEnemyObj(GameObject obj)
        {
            enemyObjList.Remove(obj);
        }

        public void NextStage()
        {
            
        }

        public void GameOver()
        {
            
        }
    }
}