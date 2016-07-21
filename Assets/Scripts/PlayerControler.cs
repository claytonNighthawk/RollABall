using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public Text finishText;
    public AudioClip collectSound;
    public AudioClip winSound;
    public GameObject endPortal;
    public Canvas pauseMenu;
    public float speedUp;

    private Rigidbody rb;
    private int count;
    private bool speedPowerUp;

    void Start (){
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        finishText.text = "";
        pauseMenu.enabled = false;
        Time.timeScale = 1;
        speedPowerUp = false;
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)) {

            if (pauseMenu.enabled == true) {
                pauseMenu.enabled = false;
                Time.timeScale = 1;
            }
            else {
                pauseMenu.enabled = true;
                Time.timeScale = 0;
            }
        }
    }
        
    void FixedUpdate (){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (speedPowerUp){
            rb.AddForce(speedUp * movement * speed);
        }
        else{
            rb.AddForce(movement * speed);
        }
       
        if (Input.GetKeyDown(KeyCode.Return)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }

    void OnTriggerEnter(Collider other){

        if (other.gameObject.CompareTag("Pick Up")){
            other.gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
            count += 1;
            SetCountText();
        }

        if (other.gameObject.CompareTag("Finish")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            AudioSource.PlayClipAtPoint(winSound, transform.position);
            finishText.text = "If level doesn't advance this is the last level currently.";
        }
        
        if (other.gameObject.CompareTag("Respawn")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (other.gameObject.CompareTag("Speed Up")){
            if (speedPowerUp){
                speedPowerUp = false;
            }
            else{
                speedPowerUp = true;
            }
        }
    }

    void SetCountText (){
        countText.text = "Count: " + count.ToString();
        if (count >= 12){
            winText.text = "You Win!";
            endPortal.SetActive(true);
        }
    }
}