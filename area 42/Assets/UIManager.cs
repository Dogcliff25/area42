using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour
{
    public TMP_Text textoCantidad;
    public Button botonDerecha;
    public Button botonIzquierda;
    public Button botonRestar;

    public Image piedraImagen;

    public TMP_Text listaRestadas; // Texto para mostrar la lista de cantidades restadas

    private int indicePiedraActual = 0;
    private int[] cantidadPiedra;
    private int[] cantidadRestada; // Cantidades restadas de cada tipo de piedra
    private Color[] coloresPiedras;

    void Start()
    {
        // Buscar y asignar el componente de imagen
        piedraImagen = GameObject.Find("PiedraImagen").GetComponent<Image>();
        if (piedraImagen == null)
        {
            Debug.LogError("No se encontró el componente Image en el objeto con nombre 'PiedraImagen'.");
            return;
        }

        // Definir los colores para cada tipo de piedra
        coloresPiedras = new Color[5];
        coloresPiedras[0] = Color.blue;
        coloresPiedras[1] = Color.red;
        coloresPiedras[2] = Color.green;
        coloresPiedras[3] = Color.white;
        coloresPiedras[4] = Color.gray;

        // Buscar y asignar el componente de texto por nombre en la jerarquía
        GameObject textoObject = GameObject.Find("PiedrasCantidad");
        if (textoObject != null)
        {
            textoCantidad = textoObject.GetComponent<TextMeshProUGUI>();
        }

        if (textoCantidad == null)
        {
            Debug.LogError("No se encontró el componente TextMeshProUGUI en el objeto con nombre 'PiedrasCantidad'.");
            return;
        }

        // Buscar y asignar el componente de texto para la lista de restadas
        GameObject listaRestadasObject = GameObject.Find("ListaRestadas");
        if (listaRestadasObject != null)
        {
            listaRestadas = listaRestadasObject.GetComponent<TextMeshProUGUI>();
        }

        if (listaRestadas == null)
        {
            Debug.LogError("No se encontró el componente TextMeshProUGUI en el objeto con nombre 'ListaRestadas'.");
            return;
        }

        // Inicializa las cantidades de piedras desde managervariables
        cantidadPiedra = new int[5];
        cantidadPiedra[0] = managervariables.cantidadpiedraazul;
        cantidadPiedra[1] = managervariables.cantidadpiedraroja;
        cantidadPiedra[2] = managervariables.cantidadpiedraverde;
        cantidadPiedra[3] = managervariables.cantidadpiedrablanca;
        cantidadPiedra[4] = managervariables.cantidadpiedragris;

        // Inicializa las cantidades restadas
        cantidadRestada = new int[5];

        // Asigna los métodos a los botones
        GameObject botonDerechaObject = GameObject.Find("BotonDerecha");
        if (botonDerechaObject != null)
        {
            botonDerecha = botonDerechaObject.GetComponent<Button>();
        }

        GameObject botonIzquierdaObject = GameObject.Find("BotonIzquierda");
        if (botonIzquierdaObject != null)
        {
            botonIzquierda = botonIzquierdaObject.GetComponent<Button>();
        }

        GameObject botonRestarObject = GameObject.Find("BotonRestar");
        if (botonRestarObject != null)
        {
            botonRestar = botonRestarObject.GetComponent<Button>();
        }

        if (botonDerecha != null)
        {
            botonDerecha.onClick.AddListener(() => CambiarPiedra(1));
        }
        else
        {
            Debug.LogError("No se encontró el botón 'BotonDerecha'.");
        }

        if (botonIzquierda != null)
        {
            botonIzquierda.onClick.AddListener(() => CambiarPiedra(-1));
        }
        else
        {
            Debug.LogError("No se encontró el botón 'BotonIzquierda'.");
        }

        if (botonRestar != null)
        {
            botonRestar.onClick.AddListener(RestarPiedra);
        }
        else
        {
            Debug.LogError("No se encontró el botón 'BotonRestar'.");
        }

        // Muestra la cantidad inicial
        ActualizarUI();
    }

    void CambiarPiedra(int direccion)
    {
        indicePiedraActual = (indicePiedraActual + direccion + 5) % 5; // Asegura el rango de 0 a 4
        ActualizarUI();
    }

    void RestarPiedra()
    {
        if (cantidadPiedra[indicePiedraActual] > 0)
        {
            cantidadPiedra[indicePiedraActual]--;
            cantidadRestada[indicePiedraActual]++;
            ActualizarUI();
            ActualizarListaRestadas();
        }
        else
        {
            Debug.Log("No hay suficientes piedras para restar.");
        }
    }

    void ActualizarUI()
    {
        if (piedraImagen != null)
        {
            piedraImagen.color = coloresPiedras[indicePiedraActual];
        }
        if (textoCantidad != null)
        {
            string[] nombresPiedras = { "Azul", "Roja", "Verde", "Blanca", "Gris" };
            textoCantidad.text = "Piedra " + nombresPiedras[indicePiedraActual] + ": " + cantidadPiedra[indicePiedraActual].ToString();
        }
    }

    void ActualizarListaRestadas()
    {
        if (listaRestadas != null)
        {
            string[] nombresPiedras = { "Azul", "Roja", "Verde", "Blanca", "Gris" };
            listaRestadas.text = "Piedras Restadas:\n";
            for (int i = 0; i < cantidadRestada.Length; i++)
            {
                listaRestadas.text += nombresPiedras[i] + ": " + cantidadRestada[i].ToString() + "\n";
            }
        }
    }
}