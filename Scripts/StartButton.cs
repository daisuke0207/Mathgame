using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject StartFade;
    bool s = true;

    public void StartFadeOut()
    {
        if (s)
        {
            s = false;
            StartFade.SetActive(true);
            s = true;
        }
    }

    void Start()
    {
        s = true;
    }
}
