using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform playerTransform;

    public Vector3 offset;

    public Vector2 maxPosition;
    public Vector2 minPosition;
    
    public float interpolationRatio = 0;
    
    // Start is called before the first frame update
    void Awake()
    {
      playerTransform = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      if(playerTransform == null)
      {
        return;
      }
    { 
     Vector3 desirePosition = playerTransform.position + offset;
     float clampX = Mathf.Clamp(desirePosition.x, minPosition.x, maxPosition.x);
     float clampY = Mathf.Clamp(desirePosition.y, minPosition.y, maxPosition.y);
     
     Vector3 clampedPosition = new Vector3(clampX, clampY, desirePosition.z);
     
     Vector3 lerpePosition = Vector3.Lerp(transform.position, clampedPosition, interpolationRatio);
     
      transform.position = lerpePosition;
    }

    }
}