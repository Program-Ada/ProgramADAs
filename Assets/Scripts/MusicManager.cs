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
     if(DataPersistenceManager.Instance.lastScene != "Inicial_Cutscene"){
        mm = this; 
        src = GetComponent<AudioSource>();
     }
   }
}
