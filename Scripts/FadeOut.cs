using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    float alfa;
    float speed = 0.01f;
    float red, green, blue;
    float i = 0;
    public AudioSource Audio;
    public AudioClip spcialButton;
    public AudioClip normal;
    bool i1;

    public void FadePanel()
    {
        while (alfa < 1f)
        {
            GetComponent<Image>().color = new Color(red, green, blue, alfa);
            alfa += speed;
        }
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            if (i1)
            {
                Audio.PlayOneShot(spcialButton);
                i1 = false;
            }    
            if (i > 0.3f)
            {
                if(ModeLevel.Level_number != "タイム")
                {
                    SceneManager.LoadScene("MathBattle");
                }
                else if(ModeLevel.Level_number == "タイム")
                {
                    SceneManager.LoadScene("MathBattle1");
                }
            }
        }
    }

    void Start()
    {
        i = 0;
        i1 = true;
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
        alfa = GetComponent<Image>().color.a;
    }

    void Update()
    {
        FadePanel();
        i += Time.deltaTime;
    }
}
