using UnityEngine;

public class Pipes : MonoBehaviour {

    public float speed = 5f;

    private float left;

    void Start() {
        left = Camera.main.ScreenToWorldPoint(Vector3.zero).x -1f;
    }

    void Update() {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < left) {
            Destroy(gameObject);
        }
    }
}
