using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour {

    public WeaponData wdata;
    public WeaponStats weaponStats;
    
    float timer;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            Attack();
            timer = weaponStats.timeToAttack;
        }
    }

    public virtual void SetData(WeaponData weaponData)
    {
        wdata = weaponData;

        weaponStats = new WeaponStats(wdata.stats.damage, wdata.stats.timeToAttack, wdata.stats.numberOfAttacks);
    }
    public abstract void Attack();

    protected void ApplyDamage(Collider2D[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            IDamageable e = colliders[i].GetComponent<IDamageable>();
            if (e != null)
            {
                e.TakeDamage(weaponStats.damage);
                PostDamage(weaponStats.damage, colliders[i].transform.position);
            }
        }
    }

    public virtual void PostDamage(int damage, Vector3 targetPosition)
    {
        MessageSystem.instance.PostMessage(damage.ToString(), targetPosition);
    }

    public void Upgrade(UpgradeData upgradeData)
    {
        weaponStats.Sum(upgradeData.weaponUpgradeStats);
    }
}
