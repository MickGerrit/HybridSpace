using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObjectSeeThru : MonoBehaviour {
    [SerializeField]
    Renderer interactable;

    float _counter=0;
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetButton("Activate"))
        {
            //blink
            float opacity = interactable.material.GetFloat("_Transparency");
            opacity = 0.5f*(Mathf.Cos(Mathf.Deg2Rad*(_counter+190))+1);

            _counter += 20f;
            interactable.material.SetFloat("_Transparency", opacity);

            //float opacity = interactable.material.GetFloat("_Transparency");

            //if (opacity!=1.0f)
            //{
            //    opacity=Mathf.Lerp(opacity, 1, 0.1f);
            //    if (opacity > 0.98f) opacity = 1;
            //    interactable.material.SetFloat("_Transparency", opacity);
            //}
        }
        else
        {
            _counter = 0;
            //fade
            float opacity = interactable.material.GetFloat("_Transparency");

            if (opacity != 0.0f)
            {
                opacity=Mathf.Lerp(opacity, 0, 0.5f);
                if (opacity < 0.02f) opacity = 0;
                interactable.material.SetFloat("_Transparency", opacity);
            }
        }

	}
}
