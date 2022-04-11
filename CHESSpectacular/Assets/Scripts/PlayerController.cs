using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerControllers control;
    PlayerControllers.GameplayActions actions;
    private Vector2 moveVector;
    private Vector2 mouseVector;
    private Rigidbody rb;
	private Transform camT;
    private SwordController sword;
    public static int itemsCollected = 0, damage = 0, nHearts = 10;

    public float force = 10f;
    public float sensibility = 0.5f;
    private bool attack = false;
    private void Awake() { 
        control = new PlayerControllers();
        itemsCollected = 0;
        actions = control.Gameplay;
        rb = GetComponent<Rigidbody>();
        camT = transform.GetChild(0);
        sword = gameObject.AddComponent<SwordController>();
		
		actions.MoveCamera.performed += ctx => mouseVector = ctx.ReadValue<Vector2>();
        actions.Movement.performed += ctx => moveVector = ctx.ReadValue<Vector2>();
        actions.Attack.performed += ctx => attack = true;
    }
    private void OnEnable() { 
        control.Enable();
    }
    private void OnDestroy() { 
        control.Disable();
    }
    private void Update() { 
        transform.Rotate( 0f, mouseVector.x * sensibility ,0f);
		camT.Rotate( -mouseVector.y * sensibility ,0f, 0f);	
        rb.AddForce(((transform.forward * moveVector.y) + (transform.right * moveVector.x)) * force);
        if(attack) {
            attack = false;
            sword.attack();
        }
        if(transform.position.y < -200f)
            Die();
    }
    public void GotItem() {
        itemsCollected++;
    }
    private void itHurts() {
        damage++;
        if(damage >= nHearts) Die();
    }
    private void Die() {
        SceneController.ToLose();
    }
    public void OnTriggerEnter(Collider other) {
        if(other.tag == "EnemyWeapon") {
            rb.AddForce(transform.up * 5f, ForceMode.Impulse);
            itHurts();
        }
        if(other.tag == "Obstacle") {
            itHurts();
            transform.position = new Vector3(0, -75, 195);
        }
        if(other.tag == "Rook") {
            itHurts();
            transform.position = new Vector3(0, -110, 300);
        }
    }
}
