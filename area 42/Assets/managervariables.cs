using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class managervariables : MonoBehaviour
{
    // Variables estáticas para almacenar la cantidad de cada tipo de piedra
    public static int cantidadPiedraAzul = 0;
    public static int cantidadPiedraRoja = 0;
    public static int cantidadPiedraVerde = 0;
    public static int cantidadPiedraBlanca = 0;
    public static int cantidadPiedraGris = 0;

    // Variables estáticas booleanas para verificar si el personaje tiene cada tipo de piedra
    public static bool tienePiedraAzul = false;
    public static bool tienePiedraRoja = false;
    public static bool tienePiedraVerde = false;
    public static bool tienePiedraBlanca = false;
    public static bool tienePiedraGris = false;

    public static void AgregarPiedra(string tipoPiedra)
    {
        switch (tipoPiedra)
        {
            case "azul":
                cantidadPiedraAzul++;
                tienePiedraAzul = true;
                Debug.Log("Piedra azul agregada. Cantidad: " + cantidadPiedraAzul);
                break;
            case "roja":
                cantidadPiedraRoja++;
                tienePiedraRoja = true;
                Debug.Log("Piedra roja agregada. Cantidad: " + cantidadPiedraRoja);
                break;
            case "verde":
                cantidadPiedraVerde++;
                tienePiedraVerde = true;
                Debug.Log("Piedra verde agregada. Cantidad: " + cantidadPiedraVerde);
                break;
            case "blanca":
                cantidadPiedraBlanca++;
                tienePiedraBlanca = true;
                Debug.Log("Piedra blanca agregada. Cantidad: " + cantidadPiedraBlanca);
                break;
            case "gris":
                cantidadPiedraGris++;
                tienePiedraGris = true;
                Debug.Log("Piedra gris agregada. Cantidad: " + cantidadPiedraGris);
                break;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
