using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    float alfa1 = 1f;
    float speed = 0.05f;
    float red1 = 0, green1 = 0, blue1 = 0;
    public GameObject Menupanel;

    public IEnumerator FadePanel()
    {
        red1 = Menupanel.GetComponent<Image>().color.r;
        green1 = Menupanel.GetComponent<Image>().color.g;
        blue1 = Menupanel.GetComponent<Image>().color.b;
        alfa1 = Menupanel.GetComponent<Image>().color.a;
        while (alfa1 > 0f)
        {
            Menupanel.GetComponent<Image>().color = new Color(red1, green1, blue1, alfa1);
            alfa1 -= speed;
            yield return new WaitForSeconds(0.01f);
        }
        this.gameObject.SetActive(false);
    }

    void Start()
    {
        StartCoroutine(FadePanel());
    }

    void Update()
    {
        
    }
}
