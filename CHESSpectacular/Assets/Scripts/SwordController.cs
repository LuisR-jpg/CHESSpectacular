using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    private GameObject Sword;
    public bool canAttack = true;
    public float attackTime = 0.5f;
    void Awake() { 
        Sword = GameObject.Find("PlayerSword");
    }
    public void attack() {
        if(canAttack) {
            swordAttack();
        }
    }
    private void swordAttack() {
        canAttack = false;
        Animator animation = Sword.GetComponent<Animator>();
        animation.SetTrigger("Attack");
        StartCoroutine(ResetAttackCooldown());
    }
    IEnumerator ResetAttackCooldown() {
        yield return new WaitForSeconds(attackTime);
        canAttack = true;
    }
}
