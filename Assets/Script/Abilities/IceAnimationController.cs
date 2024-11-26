using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceAnimationController : MonoBehaviour
{
    [SerializeField] private Animator agentAnimator;
    // Start is called before the first frame update
    private void SetDeathAnimation(bool val)
    {
        agentAnimator.SetBool("Death", val);
    }

    public void AnimateDeath(bool val)
    {
        SetDeathAnimation(val);
    }

    public void EndDestroy()
    {
        Destroy(this.gameObject);
    }
}
