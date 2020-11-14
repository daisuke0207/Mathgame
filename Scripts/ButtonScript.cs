using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    string sceneName;

    public AudioSource ButtonAud;
    public AudioClip RetrySnd;
    public AudioClip BackMenuSud;
    bool playAud = false;

    bool r = true;
    public void RetryButton()
    {
        if (r)
        {
            r = false;
            playAud = true;
            if(SceneManager.GetActiveScene().name == "MathBattle")
            {
                sceneName = "MathBattle";
            }
            else if(SceneManager.GetActiveScene().name == "MathBattle1")
            {
                sceneName = "MathBattle1";
            }
            ButtonAud.PlayOneShot(RetrySnd);            
        }
    }

    public void BackMenuButton()
    {
        playAud = true;
        sceneName = "Menu";
        ButtonAud.PlayOneShot(BackMenuSud);
    }

    void Start()
    {
        r = true;
        playAud = false;
        ButtonAud = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (playAud && !ButtonAud.isPlaying)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(sceneName);
            r = true;
        }
    }
}
