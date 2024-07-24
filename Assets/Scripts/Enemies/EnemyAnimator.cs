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

    }

    public void AttackAnimation()
    {

    }
    public void DeathAnimation()
    {

    }
}
