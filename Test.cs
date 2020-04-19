using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

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
            .AddTo(this.gameObject);

        Observable.Timer(TimeSpan.FromSeconds(5))
           .Subscribe(_ => Destroy(this.gameObject));
    }

}