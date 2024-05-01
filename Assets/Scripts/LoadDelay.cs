using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadDelay : MonoBehaviour
{
    public float delay = 3f; // Time delay in seconds
    public string sceneName; // Name of the scene to load

    void Start()
    {
        Invoke("LoadScene", delay);
    }

    void LoadScene()
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneName);
    }
}
