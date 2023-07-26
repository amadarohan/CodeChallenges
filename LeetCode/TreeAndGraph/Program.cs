using GraphUsingMatrix;
using System.Collections.ObjectModel;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System;
using System.Text;
using AnotherImplementaionInCoreReview;

var adjMatrixGraph = new AdjacencyMatrixGraph(9, false);
adjMatrixGraph.AddEdge(0, 8);
adjMatrixGraph.AddEdge(0, 3);
adjMatrixGraph.AddEdge(8, 4);
var adjacent0 = adjMatrixGraph.GetAdjacentVertices(0);
var adjacent8 = adjMatrixGraph.GetAdjacentVertices(8);

var adjacenttest = adjMatrixGraph.GetAdjacentVertices(3);

///////////////////////
namespace GraphUsingMatrix
{
    public abstract class GraphBase
    {
        protected readonly int numVertices;
        protected readonly bool directed;

        public GraphBase(int numVertices, bool directed = false)
        {
            this.numVertices = numVertices;
            this.directed = directed;
        }

        public abstract void AddEdge(int v1, int v2, int weight);

        public abstract IEnumerable<int> GetAdjacentVertices(int v);

        public abstract int GetEdgeWeight(int v1, int v2);

        public abstract void Display();

        public int NumVertices { get { return numVertices; } }


        /////////////////////////////////////////////////////////////////

    }

    public class AdjacencyMatrixGraph : GraphBase
    {
        int[,] Matrix;
        public AdjacencyMatrixGraph(int numVertices, bool directed = false) : base(numVertices, directed)
        {
            GenerateEmptyMatrix(numVertices);
        }
        public override void AddEdge(int v1, int v2, int weight = 1)
        {
            if (v1 >= numVertices || v2 >= numVertices || v1 < 0 || v2 < 0)
                throw new ArgumentOutOfRangeException("Vertices are out of bounds");

            if (weight < 1) throw new ArgumentException("Weight cannot be less than 1");

            Matrix[v1, v2] = weight;

            //In an undirected graph all edges are bi-directional
            if (!directed) Matrix[v2, v1] = weight;
        }

        public override void Display()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<int> GetAdjacentVertices(int v)
        {
            if (v < 0 || v >= this.numVertices) throw new ArgumentOutOfRangeException("Cannot access vertex");

            List<int> adjacentVertices = new List<int>();
            for (int i = 0; i < this.numVertices; i++)
            {
                if (this.Matrix[v, i] > 0)
                    adjacentVertices.Add(i);
            }
            return adjacentVertices;
        }

        public override int GetEdgeWeight(int v1, int v2)
        {
            return this.Matrix[v1, v2];
        }

        private void GenerateEmptyMatrix(int numVertices)
        {
            Matrix = new int[numVertices, numVertices];
            for (int row = 0; row < numVertices; row++)
            {
                for (int col = 0; col < numVertices; col++)
                {
                    Matrix[row, col] = 0;
                }
            }
        }
    }
}

namespace GraphUsingNodeHashSet
{
    public class Node
    {
        private readonly int VertexId;
        private readonly HashSet<int> AdjacencySet;

        public Node(int vertexId)
        {
            this.VertexId = vertexId;
            this.AdjacencySet = new HashSet<int>();
        }

        public void AddEdge(int v)
        {
            if (this.VertexId == v)
                throw new ArgumentException("The vertex cannot be adjacent to itself");
            this.AdjacencySet.Add(v);
        }

        public HashSet<int> GetAdjacentVertices()
        {
            return this.AdjacencySet;
        }
    }

    public class AdjacencySetGraph : GraphBase
    {
        private HashSet<Node> vertexSet;
        public AdjacencySetGraph(int numVertices, bool directed = false) : base(numVertices, directed)
        {
            this.vertexSet = new HashSet<Node>();
            for (var i = 0; i < numVertices; i++)
            {
                vertexSet.Add(new Node(i));
            }
        }

        public override void AddEdge(int v1, int v2, int weight = 1)
        {
            if (v1 >= this.numVertices || v2 >= this.numVertices || v1 < 0 || v2 < 0)
                throw new ArgumentOutOfRangeException("Vertices are out of bounds");

            if (weight != 1) throw new ArgumentException("An adjacency set cannot represent non-one edge weights");

            this.vertexSet.ElementAt(v1).AddEdge(v2);

            //In an undirected graph all edges are bi-directional
            if (!this.directed) this.vertexSet.ElementAt(v2).AddEdge(v1);
        }

        public override void Display()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<int> GetAdjacentVertices(int v)
        {
            if (v < 0 || v >= this.numVertices) throw new ArgumentOutOfRangeException("Cannot access vertex");
            return this.vertexSet.ElementAt(v).GetAdjacentVertices();
        }

        public override int GetEdgeWeight(int v1, int v2)
        {
            return 1;
        }
    } 
}

namespace SomeIplementationInStackOverFlow {
    class Example
    {
        public List<Node> InitGraph()
        {
            var nodes = new Dictionary<string, Node>();

            nodes.Add("Head", new Node("Head"));
            nodes.Add("T1", new Node("T1"));
            nodes.Add("T2", new Node("T2"));
            // While that works, a method is nicer:
            nodes.Add("C1");

            // These two lines should really be factored out to a single method call
            nodes["Head"].Successors.Add(nodes["T1"]);
            nodes["T1"].Predecessors.Add(nodes["Head"]);
            nodes["Head"].Successors.Add(nodes["T2"]);
            nodes["T2"].Predecessors.Add(nodes["Head"]);

            // Yes. Much nicer
            nodes.Connect("Head", "C1");
            nodes.Connect("T1", "C1");
            nodes.Connect("T2", "C1");

            var nodelist = new List<Node>(nodes.Values);
            return nodelist;
        }
    }
    public static class NodeHelper
    {
        public static void Add(this Dictionary<string, Node> dict, string nodename)
        {
            dict.Add(nodename, new Node(nodename));
        }
        public static void Connect(this Dictionary<string, Node> dict, string from, string to)
        {
            dict[from].Successors.Add(dict[to]);
            dict[to].Predecessors.Add(dict[from]);
        }
    }

    public class Node
    {
        public string Name { get; set; }
        public int Coolness { get; set; }
        public List<Node> Predecessors { get; set; }
        public List<Node> Successors { get; set; }
        public Node()
        {
            Coolness = 1;
        }

        public Node(string name) : this()
        {
            this.Name = name;
        }
    }
}

namespace AnotherImplementaionInCoreReview {
//    The separate properties and backing store are redundant.We don't do anything extra when getting or setting the values so we can just use the properties.

//When we have multiple constructors, we should chain them, or in this case, we can just use an optional parameter. (The params version makes initialization a bit simpler).

//We should make the incoming parameter as general as possible.By declaring it as a List<Vertex<T>> we are preventing the user passing in an Vertex<T>[] or a Collection<Vertex<T>>.If we declare it as IEnumerable<Vertex<T>> we can pass in each of these, as well as the list. It means an extra call inside the constructor (ToList()) but this is just one place.

//Usually I would make the value for the vertex readonly (I would expect the neighbors to change but not the vertex value) if this is wrong, we can just make the value read/write.

//The use of Visit() and making the IsVisited setter public is redundant, we need to use Visit() and make the setter private (in which case we can only search once) or we need to remove Visit().

//As with the constructor, when adding multiple neighbors(AddEdge() ) we should pass in an IEnumerable<Vertex<T>> rather than a List<Vertex<T>> and should add the params version.

//If we are worried enough about performance that we want to use StringBuilder in ToString() we should get rid of the + " " calls inside it, we can use string formatting instead. (The Aggregate() call is just showing off, sorry)

//This still leaves us with the trailing space for the last neighbor, but if we can live with this we're fine. However, unless performance is a real issue, I would drop the StringBuilder and just use string.Join()

    class Vertex<T>
    {
        public Vertex(T value, params Vertex<T>[] parameters)
            : this(value, (IEnumerable<Vertex<T>>)parameters) { }

        public Vertex(T value, IEnumerable<Vertex<T>> neighbors = null)
        {
            Value = value;
            Neighbors = neighbors?.ToList() ?? new List<Vertex<T>>();
            IsVisited = false;  // can be omitted, default is false but some
                                // people like to have everything explicitly
                                // initialized
        }

        public T Value { get; }   // can be made writable

        public List<Vertex<T>> Neighbors { get; }

        public bool IsVisited { get; set; }

        public int NeighborCount => Neighbors.Count;

        public void AddEdge(Vertex<T> vertex)
        {
            Neighbors.Add(vertex);
        }

        public void AddEdges(params Vertex<T>[] newNeighbors)
        {
            Neighbors.AddRange(newNeighbors);
        }

        public void AddEdges(IEnumerable<Vertex<T>> newNeighbors)
        {
            Neighbors.AddRange(newNeighbors);
        }

        public void RemoveEdge(Vertex<T> vertex)
        {
            Neighbors.Remove(vertex);
        }

        public override string ToString()
        {
            return Neighbors.Aggregate(new StringBuilder($"{Value}: "), (sb, n) => sb.Append($"{n.Value} ")).ToString();
            //return $"{Value}: {(string.Join(" ", Neighbors.Select(n => n.Value)))}";
        }

    }




    class UndirectedGenericGraph<T>
    {

        public UndirectedGenericGraph(params Vertex<T>[] initialNodes)
            : this((IEnumerable<Vertex<T>>)initialNodes) { }

        public UndirectedGenericGraph(IEnumerable<Vertex<T>> initialNodes = null)
        {
            Vertices = initialNodes?.ToList() ?? new List<Vertex<T>>();
        }

        public List<Vertex<T>> Vertices { get; }

        public int Size => Vertices.Count;

        public void AddPair(Vertex<T> first, Vertex<T> second)
        {
            AddToList(first);
            AddToList(second);
            AddNeighbors(first, second);
        }

        public void DepthFirstSearch(Vertex<T> root, Action<string> writer)
        {
            UnvisitAll();
            DepthFirstSearchImplementation(root, writer);

        }

        public void CheckVertices()
        {
            var la = new Vertex<string>("Los Angeles");
            var sf = new Vertex<string>("San Francisco");
            var lv = new Vertex<string>("Las Vegas");
            var se = new Vertex<string>("Seattle");
            var au = new Vertex<string>("Austin");
            var po = new Vertex<string>("Portland");

            var testGraph = new UndirectedGenericGraph<string>();

            // la <=> sf, lv, po
            testGraph.AddPair(la, sf);
            testGraph.AddPair(la, lv);
            testGraph.AddPair(la, po);

            // sf <=> se, po
            testGraph.AddPair(sf, se);
            testGraph.AddPair(sf, po);

            // lv <=> au
            testGraph.AddPair(lv, au);

            // se <=> po
            testGraph.AddPair(se, po);

            // Check to see that all neighbors are properly set up
            foreach (var vertex in testGraph.Vertices)
            {
                System.Diagnostics.Debug.WriteLine(vertex.ToString());
            }

            // Test searching algorithms
            testGraph.DepthFirstSearch(la, (m) => System.Diagnostics.Debug.WriteLine(m));

        }

        private void DepthFirstSearchImplementation(Vertex<T> root, Action<string> writer)
        {
            if (!root.IsVisited)
            {
                writer($"{root.Value} ");
                root.IsVisited = true;

                foreach (Vertex<T> neighbor in root.Neighbors)
                {
                    DepthFirstSearchImplementation(neighbor, writer);
                }
            }
        }

        private void AddToList(Vertex<T> vertex)
        {
            if (!Vertices.Contains(vertex))
            {
                Vertices.Add(vertex);
            }
        }

        private void AddNeighbors(Vertex<T> first, Vertex<T> second)
        {
            AddNeighbor(first, second);
            AddNeighbor(second, first);
        }

        private void AddNeighbor(Vertex<T> first, Vertex<T> second)
        {
            if (!first.Neighbors.Contains(second))
            {
                first.AddEdge(second);
            }
        }

        private void UnvisitAll()
        {
            foreach (var vertex in Vertices)
            {
                vertex.IsVisited = false;
            }
        }

    }


}

namespace AnotherImplementaionWithDictionaries
{
    //https://stackoverflow.com/questions/13819744/graph-adjacency-list-implementation

    public interface IGraph
    {
        void InsertEdge(int edgeAKey, int edgeBKey);
        void IsertNewVertex(int vertexKey);
        LinkedList<Vertex> FindByKey(int vertexKey);
        bool ExistKey(int vertexKey);
    }

    public class GraphDirect : IGraph
    {
        private Dictionary<int, LinkedList<Vertex>> Vertexes { get; set; }

        public GraphDirect()
        {
            Vertexes = new Dictionary<int, LinkedList<Vertex>>();
        }

        public bool ExistKey(int vertexKey)
        {
            if (this.FindByKey(vertexKey) == null)
                return false;
            else
                return true;
        }

        public void IsertNewVertex(int vertexKey)
        {
            if (!this.ExistKey(vertexKey))
            {
                Vertex vertex = new Vertex(vertexKey);
                LinkedList<Vertex> listVertexes = new LinkedList<Vertex>();
                listVertexes.AddFirst(vertex);
                this.Vertexes.Add(vertexKey, listVertexes);
            }
        }

        public void InsertEdge(int vertexAKey, int vertexBKey)
        {
            //Create the vertex A, if it doesn't exist            
            if (!this.ExistKey(vertexAKey))
            {
                this.IsertNewVertex(vertexAKey);
            }
            //Will always insert the vertex B on this edge
            this.FindByKey(vertexAKey).AddLast(new Vertex(vertexBKey));
            //Create the vertex B, if doesn't exist
            if (!this.ExistKey(vertexBKey))
            {
                this.IsertNewVertex(vertexBKey);
            }
        }

        public LinkedList<Vertex> FindByKey(int vertexKey)
        {
            if (this.Vertexes.ContainsKey(vertexKey))
                return this.Vertexes[vertexKey];

            return null;
        }

    }

    public enum State { Visited = 0, UnVisited = 1, Processed = 2 }

    public class Vertex
    {
        public int Key;
        public int Value;
        public State Status = State.UnVisited;

        public Vertex(int key)
        {
            this.Key = key;
            this.Value = 0;
        }

        public Vertex(int key, int value)
        {
            this.Key = key;
            this.Value = value;
        }
    }

    public class Start
    {
        public static void Main()
        {
            GraphDirect gDirect = new GraphDirect();
            gDirect.InsertEdge(2, 3);
            gDirect.InsertEdge(2, 8);
            gDirect.InsertEdge(5, 6);
        }
    }
}