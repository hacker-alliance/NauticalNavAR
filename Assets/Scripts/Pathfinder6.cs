using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Pathfinder6 : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour2;
    public GameObject arrow;

   void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {

        Debug.Log("test");
    }

    void ITrackableEventHandler.OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        int oo = 1000;
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Debug.Log("Found");

            int NO_PARENT = -1;
            double[,] adjacencyMatrix = {  { 0, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo },
                    										   { oo, 0, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo },
                    										   { oo, oo, 0, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo },
                    										   { oo, oo, oo, 0, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo },
                    										   { oo, oo, oo, oo, 0, 9.59, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo },
                    										   { oo, oo, oo, oo, 9.59, 0, oo, oo, oo, oo, 6.67, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo },
                    										   { oo, oo, oo, oo, oo, oo, 0, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo },
                    										   { oo, oo, oo, oo, oo, oo, oo, 0, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo },
                    										   { oo, oo, oo, oo, oo, oo, oo, oo, 0, oo, oo, oo, oo, oo, oo, 12.853, oo, oo, oo, oo, oo },
                    										   { oo, oo, oo, oo, oo, oo, oo, oo, oo, 0, oo, oo, oo, oo, 11.403, oo, oo, oo, oo, oo, oo },
                    										   { oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, 0, 6.525, 6.38, 13.398, oo, oo, oo, oo, oo, oo, oo },
                    										   { oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, 6.525, 0, 2.358, oo, oo, oo, oo, oo, oo, oo, oo },
                    										   { oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, 6.38, 2.358, 0, oo, oo, oo, oo, oo, oo, oo, oo },
                    										   { oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, 13.398, oo, oo, 0, 6.65, oo, oo, oo, oo, oo, oo },
                    										   { oo, oo, oo, oo, oo, oo, oo, oo, oo, 11.403, oo, oo, oo, 6.65, 0, 6.67, oo, oo, oo, oo, oo },
                    										   { oo, oo, oo, oo, oo, oo, oo, oo, 12.853, oo, oo, oo, oo, oo, 6.67, 0, 4.06, oo, oo, oo, oo },
                    										   { oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, 4.06, 0, 4.93, oo, oo, oo },
                    										   { oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, 4.93, 0, 5.336, oo, oo },
                    										   { oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, 5.336, 0, 20, 20 },
                    										   { oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, 20, 0, oo },
                    										   { oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, oo, 20, oo, 0 } };

            int thisNode = 6;
            int[] theseEdgeNodes = {5, 11, 15};
            int[] theseEdgeAngles = {0, 180, 90};
            int[,] finalPaths = dijkstra(adjacencyMatrix, thisNode-1);

            int destination = -1;
            if (PopulateDropDown.destination == 0)
            {
                destination = 12;
            } else if (PopulateDropDown.destination == 1)
            {
                destination = 13;
            } else if (PopulateDropDown.destination == 2)
            {
                destination = 20;
            } else if (PopulateDropDown.destination == 3)
            {
                destination = 21;
            } else if (PopulateDropDown.destination == 4)
            {
                destination = 17;
            } else if (PopulateDropDown.destination == 5)
            {
                destination = 6;
            }

            int[] finalPath = new int[finalPaths.GetLength(0)];
            for (int i=0; i<finalPaths.GetLength(0); i++)
            {
                finalPath[i] = finalPaths[destination-1, i];
            }

            int nextNode = -1;

            if (thisNode != finalPath[0])
            {
                for (int i=0; i<finalPath.Length; i++)
                {
                    if (finalPath[i] == 0)
                    {
                        nextNode = finalPath[i-2];
                        break;
                    }
                }

                int angle = -1;
                for (int i=0; i<theseEdgeNodes.Length; i++)
                {
                    if (theseEdgeNodes[i] == nextNode)
                    {
                        angle = theseEdgeAngles[i];
                    }
                }

                arrow.transform.localRotation = Quaternion.Euler(0, angle, 0);
            }
        }
        else
        {
            Debug.Log("Not Found");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        mTrackableBehaviour2 = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour2)
        {
            mTrackableBehaviour2.RegisterTrackableEventHandler(this);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private static int[,] dijkstra(double[,] adjacencyMatrix,
                                            int startVertex)
    {
        int nVertices = adjacencyMatrix.GetLength(0);

        int[,] finalPaths = new int[nVertices, nVertices];

        // shortestDistances[i] will hold the
        // shortest distance from src to i
        double[] shortestDistances = new double[nVertices];

        // added[i] will true if vertex i is
        // included / in shortest path tree
        // or shortest distance from src to
        // i is finalized
        bool[] added = new bool[nVertices];

        // Initialize all distances as
        // INFINITE and added[] as false
        for (int vertexIndex = 0; vertexIndex < nVertices;
                                            vertexIndex++)
        {
            shortestDistances[vertexIndex] = int.MaxValue;
            added[vertexIndex] = false;
        }

        // Distance of source vertex from
        // itself is always 0
        shortestDistances[startVertex] = 0;

        // Parent array to store shortest
        // path tree
        int[] parents = new int[nVertices];

        // The starting vertex does not
        // have a parent
        parents[startVertex] = -1;

        // Find shortest path for all
        // vertices
        for (int i = 1; i < nVertices; i++)
        {

            // Pick the minimum distance vertex
            // from the set of vertices not yet
            // processed. nearestVertex is
            // always equal to startNode in
            // first iteration.
            int nearestVertex = -1;
            double shortestDistance = double.MaxValue;
            for (int vertexIndex = 0;
                    vertexIndex < nVertices;
                    vertexIndex++)
            {
                if (!added[vertexIndex] &&
                    shortestDistances[vertexIndex] <
                    shortestDistance)
                {
                    nearestVertex = vertexIndex;
                    shortestDistance = shortestDistances[vertexIndex];
                }
            }

            // Mark the picked vertex as
            // processed
            added[nearestVertex] = true;

            // Update dist value of the
            // adjacent vertices of the
            // picked vertex.
            for (int vertexIndex = 0;
                    vertexIndex < nVertices;
                    vertexIndex++)
            {
                double edgeDistance = adjacencyMatrix[nearestVertex, vertexIndex];

                if (edgeDistance > 0
                    && ((shortestDistance + edgeDistance) <
                        shortestDistances[vertexIndex]))
                {
                    parents[vertexIndex] = nearestVertex;
                    shortestDistances[vertexIndex] = shortestDistance +
                                                    edgeDistance;
                }
            }
        }

        Debug.Log("Vertex\t Distance\tPath");

        for (int vertexIndex = 0;
                vertexIndex < nVertices;
                vertexIndex++)
        {
            if (vertexIndex != startVertex)
            {
                Debug.Log("\n" + startVertex + " -> " + vertexIndex + " \t\t " + shortestDistances[vertexIndex] + "\t\t");

                int currentVertex = vertexIndex;
                int k = 0;
                while (currentVertex != -1)
                {
                    Debug.Log(currentVertex + " ");
                    finalPaths[vertexIndex, k] = currentVertex+1;
                    k++;
                    currentVertex = parents[currentVertex];
                }
            }
        }

        return finalPaths;
    }
}
