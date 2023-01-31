using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeProjectile : MonoBehaviour {

    Vector3 direction;
    public float speed;
    public int damage;

    bool hitDetected = false;
    private static Vector3 rot = new Vector3(0f,0f,14f);

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        if (Time.frameCount % 5 == 0)
        {
            transform.Rotate(rot);
            Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 0.6f);
            foreach (Collider2D c in hit)
            {
                IDamageable e = c.GetComponent<IDamageable>();
                if (e != null)
                {
                    e.TakeDamage(damage);
                    PostDamage(damage, c.transform.position);
                    hitDetected = true;
                }
            }

            if (hitDetected) { Destroy(gameObject); }
        }
    }

    public virtual void PostDamage(int damage, Vector3 targetPosition)
    {
        MessageSystem.instance.PostMessage(damage.ToString(), targetPosition);
    }

    public void SetDirection(float dir_x, float dir_y)
    {
        if (dir_x < 0)
        {
            dir_x = -1f;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
        else
        {
            dir_x = 1f;
        }

        direction = new Vector3(dir_x, dir_y);
    }
}
