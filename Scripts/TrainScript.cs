using UnityEngine;

public class TrainScript : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(screenPosition);
        }
    }
}
