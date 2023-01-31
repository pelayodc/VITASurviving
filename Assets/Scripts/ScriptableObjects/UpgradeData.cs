using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeType
{ 
    WeaponUpgrade,
    ItemUpgrade,
    WeaponUnlock,
    ItemUnlock,
    Coins,
    Heal
}

[CreateAssetMenu]
public class UpgradeData : ScriptableObject {

    public UpgradeType upgradeType;
    public string Name;
    public Sprite Icon;

    public WeaponData weaponData;
    public WeaponStats weaponUpgradeStats;

    public Item item;
    public ItemStats ItemUpgradeStats;

    public List<UpgradeData> upgrades;
}
