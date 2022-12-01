using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    //this objects position should be the same as the cars position
    [SerializeField] GameObject playerObject;

    void LateUpdate()
    {
        transform.position = playerObject.transform.position + new Vector3(0,0,-10);
    }
}
