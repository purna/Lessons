using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPosition : MonoBehaviour
{

    public GameObject prefab;
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Input.mousePosition;
            pos.z = Camera.main.nearClipPlane;
            Vector2 world_pos = Camera.main.ScreenToWorldPoint(pos);
            Instantiate(prefab, world_pos, Quaternion.identity);
        }

    }
}

