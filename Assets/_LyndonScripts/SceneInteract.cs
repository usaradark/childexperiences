using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInteract : MonoBehaviour

{
    public GameObject[] persistantObjects;
    private void Awake()
    {
        for (int i = 0; i < persistantObjects.Length; ++i)
        {
            if(persistantObjects[i].gameObject != null)
            {
                DontDestroyOnLoad(persistantObjects[i]);
            }
        }

    }
    

    public void load(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
