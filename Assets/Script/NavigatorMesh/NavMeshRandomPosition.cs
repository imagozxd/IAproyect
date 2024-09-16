using UnityEngine;
using UnityEngine.AI;

public class NavMeshRandomPosition : MonoBehaviour
{
    public float range = 10f; // Rango dentro del cual se buscar� una posici�n
    private NavMeshHit hit;   // Estructura para almacenar la posici�n encontrada en el NavMesh

    // Funci�n para obtener una posici�n aleatoria v�lida en el NavMesh
    public bool GetRandomNavMeshPosition(Vector3 center, float range, out Vector3 result)
    {
        // Generar una posici�n aleatoria dentro de una esfera alrededor del centro
        Vector3 randomDirection = Random.insideUnitSphere * range;
        randomDirection += center;

        // Verificar si la posici�n aleatoria est� dentro del NavMesh
        if (NavMesh.SamplePosition(randomDirection, out hit, range, NavMesh.AllAreas))
        {
            result = hit.position;  // Guardar la posici�n encontrada
            return true;            // Retornar verdadero si se encuentra una posici�n v�lida
        }

        result = Vector3.zero;       // Si no se encuentra una posici�n v�lida, devolver Vector3.zero
        return false;                // Retornar falso si no se encuentra una posici�n v�lida
    }

    // M�todo opcional para visualizar la posici�n aleatoria en la escena
    private void OnDrawGizmos()
    {
        if (hit.position != Vector3.zero)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(hit.position, 1f);
        }
    }
}
