using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    public void WalkAnimation()
    {
        _anim.SetTrigger("Walk");
    }

    public void AttackAnimation()
    {
        _anim.SetTrigger("Attack");
    }
    public void DeathAnimation()
    {
        _anim.SetTrigger("Death");
    }
}
