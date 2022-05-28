using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public Rigidbody rb;
    public float jumpForce;
    public GameObject splashPrefab;
    private GameManager gm;

    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        rb.AddForce(Vector3.up * jumpForce);
        GameObject splash = Instantiate(splashPrefab, transform.position - new Vector3(0f,  0.23f,0f), transform.rotation);
        splash.transform.SetParent(other.gameObject.transform);

        string metarialName = other.gameObject.GetComponent<MeshRenderer>().material.name;

      if (metarialName == "UnSafeColor (Instance)")
        {
            //bölüm yeniden baþlat
            gm.RestartGame();
        }

        else if (metarialName == "LastRing (Instance)")
        {
            //bir sonraki levele geç.
            Debug.Log("Next Level");
        }
    }
}
