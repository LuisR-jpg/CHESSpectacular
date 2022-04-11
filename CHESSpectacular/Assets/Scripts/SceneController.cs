using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController: MonoBehaviour
{
    public void ToPlay(){
        SceneManager.LoadScene("First");
    }
    public void ToMenu(){
        SceneManager.LoadScene("Menu");
    }
    public static void ToLose(){
        SceneManager.LoadScene("Lost");
    }
    public static void ToWin(){
        SceneManager.LoadScene("Won");
    }
    public void Exit(){
        Application.Quit();
    }
}