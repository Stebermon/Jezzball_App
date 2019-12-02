using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCreation : MonoBehaviour
{
    public Vector2 startPos;
    public Vector2 direction;
    public double sensitivity = 1.5;
    public bool horiMove;
    public bool vertMove;
    public bool movement;
    public Vector3 directionVector;
    public Vector3 directionVert;
    public GameObject Wall;
    private RaycastHit hit;
    private Ray ray;
    private Ray startRay;
    private GameObject selection;

    //inside class
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        directionVector = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        directionVert = new Vector3(0, Input.GetAxis("Vertical"), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.transform.GetComponent<SpriteRenderer>().color);
                hit.transform.GetComponent<SpriteRenderer>().color = Color.red;
                //Debug.Log(hit.collider.gameObject);
                Destroy(hit.collider.gameObject);
                var attackWall = Instantiate(Wall, hit.transform.position, Quaternion.identity);
                attackWall.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.transform.GetComponent<SpriteRenderer>().color);
                hit.transform.GetComponent<SpriteRenderer>().color = new Color(.9f, .9f, .9f, 1f); ;
            }
        }
        if (Input.GetKeyDown("a"))
        {
            transform.Rotate(Vector3.forward * 2);
        }

        if (Input.GetKeyDown("d"))
        {
            transform.Rotate(Vector3.back * 2);
        }


        //if no keyboard input... use mobile controls
        if (directionVector == Vector3.zero)
        {
            
            //check for moved or stationary finger
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
            {

                //check for change in direction every frame
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

                if (Input.GetTouch(0).phase == TouchPhase.Stationary)
                {
                    startRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

                    if (Physics.Raycast(startRay, out hit))
                    {
                        selection = hit.collider.gameObject;
                        hit.transform.GetComponent<SpriteRenderer>().color = Color.red;
                        if (Mathf.Abs(touchDeltaPosition.x) < sensitivity || Mathf.Abs(touchDeltaPosition.y) < sensitivity)
                        {
                            hit.transform.GetComponent<SpriteRenderer>().color = new Color(.9f, .9f, .9f, 1f);
                        }
                    }

                }

                //if direction is greater than sensitivity (1.5), set the movement to right, also set mobileRight to true... this will allow movement with stationary finger
                if (touchDeltaPosition.x > sensitivity || touchDeltaPosition.x < -sensitivity)
                {
                    // Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

                    if (Physics.Raycast(ray, out hit))
                    {
                        var position = hit.transform.position;

                        Destroy(hit.collider.gameObject);
                        var attackWall = Instantiate(Wall, position, Quaternion.identity);
                        attackWall.GetComponent<SpriteRenderer>().color = Color.red;
                        //set movement right
                        directionVector = Vector3.back * 2;
                        //transform.Rotate(directionVector);

                        //allows for movement after finger stops moving
                        horiMove = true;
                        vertMove = false;
                    }
                }

                //else check to see if direction of finger movement is less than -sensitivity (-1.5) if so set direction to left and mobileRight to false
                else if (touchDeltaPosition.y < -sensitivity || touchDeltaPosition.y > sensitivity)
                {

                    //set direction to left
                    directionVector = Vector3.forward * 2;
                    //transform.Rotate(directionVector);

                    // set mobileRight to false allowing later testing
                    vertMove = true;
                    horiMove = false;
                }

                


                //check to see if last direction was right,... if so move right while finger direction is 0
                if (horiMove)
                {
                    //directionVector = Vector3.right;
                }

                //if last direction was left move left as above
                if (vertMove)
                {
                    //directionVector = Vector3.left;
                }
                
            }
            //if touch direction is 0 (Finger NOT moving)
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {

                var ray2 = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

                if (Physics.Raycast(ray2, out hit))
                {
                    if (hit.collider.gameObject == selection)
                    {
                        selection.transform.GetComponent<SpriteRenderer>().color = new Color(.9f, .9f, .9f, 1f);
                    }
                }
            }

        }

        //code for other part of game... allows me to disable movement quickly
        if (!movement)
        {
            directionVector = Vector3.zero;

        }
    }
    public Vector3 getDirection()
    {
        return directionVector;
    }
}
