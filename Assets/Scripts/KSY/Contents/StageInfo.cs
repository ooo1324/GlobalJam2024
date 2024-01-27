using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KSY
{

    public class StageInfo
    {
        private int waveTime;

        public int WaveTime
        {
            get { return waveTime; }
        }

        private float spawnRate;
        public float SpawnRate
        {
            get { return spawnRate; }
        }

        private List<int> spawnMaxCount = new List<int>();
        public List<int> SpawnMaxCount
        {
            get { return spawnMaxCount; }
        }
        

        public StageInfo(int time, float spawnRate, List<int> maxCount)
        {
            waveTime = time;
            this.spawnRate = spawnRate;
            spawnMaxCount = maxCount;
        }
    }

}