using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public void Awake()
    {
        player = GameObject.Find("Player").transform;
    }
    public void Update()
    {   
        transform.LookAt(player);    

    }
}
