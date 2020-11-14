using UnityEngine;
using UnityEngine.UI;

public class GameUI2 : MonoBehaviour 
{
    public Text numberText;
    public Text numberText2;

    public int clearNumber = 0;
    public int cleatNumber2 = 0;
    public float gametime = 0f;

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

    //時間のテキスト
    public Text GameScoreTimeText;

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

    public void GameTime2()
    {
        this.gametime += Time.deltaTime;
        GameScoreTimeText.text = gametime.ToString("F2");
    }

    public void BigBallGauge()
    {
        bigballGauge.GetComponent<Image>().fillAmount += 0.1f;
    }


    void Start()
    {
        Number_Random();
        Number2_Random();
    }

    void Update()
    {
        GameTime2();
    }
}

