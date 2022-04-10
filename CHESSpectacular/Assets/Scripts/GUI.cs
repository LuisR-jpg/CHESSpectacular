using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    PlayerController pc;
    public Sprite board;
    public int nItems = 5;
    public Image[] images;
    void Awake() {
    }
    void Update()
    {
        DrawItems();
    }
    void DrawItems() {
        for(int i = 0; i < PlayerController.itemsCollected; i++){
            Image imageChild = transform.GetChild(i).GetComponent<Image>();
            print(imageChild);
            imageChild.sprite = board; 
        }
    }

}
