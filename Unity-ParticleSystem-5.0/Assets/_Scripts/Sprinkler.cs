using UnityEngine;
using System.Collections;

public class Sprinkler : MonoBehaviour {
	private float heightAboveFloor;
	private ParticleSystem[] sprinklers;

	private ParticleCollisionEvent[][] collisionEvents;
	private GameObject fireBarrel;
	private Fire fire;
	// Use this for initialization
	void Awake () {
		sprinklers = GetComponentsInChildren<ParticleSystem>();
	}

	void Start () {
		heightAboveFloor = transform.position.y;

		collisionEvents = new ParticleCollisionEvent[sprinklers.Length][];
		
		fireBarrel = GameObject.FindWithTag ("FireBarrel");
		
		fire = fireBarrel.GetComponent<Fire>();
	}

	void OnParticleCollision (GameObject other){
		if (other.tag == "FireBarrel") {
			for (int i = 0; i < collisionEvents.Length; i++) {
				collisionEvents[i] = new ParticleCollisionEvent[sprinklers[i].GetSafeCollisionEventSize()];
				sprinklers[i].GetCollisionEvents(gameObject, collisionEvents[i]);
				
				for (int j = 0; j < collisionEvents[i].Length; j++) {
					foreach (var ph in fire.particles) {
						if (ph.varyAlpha) {
							ph.DecreaseAlpha();
						}
						if (ph.varyEmission) {
							ph.DecreaseEmission ();
						}
						if (ph.varyIntensity) {
							ph.DecreaseIntensity ();
						}
						if (ph.varyRange) {
							ph.DecreaseRange ();
						}
					}					}
			}
		}
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit[] hits;

			hits = Physics.RaycastAll(ray);

			foreach (var hit in hits) {
				if (hit.collider.name == "ground") {
					transform.position = hit.point + new Vector3(0f, heightAboveFloor, 0f);
				}
			}
			if (!sprinklers[0].isPlaying) {
				foreach (var sprinkler in sprinklers) {
					sprinkler.Play ();
				}
			}
		}else{
			if (sprinklers[0].isPlaying) {
				foreach (var sprinkler in sprinklers) {
					sprinkler.Stop ();
				}
			}
		}
	
	}
}
