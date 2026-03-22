using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStartScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void loadScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
