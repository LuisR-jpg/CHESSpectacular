using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class RookController : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 4.8f, offset = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(Move());
    }
    IEnumerator Move() {
        yield return new WaitForSeconds(offset);
        float cZ;
        while(true) {
            cZ = transform.position.z;
            rb.velocity = new Vector3(0f, 0f, -speed);
            yield return new WaitUntil(() => Math.Abs(transform.position.z - cZ) >= 4.8f);
            rb.velocity = new Vector3(0f, 0f, 0f);
            yield return new WaitForSeconds(12 - 2*offset);
            cZ = transform.position.z;
            rb.velocity = new Vector3(0f, 0f, speed);
            yield return new WaitUntil(() => Math.Abs(transform.position.z - cZ) >= 4.8);
            rb.velocity = new Vector3(0f, 0f, 0f);
            yield return new WaitForSeconds(2*offset);
        }
    }
}
