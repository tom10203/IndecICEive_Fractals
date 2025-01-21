using System;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class GuyBubble : MonoBehaviour
{

    // Oscillation viarables
    //
    [SerializeField] float vOscillationSpeedBase=1;
    [SerializeField] float vForceOscillation=1;
    [SerializeField] float vForceOscillationTime=1;
    [SerializeField] float vOscilAmount=.2f;
    [SerializeField] float vOscilTimer;
    [SerializeField] float vOscilCycle;
    [SerializeField] float vOscilTimerMax;
    [SerializeField] float vOsciAmtTmp;
    [SerializeField] float vWobbleX;
    [SerializeField] float vWobbleY;   
    [SerializeField] float vWobbleZ;
    [SerializeField] float vOscilLowerForceLimit;
    public Vector3 vBlowTmp;
    public Vector3 vBlowTmpAtLastImpulse;

    //brownian motion varaibles
    [SerializeField] Transform gResistance;
    [SerializeField] Vector3 vResistPointVector;
    [SerializeField] float vResistPointMoveSpeed;
    [SerializeField] float vResistance;
    [SerializeField] float vResistInterval;
    [SerializeField] Rigidbody rb;
    [SerializeField] Vector3 vResistOffset;


    //Bubble Health
    public float vBubbleHealth;
    [SerializeField] float vBubbleMaxHealth;
    [SerializeField] float vBubbleColorFractionMin;
    [SerializeField] Color cBubbleColour;
    [SerializeField] Cone_tf MBSCone_tf;
    [SerializeField] float vForceDamageThreshold;
    [SerializeField] float vForceDamageInc;

    //GameEnd
    [SerializeField] MBSGameManagerGuy MBSGameManagerGuy;


    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();

        MBSGameManagerGuy = FindFirstObjectByType<MBSGameManagerGuy>().GetComponent<MBSGameManagerGuy>();
       
    }

    // Update is called once per frame
    void Update()
    {

       
        // check to see if there is significant force on the bubble
        if (vBlowTmp.magnitude > vOscilLowerForceLimit )
        {
            MBSGameManagerGuy.SoundJetonBubble();
            vOscilTimer = vOscilTimerMax;
            FnDamage();

        }

        // oscilates if there is force or the aftermath of force
        if (vOscilTimer > 0)
        {
            FnOscilate();
            FnBrownian();
            vOscilTimer -= Time.deltaTime;


        }

        //random motion
        
       

        

    }

    void FnOscilate()
    {
        // oscillation timer speed set
        vOscilCycle += (Time.deltaTime * vBlowTmpAtLastImpulse.magnitude *(vOscilTimer/vOscilTimerMax) * vOscillationSpeedBase * vForceOscillationTime);

        //Oscillint ampulitdue
        vOsciAmtTmp = vForceOscillation / vBlowTmp.magnitude;

        if (vOsciAmtTmp > 1)
        { vOsciAmtTmp = 1; }
        vOsciAmtTmp *= vOscilAmount * vOscilTimer/vOscilTimerMax;

        //Wobble on all 3 axix according to sine curve - change size
        vWobbleX = 1 + (Mathf.Sin(vOscilCycle) * vOsciAmtTmp);
        vWobbleZ = 1 + (Mathf.Sin(vOscilCycle) * -vOsciAmtTmp);
        vWobbleY = 1 + (Mathf.Cos(vOscilCycle) * vOsciAmtTmp);

        transform.localScale = new Vector3(vWobbleX, vWobbleY, vWobbleZ);



    }


    void FnBrownian()
    {
       

        // push positon orbits

        gResistance.position = transform.position + new Vector3(  Mathf.Sin(vOscilCycle * vResistPointMoveSpeed),Mathf.Cos(vOscilCycle * vResistPointMoveSpeed),0);




        // apply force
        
        
       vResistOffset = (gResistance.position).normalized * vResistance * vBlowTmpAtLastImpulse.magnitude * vOscilTimer / vOscilTimerMax;
        vResistOffset.z = 0;   

        rb.AddForce(-vResistOffset,ForceMode.Impulse);
        rb.AddTorque(-vResistOffset, ForceMode.Impulse);

        
    }

    void FnDamage()
    {
        float vDamageTmp = vBlowTmp.magnitude - vForceDamageThreshold;
        if (vDamageTmp >0)
        {
            vDamageTmp *= vForceDamageInc *Time.deltaTime;

            FnHealthChange(vDamageTmp);

        }


    }


    public void FnHealthChange(float vHitTmp)
        // routine reduces health and changes the colour of the bubble to red as healh reduces, nd makes it more translucent.
    {
        vBubbleHealth -= vHitTmp;

        cBubbleColour.a = vBubbleColorFractionMin + (1- vBubbleColorFractionMin) * (vBubbleHealth/vBubbleMaxHealth);
        cBubbleColour.r = 1;
        cBubbleColour.b = vBubbleHealth / vBubbleMaxHealth;
        cBubbleColour.g = vBubbleHealth / vBubbleMaxHealth;
        GetComponent<Renderer>().material.color = cBubbleColour;

        MBSGameManagerGuy.SoundDamage();

        if (vBubbleHealth <0)
        {

            FnBurst();
        }

    }

    void FnBurst()
    {

        GetComponent<Renderer>().enabled = false;

        MBSGameManagerGuy.SoundBurst();
        MBSGameManagerGuy.FnGameOver();
    }


    private void OnTriggerEnter(Collider other)
    {
        // detect enemy


        if (other.gameObject.layer == 7)
        {

            FnBurst();




        }


    }


}
