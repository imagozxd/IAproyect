using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform target;
    public float wanderRadius = 10f;
    public float evadeDistance = 5f; 

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // Obtener el NavMeshAgent del NPC
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            MoveToPosition(target.position); // Mover al target
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Wander(); // Mover a una posición aleatoria
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Evade(); // Evasión del target
        }
    }

    public void MoveToPosition(Vector3 destination)
    {
        if (agent != null)
        {
            agent.SetDestination(destination); // Establecer destino para el agente
        }
    }

    public void Wander()
    {
        Vector3 randomPos = RandomPosition(transform.position, wanderRadius);
        MoveToPosition(randomPos); // Mover al NPC a la posición aleatoria calculada
    }

    private Vector3 RandomPosition(Vector3 center, float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += center;

        NavMeshHit hit;
        
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, NavMesh.AllAreas))
        {
            return hit.position; // Si se encuentra una posición válida, devolverla
        }
        return center; // Si no se encuentra una posición, devolver la posición actual
    }

    public void Evade()
    {
        if (target == null) return;

        Vector3 directionToTarget = transform.position - target.position; // Calcular la dirección opuesta al target
        Vector3 evadePosition = transform.position + directionToTarget.normalized * evadeDistance; // Calcular la posición de evasión

        NavMeshHit hit;
        if (NavMesh.SamplePosition(evadePosition, out hit, evadeDistance, NavMesh.AllAreas))
        {
            MoveToPosition(hit.position); // Mover al NPC a la posición de evasión
        }
    }
}
