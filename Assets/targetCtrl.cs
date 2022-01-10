using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class targetCtrl : MonoBehaviour
{
    int count = 0;
    int score = 0;
    public GameObject bamsongi;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            count = count + 1;
        }
    }

    public void AddScore(int num)
    {
        score = score + num;
    }

    void OnGUI()
    {
        GUI.color = Color.black;
        GUI.Label(new Rect(50, 150, 100, 20), count.ToString());
        GUI.Label(new Rect(50, 90, 100, 20), "점수 : ");
        GUI.Label(new Rect(90, 90, 100, 20), score.ToString());

        if (count > 5)
        {
            Time.timeScale = 0.0f;
            GUI.Label(new Rect(Screen.width / 2, 300, 150, 20), "R키를 누르면 계속");
            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene("main");
            }
        }
    }
}
