using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour {

    Rigidbody2D rgbd2d;
    [HideInInspector]
    public Vector3 movementVector;
    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;

    public float speed;
    public float inicialSpeed = 3f;

    Animate animate;

	// Use this for initialization
	void Awake() {
        rgbd2d = GetComponent<Rigidbody2D>();
        movementVector = new Vector3();
        animate = GetComponent<Animate>();
	}

    private void Start()
    {
        speed = inicialSpeed;
        lastHorizontalVector = -1f;
        lastVerticalVector = 1f;
    }

    public void modSpeed(int bonus)
    {
        Debug.Log("aAS");
        speed = inicialSpeed * (1 + (bonus / 100));
    }

    // Update is called once per frame
    void Update () {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        if(movementVector.x !=0)
        {
            lastHorizontalVector = movementVector.x;
        }
        if (movementVector.y != 0)
        {
            lastVerticalVector = movementVector.y;
        }

        animate.horizontal = movementVector.x;
        movementVector *= speed;

        rgbd2d.velocity = movementVector;
	}
}
