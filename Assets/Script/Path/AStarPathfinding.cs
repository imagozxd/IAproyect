using System.Collections.Generic;
using UnityEngine;

public class AStarPathfinding : MonoBehaviour
{
    public Node startNode; // Nodo inicial
    public Node targetNode; // Nodo objetivo
    private List<Node> path = new List<Node>();

    public void FindPath(Node start, Node target)
    {
        List<Node> openSet = new List<Node>(); // Nodos por evaluar
        HashSet<Node> closedSet = new HashSet<Node>(); // Nodos ya evaluados

        openSet.Add(start);

        Dictionary<Node, Node> cameFrom = new Dictionary<Node, Node>();
        Dictionary<Node, float> gCost = new Dictionary<Node, float>(); // Costo desde el inicio hasta el nodo actual
        Dictionary<Node, float> fCost = new Dictionary<Node, float>(); // gCost + heurística

        foreach (Node node in FindObjectsOfType<Node>())
        {
            gCost[node] = float.MaxValue;
            fCost[node] = float.MaxValue;
        }

        gCost[start] = 0;
        fCost[start] = Heuristic(start, target);

        while (openSet.Count > 0)
        {
            Node currentNode = GetNodeWithLowestFCost(openSet, fCost);

            if (currentNode == target)
            {
                RetracePath(start, target, cameFrom);
                return;
            }

            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            foreach (Node neighbor in currentNode.connectedNodes)
            {
                if (closedSet.Contains(neighbor) || !neighbor.isWalkable)
                    continue;

                float tentativeGCost = gCost[currentNode] + Vector3.Distance(currentNode.transform.position, neighbor.transform.position);

                if (tentativeGCost < gCost[neighbor])
                {
                    cameFrom[neighbor] = currentNode;
                    gCost[neighbor] = tentativeGCost;
                    fCost[neighbor] = gCost[neighbor] + Heuristic(neighbor, target);

                    if (!openSet.Contains(neighbor))
                        openSet.Add(neighbor);
                }
            }
        }
    }

    private float Heuristic(Node nodeA, Node nodeB)
    {
        return Vector3.Distance(nodeA.transform.position, nodeB.transform.position);
    }

    private Node GetNodeWithLowestFCost(List<Node> openSet, Dictionary<Node, float> fCost)
    {
        Node lowestFCostNode = openSet[0];

        foreach (Node node in openSet)
        {
            if (fCost[node] < fCost[lowestFCostNode])
                lowestFCostNode = node;
        }

        return lowestFCostNode;
    }

    private void RetracePath(Node start, Node end, Dictionary<Node, Node> cameFrom)
    {
        path.Clear();
        Node currentNode = end;

        while (currentNode != start)
        {
            path.Add(currentNode);
            currentNode = cameFrom[currentNode];
        }

        path.Reverse();
        // Aquí tendrías la lista de nodos en el camino más corto
    }

    public List<Node> GetPath()
    {
        return path;
    }
}
