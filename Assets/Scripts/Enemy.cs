using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable {

    Transform targetDestination;
    GameObject targetGameObject;
    Character targetCharacter;
    [SerializeField] float speed;

    Rigidbody2D rgbd2d;
    Animator animator;

    public int hp = 4;
    [SerializeField] int damage = 2;
    [SerializeField] int expReward = 200;

    private bool isBoss = false;
    BossBarController bc;

    void Awake() {
        rgbd2d = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        animator.SetFloat("Horizontal", -1f);
    }
	
	void FixedUpdate () {
        animator.SetFloat("Horizontal",  targetDestination.position.x - transform.position.x);
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rgbd2d.velocity = direction * speed;
	}

    public void SetTarget(Transform target)
    {
        targetDestination = target;
        targetGameObject = targetDestination.gameObject;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject == targetGameObject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if(targetCharacter == null)
        {
            targetCharacter = targetGameObject.GetComponent<Character>();
        }

        targetCharacter.TakeDamage(damage);
    }

    public void SetAsBoss(BossBarController b)
    {
        isBoss = true;
        bc = b;
        bc.show();
        bc.SetState(hp, hp);
    }

    public void TakeDamage(int damage)
    {
        hp-=damage;

        if(isBoss)
            bc.SetState(hp, 1000);

        if(hp < 1)
        {
            if (targetCharacter == null)
            {
                targetCharacter = targetGameObject.GetComponent<Character>();
            }
            targetCharacter.AddExperience(expReward);
            targetCharacter.addKill();
            GetComponent<DropOnDestroy>().CheckDrop();
            if (isBoss)
                bc.hide();

            Destroy(this.gameObject);
        }
    }
}
