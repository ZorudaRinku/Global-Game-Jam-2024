using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Scene_Management : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        String[] bond = {"Town","Boss","Electric Birds","ShopIdle","Cave","Electric_Cities","Bar"};
        int random = Random.Range(0, 6);
        AudioManager.instance.PlayMusic(bond[random]); 
        
    }

    public void Quit()
    {
        Application.Quit();
    }
}
