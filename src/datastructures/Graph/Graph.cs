// using System.Collections.Generic;

using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AD
{
    public partial class Graph : IGraph
    {
        public static readonly double INFINITY = System.Double.MaxValue;

        public Dictionary<string, Vertex> vertexMap = new ();

        /// <summary>
        ///    Adds a vertex to the graph. If a vertex with the given name
        ///    already exists, no action is performed.
        /// </summary>
        /// <param name="name">The name of the new vertex</param>
        public void AddVertex(string name)
        {
            GetVertex(name);
        }
        
        /// <summary>
        ///    Gets a vertex from the graph by name. If no such vertex exists,
        ///    a new vertex will be created and returned.
        /// </summary>
        /// <param name="name">The name of the vertex</param>
        /// <returns>The vertex with the given name</returns>
        public Vertex GetVertex(string name)
        {
            if (vertexMap.TryGetValue(name, out var vertex)) return vertex;

            var newVertex = new Vertex(name);
            vertexMap.Add(name, newVertex);
            return newVertex;
        }
        
        /// <summary>
        ///    Creates an edge between two vertices. Vertices that are non existing
        ///    will be created before adding the edge.
        ///    There is no check on multiple edges!
        /// </summary>
        /// <param name="source">The name of the source vertex</param>
        /// <param name="dest">The name of the destination vertex</param>
        /// <param name="cost">cost of the edge</param>
        public void AddEdge(string source, string dest, double cost = 1)
        {
            var sourceVertex = GetVertex(source);
            var destVertex = GetVertex(dest);
            sourceVertex.CreateAdjacent(destVertex, cost);
        }
        
        /// <summary>
        ///    Clears all info within the vertices. This method will not remove any
        ///    vertices or edges.
        /// </summary>
        public void ClearAll()
        {
            foreach (var vertex in vertexMap.Values) vertex.Reset();
        }

        /// <summary>
        ///    Performs the Breatch-First algorithm for unweighted graphs.
        /// </summary>
        /// <param name="name">The name of the starting vertex</param>
        public void Unweighted(string name)
        {
            var vertex = GetVertex(name);
            var q = new Queue<Vertex>();
            vertex.distance = 0;
            q.Enqueue(vertex);

            while (q.Any())
            {
                vertex = q.Dequeue();

                foreach (var edge in vertex.GetAdjacents().Where(edge => edge.dest.distance > vertex.distance + 1))
                {
                    edge.dest.distance = vertex.distance + 1;
                    edge.dest.prev = vertex;
                    q.Enqueue(edge.dest);
                }
            }
        }

        /// <summary>
        ///    Performs the Dijkstra algorithm for weighted graphs.
        /// </summary>
        /// <param name="name">The name of the starting vertex</param>
        public void Dijkstra(string name)
        {
            ClearAll();
            var pq = new PriorityQueue<Vertex>();

            var vertex = GetVertex(name);
            vertex.distance = 0;
            
            pq.Add(vertex);

            while (pq.size >= 1)
            {
                vertex = pq.Remove();
                
                // if it's already known, skip it
                if (vertex.known) continue;
                vertex.known = true;

                foreach (var edge in vertex.GetAdjacents())
                {
                    // calculate the new distance to the neighbor
                    var newDistance = vertex.distance + edge.cost;
                    
                    // route to neighbor is already shorter so skip it
                    if (edge.dest.distance < newDistance) continue;
                    
                    // set the new lowest distance to the neighbor vertex
                    edge.dest.distance = newDistance;
                    edge.dest.prev = vertex;
                    
                    // add the edge to the priority queue since it has a new shortest route
                    pq.Add(edge.dest);
                }
            }
        }
        
        /// <summary>
        ///    Converts this instance of Graph to its string representation.
        ///    It will call the ToString method of each Vertex. The output is
        ///    ascending on vertex name.
        /// </summary>
        /// <returns>The string representation of this Graph instance</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var key in vertexMap.Keys.OrderBy(x => x))
            {
                sb.Append(vertexMap[key]);
                sb.Append('\n');
            }

            return sb.ToString();
        }


        /// <summary>
        /// Determines whether the graph is connected, i.e., there is a path
        /// between every pair of vertices.
        /// </summary>
        /// <returns>True if the graph is connected, otherwise false</returns>
        public bool IsConnected()
        {
            // Check if the graph is empty (no vertices)
            if (vertexMap.Count == 0)
            {
                return true; // An empty graph is considered connected
            }

            // Pick any vertex as the starting point for DFS
            var startVertex = vertexMap.Values.First();

            // Perform DFS from the starting vertex
            var visited = new HashSet<Vertex>();
            DFS(startVertex, visited);

            // If all vertices have been visited, the graph is connected
            return visited.Count == vertexMap.Count;
        }

        private void DFS(Vertex currentVertex, HashSet<Vertex> visited)
        {
            visited.Add(currentVertex);

            foreach (var neighbor in currentVertex.GetAdjacents())
            {
                if (!visited.Contains(neighbor.dest))
                {
                    DFS(neighbor.dest, visited);
                }
            }
        }
        
        private void BFS(Vertex startVertex, HashSet<Vertex> visited)
        {
            var queue = new Queue<Vertex>();
            queue.Enqueue(startVertex);
            visited.Add(startVertex);

            while (queue.Count > 0)
            {
                var currentVertex = queue.Dequeue();

                foreach (var neighbor in currentVertex.GetAdjacents())
                {
                    if (!visited.Contains(neighbor.dest))
                    {
                        visited.Add(neighbor.dest);
                        queue.Enqueue(neighbor.dest);
                    }
                }
            }
        }


    }
}