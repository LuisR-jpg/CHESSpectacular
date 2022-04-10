using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 2.5f, offset = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(Obstacle());
    }
    IEnumerator Obstacle() {
        yield return new WaitForSeconds(offset);
        while(true) {
            rb.velocity = new Vector3(0f, speed, 0);
            yield return new WaitUntil(() => transform.position.y > -72);
            rb.velocity = new Vector3(0f, -2*speed, 0);
            yield return new WaitUntil(() => transform.position.y <= -80);
        }
    }
}
