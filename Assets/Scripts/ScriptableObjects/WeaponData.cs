using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponStats
{
    public int damage;
    public float timeToAttack;
    public int numberOfAttacks;

    public WeaponStats(int damage, float timeToAttack, int numberOfAttacks)
    {
        this.damage = damage;
        this.timeToAttack = timeToAttack;
        this.numberOfAttacks = numberOfAttacks;
    }

    public void Sum(WeaponStats ws)
    {
        this.damage += ws.damage;
        this.timeToAttack -= ws.timeToAttack;
        this.numberOfAttacks += ws.numberOfAttacks;
    }

}

[CreateAssetMenu]
public class WeaponData : ScriptableObject {

    public string Name;
	public WeaponStats stats;
    public GameObject weaponBasePrefab;
    public Sprite weaponBaseSpr;
}
