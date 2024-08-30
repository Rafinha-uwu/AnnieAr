using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ReadCode : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    Manager manager;
    public GameObject Man;

    public GameObject personagem;

    bool arrasta = false;
    float angY = 3f;
    float mouseX;


    // Start is called before the first frame update
    void Start()
    {
        manager = Man.GetComponent<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (arrasta == true)
        {

            if (mouseX > Mouse.current.position.ReadValue().x)
            {
                Vector3 p3 = this.transform.localPosition;
                p3.x -= 0.004f;
                if (p3.x > -0.4)
                {
                    this.transform.localPosition = p3;
                    personagem.transform.localEulerAngles += new Vector3(0f, angY, 0f);
                }
            }
            if (mouseX < Mouse.current.position.ReadValue().x)
            {
                Vector3 p3 = this.transform.localPosition;
                p3.x += 0.004f;
                if (p3.x < 0.2)
                {
                    this.transform.localPosition = p3;
                    personagem.transform.localEulerAngles -= new Vector3(0f, angY, 0f);
                }
            }

            mouseX = Mouse.current.position.ReadValue().x;


            print(mouseX);
            
        }
           
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Pos
        this.transform.localPosition += new Vector3(0f, -0.01f, 0f);

        //Cor
        Color currentColor = this.GetComponentInChildren<Renderer>().material.GetColor("_Color");
        currentColor.a += 50f;
        this.GetComponentInChildren<Renderer>().material.SetColor("_Color", currentColor);

        if(this.gameObject.name == "Slide")
        {
            arrasta = true;
        }


    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Pos
        this.transform.localPosition += new Vector3(0f, 0.01f, 0f);

        //Cor
        Color currentColor = this.GetComponentInChildren<Renderer>().material.GetColor("_Color");
        currentColor.a -= 50f;
        this.GetComponentInChildren<Renderer>().material.SetColor("_Color", currentColor);

        //Var

        if (this.gameObject.name == "Slide")
        {
            if (personagem.gameObject.transform.eulerAngles.z < 10 && personagem.gameObject.transform.eulerAngles.z > -10)
            {
                manager.Butt = "Next";
            }
            arrasta = false;
        }
        else { manager.Butt = this.gameObject.name; }
        



    }

}
