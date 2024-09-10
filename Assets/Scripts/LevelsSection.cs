using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelsSection : MonoBehaviour
{
    public GameObject levelsCanvas;
    public GameObject[] chapters;
    public TextMeshProUGUI chapterText;
    public int chapterNumber;

    public AudioClip chapterchange;
    public AudioClip levelselected;
   

    private void Start() {

        
        
        getActiveChapter();

        for (int i = 0; i < chapters.Length-1; i++)
        {
            chapters[i].SetActive(false);
            
        }
        
        if(PlayerPrefs.HasKey("chapter"))
        {
        chapterNumber = PlayerPrefs.GetInt("chapter");
        chapters[chapterNumber].SetActive(true);
        chapterText.text = "CHAPTER " + (chapterNumber+1).ToString();
        }
        levelsCanvas.SetActive(true);


    }

    private void Update() {
        
        getActiveChapter();

    }

    public void GoToMenu(string sceneName)
    {
        //ingamecanvas.SetActive(false);
        levelsCanvas.SetActive(false);
        LevelManager.Instance.LoadScene(sceneName);

    }

    public void getActiveChapter()
    {
        for (int i = 0; i < chapters.Length-1; i++)
        {
            
            if(chapters[i].activeSelf)
            {
                PlayerPrefs.SetInt("chapter",i);
            }

        }
    }

    public void chapterToLeft()
    {


        if(!(chapterNumber - 1 < 0))

    {
        GetComponent<AudioSource>().PlayOneShot(chapterchange);
        
        chapters[chapterNumber].SetActive(false);

        chapterNumber = chapterNumber-1;

        PlayerPrefs.SetInt("chapter",chapterNumber);

        chapterText.text = "CHAPTER " + (chapterNumber+1).ToString();

        
        chapters[chapterNumber].SetActive(true);

        
    }

        


    }

    public void chapterToRight()
    {

        if(!(chapterNumber + 1 > chapters.Length-1))

    {

        GetComponent<AudioSource>().PlayOneShot(chapterchange);
        
        chapters[chapterNumber].SetActive(false);

        chapterNumber = chapterNumber+1;

        PlayerPrefs.SetInt("chapter",chapterNumber);

        chapterText.text = "CHAPTER " + (chapterNumber+1).ToString();

        
        chapters[chapterNumber].SetActive(true);

        
    }
    
    }

    public void levelSelect(string sceneName)
    {
        
        GetComponent<AudioSource>().PlayOneShot(levelselected);
        levelsCanvas.SetActive(false);
        LevelManager.Instance.LoadScene(sceneName);
    }





}
