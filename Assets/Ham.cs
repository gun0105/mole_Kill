using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ham : MonoBehaviour
{
    public float Speed = 50f;
    Quaternion hammerTarget;
    Quaternion hammerUp = Quaternion.Euler(0, 0, 0);
    Quaternion hammerDown = Quaternion.Euler(90, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
            transform.position = new Vector3 (hit.point.x, transform.position.y, hit.point.z);

        if (Input.GetMouseButtonDown(0)) hammerTarget = hammerDown;
        transform.rotation = Quaternion.Lerp(transform.rotation, hammerTarget, Mathf.Clamp (Speed * Time.deltaTime, 0, 0.9999f));
        if (transform.rotation == hammerDown) hammerTarget = hammerUp;
//        if (Input.GetMouseButtonUp(0)) hammerTarget = hammerUp;
    }
}
