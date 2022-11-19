using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoMuerto : MonoBehaviour
{
    public float duracionBusqueda = 4f;
    public Color ColorEstado = Color.yellow;

    private MaquinaDeEstados maquinaDeEstados;
    private ControladorNavMesh controladorNavMesh;
    private ControladorVision controladorVision;
    private float tiempoBuscando;

    private Animator anim;

    void Awake()
    {
        maquinaDeEstados = GetComponent<MaquinaDeEstados>();
        controladorNavMesh = GetComponent<ControladorNavMesh>();
        controladorVision = GetComponent<ControladorVision>();
        anim = GetComponent<Animator>();
    }

    void OnEnable()
    {

        controladorNavMesh.DetenerNavMeshAgent();
        tiempoBuscando = 0f;
    }

    void Update()
    {
        RaycastHit hit;
        if (controladorVision.PuedeVerAlJugador(out hit))
        {
           
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoHuir);
            return;
        }

        //if dont see fall in the floor
        tiempoBuscando += Time.deltaTime;
        if (tiempoBuscando >= duracionBusqueda)
        {
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPatrulla2);
            return;
        }
        anim.Play("Z_FallingForward");
    }
}
