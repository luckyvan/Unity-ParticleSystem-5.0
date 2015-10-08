using UnityEngine;
using System.Collections;

public class BarrelLid : MonoBehaviour {
	public float dropletForce;
	public Rigidbody lid;

	private ParticleSystem[] sprinklers;
	private ParticleCollisionEvent[][] collisionEvents;
	// Use this for initialization
	void Awake () {
		sprinklers = GetComponentsInChildren<ParticleSystem>();
	}

	void Start () {
		collisionEvents = new ParticleCollisionEvent[sprinklers.Length][];
	}
	
	void OnParticleCollision(GameObject other){
		if (collisionEvents == null) {
			return;
		}

		if (other.tag == "Barrel") {
			for (int i = 0; i < collisionEvents.Length; i++) {
				collisionEvents[i] = new ParticleCollisionEvent[sprinklers[i].GetSafeCollisionEventSize()];
				sprinklers[i].GetCollisionEvents(gameObject, collisionEvents[i]);

				for (int j = 0; j < collisionEvents[i].Length; j++) {
					lid.AddForceAtPosition(Vector3.down*dropletForce, collisionEvents[i][j].intersection);
				}
			}
		}
	}
}
