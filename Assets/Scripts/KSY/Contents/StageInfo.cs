using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KSY
{

    public class StageInfo
    {
        private List<int> spawnMaxCount = new List<int>();
        public List<int> SpawnMaxCount
        {
            get { return spawnMaxCount; }
        }
        

        public StageInfo(List<int> maxCount)
        {
            spawnMaxCount = maxCount;
        }
    }

}