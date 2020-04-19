using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class Test :MonoBehaviour
{
    void Start() {
        this.UpdateAsObservable()
            .Where(_ => Input.GetMouseButtonDown(0))
            .Subscribe(_ => Debug.Log("Left!"));

        this.UpdateAsObservable()
            .Where(_ => Input.GetMouseButtonDown(1))
            .Subscribe(_ => Debug.Log("Right!"));

        Observable.EveryUpdate()
            .Where(_ => Input.GetKeyDown(KeyCode.Space))
            .Subscribe(_ => Debug.Log("Space!-NO AddTo"));

        Observable.EveryUpdate()
            .Where(_ => Input.GetKeyDown(KeyCode.Space))
            .Subscribe(_ => Debug.Log("Space!-AddTo"))
            .AddTo(this);

        Invoke("destroy", 5.0f);
    }
    void destroy() {
        Debug.Log("destroy");
        Destroy(this.gameObject);
    }
}