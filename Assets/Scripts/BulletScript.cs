using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float Speed = 5;
    [SerializeField] private float DistancesDestroy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * Speed);
    }

    //XÓA ĐẠN
    // Xử lý khi va chạm với vật thể đặc (Collision)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Nếu đạn đập trúng bất kỳ bức tường nào có thẻ "Wall"
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject); // Xóa viên đạn ngay lập tức
        }
    }

}
