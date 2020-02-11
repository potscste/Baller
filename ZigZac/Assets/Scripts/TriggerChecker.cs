using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit(Collider collider) {
        if (collider.gameObject.tag == "Ball") {
            Invoke("FallDown", 0.3f);

            Destroy(transform.parent.gameObject, 2f);
        }
    }

    void FallDown() {
        GetComponentInParent<Rigidbody>().useGravity = true;
        GetComponentInParent<Rigidbody>().isKinematic = false;
    }
}
