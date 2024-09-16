using UnityEngine;

public class NavMeshRayCast : MonoBehaviour
{
    public Transform startPoint;   // El punto de inicio del RayCast
    public Transform endPoint;     // El punto final del RayCast

    void Update()
    {
        if (startPoint != null && endPoint != null)
        {
            PerformRayCast(startPoint.position, endPoint.position);
        }
    }

    // Función para realizar el RayCast entre dos puntos
    private void PerformRayCast(Vector3 start, Vector3 end)
    {
        RaycastHit hit; // Estructura para almacenar información del impacto del RayCast
        Vector3 direction = end - start; // Dirección del RayCast

        // Realizar el RayCast
        if (Physics.Raycast(start, direction, out hit, direction.magnitude))
        {
            Debug.Log("RayCast impactó en: " + hit.point);
            Debug.Log("Objeto impactado: " + hit.collider.name);

            // Visualizar el RayCast en la escena
            Debug.DrawLine(start, hit.point, Color.red, 1f); // Línea desde el inicio al punto de impacto
            Debug.DrawLine(hit.point, end, Color.green, 1f); // Línea desde el punto de impacto al final
        }
        else
        {
            Debug.Log("RayCast no impactó en ningún objeto.");
            // Visualizar la línea completa si no hay colisión
            Debug.DrawLine(start, end, Color.blue, 1f); // Línea desde el inicio hasta el final
        }
    }

    // Método opcional para visualizar el RayCast en la escena usando Gizmos
    private void OnDrawGizmos()
    {
        if (startPoint != null && endPoint != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(startPoint.position, endPoint.position);
        }
    }
}
