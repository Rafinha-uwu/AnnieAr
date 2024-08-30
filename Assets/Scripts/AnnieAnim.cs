using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnieAnim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AtivaParametro(string Parametro)
    {
        // referência para o animator
        Animator AnimaMaq = GetComponent<Animator>();
        // itera todos os parâmetros que encontrar no animator
        foreach (AnimatorControllerParameter P in AnimaMaq.parameters)
        {
            if (P.type == AnimatorControllerParameterType.Bool)
            {
                if (P.name == Parametro)
                {
                    AnimaMaq.SetBool(P.name, true);
                    StartCoroutine(Reset(P.name, 0.1f));
                }
                else
                {
                    AnimaMaq.SetBool(P.name, false);
                }
            }
        }
    }

    private IEnumerator Reset(string paramName, float delay)
    {
        yield return new WaitForSeconds(delay);
        Animator AnimaMaq = GetComponent<Animator>();
        AnimaMaq.SetBool(paramName, false);
    }
}
