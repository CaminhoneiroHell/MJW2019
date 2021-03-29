using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float boundarieRight = 10;
    [SerializeField] private float boundarieLeft = -10;

    [SerializeField] private float boundarieUp = 7;
    [SerializeField] private float boundarieDown = -7;
    [SerializeField] private GameObject jetpackParticles;

    Vector3 startPos;
    private Vector3 jetpachStartpos;
    private bool canMoveX, canMoveY, flipJetPack;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        jetpachStartpos = jetpackParticles.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //float x, y, z;

        //x = startPos.x;
        //y = startPos.y;
        //z = startPos.z;

        //y = Mathf.Cos(Time.timeSinceLevelLoad);//x * speed * Input.GetAxis("Horizontal") * Time.deltaTime; 
        //transform.position = new Vector3(x, y, z);

        canMoveX = false;
        canMoveY = false || Input.GetAxis("Vertical") < 0 && transform.position.y > boundarieDown || Input.GetAxis("Vertical") > 0 && transform.position.y < boundarieUp;

        if ( Input.GetAxis("Horizontal") < 0 && transform.position.x > boundarieLeft)
        {
            canMoveX = true;
            GetComponent<SpriteRenderer>().flipX = true;
            flipJetPack = true;
            jetpackParticles.transform.position = new Vector3(transform.position.x + 3.1f, transform.position.y + 0.9f, transform.position.z);
        }

        if (Input.GetAxis("Horizontal") > 0 && transform.position.x < boundarieRight)
        {
            canMoveX = true;
            GetComponent<SpriteRenderer>().flipX = false;
            flipJetPack = false;
            jetpackParticles.transform.position = new Vector3(transform.position.x, transform.position.y + 0.9f, transform.position.z);
        }

        if (!canMoveY && canMoveX)
            transform.position += transform.right * _speed * Time.deltaTime * Input.GetAxis("Horizontal");

        if (!canMoveX && canMoveY)
            transform.position += transform.up * _speed * Time.deltaTime * Input.GetAxis("Vertical");

        else if(canMoveY && canMoveX)
            transform.position += transform.right * _speed * Time.deltaTime * Input.GetAxis("Horizontal")
                                  + transform.up * _speed * Time.deltaTime * Input.GetAxis("Vertical");
        
        
        
        //transform.position = transform.position;
        //print("Out of boundary");

        if (Input.GetKeyDown(KeyCode.KeypadPlus)) { _speed++; }
        if (Input.GetKeyDown(KeyCode.KeypadMinus)) { _speed--;}
    }
}
