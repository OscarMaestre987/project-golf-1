using System.Collections;
using UnityEngine;

public class WormHole : Planet
{
    [SerializeField] private WormHole planet; // Wormhole destino
    [SerializeField] private int teleportOffset = 5; // Distancia extra en la direcci�n del movimiento

    private void OnTriggerEnter(Collider other)
    {
        if (planet != null && planet != this)
        {
            Debug.Log("mover");

            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 moveDirection = rb.velocity.normalized; // Obtener la direcci�n del movimiento
                Vector3 teleportPosition = planet.GetCenter().position + moveDirection * teleportOffset; // Nueva posici�n con offset
                other.transform.position = teleportPosition; // Teletransportar con desplazamiento
                rb.velocity = rb.velocity; // Mantener la velocidad original
            }
        }
    }
}

