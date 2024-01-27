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
        public int spawnCount = 0;

        public int weaponLevel;

        [SerializeField]
        private int minusCount = 0;

        private int maxSpawnCount = 0;

        [SerializeField]
        private Spawner spawner;

        [SerializeField]
        private RoadSpawner roadSpawner;

        [SerializeField]
        private TimeText timeText;

        private List<StageInfo> stageInfoList;

        [SerializeField]
        private GameObject particle;

        private ScoreManager scoreManager;

        private float maxTime = 0;

        public int dmg;

        public void Awake()
        {
            Instance = this;
            scoreManager = GetComponent<ScoreManager>();
            weaponLevel = 3;
            currentWeapon = EWeaponType.Weapon1;
            weaponDamages = new Dictionary<EWeaponType, float>();

            weaponDamages.Add(EWeaponType.Weapon1, 1);
            weaponDamages.Add(EWeaponType.Weapon2, 2);
            weaponDamages.Add(EWeaponType.Weapon3, 3);

            // 스테이지 정보 입력
            stageInfoList = new List<StageInfo>();
 
            stageInfoList.Add(new StageInfo(5, 0.8f, new List<int> { 25, 30, 35 }));
            stageInfoList.Add(new StageInfo(5, 0.6f, new List<int> { 30, 40, 50 }));
            stageInfoList.Add(new StageInfo(5, 0.5f, new List<int> { 40, 50, 60 }));

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

            Managers.Events.AddEnemyEvent += Spawner_AddEnemyEvent;
            Managers.Events.MinusScore += Events_MinusScoreEvent;
            Managers.Events.PlusScore += Events_PlusScore;
            #endregion
        }

        private void Events_PlusScore()
        {
            minusCount++;
            CheckSpawnCount();
        }

        private void Events_MinusScoreEvent(float score)
        {
            scoreManager.Health -= score;
            minusCount++;
            CheckSpawnCount();
        }

        private void CheckSpawnCount()
        {
            // 모든 객체 삭제
            if (maxSpawnCount <= minusCount)
            {
                Debug.Log("Next Stage");

                // Stage 넘기기
                StartStage();
            }
        }

        private void Spawner_AddEnemyEvent()
        {
            spawnCount++;
        }

        private void Start()
        {
            currStage = -1;
            StartStage();
        }

        public void StartStage()
        {
            if (currStage >= 2)
            {
                // TODO : Game Ending
                return;
            }
            spawnCount = 0;
            minusCount = 0;
            //enemyObjList.Clear();       
            currStage++;
            spawner.spawnRate = stageInfoList[currStage].SpawnRate;
            maxTime = stageInfoList[currStage].WaveTime;

            List<int> spawnList = stageInfoList[currStage].SpawnMaxCount;
            for (int i = 0; i < spawnList.Count; i++)
            {
                maxSpawnCount += spawnList[i];
            }
            // Boss Count 추가
            maxSpawnCount++;
            currWave = -1;
            StartWave();
        }

        public void StartWave()
        {
            if (currWave >= 2)
            {
                return;
            }

            timeSec = 0;
            timeText.Time = timeSec;

            currWave++;
            spawner.StartSpawn(stageInfoList[currStage].SpawnMaxCount[currWave]);

            if (currWave == 2)
            {
                spawner.BossSpawn(0);
                //spawner.BossSpawn(currStage);
            }
        }

        public void WaveTimeStart()
        {
            StartCoroutine(TimeStart());
        }


        public void RemoveEnemyObj(GameObject obj)
        {
            particle.transform.position = obj.transform.position;
            particle.SetActive(true);
            Managers.Pool.Push(obj.GetComponent<Poolable>());  
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