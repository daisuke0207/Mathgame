using UnityEngine;
using UnityEngine.UI;

public class NickName : MonoBehaviour
{
    public InputField inputField;
    public Text text;

    private const string NickNameKey = "NICKNAME";
    public static string nickName = "";

    public Text MenuBestText;
    public Text TargetScoreText;

    public void InputText()
    {     
        //テキストにinputFieldの内容を反映
        text.text = inputField.text;
        nickName = text.text;           
        PlayerPrefs.SetString(NickNameKey, nickName);       
    }

    void Start()
    {
        //Componentを扱えるようにする
        //inputField = inputField.GetComponent<InputField>();
        //text = text.GetComponent<Text>();
        //nickName = PlayerPrefs.GetString(NickNameKey, "自由");
        //text.text = nickName;
        OverLine2.best = PlayerPrefs.GetFloat(OverLine2.scoreKey, 0);
        MenuBestText.text = OverLine2.best.ToString("F2") + " 秒";
        if(OverLine2.best < 50.00f)
        {
            TargetScoreText.text = "目標: 50.00 秒";
        }
        else if (OverLine2.best < 100.00f)
        {
            TargetScoreText.text = "目標: 100.00 秒";
        }
        else if (OverLine2.best < 130.00f)
        {
            TargetScoreText.text = "目標: 130.00 秒";
        }
        else if (OverLine2.best < 170.00f)
        {
            TargetScoreText.text = "目標: 170.00 秒";
        }
        else if (OverLine2.best < 200.00f)
        {
            TargetScoreText.text = "目標: 200.00 秒";
        }
        else if(OverLine2.best < 230.00f)
        {
            TargetScoreText.text = "目標: 230.00 秒";
        }
        else if(OverLine2.best < 250.00f)
        {
            TargetScoreText.text = "目標: 250.00 秒";
        }
        else if (OverLine2.best < 300.00f)
        {
            TargetScoreText.text = "目標: 300.00 秒";
        }
        else if (OverLine2.best < 350.00f)
        {
            TargetScoreText.text = "目標: 350.00 秒";
        }
        else if (OverLine2.best < 500.00f)
        {
            TargetScoreText.text = "目標: 500.00 秒";
        }
        else if(OverLine2.best > 500)
        {
            TargetScoreText.text = "目標: 1000.00 秒";
        }
    }
}
