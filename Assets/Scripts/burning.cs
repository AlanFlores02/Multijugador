using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class burning : MonoBehaviour
{
    Text lifeTxt;
    float life = 600;
    bool hasPotato=false, immune=false;

    void Start()
    {
        if (IsHost) { lifeTxt = GameObject.Find("Timer (1)").GetComponent<Text>(); }
        if (IsClient) { lifeTxt = GameObject.Find("Timer (2)").GetComponent<Text>(); }
    }

    void Update()
    {
        if (hasPotato)
        {
            life -= Time.deltaTime;
            float minutes = Mathf.Floor(timer / 60);
            float seconds = timer % 60;
        }
    }
}
