using Unity.Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraTarget : MonoBehaviour
{

    [SerializeField] private Camera cam;
    [SerializeField] private Transform player;
    [SerializeField] private float xThreshold;
    [SerializeField] private float yThreshold;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AimLogic();
    }

    private void AimLogic()
    { 
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPos = (player.position + mousePos) / 2;

        targetPos.x = Mathf.Clamp(targetPos.x, -xThreshold + player.position.x, xThreshold + player.position.x);
        targetPos.y = Mathf.Clamp(targetPos.y, -yThreshold + player.position.y, yThreshold + player.position.y);

        this.transform.position = targetPos;
    }
}
