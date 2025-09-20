/*
The MIT License (MIT)
Copyright (c) 2015 Emerson Carvalho <@emersonbroga>
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using UnityEngine;

public class Awesome2DCamera : MonoBehaviour
{
    public Transform target;
    public float distance = -10f;
    public float height = 0f;
    public float damping = 5.0f;

    public float minX = 0f;
    public float maxX = 0f;
    public float minY = 0f;
    public float maxY = 0f;

    void Start()
    {
        // Set minX to the current position of the camera
        minX = transform.position.x;


        // Set minY and maxY if needed
    }

    void Update()
    {

        Vector3 wantedPosition = target.TransformPoint(0, height, distance);

        // Clamp the camera position to the specified boundaries
        wantedPosition.x = Mathf.Clamp(wantedPosition.x, minX, maxX);

        transform.position = Vector3.Lerp(transform.position, wantedPosition, (Time.deltaTime * damping));
    }
}
