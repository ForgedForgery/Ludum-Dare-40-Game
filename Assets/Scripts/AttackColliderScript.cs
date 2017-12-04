using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackColliderScript : MonoBehaviour
{
    [SerializeField]
    private float activeTime = 1f;

    private float timer;

    public delegate void AttackHitEvent(Collider target);
    public AttackHitEvent onSlimeHit;

    private void OnEnable()
    {
        timer = activeTime;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Slime")
        {
            onSlimeHit(other);
        }
    }
}
