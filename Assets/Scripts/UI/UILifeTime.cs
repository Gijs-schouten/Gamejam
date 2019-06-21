using UnityEngine;

public class UILifeTime : MonoBehaviour {
	private float _lifeTime;
	float time = 0;

	public static UILifeTime CreateComponent(GameObject where, float lifetime) {
		UILifeTime myC = where.AddComponent<UILifeTime>();
		myC._lifeTime = lifetime;
		return myC;
	}

	void Update() {
		time += Time.deltaTime;

		if(time >= _lifeTime) {
			Destroy(gameObject);
		}
	}
}
