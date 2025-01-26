using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class anomatorolla : MonoBehaviour
{
    public Button botonPrincipal; // Bot�n que inicia la animaci�n
    public GameObject objeto3D; // Objeto 3D para la animaci�n
    public Button[] otrosBotones; // Otros botones que se deshabilitar�n
    private Animator animator;

    void Start()
    {
        if (botonPrincipal == null)
        {
            Debug.LogError("El bot�n principal no est� asignado.");
            return;
        }

        if (objeto3D == null)
        {
            Debug.LogError("El objeto 3D no est� asignado.");
            return;
        }

        animator = objeto3D.GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("No se encontr� el componente Animator en el objeto 3D.");
            return;
        }

        botonPrincipal.onClick.AddListener(IniciarAnimacion);
    }

    public void IniciarAnimacion()
    {
        animator.SetTrigger("Play");
        DeshabilitarBotones();
        float animDuration = animator.GetCurrentAnimatorStateInfo(0).length;
        Invoke("HabilitarBotones", animDuration);
    }

    void DeshabilitarBotones()
    {
        foreach (Button boton in otrosBotones)
        {
            boton.interactable = false;
        }
        botonPrincipal.interactable = false;
    }

    void HabilitarBotones()
    {
        foreach (Button boton in otrosBotones)
        {
            boton.interactable = true;
        }
        botonPrincipal.interactable = true;
    }
}

