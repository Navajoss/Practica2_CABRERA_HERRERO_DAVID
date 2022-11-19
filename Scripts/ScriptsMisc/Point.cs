using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        FPS_Player player = other.GetComponent<FPS_Player>();
        {
            if (player != null)
            {
                
                Points.Instance.StartFadeOut();
                Destroy(this.gameObject);
            }
        }
    }
}
