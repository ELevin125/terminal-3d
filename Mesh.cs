namespace Terminal_3D.Geometry
{
    public struct Vertex
    {
        public Vector3 Position;

        public Vertex(Vector3 position)
        {
            Position = position;
        }
    }

    public struct Edge
    {
        public int V1;
        public int V2;

        public Edge(int v1, int v2)
        {
            V1 = v1;
            V2 = v2;
        }
    }
    public class Mesh
    {
        public List<Vertex> Vertices;
        public List<Edge> Edges;

        public Mesh()
        {
            Vertices = new List<Vertex>();
            Edges = new List<Edge>();
        }

        public void AddVertex(Vertex vertex)
        {
            Vertices.Add(vertex);
        }

        public void AddEdge(int vertexIndex1, int vertexIndex2)
        {
            Edges.Add(new Edge(vertexIndex1, vertexIndex2));
        }
    }
}
