using UnityEngine;

public class BallDirecotr : MonoBehaviour
{
    public GameObject ball1, ball2, ball3, ball4, ball5, ball6;
    GameObject ball;
    public GameObject canvas;

    int start_drop_count = 20; 
    float pos_y = 700.0f;       
    int dice = 0;

    float drop_span = 0f;
    float drop_time = 0f;
    float all_time = 0f;

    public GameObject stopjudge;

    private void DropBall(int drop)
    {
        for (int i = 0; i < drop; i++)
        {
            dice = Random.Range(1, 11);
            if(dice <= 2) { ball = ball1; }
            else if (dice <= 4) { ball = ball2;}
            else if (dice <= 6) { ball = ball3;}
            else if (dice <= 8) { ball = ball4;}
            else if (dice == 9) { ball = ball5;}
            else if (dice == 10) { ball = ball6;}

            Vector3 position = ball.transform.position;
            position.x = Random.Range(position.x - 300.0f, position.x + 300.0f);
            position.y = pos_y;
            pos_y += 30.0f;
            GameObject Ball_prefab = Instantiate(ball, position, ball.transform.rotation) as GameObject;
            Ball_prefab.transform.SetParent(canvas.transform, false);
        }
    }
   
    private void DropAdd() 
    {
        all_time += Time.deltaTime;
        drop_time += Time.deltaTime;

        ModeChange();

        if (drop_span <= drop_time)
        {
            drop_time = 0;
            dice = Random.Range(1, 11);
            if (dice <= 2) { ball = ball1; }
            else if (dice <= 4) { ball = ball2; }
            else if (dice <= 6) { ball = ball3; }
            else if (dice <= 8) { ball = ball4; }
            else if (dice == 9) { ball = ball5; }
            else if (dice == 10) { ball = ball6; }
            Vector3 position = ball.transform.position;
            position.x = Random.Range(position.x - 300.0f, position.x + 300.0f);
            position.y = pos_y;
            pos_y += 30.0f;
            GameObject Ball_prefab = Instantiate(ball, position, ball.transform.rotation) as GameObject;
            Ball_prefab.transform.SetParent(canvas.transform, false);
        }
    }


    GameObject Ball_prefa;
    public void DropBigball(GameObject bigball, GameObject lastball) 
    {
        Ball_prefa = Instantiate(bigball, lastball.transform.position, bigball.transform.rotation) as GameObject;  
        Ball_prefa.transform.SetParent(canvas.transform, false);
    }


    public void ModeChange()
    {
        if(ModeLevel.Level_number == "タイム")
        {
            start_drop_count = 20;

            if (all_time <= 10.0f) { drop_span = 1.5f; }
            else if (all_time <= 20.0f) { drop_span = 1.0f; }
            else if (all_time <= 30.0f) { drop_span = 0.8f; }
            else if (all_time <= 40.0f) { drop_span = 0.6f; }
            else if (all_time <= 50.0f) { drop_span = 0.5f; }
            else if (all_time <= 60.0f) { drop_span = 1.0f; }
            else if (all_time <= 70.0f) { drop_span = 0.8f; }
            else if (all_time <= 80.0f) { drop_span = 0.7f; }
            else if (all_time <= 90.0f) { drop_span = 0.6f; }
            else if (all_time <= 100.0f) { drop_span = 0.5f; }
            else if (all_time <= 110.0f) { drop_span = 0.4f; }
            else if (all_time <= 120.0f) { drop_span = 1.0f; }
            else if (all_time <= 130.0f) { drop_span = 0.7f; }
            else if (all_time <= 140.0f) { drop_span = 0.6f; }
            else if (all_time <= 150.0f) { drop_span = 0.5f; }
            else if (all_time <= 160.0f) { drop_span = 0.4f; }
            else if (all_time <= 170.0f) { drop_span = 1.0f; }
            else if (all_time <= 180.0f) { drop_span = 0.55f; }
            else if (all_time <= 190.0f) { drop_span = 0.5f; }
            else if (all_time <= 200.0f) { drop_span = 0.45f; }
            else if(all_time > 200.0f) { drop_span = 0.4f; }
        }
        else if(ModeLevel.Level_number == "1")
        {
            start_drop_count = 20;

            if (all_time <= 10.0f) { drop_span = 1.4f; }
            else if (all_time <= 20.0f) { drop_span = 1.0f; }
            else if (all_time <= 30.0f) { drop_span = 0.9f; }
            else if (all_time <= 40.0f) { drop_span = 1.1f; }
        }
        else if (ModeLevel.Level_number == "2")
        {
            start_drop_count = 25;

            if (all_time <= 10.0f) { drop_span = 1.3f; }
            else if (all_time <= 20.0f) { drop_span = 1.0f; }
            else if (all_time <= 30.0f) { drop_span = 0.9f; }
            else if (all_time <= 40.0f) { drop_span = 1.1f; }
        }
        else if (ModeLevel.Level_number == "3")
        {
            start_drop_count = 20;

            if (all_time <= 10.0f) { drop_span = 1.1f; }
            else if (all_time <= 20.0f) { drop_span = 0.9f; }
            else if (all_time <= 30.0f) { drop_span = 0.8f; }
            else if (all_time <= 40.0f) { drop_span = 1.0f; }
        }
        else if (ModeLevel.Level_number == "4")
        {
            start_drop_count = 25;

            if (all_time <= 10.0f) { drop_span = 1.1f; }
            else if (all_time <= 20.0f) { drop_span = 0.9f; }
            else if (all_time <= 30.0f) { drop_span = 0.8f; }
            else if (all_time <= 40.0f) { drop_span = 1.0f; }
        }
        else if (ModeLevel.Level_number == "5")
        {
            start_drop_count = 20;

            if (all_time <= 10.0f) { drop_span = 1.0f; }
            else if (all_time <= 20.0f) { drop_span = 0.8f; }
            else if (all_time <= 30.0f) { drop_span = 0.7f; }
            else if (all_time <= 40.0f) { drop_span = 0.8f; }
        }
        else if (ModeLevel.Level_number == "6")
        {
            start_drop_count = 25;

            if (all_time <= 10.0f) { drop_span = 1.0f; }
            else if (all_time <= 20.0f) { drop_span = 0.8f; }
            else if (all_time <= 30.0f) { drop_span = 0.7f; }
            else if (all_time <= 40.0f) { drop_span = 0.8f; }
        }
        else if (ModeLevel.Level_number == "7")
        {
            start_drop_count = 20;

            if (all_time <= 10.0f) { drop_span = 0.9f; }
            else if (all_time <= 20.0f) { drop_span = 0.7f; }
            else if (all_time <= 30.0f) { drop_span = 0.6f; }
            else if (all_time <= 40.0f) { drop_span = 0.5f; }
        }
        else if (ModeLevel.Level_number == "8")
        {
            start_drop_count = 25;

            if (all_time <= 10.0f) { drop_span = 0.9f; }
            else if (all_time <= 20.0f) { drop_span = 0.7f; }
            else if (all_time <= 30.0f) { drop_span = 0.6f; }
            else if (all_time <= 40.0f) { drop_span = 0.5f; }
        }
        else if (ModeLevel.Level_number == "9")
        {
            start_drop_count = 20;

            if (all_time <= 10.0f) { drop_span = 0.8f; }
            else if (all_time <= 20.0f) { drop_span = 0.6f; }
            else if (all_time <= 30.0f) { drop_span = 0.5f; }
            else if (all_time <= 40.0f) { drop_span = 0.4f; }
        }
        else if (ModeLevel.Level_number == "10")
        {
            start_drop_count = 25;

            if (all_time <= 10.0f) { drop_span = 0.8f; }
            else if (all_time <= 20.0f) { drop_span = 0.6f; }
            else if (all_time <= 30.0f) { drop_span = 0.5f; }
            else if (all_time <= 40.0f) { drop_span = 0.4f; }
        }
    }

    void Start()
    {
        ModeChange();
        DropBall(start_drop_count) ;
    }


    void Update()
    {
        DropAdd();
        if (stopjudge.activeSelf == true)
        {
            Time.timeScale = 0f;
        }
    }

    public void Stop()
    {
        Time.timeScale = 0f;
    }
    public void Restart()
    {
        Time.timeScale = 1f;
    }

}
