using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{


    public GameObject shopCanvas;

    public Material[] BallSkins;
    public GameObject shopBall;
    public TextMeshProUGUI BallSkinText;
    private int ballSkinNumber;



    public Material[] TrailSkins;
    public TextMeshProUGUI TrailSkinText;
    private int trailSkinNumber;


    public GameObject[] pages;
    public TextMeshProUGUI pagesText;
    private int pageNumber;

    public Image Health1;
    public Image Health2;
    public Image Health3;
    public Image Health4;

    private int healthLevel;
    private int cooldownLevel;
    private int restoreLevel;

    private int toplamStar;
    private int currentStar;
    private int harcananStar;
    public TextMeshProUGUI currentStarText;


    private void Awake()
    {

        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
        }


        if (PlayerPrefs.HasKey("Page"))
        {
            pageNumber = PlayerPrefs.GetInt("Page");

            for (int i = 0; i < pages.Length; i++)
            {


                if (i == pageNumber)
                {
                    pages[i].SetActive(true);

                }



            }

        }
        else
        {

            for (int i = 0; i < pages.Length; i++)
            {


                if (i == 0)
                {
                    pages[i].SetActive(true);

                }


            }

        }

        PlayerPrefs.DeleteKey("BallSkin");
        getCurrentBallSkin();


    }





    private void Start()
    {

        updateStarText();

    }


    private void Update()
    {

        getActivePage();
        pageNameChanger();
        ballMetarialChange();

    }

    public void GoToMenu(string sceneName)
    {

        shopCanvas.SetActive(false);
        LevelManager.Instance.LoadScene(sceneName);

    }

    public void getActivePage()
    {
        for (int i = 0; i < pages.Length - 1; i++)
        {

            if (pages[i].activeSelf)
            {
                PlayerPrefs.SetInt("Page", i);
                pageNumber = i;

            }

        }
    }

    public void PreviousPage()
    {


        if (!(pageNumber - 1 < 0))

        {

            pages[pageNumber].SetActive(false);

            pageNumber = pageNumber - 1;

            PlayerPrefs.SetInt("Page", pageNumber);

            pages[pageNumber].SetActive(true);


        }




    }

    public void NextPage()
    {

        if (!(pageNumber + 1 > pages.Length - 1))
        {


            pages[pageNumber].SetActive(false);

            pageNumber = pageNumber + 1;

            PlayerPrefs.SetInt("Page", pageNumber);

            pages[pageNumber].SetActive(true);


        }

    }

    private void pageNameChanger()
    {


        if (pageNumber == 0)
        {

            pagesText.text = "SHIELD";

        }

        if (pageNumber == 1)
        {

            pagesText.text = "BALL";
        }


    }

    private void ballMetarialChange()
    {
        shopBall.GetComponent<Renderer>().material = BallSkins[ballSkinNumber];
        if (ballSkinNumber == 0)
        {
            BallSkinText.text = "ICE";
            BallSkinText.color = Color.cyan;
        }
        if (ballSkinNumber == 1)
        {
            BallSkinText.text = "POISON";
            BallSkinText.color = Color.green;
        }
        if (ballSkinNumber == 2)
        {
            BallSkinText.text = "BLOOD";
            BallSkinText.color = Color.red;
        }
        if (ballSkinNumber == 3)
        {
            BallSkinText.text = "MAGIC";
            BallSkinText.color = Color.magenta;
        }
        if (ballSkinNumber == 4)
        {
            BallSkinText.text = "LAVA";
            BallSkinText.color = Color.yellow;
        }


    }

    public void NextBallSkin()
    {

        if (!(ballSkinNumber + 1 > BallSkins.Length - 1))
        {
            ballSkinNumber = ballSkinNumber + 1;
            PlayerPrefs.SetInt("BallSkin", ballSkinNumber);

        }

    }

    public void PreviousBallSkin()
    {
        if (!(ballSkinNumber - 1 < 0))
        {
            ballSkinNumber = ballSkinNumber - 1;
            PlayerPrefs.SetInt("BallSkin", ballSkinNumber);
        }

    }

    public void getCurrentBallSkin()
    {

        if (PlayerPrefs.HasKey("BallSkin"))
        {
            ballSkinNumber = PlayerPrefs.GetInt("BallSkin");


        }
        else
        {
            ballSkinNumber = 0;
            PlayerPrefs.SetInt("BallSkin", ballSkinNumber);
        }

    }

    public void NextTrailSkin()
    {


    }

    public void PreviousTrailSkin()
    {

    }

    private void StarCount()
    {
        toplamStar = 0;

        for (int i = 0; i <= 36; i++)
        {
            if (PlayerPrefs.HasKey("Level_" + i.ToString() + "_Stars"))
            {

                toplamStar = toplamStar + PlayerPrefs.GetInt("Level_" + i.ToString() + "_Stars");

            }

        }

        print(toplamStar);

    }

    public void updateStarText()
    {
        StarCount();

        currentStar = toplamStar - harcananStar;

        currentStarText.text = "7 <size=42><color=#9399a3>/ 96</size></color>";

        currentStarText.text = currentStar.ToString() + "<size=42><color=#9399a3> / " + toplamStar.ToString() + "</size></color>";


    }

     public void UpdateHealthBars()
    {

        if (PlayerPrefs.HasKey("Health"))
        {
            healthLevel = PlayerPrefs.GetInt("Health");

            if (healthLevel == 0)
            {
                Health1.color = new Color(1, 1, 1, 0);
                Health2.color = new Color(1, 1, 1, 0);
                Health3.color = new Color(1, 1, 1, 0);
                Health4.color = new Color(1, 1, 1, 0);

            }
            else if (healthLevel == 1)
            {

                Health1.color = new Color(1, 1, 1, 1);
                Health2.color = new Color(1, 1, 1, 0);
                Health3.color = new Color(1, 1, 1, 0);
                Health4.color = new Color(1, 1, 1, 0);

            }
            else if (healthLevel == 2)
            {

                Health1.color = new Color(1, 1, 1, 1);
                Health2.color = new Color(1, 1, 1, 1);
                Health3.color = new Color(1, 1, 1, 0);
                Health4.color = new Color(1, 1, 1, 0);

            }
            else if (healthLevel == 3)
            {

                Health1.color = new Color(1, 1, 1, 1);
                Health2.color = new Color(1, 1, 1, 1);
                Health3.color = new Color(1, 1, 1, 1);
                Health4.color = new Color(1, 1, 1, 0);

            }
            else if (healthLevel == 4)
            {
                Health1.color = new Color(1, 1, 1, 1);
                Health2.color = new Color(1, 1, 1, 1);
                Health3.color = new Color(1, 1, 1, 1);
                Health4.color = new Color(1, 1, 1, 1);
            }

        }
        else
        {
            PlayerPrefs.SetInt("Health", 0);
            healthLevel = 0;

            Health1.color = new Color(1, 1, 1, 0);
            Health2.color = new Color(1, 1, 1, 0);
            Health3.color = new Color(1, 1, 1, 0);
            Health4.color = new Color(1, 1, 1, 0);

        }

    }

    public void UpgradeHealthBars()
    {
        if (PlayerPrefs.HasKey("Health"))
        {
            healthLevel = PlayerPrefs.GetInt("Health");

            if (healthLevel == 0)
            {

                
            }

            
        }






    }








}
