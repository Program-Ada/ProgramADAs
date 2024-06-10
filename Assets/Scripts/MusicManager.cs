using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
   }
}
