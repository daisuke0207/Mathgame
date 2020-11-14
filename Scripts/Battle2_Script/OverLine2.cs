using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverLine2 : MonoBehaviour
{
    public GameUI2 GameUI2;
    Image LineImage;
    public GameObject LineCount;
    public Text LineCountText;
    float time = 0;
    List<string> targetsList = new List<string>();

    public AudioSource OverLineSou;
    public AudioClip CountPPSound;
    bool coundSound = false;
    public AudioClip lose_down;
    bool losedown = true;

    public GameObject EndUI;
    public GameObject audioSuc;
    public AudioSource EndAud;

    public Text bestText;
    [HideInInspector] public static float best = 0f;
    public Text scoreTimeText;

    public AudioSource BGM;

    public static string scoreKey = "SCORE_KEY";

    public GameObject NewTime;

    bool angou = true;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        targetsList.Add("1");
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        targetsList.RemoveAt(0);

        if (targetsList.Count == 0)
        {
            LineImage.color = new Color(0.5f, 0, 0, 0.5f);
            LineCount.SetActive(false);
            time = 0;
            OverLineSou.Stop();
        }
    }

    void Start()
    {
        LineImage = this.gameObject.GetComponent<Image>();
        targetsList = new List<string>();
        losedown = true;
        angou = true;
    }

    void Update()
    {
        if (GameUI2.aud_stop == "成功")
        {
            OverLineSou.Stop();
            GameUI2.aud_stop = "";
        }
        else if (targetsList.Count > 0)
        {
            time += Time.deltaTime;
            LineImage.color = new Color(1, 0, 0, 1);
            if (time >= 6f)
            {
                BGM.Stop();
                LineCountText.text = "0";
                audioSuc.SetActive(true);
                if (!EndAud.isPlaying)
                {
                    scoreTimeText.text = "今回のタイム: " + GameUI2.gametime.ToString("F2") + "秒";

                    best = PlayerPrefs.GetFloat(scoreKey, 0f);

                    if (GameUI2.gametime >= best)
                    {
                        best = GameUI2.gametime;

                        if (angou)
                        {
                            NewTime.SetActive(true);
                            bestText.text = "ベストタイム: " + best.ToString("F2") + "秒";
                            PlayerPrefs.SetFloat(scoreKey, best);

                            angou = false;
                        }
                    }
                    else
                    {
                        bestText.text = "ベストタイム: " + best.ToString("F2") + "秒";
                    }


                    EndUI.SetActive(true);
                    if (losedown)
                    {
                        EndAud.PlayOneShot(lose_down);
                        losedown = false;
                    }
                }
            }
            else if (time >= 5f)
            {
                LineCountText.text = "1";
            }
            else if (time >= 4f)
            {
                LineCountText.text = "2";
            }
            else if (time >= 3f)
            {
                LineCountText.text = "3";
            }
            else if (time >= 2f)
            {
                LineCountText.text = "4";
                if (coundSound)
                {
                    OverLineSou.PlayOneShot(CountPPSound);
                    coundSound = false;
                }
            }
            else if (time >= 1f)
            {
                LineCount.SetActive(true);
                LineCountText.text = "5";
                coundSound = true;
            }
        }
    }

}
