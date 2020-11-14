using UnityEngine;
using UnityEngine.UI;

public class ModeLevel : MonoBehaviour 
{
    public GameObject ModeUi;
    public static string Level_number = "タイム";
    private const string Modekey = "MODE_SELECT";

    public AudioSource ModeSelectAud;
    public AudioClip ModeSelectSnd;
    bool select = true;
    bool mode = true;

    public Text modelevel;
    private GameObject ObjGet;

    static string objIm;
    private const string objImKey = "IMA1_10";

    public void ModeButton()
    {
        ModeSelectAud.PlayOneShot(ModeSelectSnd);
        ModeUi.SetActive(true);
    }

    public void Level1()
    {
        if (select)
        {
            select = false;
            Level_number = "1"; 
            modelevel.text = "レベル1";

            ModeSelectAud.PlayOneShot(ModeSelectSnd);
            mode = false;
        }
    }
    public void Level2()
    {
        if (select)
        {
            select = false;
            Level_number = "2"; 
            modelevel.text = "レベル2";

            ModeSelectAud.PlayOneShot(ModeSelectSnd);
            mode = false;
        }
    }
    public void Level3()
    {
        if (select)
        {
            select = false;
            Level_number = "3"; 
            modelevel.text = "レベル3";

            ModeSelectAud.PlayOneShot(ModeSelectSnd);
            mode = false;
        }
    }
    public void Level4()
    {
        if (select)
        {
            select = false;
            Level_number = "4"; 
            modelevel.text = "レベル4";

            ModeSelectAud.PlayOneShot(ModeSelectSnd);
            mode = false;
        }
    }
    public void Level5()
    {
        if (select)
        {
            select = false;
            Level_number = "5"; 
            modelevel.text = "レベル5";

            ModeSelectAud.PlayOneShot(ModeSelectSnd);
            mode = false;
        }
    }
    public void Level6()
    {
        if (select)
        {
            select = false;
            Level_number = "6"; 
            modelevel.text = "レベル6";

            ModeSelectAud.PlayOneShot(ModeSelectSnd);
            mode = false;
        }
    }
    public void Level7()
    {
        if (select)
        {
            select = false;
            Level_number = "7";
            modelevel.text = "レベル7";

            ModeSelectAud.PlayOneShot(ModeSelectSnd);
            mode = false;
        }
    }
    public void Level8()
    {
        if (select)
        {
            select = false;
            Level_number = "8"; 
            modelevel.text = "レベル8";

            ModeSelectAud.PlayOneShot(ModeSelectSnd);
            mode = false;
        }
    }
    public void Level9()
    {
        if (select)
        {
            select = false;
            Level_number = "9"; 
            modelevel.text = "レベル9";

            ModeSelectAud.PlayOneShot(ModeSelectSnd);
            mode = false;
        }
    }
    public void Level10()
    {
        if (select)
        {
            select = false;
            Level_number = "10"; 
            modelevel.text = "レベル10";

            ModeSelectAud.PlayOneShot(ModeSelectSnd);
            mode = false;
        }
    }
    public void LevelTime()
    {
        if (select)
        {
            select = false;
            Level_number = "タイム";
            modelevel.text = "タイム";

            ModeSelectAud.PlayOneShot(ModeSelectSnd);
            mode = false;
        }
    }


    void Start()
    {
        Level_number = PlayerPrefs.GetString(Modekey, "タイム");
        if(Level_number != "タイム")
        {
            modelevel.text = "レベル" + Level_number;
        }
        if(Level_number == "タイム")
        {
            modelevel.text = "タイム";
        }

        objIm = PlayerPrefs.GetString(objImKey);

        if (GameUI.clearjudge == "1" && !objIm.Contains("1")) {  objIm += "1,"; }
        else if (GameUI.clearjudge == "2"&&!objIm.Contains("2")) { objIm += "2,";}
        else if (GameUI.clearjudge == "3"&&!objIm.Contains("3")) { objIm += "3,";}
        else if (GameUI.clearjudge == "4"&&!objIm.Contains("4")) { objIm += "4,";}
        else if (GameUI.clearjudge == "5"&&!objIm.Contains("5")) { objIm += "5,";}
        else if (GameUI.clearjudge == "6"&&!objIm.Contains("6")) { objIm += "6,";}
        else if (GameUI.clearjudge == "7"&&!objIm.Contains("7")) { objIm += "7,";}
        else if (GameUI.clearjudge == "8"&&!objIm.Contains("8")) { objIm += "8,";}
        else if (GameUI.clearjudge == "9"&&!objIm.Contains("9")) { objIm += "9,"; }
        else if (GameUI.clearjudge == "10"&& !objIm.Contains("10")) { objIm += "10,"; }
        PlayerPrefs.SetString(objImKey, objIm);
        PlayerPrefs.Save();
        
        if (objIm.Contains("1")) {ObjGet = GameObject.Find("Level1"); ObjGet = GameObject.Find("Level1"); ObjGet.GetComponent<Image>().color = new Color(0, 0, 1, 1); }
        if (objIm.Contains("2")) {ObjGet = GameObject.Find("Level2"); ObjGet = GameObject.Find("Level2"); ObjGet.GetComponent<Image>().color = new Color(0, 0, 1, 1); }
        if (objIm.Contains("3")) {ObjGet = GameObject.Find("Level3"); ObjGet = GameObject.Find("Level3"); ObjGet.GetComponent<Image>().color = new Color(0, 0, 1, 1); }
        if (objIm.Contains("4")) {ObjGet = GameObject.Find("Level4"); ObjGet = GameObject.Find("Level4"); ObjGet.GetComponent<Image>().color = new Color(0, 0, 1, 1); }
        if (objIm.Contains("5")) {ObjGet = GameObject.Find("Level5"); ObjGet = GameObject.Find("Level5"); ObjGet.GetComponent<Image>().color = new Color(0, 0, 1, 1); }
        if (objIm.Contains("6")) {ObjGet = GameObject.Find("Level6"); ObjGet = GameObject.Find("Level6"); ObjGet.GetComponent<Image>().color = new Color(0, 0, 1, 1); }
        if (objIm.Contains("7")) {ObjGet = GameObject.Find("Level7"); ObjGet = GameObject.Find("Level7"); ObjGet.GetComponent<Image>().color = new Color(0, 0, 1, 1); }
        if (objIm.Contains("8")) {ObjGet = GameObject.Find("Level8"); ObjGet = GameObject.Find("Level8"); ObjGet.GetComponent<Image>().color = new Color(0, 0, 1, 1); }
        if (objIm.Contains("9")) {ObjGet = GameObject.Find("Level9"); ObjGet = GameObject.Find("Level9"); ObjGet.GetComponent<Image>().color = new Color(0, 0, 1, 1); }
        if (objIm.Contains("10")) { ObjGet = GameObject.Find("Level10"); ObjGet = GameObject.Find("Level10"); ObjGet.GetComponent<Image>().color = new Color(0, 0, 1, 1); }
    }


    void Update()
    {
        if (mode == false) //!ModeSelectAud.isPlaying
        {
            select = true;
            ModeUi.SetActive(false);
            PlayerPrefs.SetString(Modekey, Level_number);
            PlayerPrefs.Save();
            mode = true;
        }
    }
}
