using UnityEngine;
using System.Collections;

public class EstadoAlerta : MonoBehaviour {

    public float velocidadGiroBusqueda = 120f;
    public float duracionBusqueda = 4f;
    public Color ColorEstado = Color.yellow;

    private MaquinaDeEstados maquinaDeEstados;
    private ControladorNavMesh controladorNavMesh;
    private ControladorVision controladorVision;
    private float tiempoBuscando;

    private Animator anim;
    
    void Awake () {
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
	//we use raycast to see player 
	void Update () {
        RaycastHit hit;
        if (controladorVision.PuedeVerAlJugador(out hit))
        {
            //if see follow then 
            controladorNavMesh.perseguirObjectivo = hit.transform;
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPersecucion);
            return;
        }
        //if dont see rotate in position looking for player
        transform.Rotate(0f, velocidadGiroBusqueda * Time.deltaTime, 0f);
        tiempoBuscando += Time.deltaTime;
        if(tiempoBuscando >= duracionBusqueda)
        {
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPatrulla);
            return;
        }
        anim.Play("Z_Idle 0");
    }
}
