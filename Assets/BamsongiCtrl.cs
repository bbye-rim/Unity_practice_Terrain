using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiCtrl : MonoBehaviour
{
    float timer = 0.0f;
    bool is_shot = false;
    public GameObject target;
    bool is_collided = false;
    float xrnd, yrnd, wind;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 0.05 && !is_shot)
        {
            is_shot = true;
        }
    }

    public void Shoot(Vector3 dir)
    {
        xrnd = Random.Range(-10.0f, 10.0f);
        yrnd = Random.Range(-5.0f, 5.0f);
        wind = Random.Range(-20.0f, 20.0f);
        GetComponent<Rigidbody>().AddForce(dir);
        GetComponent<Rigidbody>().AddForce(xrnd*wind, yrnd*wind, 0);
        if(is_collided)
        {
            wind = 0.0f;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<ParticleSystem>().Play();
        this.is_collided = true;

        Vector3 collided_position = transform.position;
        float distance = collided_position.x * collided_position.x + (collided_position.y - 6.5f) * (collided_position.y - 6.5f);
        distance = Mathf.Sqrt(distance);
        Debug.Log(collided_position);
        Debug.Log(distance);
        

        GameObject t = GameObject.Find("target") as GameObject;

        if (distance >= 0.0 && distance < 0.4)
            t.GetComponent<targetCtrl>().AddScore(100);
        else if (distance >= 0.4 && distance < 0.8)
            t.GetComponent<targetCtrl>().AddScore(80);
        else if (distance >= 0.8 && distance < 1.2)
            t.GetComponent<targetCtrl>().AddScore(60);
        else if (distance >= 1.2 && distance < 1.6)
            t.GetComponent<targetCtrl>().AddScore(40);
        else if (distance >= 1.6 && distance < 2.0)
            t.GetComponent<targetCtrl>().AddScore(20);
        else if (distance >= 2.0)
            t.GetComponent<targetCtrl>().AddScore(0);
    }

    void OnGUI()
    {
        GUI.color = Color.black;
        GUI.Label(new Rect(50, 30, 100, 20), "Ç³Çâ");
        GUI.Label(new Rect(50, 50, 100, 20), "x : ");
        GUI.Label(new Rect(90, 50, 100, 20), xrnd.ToString());
        GUI.Label(new Rect(50, 70, 100, 20), "y : ");
        GUI.Label(new Rect(90, 70, 100, 20), yrnd.ToString());
        GUI.Label(new Rect(50, 110, 100, 20), "Ç³¼Ó : ");
        GUI.Label(new Rect(90, 110, 100, 20), wind.ToString());
    }
}
