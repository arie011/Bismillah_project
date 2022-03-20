using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keluar : MonoBehaviour
{
        public AudioSource buttonSound;
        public void KeluarGame()
        {
            AudioSource ButtonSound = buttonSound.GetComponent<AudioSource> ();
            buttonSound.PlayOneShot(buttonSound.clip); 
            Application.Quit();
        }

}
