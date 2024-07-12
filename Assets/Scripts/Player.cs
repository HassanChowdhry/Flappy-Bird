using UnityEngine;

public class Player : MonoBehaviour {
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int currentSpriteIndex;

    public float strength = 5f;
    public float gravity = -9.81f;

    private Vector3 direction;

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start() {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    void OnEnable() {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            direction = Vector3.up * strength;
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }
    
    private void AnimateSprite() {
        currentSpriteIndex = (currentSpriteIndex + 1) % sprites.Length;
        spriteRenderer.sprite = sprites[currentSpriteIndex];
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Obstacle")) {
            FindObjectOfType<GameManager>().GameOver();
        } else if (other.gameObject.CompareTag("Scoring")) {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }

}