using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
   public AudioSource src;
   public AudioClip correct_sfx, wrong_sfx, confirm_sfx, cancel_sfx;
   public static SoundManager sm;

   void Awake(){
     sm = this;
     src = GetComponent<AudioSource>();
   }

   public void Correct(){
        src.clip = correct_sfx;
        src.Play();
   } 

    public void Wrong(){
        src.clip = wrong_sfx;
        src.Play();
   } 

    public void Click(){
        src.clip = confirm_sfx;
        src.Play();
   } 

       public void Cancel(){
        src.clip = cancel_sfx;
        src.Play();
   } 
}
