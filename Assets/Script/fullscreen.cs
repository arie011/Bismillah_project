using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fullscreen : MonoBehaviour
{
    public void fullscreenOnOff()
    {
        if(Screen.fullScreen == true)
        {
            Screen.fullScreen = false;
        }
        else
        {
            Screen.fullScreen = true;
        }
    }
}
