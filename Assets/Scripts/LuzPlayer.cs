using UnityEngine;
using UnityEngine.UI;

public class LuzPlayer : MonoBehaviour
{
    public Transform player;
    public RectTransform luzRect;
    public Camera cam;

    void Update()
    {
        Vector2 screenPos = cam.WorldToScreenPoint(player.position);
        luzRect.position = screenPos;
    }
}