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
        print(PlayerController.itemsCollected);
        for(int i = 0; i < PlayerController.itemsCollected; i++){
            print("B" + i.ToString());
            GameObject img = GameObject.Find("B" + i.ToString());
            print(img);
            Image b = img.GetComponent<Image>();
            b.sprite = board;
            print(b);
        }
    }

}
