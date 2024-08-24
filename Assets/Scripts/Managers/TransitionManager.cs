using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public Animator transitionBackground;
    public Animator topBlackBar;
    public GameObject bottomBlackBar;

    private void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable() {
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadScene){
        Debug.Log("Loaded");
        transitionBackground.SetBool("EnterScene", true);
    }

    private void OnSceneUnloaded(Scene scene){
        Debug.Log("Unloaded");
        transitionBackground.SetBool("EnterScene", false);
    }
}
