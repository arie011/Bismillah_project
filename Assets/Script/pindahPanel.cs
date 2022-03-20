using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pindahPanel : MonoBehaviour
{
    public AudioSource buttonSound;
    public GameObject PanelAwal;
    public GameObject PanelTujuan;
    public void PanelBaru()
    {
        buttonSound.PlayOneShot(buttonSound.clip);
        PanelAwal.SetActive(false);
        PanelTujuan.SetActive(true);
    }
}
