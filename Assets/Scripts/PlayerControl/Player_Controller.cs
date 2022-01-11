using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_Controller : MonoBehaviour
{
    protected Player player;
    public class Player
    {
        public float speedRotate = 0.2f;
        public float speedMove = 3;
        public int score;
    }

    [SerializeField] private Renderer lights;
    [SerializeField] private bool isRagdoll = false, isFinish = false;
    [SerializeField] public bool isMoving;
    [SerializeField] private ParticleSystem dust;
    [SerializeField] public GameObject startPanel;
    [SerializeField] private GameObject colorState;
    [SerializeField] private GameObject restartGame;
    [SerializeField] public Text timer;
    [SerializeField] public float time;

    private Rigidbody[] rigidbodies;
    private Collider[] ragdollCollider;
    private CharacterController chPlayer ;
    private Animator animPlayer;

    private Vector2 dirRotate;
    private Vector3 dirMove;

    private Coroutine speedRestoreCorotine;
    private float h, playerXAngle;
    private void Awake()
    {
        chPlayer = GetComponent<CharacterController>();
        player = new Player();
        chPlayer.enabled=true;
        
        animPlayer = GetComponent<Animator>();
    }
    private void Start()
    {
        Time.timeScale = 1;
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        ragdollCollider = GetComponentsInChildren<Collider>();
        foreach(Collider col in ragdollCollider)
        {
            if(col.CompareTag("Ragdoll"))
                col.enabled = false;
        }
        foreach (Rigidbody rb in rigidbodies)
        {
            if (rb.CompareTag("Ragdoll"))
                rb.isKinematic = true;
        }

    }
    private void FixedUpdate()
    {
        
        if(!isRagdoll&&!isFinish&&!startPanel.activeSelf)
        {
            colorState.SetActive(true);
            Timer();
            Movement();
        }
        
        if (isMoving && lights.material.color == Color.red)
        {   
            Ragdoll();
            timer.text = "YOU LOSE";
            RestartGame(); 
        }
        if (isMoving)
        {   
            ParticleSystem.EmissionModule psdust = dust.emission;
            psdust.rateOverTime = 8;
        }
        if (!isMoving)
        {   
            
            ParticleSystem.EmissionModule psdust = dust.emission;
            psdust.rateOverTime = 0;
        }
    }

    private void Movement()
    {   
            
        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            isMoving = true;
            Touch touch = Input.touches[0];
            h = touch.deltaPosition.x;
            //h = Input.GetAxis("Mouse X");
            dirMove = new Vector3(0, 0, player.speedMove);
            dirMove = this.transform.TransformDirection(dirMove);

            animPlayer.SetBool("Running", true);
            chPlayer.SimpleMove(dirMove);
            
            Rotate();
        }
        else
        {

            isMoving = false;
            animPlayer.SetBool("Running", false);
            chPlayer.SimpleMove(Vector2.zero);
        }

    }

    private void Rotate()
    {
        dirRotate = new Vector2(h, 0);
        if (dirRotate != Vector2.zero)
        {
            playerXAngle += h * player.speedRotate;
            playerXAngle = Mathf.Clamp(playerXAngle, -45, 45);

            Quaternion targetRot = Quaternion.LookRotation(dirRotate);
            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, targetRot, player.speedRotate);
            this.transform.localRotation = Quaternion.Euler(new Vector2(0, playerXAngle));
        }
    }
    public void RestartGame()
    {
        StopAllCoroutines();
        chPlayer.enabled = false;
        restartGame.SetActive(true);
    }

    public void SpeedUp(float addedSpeed, float time)
    {
        if (speedRestoreCorotine != null)
        {
            StopCoroutine(speedRestoreCorotine);
            player.speedMove = 3;
            speedRestoreCorotine = null;
        }
        speedRestoreCorotine = StartCoroutine(TempSpeedChange(addedSpeed, time));
    }
    public void Ragdoll()
    {
        isRagdoll = true;
        chPlayer.enabled = false;
        animPlayer.enabled = false;
        isMoving = false;
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.isKinematic = false;
        }
        foreach (Collider col in ragdollCollider)
        {
            col.enabled = true;
            
        }
    }
    public void FinishGame()
    {
        StopAllCoroutines();
        isFinish = true;
        timer.text = "YOU WIN";
        chPlayer.enabled = false;
        animPlayer.SetBool("Win", true);
        isMoving = false;
    }
    private void Timer()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            timer.text = Mathf.Round(time).ToString();
        }
        else
        {   
            timer.text = "Time`s UP";
            Ragdoll();
            RestartGame();
        }
    }
    IEnumerator TempSpeedChange(float speed,float time)
    {
        float defaultSpeed = player.speedMove;
        player.speedMove += speed;
        yield return new WaitForSeconds(time);
        player.speedMove = defaultSpeed;
    }

    

}
