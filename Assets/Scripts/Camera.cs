using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Arraste seu Player aqui no Inspector
    public float smoothSpeed = 0.125f; // Suavidade do movimento

    void FixedUpdate()
    {
        if (player != null)
        {
            // Cria a posição alvo com X e Y do jogador, mantendo o Z fixo em -10
            Vector3 desiredPosition = new Vector3(player.position.x, player.position.y, -10);
            
            // Faz a câmera ir suavemente até essa posição
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        }
    }
}