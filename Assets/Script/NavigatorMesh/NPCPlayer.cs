using UnityEngine;
using UnityEngine.AI;

public class NPCPlayer : MonoBehaviour
{
    private NavMeshAgent agent;  // El componente NavMeshAgent para mover el NPC
    public NavMeshRandomPosition navMeshRandomPosition;  // Referencia al script de posiciones aleatorias
    public float moveRange = 10f;  // Rango dentro del cual buscar una nueva posici�n
    public float waitTime = 3f;    // Tiempo de espera antes de buscar una nueva posici�n

    private void Start()
    {
        // Obtener el NavMeshAgent del NPC
        agent = GetComponent<NavMeshAgent>();

        // Iniciar el proceso de movimiento repetido
        InvokeRepeating("MoveToRandomPosition", 1f, waitTime);
    }

    // M�todo para mover al NPC a una posici�n aleatoria en el NavMesh
    private void MoveToRandomPosition()
    {
        Vector3 randomPosition;
        // Llamar al m�todo de NavMeshRandomPosition para obtener una posici�n aleatoria v�lida
        if (navMeshRandomPosition.GetRandomNavMeshPosition(transform.position, moveRange, out randomPosition))
        {
            // Si se encuentra una posici�n v�lida, mover al NPC a esa posici�n
            agent.SetDestination(randomPosition);
        }
        else
        {
            Debug.Log("No se encontr� una posici�n v�lida en el NavMesh.");
        }
    }
}
