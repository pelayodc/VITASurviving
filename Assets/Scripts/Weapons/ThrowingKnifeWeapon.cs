using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingKnifeWeapon : WeaponBase {

    [SerializeField] GameObject knifePrefab;
    [SerializeField] float offset = 0.4f;

    PlayerMove playerMove;

    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();
    }

    public override void Attack()
    {
        for(int i=0; i<weaponStats.numberOfAttacks;i++)
        {
            GameObject thrownKnife = Instantiate(knifePrefab);
            Vector3 pos = transform.position;
            pos.y -= (offset * weaponStats.numberOfAttacks)/2;
            pos.y += i * offset;
            thrownKnife.transform.position = pos;

            thrownKnife.GetComponent<ThrowingKnifeProjectile>().damage = weaponStats.damage;
            thrownKnife.GetComponent<ThrowingKnifeProjectile>().SetDirection(playerMove.lastHorizontalVector, 0f);
        }
    }

}
