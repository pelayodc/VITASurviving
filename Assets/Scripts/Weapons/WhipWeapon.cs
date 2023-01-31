using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : WeaponBase {
	
    [SerializeField] GameObject leftWhipGameObject;
    [SerializeField] GameObject rightWhipGameObject;

    PlayerMove playerMove;
    [SerializeField] Vector2 whipAttackSize = new Vector2(4f,2f);

    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();
    }

    public override void Attack()
    {
        StartCoroutine(AttackStage());
    }

    IEnumerator AttackStage()
    {
        for(int i=0;i<weaponStats.numberOfAttacks;i++)
        {
            if (playerMove.lastHorizontalVector > 0)
            {
                rightWhipGameObject.SetActive(true);
                Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhipGameObject.transform.position, whipAttackSize, 0f);
                ApplyDamage(colliders);
            }
            else
            {
                leftWhipGameObject.SetActive(true);
                Collider2D[] colliders = Physics2D.OverlapBoxAll(leftWhipGameObject.transform.position, whipAttackSize, 0f);
                ApplyDamage(colliders);
            }

            yield return new WaitForSeconds(0.25f);
        }
    }

}
