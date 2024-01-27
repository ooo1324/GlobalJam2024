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
        public float timeSec = 0;

        [SerializeField]
        public EWeaponType currentWeapon;

        [SerializeField]
        public Dictionary<EWeaponType, float> weaponDamages;

        [SerializeField]
        public int currStage = -1;

        [SerializeField]
        private int currWave = -1;

        [SerializeField]
        public int spawnMaxCount = 0;

        [SerializeField]
        private Spawner spawner;

        [SerializeField]
        private RoadSpawner roadSpawner;

        [SerializeField]
        private TimeText timeText;

        private List<StageInfo> stageInfoList;

        private List<GameObject> enemyObjList;

        private float maxTime = 0;

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
            stageInfoList.Add(new StageInfo(5, new List<int> { 15, 20, 25 }));
            stageInfoList.Add(new StageInfo(5, new List<int> { 20, 30, 40 }));
            stageInfoList.Add(new StageInfo(5, new List<int> { 30, 40, 50 }));

            #region spawner
            GameObject spawnerObj = GameObject.Find("@Spawner");
            GameObject roadSpawnerObj = GameObject.Find("@RoadSpawner");

            if (spawnerObj == null || roadSpawnerObj == null)
            {
                Debug.LogError("Don't Found Spawner");
                return;
            }

            roadSpawner = roadSpawnerObj.GetComponent<RoadSpawner>();
            spawner = spawnerObj.GetComponent<Spawner>();
            #endregion
        }

        private void Start()
        {
            currStage = -1;
            StartStage();
        }

        public void StartStage()
        {
            enemyObjList.Clear();
            currStage++;
            maxTime = stageInfoList[currStage].WaveTime;    
            currWave = -1;
            StartWave();
        }

        public void StartWave()
        {
            if (currWave >= 2)
            {
                // TODO: Stage 넘기기

                return;
            }
            currWave++;
            spawner.StartSpawn(stageInfoList[currStage].SpawnMaxCount[currWave]);
        }

        public void WaveTimeStart()
        {
            timeSec = 0;
            timeText.Time = timeSec;

            StartCoroutine(TimeStart());
        }

        public void AddEnemyObj(GameObject obj)
        {
            enemyObjList.Add(obj);
        }

        public void RemoveEnemyObj(GameObject obj)
        {
            enemyObjList.Remove(obj);
        }

        public void SpawnerMove(GameObject obj)
        {
            roadSpawner.RoadSpawn(obj);
        }

        public void NextStage()
        {
            
        }

        public void GameOver()
        {
            
        }

        IEnumerator TimeStart()
        {
            while (timeSec < maxTime)
            {
                timeSec += Time.deltaTime;
                timeText.Time = timeSec;
                yield return new WaitForFixedUpdate();
            }

            StartWave();
        }
    }
}