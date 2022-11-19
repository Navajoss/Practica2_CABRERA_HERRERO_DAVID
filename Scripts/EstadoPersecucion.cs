using UnityEngine;
using System.Collections;

public class EstadoPersecucion : MonoBehaviour
{

    public Color ColorEstado = Color.red;
    public PlayerStatusUI playerStatusUI;
    public PlayerHealt playerHealth;

    private MaquinaDeEstados maquinaDeEstados;
    private ControladorNavMesh controladorNavMesh;
    private ControladorVision controladorVision;
    public float Damage = -10;
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
        //see the player?
        RaycastHit hit;
        if (!controladorVision.PuedeVerAlJugador(out hit, true))
        {
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoAlerta);
            return;
        }

        controladorNavMesh.ActualizarPuntoDestinoNavMeshAgent();
        anim.Play("Z_Run_InPlace");
    }
    public void OnTriggerStay(Collider other)
    {
        PlayerHealt player = other.GetComponent<PlayerHealt>();
        {
            if (player != null)
            {
                player.Take = true;
            }
        }
    }

}
