using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public Camera sceneCam;
    public Rigidbody2D rb;
    public float moveSpeed;
    public int hp;
    public int souls = 0;
    public SpriteRenderer characterSprite;
    [SerializeField] private AudioClip rip;
    private Vector2 moveDirection;
    private Vector2 mousePos;
    public bool isDead;
    public bool isImmune;

    public void TakeDamage(int damage)
    {
        if(damage < 0){
            if(hp >= 3){
                return;
            }
        }
        if(isDead || isImmune){
            return;
        }
        hp -= damage;
        StartCoroutine(Immunity(0.5f));
        HealthManage.instance.HealthBarUpdate(hp);
        if(hp == 3){
            characterSprite.color = new Color(0.32f, 0.32f, 0xFF);
        }
        if(hp == 2){
            characterSprite.color = new Color(0.61f, 0.2f, 0.78f);
        }
        if(hp == 1){
            characterSprite.color = new Color(0.78f, 0.2f, 0.4f);
        }
        if(hp == 0){
            Die();
        }
    }
    public void GiveSoul(int soul){
        souls += soul;
    }
    public int GetSouls(int checkSouls, int takeSouls = 0){
        if(souls < checkSouls){
            return -1;
        }
        else{
            int surplus = souls - checkSouls;
            souls -= takeSouls;
            return surplus;
        }
    }
    void Update()
    {
        if(!PauseMenu.isPaused && !isDead){
            ProcessInputs();
        }
    }

    void FixedUpdate()
    {
        if(isDead){
            return;
        }
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY);
        mousePos = sceneCam.ScreenToWorldPoint(Input.mousePosition);
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        Vector2 aimDirection = mousePos -rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x)*Mathf.Rad2Deg -90f;
        rb.rotation = aimAngle;
    }
    private async void Die(){
        isDead = true;
        rb.velocity = new Vector2(0, 0);
        GetComponent<Collider2D>().enabled = false;
        Destroy(TimeKeeper.instance.gameObject);
        characterSprite.color = new Color(0, 0, 0, 0.5f);
        GameObject sound = SoundFX.instance.PlaySoundFX(rip, gameObject.transform, 1, true);
        while(sound != null){
            await Task.Yield();
        }
        SceneManager.LoadScene("GameOver");
    }
    private IEnumerator Immunity(float time){
        isImmune = true;
        yield return new WaitForSeconds(time);
        isImmune = false;
    }
}
