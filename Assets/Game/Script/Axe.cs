using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Bullet
{
    public Transform skin;
    // Start is called before the first frame update
    void Start()
    {
        
    }   

    // Update is called once per frame
    void Update()
    {
        skin.Rotate(Vector3.forward, Time.deltaTime * 300f);
    }
    public override void OnInit()
    {
        Moving();
    }

    public override void Moving()
    {
        base.Moving();
        
       
    }
}
