using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public static TransitionManager Instance { get; private set;}
    public Animator transitionBackground;
    public GameObject topBlackBar;
    public GameObject bottomBlackBar;

    private void Awake() {
        Instance = this;
        PlayEnterSceneAnimation();
    }

    public void PlayEnterSceneAnimation(){
        transitionBackground.SetBool("EnterScene", true);

        if(DataPersistenceManager.Instance.lastScene == "InicialCutscene"){
            topBlackBar.SetActive(true);
            bottomBlackBar.SetActive(true);

            StartCoroutine(WaitAnimationEnd(false,""));
            topBlackBar.GetComponent<Animator>().SetBool("Open", true);
            bottomBlackBar.GetComponent<Animator>().SetBool("Open", true);
        }
    }

    public void PlayExitSceneAnimation(string SceneName){
        transitionBackground.SetBool("EnterScene", false);
        StartCoroutine(WaitAnimationEnd(true,SceneName));
    }

    IEnumerator WaitAnimationEnd(bool ChangeScene, string SceneName)
    {
        yield return new WaitForSeconds(2);

        if(ChangeScene){
            SceneManager.LoadScene(SceneName);
        }
    }
}
