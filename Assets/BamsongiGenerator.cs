using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiGenerator : MonoBehaviour
{
    public GameObject bamsongi_prefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject bamsongi = Instantiate(bamsongi_prefab) as GameObject;
            Ray screen_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 shooting_ray = screen_ray.direction;
            bamsongi.GetComponent<BamsongiCtrl>().Shoot(shooting_ray * 1000);
            Destroy(bamsongi, 3.0f); // 부딪히고 3초 후 밤송이 자동 삭제
        }    
    }
}
