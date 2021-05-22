using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Main : MonoBehaviour
{
    public static int Gold = 0;
    public ScorePlayFab scorePlayFab;
    public GameObject Earth;
    public Vector2 EarthPos1;
    public Vector2 EarthPos2;

    private int randomResource;
    public GameObject[] Resource;
    public GameObject This;
    public Vector3 ThisPos;
    public Vector3 DelPos;
    public Vector3 NextPos;

    public Text TextPanel;
    public Text GoldPanel;

    public Text ScoreText;
    public Text ScoreTextPanel;
    public int Score = 0;
    public static  int HighScore = 0;
    
    public Image TimerBar;
    public float maTime = 1.5f;
    public float timeLeft;

    public GameObject LosePanel;
    public GameObject GamePanel;

    public bool Proverka = false;
    public bool Proverka1;

    
    public GameObject EffectTransform;
    public GameObject Anim1;
    public GameObject Anim3;
    public GameObject Anim2;

    public GameObject Zastavka;
    public bool ZastavkaProverka;
    


    void Start()
    {
       

        //Anim1.layer = 4;
        Gold = PlayerPrefs.GetInt("Gold");
        HighScore = PlayerPrefs.GetInt("HighScore");
        timeLeft = maTime;
        Proverka1 = true;

        DelPos = new Vector3(0.0f, -1.8523f, 0.0f);
        ThisPos = This.transform.position;
        NextPos = ThisPos + DelPos;
    }

   public void Dest1()
    {
        if (randomResource == 0 || randomResource == 1 || randomResource == 2)
        {
            
            Proverka = true;
            timeLeft = 1.5f;
            
            Destroy(This);
            Instantiate(Anim1, EffectTransform.transform.position, Anim1.transform.rotation);
            randomResource = Random.Range(0, Resource.Length);
            This = Instantiate(Resource[randomResource], NextPos, Resource[randomResource].transform.rotation);
           
            ThisPos = This.transform.position;
            
            NextPos = ThisPos + DelPos;
            Score++;
            ScoreText.text = Score.ToString();

            EarthPos2 = Earth.transform.position + DelPos;
            Earth.transform.position = EarthPos2;

           
            
        }
        else Lose();
    }
    public void Dest2()
    {

        if (randomResource == 3)
        {
            timeLeft = 1.5f;
           
            Destroy(This);
            Instantiate(Anim2, EffectTransform.transform.position, Anim2.transform.rotation);
            randomResource = Random.Range(0, Resource.Length);
            This = Instantiate(Resource[randomResource], NextPos, Resource[randomResource].transform.rotation);
            ThisPos = This.transform.position;
            NextPos = ThisPos + DelPos;
            Score++;
            ScoreText.text = Score.ToString();
            EarthPos2 = Earth.transform.position + DelPos;
            Earth.transform.position = EarthPos2;
            Gold++;
            PlayerPrefs.SetInt("Gold", Gold);
        }
        else Lose();

    }
    public void Dest3()
    {
        if (randomResource == 4 || randomResource == 5 || randomResource == 6)
        {
            timeLeft = 1.5f;
           
            Destroy(This);
            Instantiate(Anim3, EffectTransform.transform.position, Anim3.transform.rotation);
            randomResource = Random.Range(0, Resource.Length);
            This = Instantiate(Resource[randomResource], NextPos, Resource[randomResource].transform.rotation);
            ThisPos = This.transform.position;
            NextPos = ThisPos + DelPos;
            Score++;
            ScoreText.text = Score.ToString();
            EarthPos2 = Earth.transform.position + DelPos;
            Earth.transform.position = EarthPos2;
        }
        else Lose();

    }
    public void Lose()
    {
        
        
        if (Score > HighScore)
        {
            Proverka1 = false;
            GamePanel.SetActive(false);
            LosePanel.SetActive(true);
             
            TextPanel.text = "Новый рекорд!";
            HighScore = Score;
            PlayerPrefs.SetInt("HighScore", HighScore);
            scorePlayFab.SendLeaderBoard(Score);
        }
        else
        {
            
            Proverka1 = false;
            GamePanel.SetActive(false);
            LosePanel.SetActive(true);
            
            TextPanel.text = "Ваш результат:";
            scorePlayFab.SendLeaderBoard(Score);
        }
    }




    void Update()
    {
        GoldPanel.text = Gold.ToString();

        ScoreTextPanel.text = Score.ToString();
        if (timeLeft > 0 && Proverka == true)
        {
            timeLeft -= Time.deltaTime;
            TimerBar.fillAmount = timeLeft / maTime;
            if (timeLeft < 0 && Proverka1 == true)
            {
                Lose();
            }
        }

    }


}
