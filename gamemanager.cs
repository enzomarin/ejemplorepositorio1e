using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class gamemanager : MonoBehaviour {
	
	public GameObject camaraSecundaria;
	public GameObject camaraPrincipal;
	public bool cambiarCamaras;
	public float velocidadMovimiento;
	public float velocidadRotacion;
	public bool tocaPiso;
	public float fuerzaDeSalto;

	public Animator anim;
	
	void Start () {
		cambiarCamaras = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		float v = Input.GetAxis("Vertical") * Time.deltaTime * velocidadMovimiento;
		float h= Input.GetAxis("Horizontal") * Time.deltaTime* velocidadRotacion;
		//transform.GetComponent<Rigidbody>().velocity= new Vector3(v,0,h);
		if (tocaPiso)
		{
			anim.SetFloat("velocidadMov", v);
			transform.Translate(v,0,0);	
		}		
		else
		{
			anim.SetFloat("velocidadMov",0f);
			transform.Translate(v*0.5f,0,0);
		}
		
		transform.Rotate(0,h,0);
		tocaPiso= Physics.Raycast(transform.position,new Vector3(0,-1,0), 1.2f);
		if (Input.GetKeyDown(KeyCode.C))
		{
			if (cambiarCamaras)
			{
				camaraPrincipal.GetComponent<CinemachineVirtualCamera>().Priority=1;
				camaraSecundaria.GetComponent<CinemachineVirtualCamera>().Priority=0;
				cambiarCamaras = !cambiarCamaras;
				
			}
			else
			{
				camaraPrincipal.GetComponent<CinemachineVirtualCamera>().Priority=0;
				camaraSecundaria.GetComponent<CinemachineVirtualCamera>().Priority=1;
				cambiarCamaras = !cambiarCamaras;				
			}
			
		}
		if (Input.GetKeyDown(KeyCode.Space) && tocaPiso)
		{
			transform.GetComponent<Rigidbody>().AddForce(new Vector3(0,fuerzaDeSalto,0), ForceMode.VelocityChange);
		}
		if (Input.GetKeyDown(KeyCode.R))
		{
			anim.SetTrigger("animRisa");
		}
	}

}
