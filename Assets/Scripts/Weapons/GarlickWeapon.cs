﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlickWeapon : WeaponBase {

    [SerializeField] float attackAreaSize = 2.5f;

    public override void Attack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackAreaSize);
        ApplyDamage(colliders);
    }
}
