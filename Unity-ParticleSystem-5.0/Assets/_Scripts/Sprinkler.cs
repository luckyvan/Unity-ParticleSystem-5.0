using UnityEngine;
using System.Collections;

public class Sprinkler : MonoBehaviour {
	private float heightAboveFloor;
	private ParticleSystem[] sprinklers;
	// Use this for initialization
	void Awake () {
		sprinklers = GetComponentsInChildren<ParticleSystem>();
	}

	void Start () {
		heightAboveFloor = transform.position.y;
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
