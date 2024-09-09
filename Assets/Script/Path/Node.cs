using UnityEngine;
using System.Collections.Generic;

public class Node : MonoBehaviour
{
    public List<Node> connectedNodes = new List<Node>();
    public bool isWalkable = true;

    private void OnDrawGizmos()
    {
        // Dibujar nodos y conexiones en el editor
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.2f);

        Gizmos.color = Color.yellow;
        foreach (Node connectedNode in connectedNodes)
        {
            Gizmos.DrawLine(transform.position, connectedNode.transform.position);
        }
    }
}
