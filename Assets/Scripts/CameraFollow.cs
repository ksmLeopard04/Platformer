using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform followTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        this.transform.position = new Vector3(followTransform.position.x + 3f, followTransform.position.y + 3f, this.transform.position.z);
    }
}
