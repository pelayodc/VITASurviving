using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeWeapon : WeaponBase {

    [SerializeField] GameObject axePrefab;

    public override void Attack()
    {
        for (int i = 0; i < weaponStats.numberOfAttacks; i++)
        {
            GameObject thrownAxe = Instantiate(axePrefab);
            thrownAxe.transform.position = transform.position;
            int dir = Random.Range(0, 4);
            float x = 0f, y = 0f;
            thrownAxe.GetComponent<AxeProjectile>().damage = weaponStats.damage;

            switch (dir)
            {
                case 0:
                    x = 1f;
                    y = 0f;
                    break;
                case 1:
                    x = 0f;
                    y = 1f;
                    break;
                case 2:
                    x = -1f;
                    y = 0f;
                    break;
                case 3:
                    x = 0f;
                    y = -1f;
                    break;
            }
            thrownAxe.GetComponent<AxeProjectile>().SetDirection(x, y);
        }
    }
}
