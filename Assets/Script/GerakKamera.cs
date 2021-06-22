using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerakKamera : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 50 && transform.position.x < 110)
        {
            transform.position += new Vector3(Input.GetAxis("Mouse X") * Time.deltaTime * speed, 0, Input.GetAxis("Mouse Y") * Time.deltaTime * speed);
        }
        else 
        {
            transform.position = new Vector3(75.1f, 30.48f, -4.03f);
        }
        transform.position = new Vector3(this.gameObject.transform.position.x, this.transform.position.y, -4.03f);
    }
}
