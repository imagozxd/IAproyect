using UnityEngine;
using UnityEngine.AI;

public class NavMeshRaycast : MonoBehaviour
{
    public Transform startPoint; // Punto de inicio del raycast
    public Transform endPoint; // Punto final del raycast
    public float maxDistance = 100f; // Distancia máxima del raycast

    void Update()
    {
        // Llamar a la función para hacer el Raycast
        if (startPoint != null && endPoint != null)
        {
            RaycastOnNavMesh(startPoint.position, endPoint.position);
        }
    }

    // Función para realizar el RayCast dentro del NavMesh
    private void RaycastOnNavMesh(Vector3 startPos, Vector3 endPos)
    {
        NavMeshHit hit;

        // Realizar un Raycast entre el punto inicial y final en el NavMesh
        bool hitResult = NavMesh.Raycast(startPos, endPos, out hit, NavMesh.AllAreas);

        // Si hay colisión, el raycast encontró un obstáculo
        if (hitResult)
        {
            Debug.Log("Colisión detectada en el NavMesh entre los puntos.");
            Debug.DrawLine(startPos, hit.position, Color.red); // Dibujar línea roja hasta el punto de colisión
        }
        else
        {
            Debug.Log("No hay colisión, camino despejado.");
            Debug.DrawLine(startPos, endPos, Color.green); // Dibujar línea verde si no hay colisión
        }
    }
}
