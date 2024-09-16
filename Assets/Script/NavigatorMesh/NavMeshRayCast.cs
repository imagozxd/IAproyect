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

    // Funci�n para realizar el RayCast entre dos puntos
    private void PerformRayCast(Vector3 start, Vector3 end)
    {
        RaycastHit hit; // Estructura para almacenar informaci�n del impacto del RayCast
        Vector3 direction = end - start; // Direcci�n del RayCast

        // Realizar el RayCast
        if (Physics.Raycast(start, direction, out hit, direction.magnitude))
        {
            Debug.Log("RayCast impact� en: " + hit.point);
            Debug.Log("Objeto impactado: " + hit.collider.name);

            // Visualizar el RayCast en la escena
            Debug.DrawLine(start, hit.point, Color.red, 1f); // L�nea desde el inicio al punto de impacto
            Debug.DrawLine(hit.point, end, Color.green, 1f); // L�nea desde el punto de impacto al final
        }
        else
        {
            Debug.Log("RayCast no impact� en ning�n objeto.");
            // Visualizar la l�nea completa si no hay colisi�n
            Debug.DrawLine(start, end, Color.blue, 1f); // L�nea desde el inicio hasta el final
        }
    }

    // M�todo opcional para visualizar el RayCast en la escena usando Gizmos
    private void OnDrawGizmos()
    {
        if (startPoint != null && endPoint != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(startPoint.position, endPoint.position);
        }
    }
}
