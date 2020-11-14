using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTouch : MonoBehaviour
{
    public GameUI GameUI;
    public BallDirecotr BallDirecotr;
    private string targetName = "";
    private GameObject firstBall; 
    private GameObject lastBall;
    List<GameObject> removeBallList = new List<GameObject>();
    List<int> removeBallSum = new List<int>();


    private int ballSum = 0;
    private int Number = 0;

    public AudioSource BallAudio;
    public AudioClip BallSound;
    public AudioClip BigballSound;
    public AudioClip DeleteBallSound;

    public GameObject bigball;


    //エフェクト
    public GameObject Bigeffect;
    public GameObject Balleffect;
    GameObject Deseffect;

    bool o = true;

    private void PushToList(GameObject hitObj, int Number)
    {
        BallAudio.PlayOneShot(BallSound);
        if (targetName == "Ball1(Clone)") { Number = 1; }
        else if (targetName == "Ball2(Clone)") { Number = 2; }
        else if (targetName == "Ball3(Clone)") { Number = 3; }
        else if (targetName == "Ball4(Clone)") { Number = 4; }
        else if (targetName == "Ball5(Clone)") { Number = 5; }
        else if (targetName == "Ball6(Clone)") { Number = 6; }
        else if (targetName == "Ball7(Clone)") { Number = 7; }
        else if (targetName == "Ball8(Clone)") { Number = 8; }
        else if (targetName == "Ball9(Clone)") { Number = 9; }
        removeBallList.Add(hitObj);
        removeBallSum.Add(Number);
        ColorChange(hitObj, 0.3f);
    }

    private void ColorChange(GameObject hitObj, float transparency)
    {
        Image image = hitObj.GetComponent<Image>();
        image.color = new Color(1, 1, 1, transparency);
    }


    private void OnClickFirst()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero); 
        if(hit.collider != null)
        {
            GameObject hitObj = hit.collider.gameObject;
            targetName = hitObj.name;
            if (targetName.StartsWith("Ball"))
            {
                firstBall = hitObj;
                lastBall = hitObj;

                removeBallList = new List<GameObject>();
                removeBallSum = new List<int>();
                PushToList(hitObj, Number);
            }
            else if (targetName.StartsWith("BigBall"))      
            {
                GameObject[] targets = GameObject.FindGameObjectsWithTag("Ball");
                BallAudio.PlayOneShot(BigballSound);
                Destroy(hitObj);

                Deseffect = Instantiate(Bigeffect, hitObj.transform.position, hitObj.transform.rotation) as GameObject;

                for (int i = 0; i < targets.Length; i++)
                {
                    float distance = Vector2.Distance(hitObj.transform.position, targets[i].transform.position);
                    if(distance < 1.5f)
                    {
                        Destroy(targets[i]);
                    }
                }
            }
        }
    }
    private void OnClicking()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if(hit.collider != null)
        {
            GameObject hitObj = hit.collider.gameObject;
            targetName = hitObj.name;
            if(lastBall != hitObj && removeBallList.Contains(hitObj) == false && targetName.StartsWith("Ball"))
            {
                float distance = Vector2.Distance(hitObj.transform.position, lastBall.transform.position);
                if(distance < 1.2f)
                {
                    lastBall = hitObj;
                    PushToList(hitObj, Number);
                }
            }
        }
    }
    private IEnumerator OnClickEnd()
    {
        o = false;
        int remove_cnt = removeBallList.Count;
        ballSum = removeBallSum.Sum();
        if(ballSum == GameUI.clearNumber || ballSum == GameUI.cleatNumber2)
        {
            for (int i = 0; i < remove_cnt; i++)
            {
                BallAudio.PlayOneShot(DeleteBallSound);
                Deseffect = Instantiate(Balleffect, removeBallList[i].transform.position, transform.rotation) as GameObject;
                Destroy(removeBallList[i]);         
                GameUI.BigBallGauge();
                if (GameUI.bigballGauge.GetComponent<Image>().fillAmount >= 1)
                {
                    BallDirecotr.DropBigball(bigball, lastBall);
                    GameUI.bigballGauge.GetComponent<Image>().fillAmount = 0;
                }
                yield return new WaitForSeconds(0.05f);
                Destroy(Deseffect);
            }
            if(ballSum == GameUI.clearNumber) { GameUI.Number_Random(); }
            else if(ballSum == GameUI.cleatNumber2) { GameUI.Number2_Random(); }
        }
        else
        {
            for(int i = 0; i < remove_cnt; i++)
            {
                ColorChange(removeBallList[i], 1.0f);
            }
        }
        ballSum = 0;
        firstBall = null;
        lastBall = null;
        Destroy(Deseffect);
        o = true;
    }

    void Start()
    {
        o = true;
    }

    void Update()
    {
        if (o)
        {
            if (Input.GetMouseButtonDown(0) && firstBall == null)
            {
                OnClickFirst();
            }
            else if (Input.GetMouseButton(0) && firstBall)
            {
                OnClicking();
            }
            else if (Input.GetMouseButtonUp(0) && firstBall)
            {
                StartCoroutine(OnClickEnd());
            }
        }
    }
}
