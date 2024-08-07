using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnEnable : MonoBehaviour
{
[Header("Next Scene Name")]
    public string sceneName;

    void OnEnable()
    {
      SceneManager.LoadSceneAsync(sceneName);  
    }
}
