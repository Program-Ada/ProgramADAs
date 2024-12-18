using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioSource src;
    public static MusicManager mm;
   void Awake(){
		if(mm != null){
			Destroy(this.gameObject);
			return;
		}
    	DontDestroyOnLoad(this.gameObject);
		mm = this; 
		src = GetComponent<AudioSource>();
		src.Play();
   }
  
	private void OnEnable(){
    	SceneManager.sceneLoaded += OnSceneLoaded;
  	}

    private void OnSceneLoaded(Scene scene, LoadSceneMode arg1)
    {
		if(scene.name == "InicialCutscene"){ // adicionar aqui o do minigame
			src.Stop();
		}else if(!src.isPlaying){
			src.Play();
		}
    }
}
