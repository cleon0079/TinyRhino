using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // loads a scene (specified within the inspector)
    public void SceneLoad(string name)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(name);
    }
}
