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
    [SerializeField] float vOsciAmtTmp;
    [SerializeField] float vWobbleX;
    [SerializeField] float vWobbleY;   
    [SerializeField] float vWobbleZ;
    public Vector3 vBlowTmp;

    //brownian motion varaibles
    [SerializeField] Transform gResistance;
    [SerializeField] Vector3 vResistPointVector;
    [SerializeField] float vResistPointMoveSpeed;
    [SerializeField] float vResistance;
    [SerializeField] float vResistInterval;
    [SerializeField] Rigidbody rb;


    //Bubble Health
    public float vBubbleHealth;
    [SerializeField] float vBubbleMaxHealth;
    [SerializeField] float vBubbleColorFractionMin;
    [SerializeField] Color cBubbleColour;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        cBubbleColour = GetComponent<Color>();  
    }

    // Update is called once per frame
    void Update()
    {
        FnOscilate();

        FnBrownian();
       

        

    }

    void FnOscilate()
    {

        vOscilTimer += (Time.deltaTime * vBlowTmp.magnitude * vOscillationSpeedBase * vForceOscillationTime);

        vOsciAmtTmp = vForceOscillation / vBlowTmp.magnitude;

        if (vOsciAmtTmp > 1)
        { vOsciAmtTmp = 1; }
        vOsciAmtTmp *= vOscilAmount;


        vWobbleX = 1 + (Mathf.Sin(vOscilTimer) * vOsciAmtTmp);
        vWobbleZ = 1 + (Mathf.Sin(vOscilTimer) * -vOsciAmtTmp);
        vWobbleY = 1 + (Mathf.Cos(vOscilTimer) * vOsciAmtTmp);

        transform.localScale = new Vector3(vWobbleX, vWobbleY, vWobbleZ);
    }


    void FnBrownian()
    {
       
float vBrownianTimer = Mathf.Max(Mathf.Sin(vOscilTimer*vResistInterval),0);
        // push positon orbits

        gResistance.position = transform.position + new Vector3(  Mathf.Sin(vOscilTimer* vResistPointMoveSpeed),0,Mathf.Cos(vOscilTimer * vResistPointMoveSpeed));



 // resistance inteval modifies the timer
        // apply force
        
        
        Vector3 vResistOffset = (gResistance.localPosition).normalized * vResistance * vBlowTmp.magnitude;
        vResistOffset.y = 0;   

        rb.AddForce(-vResistOffset,ForceMode.Impulse);

        
    }

    public void FnHealthChange(float vHitTmp)

    {
        vBubbleHealth -= vHitTmp;

        cBubbleColour.a = vBubbleColorFractionMin + (1- vBubbleColorFractionMin) * (vBubbleHealth/vBubbleMaxHealth);


        
    }

}
