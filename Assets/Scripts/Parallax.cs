using System.Runtime.CompilerServices;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    private float startPos, parallaxLength;
    public GameObject camera;
    public float parallaxSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position.x;
        parallaxLength = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = camera.transform.position.x * parallaxSpeed;
        float movement = camera.transform.position.x * (1 - parallaxSpeed);

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if (movement > startPos + parallaxLength)
        {
            startPos += parallaxLength;
        }
        else if (movement < startPos - parallaxLength)
        {
            startPos -= parallaxLength;
        }
    }
}
