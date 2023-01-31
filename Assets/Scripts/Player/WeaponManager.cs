using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

    [SerializeField] Transform weaponObjectsContainer;

    List<WeaponBase> weapons;

    private void Awake()
    {
        weapons = new List<WeaponBase>();
    }

    public void AddWeapon(WeaponData wdata)
    {
        GameObject weapon = Instantiate(wdata.weaponBasePrefab, weaponObjectsContainer);
        WeaponBase w = weapon.GetComponent<WeaponBase>();
        w.SetData(wdata);
        weapons.Add(w);
    }

    public void UpgradeWeapon(UpgradeData udata)
    {
        WeaponBase w = weapons.Find(wd => wd.wdata.Name == udata.weaponData.Name);
        if(w!=null)
            w.Upgrade(udata);
    }

    public int GetWeaponsCount()
    {
        return weapons.Count;
    }

    public int GetWeaponPos(UpgradeData udata)
    {
        return weapons.FindIndex(wd => wd.wdata.Name == udata.weaponData.Name);
    }
}
