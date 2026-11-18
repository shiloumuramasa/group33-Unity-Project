using UnityEngine;

public class CrosshairScript : MonoBehaviour
{
    [SerializeField] private Texture2D crosshairTexture;
    private Vector2 crosshairCenter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        crosshairCenter = new Vector2(crosshairTexture.width / 2, crosshairTexture.height / 2);
        Cursor.SetCursor(crosshairTexture, crosshairCenter, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
