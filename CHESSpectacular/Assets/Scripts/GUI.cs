using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    PlayerController pc;
    public Sprite board;
    public Sprite heart;
    public int nItems = 5;
    void Awake() {
    }
    void Update()
    {
        DrawItems();
    }
    void DrawItems() {
        for(int i = 0; i < PlayerController.itemsCollected; i++){
            GameObject img = GameObject.Find("B" + i.ToString());
            Image b = img.GetComponent<Image>();
            b.sprite = board;
        }
        for(int i = 0; i < PlayerController.damage; i++){
            GameObject img = GameObject.Find("H" + i.ToString());
            Image b = img.GetComponent<Image>();
            b.sprite = heart;
        }
    }

}
