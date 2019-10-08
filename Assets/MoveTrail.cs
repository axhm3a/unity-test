using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrail : MonoBehaviour
{

    public int moveSpeed = 230;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime * Vector3.right);
        Destroy(gameObject, 1);
    }
}
