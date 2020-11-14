using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour 
{ 
    public Text numberText; 
    public Text numberText2;

    public int clearNumber = 0;
    public int cleatNumber2 = 0;
    float gametime = 0f;

    public AudioSource ButtonAudio;
    public AudioClip NormalButton;
    public AudioSource BGM;

    public GameObject TimeGauge;
    float fillgame = 0;

    public GameObject bigballGauge;

    public GameObject EndUI;
    public GameObject audioSuc;
    public AudioSource EndAud;
    public AudioClip clear_up;
    bool clearup = true;
    public Text judgetext;

    

    public static string aud_stop = "";

    public static string clearjudge = "0";


    public void Number_Random()
    {
        clearNumber = Random.Range(10, 16);
        numberText.text = clearNumber.ToString();
    }
    public void Number2_Random()
    {
        cleatNumber2 = Random.Range(16, 21);
        numberText2.text = cleatNumber2.ToString();
    }
    public void ChangeButton()
    {
        ButtonAudio.PlayOneShot(NormalButton);
        clearNumber = Random.Range(10, 16);
        cleatNumber2 = Random.Range(16, 21);
        numberText.text = clearNumber.ToString();
        numberText2.text = cleatNumber2.ToString();
    }

    public void GameTime() 
    {
        this.gametime += Time.deltaTime;

        if (gametime >= fillgame)
        {
            for (int i = 0; i < 1; i++)
            {
                TimeGauge.GetComponent<Image>().fillAmount += 0.025f; 
                fillgame += 1f;
            }
            if(gametime >= 39.5f)
            {
                gametime = 0;
            }
        }
        else if(gametime + 5 < fillgame)
        {
            BGM.Stop();
            aud_stop = "成功";
            judgetext.text = "レベル" + ModeLevel.Level_number + "クリア";
            clearjudge = ModeLevel.Level_number;
            audioSuc.SetActive(true);
            if (!EndAud.isPlaying)
            {
                EndUI.SetActive(true);
                if (clearup)
                {
                    EndAud.PlayOneShot(clear_up);
                    clearup = false;
                }
            }
        }
    }
    public void BigBallGauge()
    {
        bigballGauge.GetComponent<Image>().fillAmount += 0.1f;
    }

    
    void Start()
    {
        Number_Random();
        Number2_Random();
        clearup = true;
    }

    void Update()
    {
        GameTime();
    }
}
