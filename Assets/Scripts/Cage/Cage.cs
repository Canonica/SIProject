using UnityEngine;
using System.Collections;
using DG.Tweening;
public class Cage : MonoBehaviour {


    public bool _isBumped;
    public float _bumpMultiplier = 5f;
    public Vector3 currentBumpDirection;
    public bool _isFlying;


    bool playSound;
    public GameObject hitFx;

    public AudioClip audioclipCry1;
    public AudioClip audioclipCry2;
    public AudioClip audioclipCry3;
    public AudioClip audioclipCry4;
    public AudioClip audioclipCry5;
    public AudioClip audioclipFall;
    private GameObject speakerMainCry;

    public AudioClip audioclipCreak1;
    public AudioClip audioclipCreak2;
    public AudioClip audioclipCreak3;
    public AudioClip audioclipCreak4;
    private GameObject speakerMainCreak;
    // Use this for initialization
    void Start () {
        playSound = false;
        InvokeRepeating("CheckUnder", 0.5f, 0.01f);
        _isFlying = false;
        hitFx = Resources.Load("Prefabs/P_AttackSurCage") as GameObject;
    }
	
	// Update is called once per frame
	void Update () {
        if (_isBumped)
        {
            if (!playSound)
            {
                int randomChance = Random.RandomRange(0, 10);
                if (randomChance >= 9)
                {
                    speakerMainCry = SoundManager.Instance.RandomizeSfx(audioclipCry1, audioclipCry2, audioclipCry3, audioclipCry4, audioclipCry5);
                    speakerMainCry.GetComponent<AudioSource>().loop = false;
                    speakerMainCreak = SoundManager.Instance.RandomizeSfx(audioclipCreak1, audioclipCreak2, audioclipCreak3, audioclipCreak4);
                    speakerMainCreak.GetComponent<AudioSource>().loop = false;
                }
                playSound = true;
            }
            CheckCollision(currentBumpDirection);
        }
        else
        {
            playSound = false;
        }

        if (_isFlying && !_isBumped)
        {
            this.transform.position = transform.position + -transform.up * 10 * Time.deltaTime;
        }

    }

    void OnCollisionEnter(Collision  other)
    {

        
        if (other.transform.tag == "Enemy")
        {
            Bump(other.gameObject);
        }else if(other.gameObject.transform.parent != null && other.gameObject.transform.parent.tag == "Player")
        {

            BumpPlayer(other.gameObject.transform.parent.gameObject, other.gameObject.transform.parent.transform.position);
        }

    }

    public void BumpPlayer(GameObject parPlayer, Vector3 parPlayerPos)
    {
        if(_isBumped && (!parPlayer.GetComponent<Player>().m_isShielding || !parPlayer.GetComponent<Player>().m_hasShield))
        {
            
            Vector3 m_tempEnemyPosition = new Vector3(parPlayer.transform.position.x, 0, parPlayer.transform.position.z);
            Vector3 m_tempPlayerPosition = new Vector3(transform.position.x, 0, transform.position.z);
            Vector3 m_bumpDirection = m_tempEnemyPosition - m_tempPlayerPosition;
            currentBumpDirection.Normalize();
            m_bumpDirection.Normalize();
            float behind = Vector3.Dot(currentBumpDirection, m_bumpDirection);
            if (behind < 0)
            {
                parPlayer.GetComponent<Player>()._isBumped = true;
                parPlayer.transform.DOMove(parPlayer.transform.position + m_bumpDirection * _bumpMultiplier * Mathf.Abs(behind)
                    , 1f).SetEase(Ease.OutQuint).OnComplete(() => StartCoroutine(parPlayer.GetComponent<Monster>().Stun())).OnComplete(() => parPlayer.GetComponent<Player>()._isBumped = false);
            }
        }
    }

    public void Bump(GameObject parEnemy)
    {
        if (!_isBumped)
        {
            GameObject tempFx = Instantiate(hitFx, transform.position, Quaternion.identity) as GameObject;
            _isBumped = true;
            Vector3 m_tempEnemyPosition = new Vector3(parEnemy.transform.position.x, 0,parEnemy.transform.position.z);
            Vector3 m_tempPlayerPosition = new Vector3(transform.position.x, 0, transform.position.z);
            Vector3 m_bumpDirection = m_tempEnemyPosition - m_tempPlayerPosition;
            currentBumpDirection = m_bumpDirection;
            this.transform.DOMove(transform.position - m_bumpDirection*2 , 1f).SetEase(Ease.OutQuint).OnComplete(() => NotBumped());
            GameManager.GetInstance()._camera.transform.DOShakePosition(0.2f);
        }
        else 
        {
            Vector3 m_tempEnemyPosition = new Vector3(parEnemy.transform.position.x, 0, parEnemy.transform.position.z);
            Vector3 m_tempPlayerPosition = new Vector3(transform.position.x, 0, transform.position.z);
            Vector3 m_bumpDirection = m_tempEnemyPosition - m_tempPlayerPosition;
            currentBumpDirection.Normalize();
            m_bumpDirection.Normalize();
            parEnemy.GetComponent<Monster>()._currentBumpDirection = m_bumpDirection;
            parEnemy.GetComponent<Monster>()._isBumped = true;
            float behind = Vector3.Dot(currentBumpDirection, m_bumpDirection);
            if(behind < 0)
            {
                parEnemy.GetComponent<MonsterAnimationManager>().LaunchBump();
                parEnemy.transform.DOMove(parEnemy.transform.position + m_bumpDirection * _bumpMultiplier * Mathf.Abs(behind)
                    , 1f).SetEase(Ease.OutQuint).OnComplete(() => StartCoroutine(parEnemy.GetComponent<Monster>().Stun()));
            }
        }
    }

    void CheckCollision(Vector3 parDirection)
    {
        RaycastHit m_hit;
        if (Physics.SphereCast(transform.position, gameObject.GetComponent<CapsuleCollider>().radius/2, -parDirection, out m_hit, Mathf.Infinity))
        {
            if ((m_hit.collider.tag == "Obstacle"  || m_hit.collider.tag == "MoveObstacle") && m_hit.distance <= gameObject.GetComponent<CapsuleCollider>().radius+0.1f)
            {
                if (m_hit.collider.tag == "MoveObstacle")
                {
                    m_hit.collider.gameObject.GetComponent<BumpObstacle>().Bump(parDirection);
                }
                Vector3 _tempPosition = transform.position;
                transform.DOKill(true);
                transform.DOMove(_tempPosition, 0.0f).OnComplete(() => _isBumped = false);
               
            }
        }
    }

    void NotBumped()
    {
        _isBumped = false;
    }

    void CheckUnder()
    {
        RaycastHit hit;
        //new Vector3(transform.position.x, transform.position.y - gameObject.GetComponent<CapsuleCollider>().height/2f, transform.position.z)
        if (Physics.SphereCast(transform.position, this.gameObject.GetComponent<CapsuleCollider>().radius, -transform.up, out hit, 0.5f))
        {

            if (hit.transform.tag == "Ground")
            {
                _isFlying = false;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                
            }
        }
        else
        {
            _isFlying = true;
            GetComponent<Rigidbody>().AddExplosionForce(10f, new Vector3(0f,5f,0f), 100);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
}
