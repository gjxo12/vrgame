using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Monster : MonoBehaviour
{

    public GameObject player;
   

    Animator animator;
    UnityEngine.AI.NavMeshAgent nav;
    public float monsterRadius = 1.0f;
    public GameObject target;
    public int speed = 3;
    public float stopdistance = 1;
    public Image hp_bar;
   
    public GameObject Target { get; set; }
    public Vector3 TargetPosition { get; set; }
    public static bool monsterAttack = false;

    public Enemyscript enemyscript;
    public int monsterHP = 100;

    public float gazeTime = 2f;                      //enemy
    private float timer;
    public bool gazeAt;
    private BoxCollider myCollider;

    public static bool pointenter;
    public static bool pointdown;                   //static으로 변수선언,몬스터 다수 참조

    private float delaytime;

    private float timer_event = 0.0f;
    private float eventtime = 1.0f;

    public float attackspeed = 1.0f;

    private Fire fire;

    public GameObject pointlight;


    

    public enum State
    {
        INITIALIZE,
        PATROL,
        MOVE,
        ATTACK,
        DEATH,
    };

    private State currentState_ = State.MOVE;

    // Use this for initialization

    void Start()
    {
        //gameObject.GetComponent<Enemyscript>().monsterHP;
        GameObject.FindWithTag("monster").GetComponent("Enemyscript");

        myCollider = GetComponent<BoxCollider>();   //enmey
    }

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("player");

        animator = GetComponent<Animator>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();

         //panelEffect.SetActive(false);

        Target = null;
        SetState(State.PATROL);

        gazeAt = false;         //enmey
        pointenter = false;
        pointdown = false;


    }

    // Update is called once per frame
    void Update()
    {
        

        // Vector3 dir = target.transform.position - transform.position;
        // dir.y = 0;
        // dir.Normalize();
        float distance = Vector3.Distance(player.transform.position, transform.position);

        PlayerAttribute playerAttribute = player.GetComponent<PlayerAttribute>();
        Monster monsterAttribute = this.GetComponent<Monster>();

        if (Target != null && monsterHP >= 0)
        {
            
            /* Vector3 dir = TargetPosition - transform.position;
             dir.Normalize();

             transform.LookAt(TargetPosition);

             if(distance > playerAttribute.Radius + monsterAttribute.monsterRadius)
             {
                 transform.position += (dir * speed * Time.deltaTime);
             }*/
            transform.LookAt(target.transform);
            nav.SetDestination(target.transform.position);
            nav.stoppingDistance = stopdistance;

            delaytime += Time.deltaTime;
            if (distance <= stopdistance && attackspeed <= delaytime )
            {
                SetState(State.ATTACK);
            }
        }
        else 
        {
            
            //Debug.Log("타겟 못찾았엉 랜덤 이동할게");
            // Vector3 dirt = TargetPosition - transform.position;
            // dirt.Normalize();

            // transform.LookAt(TargetPosition);
            //transform.position += (dirt * speed * Time.deltaTime);
            
            nav.SetDestination(TargetPosition);
        }

        timer_event += Time.deltaTime;

        if (gazeAt == true)
        {
            timer += Time.deltaTime;

            if (timer >= gazeTime)
            {
                if(eventtime <= timer_event)
                {
                    ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
                }
                // ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
                //monsterHP -= 20;
                //pointdown = true;
                
                timer = 0f;
            }
        }

            if (currentState_== State.ATTACK)
        {
            animator.SetBool("isAttack", true);
            animator.SetBool("isRunning", false);

        }
        else
        {
            animator.SetBool("isAttack", false);
            animator.SetBool("isRunning", true);
        }

        if (monsterHP <= 0)
        {
            
            SetState(State.DEATH);
        }

        if(pointdown == false)
        {
            animator.SetBool("isHit", false);
            
        }

        
    }
        

       /* if ( distance < 5 )
        {
            nav.SetDestination(player.transform.position);
            nav.stoppingDistance = stopdistance;
            SetState(State.MOVE);
           // animator.SetBool("isAttack", false);
          //  animator.SetBool("isRunning", true);

        }
        else if( distance <= stopdistance)
        {
           
            SetState(State.ATTACK);
          //  animator.SetBool("isRunning", false);
          //  animator.SetBool("isAttack", true);
        }*/

       

    public void SetState(State newState)
    {
        if (newState == currentState_)
            return;

        currentState_ = newState;


        switch (newState)
        {
            case State.MOVE:
                {
                    
                    MoveState();

                }
                break;
            case State.ATTACK:
                {
                    AttackState();

                }
                break;
            case State.PATROL:
                {
                    PatrolState();
                }
                break;
            case State.DEATH:
                {
                    DeathState();
                }
                break;
        }
    }


    void MoveState()
    {
        StartCoroutine("TransStateToPatrol", 2.0f);
        // AnimationControl monsterAnimation = gameObject.GetComponent<AnimationControl>();
        //  monsterAnimation.PlayAnimation("walk");
        monsterAttack = false;

    }

    public void AttackState()
    {
    
        PlayerAttribute playerAttribute = player.GetComponent<PlayerAttribute>();
       
        
        playerAttribute.HP -= 10;
        hp_bar.fillAmount -= 0.1f;            
        monsterAttack = true;

        delaytime = 0;
              
        transform.LookAt(player.transform);
     
      
        StartCoroutine("TransStateToPatrol", 2.0f);
    }

    void PatrolState()
    {
        GameObject newTarget = FindPlayer(searchDistanceMeter:10.0f) ;
        
        if(newTarget != null)
        {
            //적을 찾았으면
           // Debug.Log("적을 찾았엉");
            Target = newTarget;
            TargetPosition = Target.transform.position;

            SetState(State.MOVE);
            
        }
        else
        {
            //적을 못찾았으면
            Target = null;
            //Debug.Log("랜덤위치로 목표를 잡을거야");
            TargetPosition = FindRandomTargetPosition(minRangeMeter: 1, maxRangeMeter: 5);
            SetState(State.MOVE);
        }

        monsterAttack = false;
    }

    Vector3 FindRandomTargetPosition(int minRangeMeter, int maxRangeMeter)
    {
        int moveMeter = Random.RandomRange(minRangeMeter, maxRangeMeter + 1);

        int plusX = Random.RandomRange(-1, 1 + 1);
        int plusZ = Random.RandomRange(-1, 1 + 1);
        Vector3 newTargetDir = new Vector3((float)plusX, 0.0f, (float)plusZ);
        newTargetDir.Normalize();

        return transform.position + (newTargetDir * (float)moveMeter);
    }

    GameObject FindPlayer(float searchDistanceMeter)
    {
        
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if(searchDistanceMeter>distance)
        {
           return player;
        }
        else
        {
            return null;
        }
    }

    void DeathState()
    {

        animator.SetBool("isDeath", true);
        nav.Stop();
        gameObject.GetComponent<Monster>().enabled = false;
        gameObject.GetComponent<EventTrigger>().enabled = false;
        
    }

    IEnumerator TransStateToPatrol(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SetState(State.PATROL);
    }

    public void PointerEnter()
    {
        gazeAt = true;
        // transform.localScale = OriginalScale * 1.2f;
        timer = 0f;
        pointenter = true;
    }

    public void PointerExit()
    {
        gazeAt = false;
        timer = 0f;
        pointenter = false;
        //transform.localScale = OriginalScale;
    }

    public void PointerDown()
    {
               
        timer = 0f;  
        if(Fire.bullet > 0)
        {
            monsterHP -= 50;
            animator.SetBool("isHit", true);
            timer_event = 0.0f;

            

            pointdown = true;
        }   
        else
        {
            Debug.Log("총알이 없습니다");
        }     
       // monsterHP -= 25;
       // animator.SetBool("isHit", true);
       // timer_event = 0.0f;
       // pointdown = true;

        

        
    }
}


/*
        if (distance >= playerAttribute.Radius + monsterAttribute.monsterRadius) 
        {
            Debug.Log("move");
            transform.LookAt(target.transform.position);
            transform.position += dir * speed * Time.deltaTime;
            // nav.SetDestination(player.transform.position);
            animator.SetBool("isIdle", false);
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isIdle", true);
            Debug.Log("stop");         
            
        }
    */   
	
    
   /* void AnimationUpdate()
    {
        if (nav.destination != transform.position)
        {
            animator.SetBool("isRunning", true);
            animator.SetBool("isIdle", false);
        }
        else
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isIdle", true);
        }
    }
    */
   

