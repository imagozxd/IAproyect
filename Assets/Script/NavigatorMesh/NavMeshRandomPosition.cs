using UnityEngine;
using UnityEngine.AI;

public class NavMeshRandomPosition : MonoBehaviour
{
    public float range = 10f; // Rango dentro del cual se buscará una posición
    private NavMeshHit hit;   // Estructura para almacenar la posición encontrada en el NavMesh

    // Función para obtener una posición aleatoria válida en el NavMesh
    public bool GetRandomNavMeshPosition(Vector3 center, float range, out Vector3 result)
    {
        // Generar una posición aleatoria dentro de una esfera alrededor del centro
        Vector3 randomDirection = Random.insideUnitSphere * range;
        randomDirection += center;

        // Verificar si la posición aleatoria está dentro del NavMesh
        if (NavMesh.SamplePosition(randomDirection, out hit, range, NavMesh.AllAreas))
        {
            result = hit.position;  // Guardar la posición encontrada
            return true;            // Retornar verdadero si se encuentra una posición válida
        }

        result = Vector3.zero;       // Si no se encuentra una posición válida, devolver Vector3.zero
        return false;                // Retornar falso si no se encuentra una posición válida
    }

    // Método opcional para visualizar la posición aleatoria en la escena
    private void OnDrawGizmos()
    {
        if (hit.position != Vector3.zero)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(hit.position, 1f);
        }
    }
}
