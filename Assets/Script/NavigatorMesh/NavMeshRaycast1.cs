using UnityEngine;
using UnityEngine.AI;

public class NavMeshRaycast : MonoBehaviour
{
    public Transform startPoint; // Punto de inicio del raycast
    public Transform endPoint; // Punto final del raycast
    public float maxDistance = 100f; // Distancia m�xima del raycast

    void Update()
    {
        // Llamar a la funci�n para hacer el Raycast
        if (startPoint != null && endPoint != null)
        {
            RaycastOnNavMesh(startPoint.position, endPoint.position);
        }
    }

    // Funci�n para realizar el RayCast dentro del NavMesh
    private void RaycastOnNavMesh(Vector3 startPos, Vector3 endPos)
    {
        NavMeshHit hit;

        // Realizar un Raycast entre el punto inicial y final en el NavMesh
        bool hitResult = NavMesh.Raycast(startPos, endPos, out hit, NavMesh.AllAreas);

        // Si hay colisi�n, el raycast encontr� un obst�culo
        if (hitResult)
        {
            Debug.Log("Colisi�n detectada en el NavMesh entre los puntos.");
            Debug.DrawLine(startPos, hit.position, Color.red); // Dibujar l�nea roja hasta el punto de colisi�n
        }
        else
        {
            Debug.Log("No hay colisi�n, camino despejado.");
            Debug.DrawLine(startPos, endPos, Color.green); // Dibujar l�nea verde si no hay colisi�n
        }
    }
}
