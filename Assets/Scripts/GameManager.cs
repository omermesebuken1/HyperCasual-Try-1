using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;
using TMPro;


public class GameManager : MonoBehaviour
{
    public GameObject ingamecanvas;
    public GameObject settings;
    public GameObject TapToExitThing;

    public GameObject musicOnButton;
    public GameObject musicOffButton;
    public GameObject SFXOnButton;
    public GameObject SFXOffButton;
    public GameObject musicFill;
    public GameObject SFXFill;

    private Slider musicSlider;
    private Slider SFXSlider;
    private float musicFillValue;
    private float SFXFillValue;

    public GameObject EndGame;
    

    private string activeSceneNumber;


    // Getting Stars
    [Header("Stars")]
    public GameObject finishPopUp;
    private float timer;
    public float star1;
    public float star2;
    public float star3;
    private float zeroStar;
    public TextMeshProUGUI TimeText;
    public TextMeshProUGUI BestTimeText;
    public Image star1gui;
    public Image star2gui;
    public Image star3gui;
    



    private void Awake()
    {

        ingamecanvas.SetActive(true);
        musicSlider = musicFill.GetComponent<Slider>();
        SFXSlider = SFXFill.GetComponent<Slider>();
        settings.SetActive(false);
        finishPopUp.SetActive(false);
        TapToExitThing.SetActive(false);

    }

    private void Update()
    {
        if (settings.activeSelf)
        {
            MusicSliderValueChanged();
            SFXSliderValueChanged();
        }
         
       
        checkLevelID();
        CheckGameEnded();
        levelTimer();
        UpdateTimeAndStars();
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void openSettings()
    {

        settings.SetActive(true);
        TapToExitThing.SetActive(true);

    }




    // Settings

    public void GoToMenu(string sceneName)
    {
        ingamecanvas.SetActive(false);
        LevelManager.Instance.LoadScene(sceneName);

    }

    public void TaptoExit() //close settings
    {


        settings.SetActive(false);
        TapToExitThing.SetActive(false);



    }

    public void OpenLevels(string sceneName)
    {
        ingamecanvas.SetActive(false);
        LevelManager.Instance.LoadScene(sceneName);

    }

    // settings music and SFX

    public void muteMusic()
    {
        if (musicSlider.value > 0)
        {
            PlayerPrefs.SetFloat("musicSlider", musicSlider.value);
        }


        musicOnButton.SetActive(false);
        musicOffButton.SetActive(true);

        musicSlider.value = 0;

    }

    public void unmuteMusic()
    {
        if (PlayerPrefs.HasKey("musicSlider"))
        {
            musicFillValue = PlayerPrefs.GetFloat("musicSlider");
        }
        musicSlider.value = musicFillValue;
        musicOffButton.SetActive(false);
        musicOnButton.SetActive(true);

    }

    public void muteSFX()
    {
        if (SFXSlider.value > 0)
        {
            PlayerPrefs.SetFloat("SFXSlider", SFXSlider.value);
        }

        SFXOnButton.SetActive(false);
        SFXOffButton.SetActive(true);

    }

    public void unmuteSFX()
    {
        if (PlayerPrefs.HasKey("SFXSlider"))
        {
            SFXFillValue = PlayerPrefs.GetFloat("SFXSlider");
        }
        SFXSlider.value = SFXFillValue;
        SFXOffButton.SetActive(false);
        SFXOnButton.SetActive(true);
    }

    public void MusicSliderValueChanged()
    {
        if (musicSlider.value > 0)
        {
            musicOffButton.SetActive(false);
            musicOnButton.SetActive(true);
        }
        else
        {
            musicOffButton.SetActive(true);
            musicOnButton.SetActive(false);
        }
    }

    public void SFXSliderValueChanged()
    {
        if (SFXSlider.value > 0)
        {
            SFXOffButton.SetActive(false);
            SFXOnButton.SetActive(true);
        }
        else
        {
            SFXOffButton.SetActive(true);
            SFXOnButton.SetActive(false);
        }
    }


    //End Game

    public void CheckGameEnded()
    {
        if (EndGame.GetComponent<Finish>().ended)
        {
            finishPopUp.SetActive(true);
        }
    }

    public void GoToNextLevel()
    {
        

        if (PlayerPrefs.HasKey("sceneNumber"))
        {
            int newScene = PlayerPrefs.GetInt("sceneNumber") + 1;
            ingamecanvas.SetActive(false);
            LevelManager.Instance.LoadScene(newScene.ToString());

        }

    }

    public void checkLevelID(){

        activeSceneNumber = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetInt("sceneNumber", int.Parse(activeSceneNumber));
    }


    private void levelTimer()
    {
        if (FindObjectOfType<PlayerEnter>().isEnter && !FindObjectOfType<Finish>().ended)
        {
            timer += Time.deltaTime;
            //print(timer);
            
            
        }


    }

    private void Stars()
    {
        
        
        if (timer < star3)
        {
            PlayerPrefs.SetInt("Level_" + SceneManager.GetActiveScene().name + "_Stars", 3);

            star1gui.color = new Color(1, 1, 1, 1);
            star2gui.color = new Color(1, 1, 1, 1);
            star3gui.color = new Color(1, 1, 1, 1);

        }
        else if (timer < star2)
        {
            PlayerPrefs.SetInt("Level_" + SceneManager.GetActiveScene().name + "_Stars", 2);

            star1gui.color = new Color(1, 1, 1, 1);
            star2gui.color = new Color(1, 1, 1, 1);
            star3gui.color = new Color(1, 1, 1, 0.5f);

        }
        else if (timer < star1)
        {
            PlayerPrefs.SetInt("Level_" + SceneManager.GetActiveScene().name + "_Stars", 1);

            star1gui.color = new Color(1, 1, 1, 1);
            star2gui.color = new Color(1, 1, 1, 0.5f);
            star3gui.color = new Color(1, 1, 1, 0.5f);
        }
        else
        {
            PlayerPrefs.SetInt("Level_" + SceneManager.GetActiveScene().name + "_Stars", 0);

            star1gui.color = new Color(1, 1, 1, 0.5f);
            star2gui.color = new Color(1, 1, 1, 0.5f);
            star3gui.color = new Color(1, 1, 1, 0.5f);

        }


    }

    private void UpdateTimeAndStars()
    {

        //time and best time

        timer = Mathf.Round(timer * 1000.0f) * 0.001f;

        if (FindObjectOfType<Finish>().ended)
        {

            PlayerPrefs.SetFloat("Level_" + SceneManager.GetActiveScene().name + "_Time", timer);

            

            TimeText.text = "Time: " + timer.ToString(); 

            if (PlayerPrefs.HasKey("Level_" + SceneManager.GetActiveScene().name + "_BestTime"))
            {
                var BestTime = PlayerPrefs.GetFloat("Level_" + SceneManager.GetActiveScene().name + "_BestTime");

                if (BestTime > timer)
                {

                    PlayerPrefs.SetFloat("Level_" + SceneManager.GetActiveScene().name + "_BestTime", timer);
                    BestTimeText.text = "Best: " + timer.ToString();
                    Stars();

                }
                else
                {
                    BestTimeText.text = "Best: " + BestTime.ToString();
                }

            }
            else
            {
                PlayerPrefs.SetFloat("Level_" + SceneManager.GetActiveScene().name + "_BestTime", timer);
                Stars();

            }

            //stars

        

            



        }

    }











}
