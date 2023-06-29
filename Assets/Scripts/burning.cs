using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class burning : MonoBehaviour
{
    Text lifeTxt;
    SpriteRenderer img;
    Animator anim;
    int id = 1;
    float life = 600;
    public bool hasPotato=false, immune=false, gameStart=false;

    void Start()
    {
        img = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (gameStart && hasPotato)
        {
            life -= Time.deltaTime;

            float minutes = Mathf.Floor(life / 60);
            string mins = minutes.ToString();
            if (minutes < 10) { mins = "0" + mins; }

            float seconds = Mathf.Floor(life % 60);
            string secs = seconds.ToString();
            if (seconds < 10) { secs = "0" + secs; }

            lifeTxt.text = mins + ":" + secs;
        }
    }

    public void SetPlayerStats(int _id, bool _hasPotato)
    {
        id = _id;
        lifeTxt = GameObject.Find("Timer " + id).GetComponent<Text>();
        
        hasPotato = _hasPotato;
        anim.SetBool("hasBomb?", hasPotato);

        gameStart = true;
        GetComponent<Collider2D>().isTrigger = hasPotato;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision");

        if (!immune && gameStart && other.tag == "Player")
        {
            if (hasPotato)
            {
                hasPotato = false;
                anim.SetBool("hasBomb?", false);
                img.color = new Color32(255, 255, 125, 100); //Se pinta amarillo
            }
            else
            {
                hasPotato = true;
                anim.SetBool("hasBomb?", true);
                img.color = new Color32(255, 125, 125, 100); //Se pinta rojo
            }

            immune = true;
            InvokeRepeating("LoseImmunity", 1.0f, 1.0f);
        }
        else if (other.tag == "Funky") { anim.SetBool("isDancing?", true); }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Funky") { anim.SetBool("isDancing?", false); }
    }

    void LoseImmunity()
    {
        img.color = new Color32(255, 255, 225, 100); //Regresa a la normalidad
        immune = false;
        CancelInvoke();
    }
}
