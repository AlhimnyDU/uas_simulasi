using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    public Rigidbody bulletPrefabs;
    public GameObject cursor;
    public Transform shootPoint;
    public LayerMask layer;
    public float kecepatan;
    private Camera cam;

    public int maxPeluru = 10;
    private int currPeluru;
    public float reloadTime = 0.5f;
    private bool isReloading = false;
    public Text ammoDisplay;

    public Text lokasiX; 
    public Text lokasiY;
    public Text lokasiZ;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        currPeluru = maxPeluru;
    }

    // Update is called once per frame
    void Update()
    {
        LaunchProjectile();
        if (isReloading)
        {
            return;
        }

        if (Input.GetMouseButtonDown(1)) 
            StartCoroutine(Reload());

        //untuk text posisi
        lokasiX.text = "X : "+cursor.transform.position.x.ToString();
        lokasiY.text = "Y : "+cursor.transform.position.y.ToString();
        lokasiZ.text = "Z : "+cursor.transform.position.z.ToString();
    }
    IEnumerator Reload()
    {
        isReloading = true;
        //Debug.Log("Reloading....");
        ammoDisplay.text = "Reloading";

        yield return new WaitForSeconds(reloadTime);

        currPeluru = maxPeluru;
        isReloading = false;
    }

    void LaunchProjectile()
    {
        if (currPeluru <= 0)
        {
            ammoDisplay.text = "Reload";
        }
        else
        {
            ammoDisplay.text = currPeluru.ToString() + "/10";
        }

        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(camRay, out hit, 100f, layer)) //cek if raycast hit something return true
        {
            cursor.SetActive(true);
            cursor.transform.position = hit.point; //move cursor to hit positon with offset

            Vector3 Vo = CalculateVelocity(hit.point, shootPoint.position, kecepatan);

            transform.rotation = Quaternion.LookRotation(Vo); // make canon always look at angle of velocity

            if (Input.GetMouseButtonDown(0) && currPeluru > 0) //if left click start shooting
            {
                Debug.Log("Shoot...");
                Rigidbody obj = Instantiate(bulletPrefabs, shootPoint.position, Quaternion.identity);
                obj.velocity = Vo;

                currPeluru--;
                Debug.Log("Peluru : " + currPeluru);
            }
        }
        else
        {
            cursor.SetActive(false);
        }
    }

    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
    {
        //define the distance x and y first
        Vector3 distance = target - origin;
        Vector3 distance_x_z = distance;
        distance_x_z.Normalize();
        distance_x_z.y = 0;

        //creating a float that represents our distance 
        float sy = distance.y;
        float sxz = distance.magnitude;


        //calculating initial x velocity
        //Vx = x / t
        float Vxz = sxz / time;

        ////calculating initial y velocity
        //Vy0 = y/t + 1/2 * g * t
        float Vy = sy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 result = distance_x_z * Vxz;
        result.y = Vy;

        return result;
    }
}
