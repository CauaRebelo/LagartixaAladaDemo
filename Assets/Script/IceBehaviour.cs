using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBehaviour : MonoBehaviour
{
    public float drag = 1f;
    public Rigidbody2D rb;
    private bool attacked = false;

    void Start()
    {

    }

    void FixedUpdate()
    {
        if (!attacked)
        {
            rb.velocity = new Vector2((rb.velocity.x * (1 - drag)), rb.velocity.y);
        }
        else
        {
            if (rb.velocity.magnitude <= 0f)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void Damage(float side)
    {
        attacked = true;
        rb.velocity = new Vector2((side * 7), rb.velocity.y);
    }
}
