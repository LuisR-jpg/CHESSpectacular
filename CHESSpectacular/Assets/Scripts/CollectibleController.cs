﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CollectibleController : MonoBehaviour
{
    Rigidbody rb;
    Collider cl;
    GameObject go;
    private float speed = 0.5f;
    private float wait = 0.75f;
    void Start() {
        rb = GetComponent<Rigidbody>();
        cl = GetComponent<Collider>();
        go = GameObject.Find("PickupBoard");
        StartCoroutine(Float());
    }
    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player") {
            go.SetActive(false);
            PlayerController player = gameObject.AddComponent<PlayerController>();
            player.GotItem();
        }
    }
    IEnumerator Float() {
        int sgn = 1;
        for(;;){
            rb.velocity = new Vector3(0, speed*sgn, 0);
            yield return new WaitForSeconds(wait);
            sgn *= -1;
        }
    }
}
