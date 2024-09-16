using UnityEngine;
using UnityEngine.AI;

public class NPCPlayer : MonoBehaviour
{
    private NavMeshAgent agent;  // El componente NavMeshAgent para mover el NPC
    public NavMeshRandomPosition navMeshRandomPosition;  // Referencia al script de posiciones aleatorias
    public float moveRange = 10f;  // Rango dentro del cual buscar una nueva posición
    public float waitTime = 3f;    // Tiempo de espera antes de buscar una nueva posición

    private void Start()
    {
        // Obtener el NavMeshAgent del NPC
        agent = GetComponent<NavMeshAgent>();

        // Iniciar el proceso de movimiento repetido
        InvokeRepeating("MoveToRandomPosition", 1f, waitTime);
    }

    // Método para mover al NPC a una posición aleatoria en el NavMesh
    private void MoveToRandomPosition()
    {
        Vector3 randomPosition;
        // Llamar al método de NavMeshRandomPosition para obtener una posición aleatoria válida
        if (navMeshRandomPosition.GetRandomNavMeshPosition(transform.position, moveRange, out randomPosition))
        {
            // Si se encuentra una posición válida, mover al NPC a esa posición
            agent.SetDestination(randomPosition);
        }
        else
        {
            Debug.Log("No se encontró una posición válida en el NavMesh.");
        }
    }
}
