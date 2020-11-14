using UnityEngine;

public class GameAdControl : MonoBehaviour
{
    public static int gameCount = 0;
    void Start()
    {
        gameCount += 1;
        if (OverLine2.best >= 100)
        {
            gameCount += 1;
        }
    }
}
