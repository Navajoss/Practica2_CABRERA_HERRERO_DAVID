using UnityEngine;
using System.Collections;

public class MaquinaDeEstados : MonoBehaviour
{

    public MonoBehaviour EstadoPatrulla;
    public MonoBehaviour EstadoAlerta;
    public MonoBehaviour EstadoPersecucion;
    public MonoBehaviour EstadoInicial;
    public MonoBehaviour EstadoHuir;
    public MonoBehaviour EstadoMuerto;
    public MonoBehaviour EstadoPatrulla2;

    public MeshRenderer MeshRendererIndicador;

    private MonoBehaviour estadoActual;

    void Start()
    {
        ActivarEstado(EstadoInicial);
    }

    public void ActivarEstado(MonoBehaviour nuevoEstado)
    {
        if (estadoActual != null) estadoActual.enabled = false;
        estadoActual = nuevoEstado;
        estadoActual.enabled = true;


    }


}
