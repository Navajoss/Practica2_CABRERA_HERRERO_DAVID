using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoHuir : MonoBehaviour
{
    // Start is called before the first frame update
    public Color ColorEstado = Color.blue;

    private MaquinaDeEstados maquinaDeEstados;
    private ControladorNavMesh controladorNavMesh;
    private ControladorVision controladorVision;

    private Animator anim;

    void Awake()
    {
        maquinaDeEstados = GetComponent<MaquinaDeEstados>();
        controladorNavMesh = GetComponent<ControladorNavMesh>();
        controladorVision = GetComponent<ControladorVision>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        RaycastHit hit;
        if (!controladorVision.PuedeVerAlJugador(out hit, true))
        {
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoMuerto);
            return;
        }
        //if see the player run in the other direction 
        Debug.Log(transform.position - (hit.transform.forward.normalized * Vector3.Distance(transform.position, hit.transform.position)));
        controladorNavMesh.ActualizarPuntoDestinoNavMeshAgent  (transform.position +( hit.transform.forward.normalized * 10));
        anim.Play("Z_Run_InPlace");
    }
}
