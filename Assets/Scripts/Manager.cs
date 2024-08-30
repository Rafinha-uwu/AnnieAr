using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Manager : MonoBehaviour
{

    public float Fase = 0;
    public bool On = true;

    private bool FO = false;
    private bool FI = false;

    public GameObject Gate1;
    public GameObject Gate2;
    public GameObject Bush;
    public GameObject Ped;
    public GameObject AnnieBall;
    public GameObject BallGate;
    public GameObject Annie;


    AnnieAnim annie;
    public GameObject Ann;

    TypeOutScript tp;
    public GameObject TP;

    public string Butt;

    public GameObject Next;
    public GameObject B1;
    public GameObject B2;
    public GameObject B3;
    public GameObject Left;
    public GameObject Right;
    public GameObject Slide;

    public bool ANext = true;
    public bool AB1 = false;
    public bool AB2 = false;
    public bool AB3 = false;
    public bool ALeft = false;
    public bool ARight = false;
    public bool ASlide = false;

    public bool P2 = false;
    public bool P3 = false;
    public bool P4 = false;

    public Light DirectionalLight;


    // Start is called before the first frame update
    void Start()
    {
        tp = TP.GetComponent<TypeOutScript>();
        annie = Ann.GetComponent<AnnieAnim>();
    }

    // Update is called once per frame
    void Update()
    {


        if(FO)
        {
            FadeOutGameObjectAndChildren(Next);
            FadeOutGameObjectAndChildren(B1);
            FadeOutGameObjectAndChildren(B2);
            FadeOutGameObjectAndChildren(B3);
            FadeOutGameObjectAndChildren(Right);
            FadeOutGameObjectAndChildren(Left);
            FadeOutGameObjectAndChildren(Slide);
        }

        if (FI)
        {
            FadeGameObjectAndChildren(Next);
            FadeGameObjectAndChildren(B1);
            FadeGameObjectAndChildren(B2);
            FadeGameObjectAndChildren(B3);
            FadeGameObjectAndChildren(Right);
            FadeGameObjectAndChildren(Left);
            FadeGameObjectAndChildren(Slide);
        }

        switch (Butt)
        {
            case "Next":
                Fase++; On = true;
                break;

            case "1":
                if (P3 == true && P4 == false) { P4 = true; Butt = ""; }
                else { P2 = false; P3 = false; P4 = false; Butt = ""; }
                break;

            case "2":
                if (P3 == false) 
                { 
                    if(P2 == false) { P2 = true; Butt = ""; }
                    else { P3 = true; Butt = ""; }

                }
                else { P2 = false; P3 = false; P4 = false; Butt = ""; }
                break;

            case "3":
                if (P4 == true) { Fase++; On = true; }
                else { P2 = false; P3 = false; P4 = false; Butt = ""; }
                break;


            case "Right":
                Fase++; On = true;
                break;

            case "Left":
                Fase++; On = true;
                break;  

        }

        if (On)
        {
            this.GetComponents<AudioSource>()[2].Play();

            switch (Fase)
            {
                //Sad

                case 1:

                    //Text
                    tp.FinalText = "Oh, Hello Annie";
                    tp.Star();

                    //Animation
                    annie.AtivaParametro("Sad");

                    //Reset
                    Butt = "";
                    On = false;
                    break;

                case 2:

                    //Text
                    tp.FinalText = "I'm sure you're scared, but we promise everything will be alright";
                    tp.Star();

                    //Reset
                    StartCoroutine(Transit());
                    Butt = "";
                    On = false;
                    break;

                case 3:

                    //Text
                    tp.FinalText = "We'll guide you through the forest";
                    tp.Star();

                    //Animation
                    annie.AtivaParametro("Idle");

                    //Reset
                    StartCoroutine(Transit());
                    Butt = "";
                    On = false;
                    break;

                case 4:

                    //Text
                    tp.FinalText = "Let's go!";
                    tp.Star();

                    //Reset
                    StartCoroutine(Transit());
                    Butt = "";
                    On = false;
                    break;

                //SadW

                case 5:

                    //Text
                    tp.FinalText = "That's it, you're doing great";
                    tp.Star();

                    //Animation
                    annie.AtivaParametro("Sad Walk");

                    //Reset
                    StartCoroutine(Transit());
                    Butt = "";
                    On = false;
                    break;

                case 6:

                    //Text
                    tp.FinalText = "You'll be home in no time";
                    tp.Star();

                    //Reset
                    StartCoroutine(Transit());
                    Butt = "";
                    On = false;
                    break;

                //Scared-PExp

                case 7:
                    this.GetComponents<AudioSource>()[4].Play();
                    //Text
                    tp.FinalText = "Oh!";
                    tp.Star();

                    //Animation
                    annie.AtivaParametro("Scare");

                    //Reset
                    StartCoroutine(Transit());
                    Butt = "";
                    On = false;
                    

                    //Scene

                    Gate1.SetActive(true);

                    break;

                case 8:

                    //Text
                    tp.FinalText = "Looks like we'll need to open this gate";
                    tp.Star();

                    //Reset
                    StartCoroutine(Transit());
                    Butt = "";
                    On = false;

                    break;

                case 9:

                    //Text
                    tp.FinalText = "There's a 4 digit lock here, let's try and look for hints!";
                    tp.Star();

                    //Reset
                    StartCoroutine(Transit());
                    Butt = "";
                    On = false;
                    break;

                //PS 1

                case 10:

                    //Text
                    tp.FinalText = "(Move the camera around and look for the code)";
                    tp.Star();

                    //Buttons
                    ANext = false;
                    AB1 = true;
                    AB2 = true;
                    AB3 = true;

                    //Reset
                    StartCoroutine(Transit());
                    Butt = "";
                    On = false;
                    break;

                //NW

                case 11:
                    this.GetComponents<AudioSource>()[4].Play();
                    //Text
                    tp.FinalText = "That's it Annie! Good job";
                    tp.Star();

                    //Animation
                    annie.AtivaParametro("Normal Walk");

                    //Buttons

                    ANext = true;
                    AB1 = false;
                    AB2 = false;
                    AB3 = false;

                    //Scene
                    Gate1.SetActive(false);

                    //Reset
                    StartCoroutine(Transit());
                    Butt = "";
                    On = false;
                    break;

                case 12:
                    //Text
                    tp.FinalText = "Oh! These branches are blocking us, should we turn right or left?";
                    tp.Star();

                    //Animation
                    annie.AtivaParametro("Scare");

                    //Buttons

                    ANext = false;
                    ALeft = true;
                    ARight = true;

                    //Scene
                    
                    Bush.SetActive(true);

                    //Reset
                    StartCoroutine(Transit());
                    Butt = "";
                    On = false;
                    break;

                case 13:

                    //Text
                    tp.FinalText = "Nice! Let's see where this takes us";
                    tp.Star();

                    //Animation
                    annie.AtivaParametro("Normal Walk");

                    //Buttons
                    ANext = true;
                    ALeft = false;
                    ARight = false;

                    //Scene
                    Bush.SetActive(false);

                    //Reset
                    StartCoroutine(Transit());
                    Butt = "";
                    On = false;
                    break;
                //PExp
                case 14:

                    //Text
                    tp.FinalText = "Oh what's this?";
                    tp.Star();

                    //Animation
                    annie.AtivaParametro("Idle");

                    


                    //Reset
                    StartCoroutine(Transit());
                    Butt = "";
                    On = false;
                    break;

                case 15:

                    //Text
                    tp.FinalText = "A Ball? but it's broken, try and Conect the pieces!";
                    tp.Star();

                    //Buttons

                    ANext = false;
                    ASlide = true;

                    //Scene

                    Ped.SetActive(true);
                    Annie.SetActive(false);

                    //Reset
                    StartCoroutine(Transit());
                    Butt = "";
                    On = false;
                    break;

                //CW

                case 16:

                    //Text
                    tp.FinalText = "Good Job! Let's take it with us";
                    tp.Star();

                   

                    //Buttons
                    ANext = true;
                    ASlide = false;

                    //Scene
                    Ped.SetActive(false);
                    Annie.SetActive(true);
                    AnnieBall.SetActive(true);

                    //Animation
                    annie.AtivaParametro("Cube_Walk");

                    //Reset
                    StartCoroutine(Transit());
                    Butt = "";
                    On = false;
                    break;

                case 17:

                    //Text
                    tp.FinalText = "Don't worry honey, we're getting close";
                    tp.Star();


                    //Reset
                    StartCoroutine(Transit());
                    Butt = "";
                    On = false;
                    break;

                //CD

                case 18:
                    this.GetComponents<AudioSource>()[4].Play();
                    //Text
                    tp.FinalText = "Ah there you go, that's what the ball is for!";
                    tp.Star();

                    //Animation
                    annie.AtivaParametro("Cube_Drop");

                    //Scene
                    Invoke("BallFall", 1.4f);
                    Gate2.SetActive(true);

                    //Reset
                    StartCoroutine(Transit());
                    Butt = "";
                    On = false;
                    break;

                case 19:
                    this.GetComponents<AudioSource>()[4].Play();
                    //Text
                    tp.FinalText = "Nice, the gate is open!!";
                    tp.Star();

                    //Scene
                    Gate2.SetActive(false);
                    BallGate.SetActive(false);

                    //Reset
                    StartCoroutine(Transit());
                    Butt = "";
                    On = false;
                    break;

                //NW

                case 20:

                    //Text
                    tp.FinalText = "I know you're confused, everything will make sense we promise";
                    tp.Star();

                    //Animation
                    annie.AtivaParametro("Normal Walk");

                    

                    //Reset
                    StartCoroutine(Transit());
                    Butt = "";
                    On = false;
                    break;

                case 21:

                    //Text
                    tp.FinalText = "Just keep walking";
                    tp.Star();


                    //Reset
                    StartCoroutine(Transit());
                    Butt = "";
                    On = false;
                    break;

                case 22:
                    //Text
                    tp.FinalText = "Ah! Two paths again, chose one";
                    tp.Star();

                    //Animation
                    annie.AtivaParametro("Scare");

                    //Buttons
                    ANext = false;
                    ALeft = true;
                    ARight = true;

                    //Scene
                    Bush.SetActive(true);


                    //Reset
                    StartCoroutine(Transit());
                    Butt = "";
                    On = false;
                    break;

                case 23:

                    //Text
                    tp.FinalText = "Hhhm, It's a little scary here";
                    tp.Star();

                    //Animation
                    annie.AtivaParametro("Normal Walk");

                    //Buttons
                    ANext = true;
                    ALeft = false;
                    ARight = false;

                    //Scene
                    Bush.SetActive(false);

                    //Reset
                    StartCoroutine(Transit());
                    Butt = "";
                    On = false;
                    break;

                //Scared-run

                case 24:
                    this.GetComponents<AudioSource>()[0].Stop();
                    this.GetComponents<AudioSource>()[1].Stop();
                    this.GetComponents<AudioSource>()[3].Play();
                    this.GetComponents<AudioSource>()[5].Play();
                    //Text
                    tp.FinalText = "OOH! Annie run!";
                    tp.Star();

                    //Animation
                    annie.AtivaParametro("Scare");



                    //Reset
                    StartCoroutine(Transit());
                    Butt = "";
                    On = false;
                    break;

                //FW

                case 25:

                    //Text
                    tp.FinalText = "There's something comming, don't stop honey!";
                    tp.Star();

                    //Animation
                    annie.AtivaParametro("Fast_Walk");


                    //Reset
                    StartCoroutine(Transit());
                    Butt = "";
                    On = false;
                    break;

                case 26:

                    //Text
                    tp.FinalText = "We'll need to find somewhere to hide!";
                    tp.Star();

                    //Reset
                    StartCoroutine(Transit());
                    Butt = "";
                    On = false;
                    break;

                //PExp

                case 27:

                    //Text
                    tp.FinalText = "Quickly find somewhere dark so he can't see us!";
                    tp.Star();

                    //Buttons

                    ANext = false;

                    //Reset
                    StartCoroutine(Transit());
                    Butt = "";
                    On = false;
                    break;

                //Idle-NW

                case 28:
                    this.GetComponents<AudioSource>()[6].Play();
                    this.GetComponents<AudioSource>()[5].Stop();
                    //Text
                    tp.FinalText = "Uuf.. He's gone";
                    tp.Star();

                    //Animation
                    annie.AtivaParametro("Idle");

                    //Buttons

                    ANext = true;

                    //Reset
                    StartCoroutine(Transit());
                    Butt = "";
                    On = false;
                    break;

                case 29:
                    this.GetComponents<AudioSource>()[7].Play();
                    DirectionalLight.color = Color.red;

                    //Text
                    tp.FinalText = "Look! We can see the police";
                    tp.Star();

                    //Animation
                    annie.AtivaParametro("Normal Walk");

                    //Reset
                    StartCoroutine(Transit());
                    Butt = "";
                    On = false;
                    break;

                case 30:
                    
                    //Text
                    tp.FinalText = "Good job Annie, you're safe now..";
                    tp.Star();

                    //Reset
                    StartCoroutine(Transit());
                    Butt = "";
                    On = false;
                    break;

                //End

                case 31:

                    //Text
                    tp.FinalText = "We love you daughter.. We'll watch you from the stars";
                    tp.Star();

                    //Button
                    ANext = false;

                    //Scene


                    //Reset
                    StartCoroutine(Transit());
                    Butt = "";
                    On = false;
                    break;

            }
            
        }

    }

    public IEnumerator Transit()
    {
        FO = true;
        
        yield return new WaitForSeconds(1f);

        FO = false;

        if (ANext) { Next.SetActive(true); }
        else { Next.SetActive(false); }

        if (ALeft) { Left.SetActive(true); }
        else { Left.SetActive(false); }

        if (ARight) { Right.SetActive(true); }
        else { Right.SetActive(false); }

        if (AB1) { B1.SetActive(true); }
        else { B1.SetActive(false); }

        if (AB2) { B2.SetActive(true); }
        else { B2.SetActive(false); }

        if (AB3) { B3.SetActive(true); }
        else { B3.SetActive(false); }

        if (ASlide) { Slide.SetActive(true); }
        else { Slide.SetActive(false); }

        yield return new WaitForSeconds(1f);

        FI= true;

        yield return new WaitForSeconds(1f);

        FI = false;

    }

    void FadeGameObjectAndChildren(GameObject obj)
    {
        Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();

        foreach (Renderer renderer in renderers)
        {
            Color color = renderer.material.GetColor("_Color");
            color.a += 0.005f;
            renderer.material.SetColor("_Color", color);
        }
    }
    void FadeOutGameObjectAndChildren(GameObject obj)
    {
        Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();

        foreach (Renderer renderer in renderers)
        {
            Color color = renderer.material.GetColor("_Color");
            color.a -= 0.005f;  // You may adjust the fade-out speed as needed
            renderer.material.SetColor("_Color", color);
        }
    }

    public void BallFall()
    {
        AnnieBall.SetActive(false);
        BallGate.SetActive(true);
    }

}
