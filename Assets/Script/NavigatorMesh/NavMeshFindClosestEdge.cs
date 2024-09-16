using UnityEngine;
using UnityEngine.AI;

public class NavMeshFindClosestEdge : MonoBehaviour
{
    public Transform target;   // El objetivo para encontrar el borde más cercano
    private NavMeshHit hit;     // Estructura para almacenar el resultado de FindClosestEdge

    void Update()
    {
        if (target != null)
        {
            FindClosestEdgeOnNavMesh(target.position);
        }
    }

    // Función para encontrar el borde más cercano en el NavMesh desde una posición
    private void FindClosestEdgeOnNavMesh(Vector3 position)
    {
        // Buscar el borde más cercano en el NavMesh desde la posición dada
        if (NavMesh.FindClosestEdge(position, out hit, NavMesh.AllAreas))
        {
            Debug.Log("Borde más cercano encontrado en el NavMesh.");
            Debug.Log("Posición del borde: " + hit.position);

            // Visualizar el borde más cercano con un Gizmo
            Debug.DrawRay(hit.position, hit.normal * 10, Color.red, 1f); // Dibuja una línea en la dirección del borde
        }
        else
        {
            Debug.Log("No se pudo encontrar el borde más cercano en el NavMesh.");
        }
    }

    // Método opcional para visualizar el punto más cercano en el borde en la escena
    private void OnDrawGizmos()
    {
        if (hit.position != Vector3.zero)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(hit.position, 1.5f);
        }
    }
}
