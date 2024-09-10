using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainmenucanvas;

    private void Start() {
        mainmenucanvas.SetActive(true);
    }
    
    public void PLayButton(string sceneName)
    {
        mainmenucanvas.SetActive(false);
        LevelManager.Instance.LoadScene(sceneName);
    }

    public void StoreButton(string sceneName)
    {
        mainmenucanvas.SetActive(false);
        LevelManager.Instance.LoadScene(sceneName);
    }

}
