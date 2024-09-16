using UnityEngine;
using UnityEngine.AI;

public class NavMeshFindClosestEdge : MonoBehaviour
{
    public Transform target;   // El objetivo para encontrar el borde m�s cercano
    private NavMeshHit hit;     // Estructura para almacenar el resultado de FindClosestEdge

    void Update()
    {
        if (target != null)
        {
            FindClosestEdgeOnNavMesh(target.position);
        }
    }

    // Funci�n para encontrar el borde m�s cercano en el NavMesh desde una posici�n
    private void FindClosestEdgeOnNavMesh(Vector3 position)
    {
        // Buscar el borde m�s cercano en el NavMesh desde la posici�n dada
        if (NavMesh.FindClosestEdge(position, out hit, NavMesh.AllAreas))
        {
            Debug.Log("Borde m�s cercano encontrado en el NavMesh.");
            Debug.Log("Posici�n del borde: " + hit.position);

            // Visualizar el borde m�s cercano con un Gizmo
            Debug.DrawRay(hit.position, hit.normal * 10, Color.red, 1f); // Dibuja una l�nea en la direcci�n del borde
        }
        else
        {
            Debug.Log("No se pudo encontrar el borde m�s cercano en el NavMesh.");
        }
    }

    // M�todo opcional para visualizar el punto m�s cercano en el borde en la escena
    private void OnDrawGizmos()
    {
        if (hit.position != Vector3.zero)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(hit.position, 1.5f);
        }
    }
}
