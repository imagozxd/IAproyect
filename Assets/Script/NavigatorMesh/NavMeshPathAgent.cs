using UnityEngine;
using UnityEngine.AI;

public class NavMeshPathAgent : MonoBehaviour
{
    private NavMeshAgent agent;
    private NavMeshPath path;  // Almacena el Path calculado
    public Transform target;   // El objetivo hacia donde el NPC se mover�

    void Start()
    {
        // Obtener el NavMeshAgent del objeto
        agent = GetComponent<NavMeshAgent>();

        // Crear un nuevo objeto NavMeshPath
        path = new NavMeshPath();
    }

    void Update()
    {
        // Calcular el Path hacia la posici�n del objetivo
        if (target != null)
        {
            CalculateAndSetPath(target.position);
        }
    }

    // Funci�n para calcular un Path hacia una posici�n espec�fica
    private void CalculateAndSetPath(Vector3 destination)
    {
        // Calcular el Path hacia el destino
        if (NavMesh.CalculatePath(agent.transform.position, destination, NavMesh.AllAreas, path))
        {
            // Si se encuentra un camino v�lido, asignarlo al agente
            //agent.SetPath(path);//ESTA LINEA HACE QUE SE MUEVA EL AGENT
        }
        else
        {
            Debug.Log("No se pudo encontrar un camino v�lido hacia el destino.");
        }
    }

    // M�todo opcional para visualizar el Path en la escena
    private void OnDrawGizmos()
    {
        if (path != null && path.corners.Length > 0)
        {
            Gizmos.color = Color.green;
            for (int i = 0; i < path.corners.Length - 1; i++)
            {
                Gizmos.DrawLine(path.corners[i], path.corners[i + 1]);
            }
        }
    }
}
