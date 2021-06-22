using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meledak : MonoBehaviour
{
    public Transform ledakan;

    public Text textSkor;
    // Start is called before the first frame update
    void Start()
    {
        
    }
        private void OnTriggerEnter(Collider Col)
    {
        Destroy(gameObject);
        Instantiate(ledakan);
    }
    // Update is called once per frame
    void Update()
    {
        ledakan.position = gameObject.transform.position;
    }
}
