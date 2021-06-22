using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Musuh : MonoBehaviour
{
    public Transform Target;
    public Animator anim;
    public float jarak;
    public float kecepatan;

    public Text textSkor;
    int skor = 0;

    public float waktuUntukRestart = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Target.position, this.transform.position) < 100)
        {
            Vector3 direction = Target.position - this.transform.position;
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
            if (direction.magnitude > jarak)
            {
                this.transform.Translate(0, 0, kecepatan);
                anim.SetBool("Walk", true);
                anim.SetBool("Attack", false);
                anim.SetBool("Idle", false);
            }
            else
            {
                anim.SetBool("Attack", true);
                anim.SetBool("Walk", false);
                anim.SetBool("Idle", false);

                //if (Time.time == waktuUntukRestart)
                //{
                //    SceneManager.LoadScene("SampleScene");
                //}
            }
        }
        else
        {
            anim.SetBool("Idle", true);
            anim.SetBool("Attack", false);
            anim.SetBool("Walk", false);
        }
        //float coba = Time.captureDeltaTime;
        //print(Time.time + " | " + Time.deltaTime + " | " + Time.realtimeSinceStartup+" | "+Time.frameCount+" | "+coba);
        //text = "Skor : " + skor.ToString();
        //jumlahAset = gameObject.Equals;
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
