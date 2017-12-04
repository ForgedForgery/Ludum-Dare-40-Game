using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackSystem : MonoBehaviour
{
    private Animator anim;

    [SerializeField]
    private GameObject normalSwingCollider;

    [SerializeField]
    private float normalSwingCDMax = 2f;

    private float normalSwingCD = 0f;

    private void Start()
    {
        anim = GetComponent<Animator>();
        normalSwingCollider.GetComponent<AttackColliderScript>().onSlimeHit += damageSlime;
    }

    private void damageSlime(Collider target)
    {
        Destroy(target.gameObject);
    }

    private void Update()
    {
        tickCooldowns();
        checkPlayerLeftClick();
    }

    private void tickCooldowns()
    {
        if (normalSwingCD > 0f)
            normalSwingCD -= Time.deltaTime;
    }

    private void checkPlayerLeftClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            doSwingAttack();
        }
    }

    private void doSwingAttack()
    {
        if (normalSwingCD <= 0f)
        {
            anim.SetTrigger("swingAttack");
            normalSwingCD = normalSwingCDMax;
            normalSwingCollider.SetActive(true);
        }
    }
}
