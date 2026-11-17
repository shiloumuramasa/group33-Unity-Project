using UnityEngine;

public class Player_Camera : MonoBehaviour
{
    public Transform target;

    [Header("Settings")]
    [SerializeField] Vector3 fixedOffset = new Vector3(0, 0.5f, 0);
    [SerializeField] Vector2 smoothness = new Vector3(0.1f, 0.25f);
    [Space]
    [SerializeField] float mouseMoveAmount = 1;

    private bool usingMouse = true;
    private Vector2 mousePosition;
    private Vector2 velocity;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        // Get Mouse Position
        Rect screenRect = new Rect(0, 0, Screen.width, Screen.height);
        if (screenRect.Contains(Input.mousePosition)) mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        // Switch to Mouse Input
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1)) usingMouse = true;
    }

    void FixedUpdate()
    {
        // * Multiplying by 0.1363 will give roughly the same amount of Offset to both Mouse and Controller Input on 16:9 Aspect Ratio
        Vector2 myPosition = Vector2.Lerp(target.position + fixedOffset, mousePosition, mouseMoveAmount * 0.1363f);

        float posX = 0;
        float posY = 0;

        // Smooth out the Camera movement
        if (usingMouse)
        {
            // Mouse Input
            posX = Mathf.SmoothDamp(transform.position.x, myPosition.x, ref velocity.x, smoothness.x);
            posY = Mathf.SmoothDamp(transform.position.y, myPosition.y, ref velocity.y, smoothness.y);
        }
        // Apply the new position
        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}