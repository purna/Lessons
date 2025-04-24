using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChangerScript  : MonoBehaviour
{
   
   void LoadMyScene() {
    SceneManager.LoadScene("SceneName");
    }

    void UnloadMyScene() {
        SceneManager.UnloadSceneAsync("SceneName");
    }

    void Start() {
        Scene currentScene = SceneManager.GetActiveScene(); 
        Debug.Log("Current Scene Name: " + currentScene.name);
    }
    





}
