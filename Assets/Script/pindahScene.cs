using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pindahScene : MonoBehaviour
{
        public AudioSource buttonSound;
        public string namaScene;
        public void SceneBaru()
        {
            AudioSource ButtonSound = buttonSound.GetComponent<AudioSource> ();
            buttonSound.PlayOneShot(buttonSound.clip); 
            Scene sceneIni = SceneManager.GetActiveScene ();

            if(sceneIni.name != namaScene)
            {
                SceneManager.LoadScene (namaScene);
            }
        }
}
