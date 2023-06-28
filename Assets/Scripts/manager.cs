using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class manager : NetworkBehaviour
{
    /*Pasos para inciar un proyecto de netcode
     * 1.- Ir a window/Package Manager , darle click al simbolo de + en la esquina superior derecha 
     * darle a "Add package by name" e introducir lo siguiente: com.unity.netcode.gameobjects
     * 2.-Crear un objeto vacio, llamarlo NetworkManager y añadirle un componente llamado del mismo nombre
     * (Es un script que incluye el paquete de netcode)
     * 3.-En ese componente abajo donde esta el simbolo de advertencia (!) ponerle Unity Transport
     * 4.-Crear un objeto que contenga este codigo y asignarle un componente de Network Object
     * (Es un script que incluye el paquete de netcode)
     * 5.- Tambien crear un objeto que contenga Network Object y hacerlo prefab, luego asignarlo en su
     * NetworkManager en los primeros valores hay uno de "Player Prefab"
     * 
     * 
     * 
     */

    float timer = 10.0f;
    bool _client, _server;
    Button btnHost, btnClient, btnServer;
    GameObject panel;
    RectTransform canvas, progress;
    Text countdown;

    void Start()
    {
        // Get UI elements
        panel = GameObject.Find("Panel");
        countdown = GameObject.Find("Countdown").GetComponent<Text>();
        canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
        progress = GameObject.Find("ProgressBar").GetComponent<RectTransform>();
        // Event Listener 1
        btnServer = GameObject.Find("btnServer").GetComponent<Button>();
        btnServer.onClick.AddListener(StartServer);
        // Event Listener 2
        btnHost = GameObject.Find("btnHost").GetComponent<Button>();
        btnHost.onClick.AddListener(StartHost);
        // Event Listener 3
        btnClient = GameObject.Find("btnClient").GetComponent<Button>();
        btnClient.onClick.AddListener(StartClient);
    }

    public void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Player").Length >= 2)
        {
            timer -= Time.deltaTime;
            if (timer < 0) { SceneManager.LoadScene("DanceFloor"); }
            countdown.text = "STARTING IN " + timer.ToString("0.00");
            progress.offsetMax = new Vector2(canvas.rect.width * (1 - (timer / 10)), 50);
        }
        else if (timer != 10.0f)
        {
            timer = 10.0f;
            countdown.text = "Waiting for more players...";
        }
    }

    //Funcion para que empezar el host desde un boton
    public void StartHost()
    {
        panel.SetActive(false);
        NetworkManager.Singleton.StartHost();
    }
    //Funcion para que empezar el cliente desde un boton
    public void StartClient()
    {
        panel.SetActive(false);
        NetworkManager.Singleton.StartClient();
    }
    //Funcion para que empezar el servidor desde un boton
    public void StartServer()
    {
        panel.SetActive(false);
        NetworkManager.Singleton.StartServer();
    }
}
