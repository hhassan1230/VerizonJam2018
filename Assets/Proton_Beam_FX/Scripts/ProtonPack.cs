using UnityEngine;
using System.Collections;

public class ProtonPack : MonoBehaviour {

	public GameObject ProtonMainFX;
	public GameObject ProtonExtraFX;
	public AudioSource beamMainAudio;
	public AudioSource beamStartAudio;
	public AudioSource beamStopAudio;

	public ParticleSystem lightningBoltParticles;
	public ParticleSystem protonBeamParticles;
	int protonBeamFlag = 0;

    private bool firing;

    public GameObject tipOfGun;

	void  Start (){

		ProtonMainFX.SetActive(false);
		ProtonExtraFX.SetActive(false);

	}

	void  Update (){

		// Fire proton beam when left mouse button is pressed

		if (Input.GetButtonDown("Fire1"))
		{

			StartCoroutine("ProtonPackFire");

		}

		// Stop proton beam if left mouse button is released

		if (Input.GetButtonUp("Fire1"))
		{

			ProtonPackStop();

		}
        if (firing)
        {
            Vector3 origin = tipOfGun.transform.position;
            Vector3 direction = -tipOfGun.transform.forward;
            RaycastHit ObjectOut;
            Debug.DrawLine(origin, origin + direction * 10);
            if (Physics.Raycast(origin, direction, out ObjectOut, 10f)) {
                print(ObjectOut.transform.gameObject.name);
                if (ObjectOut.transform.gameObject.tag == "LandEnemy"){
                    ObjectOut.transform.gameObject.GetComponent<FloorEnemyHealth>().ApplyingDamage();
                }
            }

        }

	}

	IEnumerator ProtonPackFire (){

		ProtonExtraFX.SetActive(true);

		beamStartAudio.Play();
		protonBeamFlag = 0;


		yield return new WaitForSeconds (0.5f);
		// Wait for laser to charge

		if (protonBeamFlag == 0)
		{
			ProtonMainFX.SetActive(true);
            firing = true;
			lightningBoltParticles.Play();
			protonBeamParticles.Play();


			beamMainAudio.Play();
		}

	}


	void  ProtonPackStop (){

		protonBeamFlag = 1;

		ProtonMainFX.SetActive(false);
		lightningBoltParticles.Stop();
		protonBeamParticles.Stop();
        firing = false;

		beamMainAudio.Stop();
		beamStartAudio.Stop();
		beamStopAudio.Play();

	}
}