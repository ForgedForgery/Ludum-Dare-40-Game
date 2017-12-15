using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class TestPlayerEvents : MonoBehaviour
{
    private Transform player;

    public delegate void PlayerEvents();
    public static event PlayerEvents onPlayerLand;
    
    private void Start()
    {
        player = GetComponent<Transform>();
    }
    
    private void FixedUpdate()
    {

    }

    private void checkForPlayerLand()
    {
        if (player.position.y <= 0.5f)
        {
            onPlayerLand();
        }
    }
}
