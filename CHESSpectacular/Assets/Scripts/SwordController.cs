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
        Sword.tag = "Untagged";
    }
    public void attack() {
        if(canAttack) {
            swordAttack();
        }
    }
    private void swordAttack() {
        canAttack = false;
        Sword.tag = "Weapon";
        Animator animation = Sword.GetComponent<Animator>();
        animation.SetTrigger("Attack");
        StartCoroutine(ResetAttackCooldown());
    }
    IEnumerator ResetAttackCooldown() {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(attackTime);
        canAttack = true;
    }
    IEnumerator ResetAttackBool() {
        yield return new WaitForSeconds(1);
        Sword.tag = "Untagged";
    }
}
