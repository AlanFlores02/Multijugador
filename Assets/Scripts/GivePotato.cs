using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GivePotato : MonoBehaviour
{
    GameObject[] players;
    Image img;
    public int repetirEfecto;
    float wait=1.0f, newWait=1.0f;
    bool loop = true;

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        repetirEfecto = 12 + Random.Range(0, players.Length);
        img = GameObject.Find("Arrow").GetComponent<Image>();

        InvokeRepeating("TurnArrow", 0.5f, 0.5f);
    }

    void TurnArrow()
    {
        // Flecha cambia a que jugador apunta
        repetirEfecto--;
        img.transform.localScale = new Vector3(-1 * img.transform.localScale.x, 1, 1);
        // Insert SFX here
        if (repetirEfecto == 0) { GiveThePotato(); CancelInvoke(); }
    }

    void GiveThePotato()
    {
        // Insert other SFX here
        img.color = new Color32(255, 255, 225, 100);
    }
}

/* Decide que jugador empieza con la papa 
   Efectos especiales para ser dramáticos */