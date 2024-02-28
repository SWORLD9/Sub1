
using UnityEngine;

public class Ground_Move : MonoBehaviour
{
    [SerializeField] private float _finish;
    [SerializeField] private float _speed_Ground;
    [SerializeField] private GameObject[] _houses_Prefab;
    [SerializeField] private Vector3 _start_TF;

    private int _number_random;

 


    private void FixedUpdate()
    {
        if (this.transform.position.z > _finish)
        {
            _number_random = Random.Range(0, 2);
            Debug.Log(_number_random);
           
            Instantiate(_houses_Prefab[_number_random],_start_TF, _houses_Prefab[_number_random].transform.rotation);

            Destroy(this.gameObject);
        }
        this.transform.position += new Vector3(0, 0, _speed_Ground);
    }
}
