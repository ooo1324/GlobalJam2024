using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KSY
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        public EWeaponType currentWeapon;

        [SerializeField]
        public Dictionary<EWeaponType, float> weaponDamages;

        

        private void Start()
        {
            currentWeapon = EWeaponType.Weapon1;
            weaponDamages = new Dictionary<EWeaponType, float>();

            weaponDamages.Add(EWeaponType.Weapon1, 1);
            weaponDamages.Add(EWeaponType.Weapon2, 2);
            weaponDamages.Add(EWeaponType.Weapon3, 3);
        }
    }
}