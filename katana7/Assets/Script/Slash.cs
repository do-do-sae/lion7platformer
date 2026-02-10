using UnityEngine;

public class Slash : MonoBehaviour
{
    private GameObject p;// 플레이어 오브젝트
    Vector2 MousePos; //    마우스 위치
    Vector3 dir; //    플레이어와 마우스 위치의 방향 벡터

    float angle; //    회전 각도
    Vector3 dirNo;// 단위 방향 벡터

    public Vector3 direction = Vector3.right; // 기본 방향 벡터


    void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player");//플레이어찾기

        Transform tr = p.GetComponent<Transform>(); //트랜스폼가져오기
        MousePos = Input.mousePosition; //마우스포지션
        MousePos = Camera.main.ScreenToWorldPoint(MousePos);
        Vector3 Pos = new Vector3(MousePos.x, MousePos.y, 0);
        dir = Pos - tr.position;   //A - B

        //바라보는 각도 구하기
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;



    }

  
    void Update()
    {
        //회전적용
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        transform.position = p.transform.position;
    }


    public void Des()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //충돌한 물체가 적 미사일인지 확인
        if (collision.gameObject.GetComponent<EnemyMissile>() != null)
        {
            //미사일의 현재 방향 가져오기
            EnemyMissile missile = collision.gameObject.GetComponent<EnemyMissile>();
            SpriteRenderer missileSprite = collision.gameObject.GetComponent<SpriteRenderer>();

            //현재 방향의 정반대 방향으로 설정(-1을 곱하면 반대 방향이 됨)
            Vector2 reverseDir = -missile.GetDirection();

            //미사일의 새로운 방향 설정
            missile.SetDirection(reverseDir);


            //스프라이트 방향 뒤집기
            if (missileSprite != null)
            {
                missileSprite.flipX = !missileSprite.flipX;
            }
        }


        //적 처리
        if (collision.CompareTag("Enemy"))
        {
            //적의 죽음 애니메이션 실행
            ShootingEnemy enemy = collision.GetComponent<ShootingEnemy>();
            if (enemy != null)
            {
                enemy.PlayDeathAnimation();
            }
        }
    }











}
