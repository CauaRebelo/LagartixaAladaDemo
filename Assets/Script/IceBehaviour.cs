using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IceBehaviour : MonoBehaviour
{
    public float drag = 1f;
    public Rigidbody2D rb;
    private bool attacked = false;
    private float liveTime = 10f;

    [field: SerializeField]
    public UnityEvent<bool> OnDeath { get; set; }

    void Start()
    {
        EventSystem.current.onIceSummon += OnIceSummon;
    }

    void FixedUpdate()
    {
        if (!attacked)
        {
            liveTime -= Time.deltaTime;
            rb.velocity = new Vector2((rb.velocity.x * (1 - drag)), rb.velocity.y);
        }
        else
        {
            if (rb.velocity.magnitude <= 0f)
            {
                OnDeath?.Invoke(true);
            }
        }
        if(liveTime <= 0f)
        {
            OnDeath?.Invoke(true);
        }
    }

    public void Damage(float side)
    {
        OnDeath?.Invoke(false);
        attacked = true;
        rb.velocity = new Vector2((side * 7), rb.velocity.y);
    }

    public void OnIceSummon()
    {
        OnDeath?.Invoke(true);
    }
}
