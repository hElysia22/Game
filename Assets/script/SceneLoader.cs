using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadSceneDelayed()
    {
        Invoke("LoadStartScene", 3f);
    }

    void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
