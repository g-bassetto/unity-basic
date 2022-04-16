using UnityEngine;

public class Graph : MonoBehaviour {
    [SerializeField]
    Transform pointPrefab;

    [SerializeField, Range(10, 100)]
    int resolution = 10;

    [SerializeField]
    FunctionLibrary.FunctionName function;

    [SerializeField]
    Transform[] points;

    void Awake() {
        float step = 2f / resolution;
        var position = Vector3.zero;
        var scale = Vector3.one * step;
        points = new Transform[resolution * resolution];
        for (int i = 0, x = 0, z = 0;  i < points.Length; i++, x++) {
            if (x == resolution) {
                x = 0;
                z += 1;
            }
            var point = points[i] = Instantiate(pointPrefab);
            position.x = (x + 0.5f) * step - 1f;
            position.z = (z + 0.5f) * step - 1f;
            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);
        }
    }

    private void Update() {
        FunctionLibrary.Function f = FunctionLibrary.GetFunction(function);
        var time = Time.time;
        for (int i = 0; i < points.Length; i++) {
            var point = points[i];
            var pos = point.localPosition;
            pos.y = f(pos.x, pos.z, time);
            point.localPosition = pos;
        }
    }
}
