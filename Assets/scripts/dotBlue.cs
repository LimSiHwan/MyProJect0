using UnityEngine;
using System.Collections;

public class dotBlue : MonoBehaviour {
    
    const int dotSpeed = 3;

    void Start()
    {
        StartCoroutine(dotBlueRotation());
    }

    IEnumerator dotBlueRotation()
    {
        while (true)
        {
            transform.Rotate(Vector3.forward * dotSpeed);
            yield return new WaitForEndOfFrame();
        }
    }
}
