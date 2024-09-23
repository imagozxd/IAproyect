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
            Wander(); // Mover a una posici�n aleatoria
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Evade(); // Evasi�n del target
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
        MoveToPosition(randomPos); // Mover al NPC a la posici�n aleatoria calculada
    }

    private Vector3 RandomPosition(Vector3 center, float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += center;

        NavMeshHit hit;
        
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, NavMesh.AllAreas))
        {
            return hit.position; // Si se encuentra una posici�n v�lida, devolverla
        }
        return center; // Si no se encuentra una posici�n, devolver la posici�n actual
    }

    public void Evade()
    {
        if (target == null) return;

        Vector3 directionToTarget = transform.position - target.position; // Calcular la direcci�n opuesta al target
        Vector3 evadePosition = transform.position + directionToTarget.normalized * evadeDistance; // Calcular la posici�n de evasi�n

        NavMeshHit hit;
        if (NavMesh.SamplePosition(evadePosition, out hit, evadeDistance, NavMesh.AllAreas))
        {
            MoveToPosition(hit.position); // Mover al NPC a la posici�n de evasi�n
        }
    }
}
