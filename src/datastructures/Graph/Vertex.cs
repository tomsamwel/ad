using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AD
{
    public partial class Vertex : IVertex , IComparable<Vertex>
    {
        public string name;
        public LinkedList<Edge> adj = new();
        public double distance = double.MaxValue;
        public Vertex prev;
        public bool known = false;
        
        /// <summary>
        ///    Creates a new Vertex instance.
        /// </summary>
        /// <param name="name">The name of the new vertex</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Vertex(string name)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name), "Vertex name cannot be null.");
        }


        public Vertex(string name, Vertex dest, double cost) : this(name)
        {
            CreateAdjacent(dest, cost);
        }

        public Edge CreateAdjacent(Vertex dest, double cost)
        {
            var edge = new Edge(dest, cost);
            adj.AddLast(edge);
            return edge;
        }
        
        public string GetName()
        {
            return name;
        }
        public LinkedList<Edge> GetAdjacents()
        {
            return adj;
        }

        public bool HasAdjacents()
        {
            return adj.Count > 0;
        }

        public double GetDistance()
        {
            return distance;
        }

        public Vertex GetPrevious()
        {
            return prev;
        }

        public bool GetKnown()
        {
            return known;
        }

        public void Reset()
        {
            distance = double.MaxValue;
            prev = null;
            known = false;
        }
        
        public int CompareTo(Vertex? other)
        {
            return other != null ? distance.CompareTo(other.distance) : 1;
        }

        /// <summary>
        ///    Converts this instance of Vertex to its string representation.
        ///    <para>Output will be like : name (distance) [ adj1 (cost) adj2 (cost) .. ]</para>
        ///    <para>Adjecents are ordered ascending by name. If no distance is
        ///    calculated yet, the distance and the parantheses are omitted.</para>
        /// </summary>
        /// <returns>The string representation of this Graph instance</returns> 
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(GetName());

            if (GetDistance() < double.MaxValue)
                sb.Append($"({GetDistance()})");
            
            sb.Append(" [");

            if (GetAdjacents().Any())
            {
                foreach (var edge in GetAdjacents().OrderBy(e => e.dest.name))
                {
                    sb.Append($" {edge.dest.GetName()} ({edge.cost})");
                }
            }

            sb.Append(" ]");

            return sb.ToString();
        }

    }
}