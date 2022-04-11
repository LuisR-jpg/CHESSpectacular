using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CollectibleController : MonoBehaviour
{
    Rigidbody rb;
    Collider cl;
    GameObject go;
    public GameObject door;
    public GameObject nScene;
    public PlayerController player;
    private float speed = 0.5f;
    private float wait = 0.75f;
    public bool startsActive;
    void Start() {
        door.SetActive(startsActive);
        if(nScene != null) nScene.SetActive(false);
        rb = GetComponent<Rigidbody>();
        cl = GetComponent<Collider>();
        StartCoroutine(Float());
    }
    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player") {
            player.GotItem();
            door.SetActive(!startsActive);
            if(nScene != null) nScene.SetActive(true);
            Destroy(this.gameObject);
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
