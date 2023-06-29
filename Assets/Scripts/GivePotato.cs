using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GivePotato : MonoBehaviour
{
    GameObject[] players;
    Image img;
    int repetirEfecto, give;

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        give = Random.Range(0, players.Length);
        repetirEfecto = 12 + give;
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
        players[give].GetComponent<>();
    }
}

/* Decide que jugador empieza con la papa 
   Efectos especiales para ser dramáticos */