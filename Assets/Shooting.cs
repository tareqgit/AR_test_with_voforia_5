using UnityEngine;


public class Shooting : MonoBehaviour {


	public ParticleSystem _muzzleFlash;
	public AudioSource _gunAudio;
	public GameObject _impactPrefabs;
	public Transform cameraTransform;


	ParticleSystem _impactEffect;
	// Use this for initialization
	void Start () {
		_impactEffect = Instantiate (_impactPrefabs).GetComponent<ParticleSystem> ();

	}
	
	// Update is called once per frame
	void Update () {

	//	if (Input.GetKeyDown(KeyCode.Mouse1))
		//	CmdHitPlayer (gameObject);
	//	Debug.DrawRay (raypos, cameraTransform.forward, Color.red);
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			_muzzleFlash.Stop ();
			_muzzleFlash.Play ();
			_gunAudio.Stop ();
			_gunAudio.Play ();


			RaycastHit hit;
			Vector3 raypos = cameraTransform.position + (1f * cameraTransform.forward);

			if (Physics.Raycast (raypos, cameraTransform.TransformDirection(Vector3.forward), out hit, 100f)) {
		//	if (Physics.Raycast(transform.position, -Vector3.forward, out hit, 100.0f)){
				Debug.Log ("hit");
				_impactEffect.transform.position = hit.point;
				_impactEffect.Stop ();
				_impactEffect.Play ();
				Invoke ("stopParticle", .5f);


				if (hit.transform.tag == "Target") {
					
					Destroy (hit.transform.gameObject);


				}
			}
		}
	}
	void stopParticle(){
		_impactEffect.Stop ();
	}
	 

}