using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public GameObject panel;

    public void UnloadScene(string sceneName)
    {
        Debug.Log(sceneName);
        //SceneManager.UnloadScene(sceneName);
    }

}
