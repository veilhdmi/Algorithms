using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Crear una clase con 2 variables
class Graph{
	
// N° de vertices
private int _V; //creamos una variable para el numero de vertices

//Lista de vertices adyacentes
LinkedList<int>[] _adj; //crear una lista vacia que almacene la lista de adyacentes de cada vertice Ej: LinkedList<int>[vertice 0] lista_ady_v0


public Graph(int V) //creamos una clase constructor con un parametro para la clase Graph
{
	
	_adj = new LinkedList<int>[V]; // establecer el valor inicial de la variable _adj como una lista enlazada con V elementos
	for(int i = 0; i < _adj.Length; i++)
	{
		_adj[i] = new LinkedList<int>(); //crear una lista en cada elemento de _adj
	}
	_V = V;// establecer el valor inicial de la varibale _V con el valor introducido en el parametro
}



public void AddEdge(int v, int w) //crear metodo con dos parámetros que añade el elemento w al final de la lista _adj[de la posicion v]
{		
	_adj[v].AddLast(w); //w representa un vertice adjacente al vertice v

}

//Metodo que aplicará las propiedades del algoritmo BFS
public void BFS(int s) //recibe un parametro s, que será el vértice con el que se inicia el recorrido
{
	//se crea un arreglo que almacenará datos booleanos para marcar los vertices como no visitados por defecto
	bool[] visitados = new bool[_V];
	for(int i = 0; i < _V; i++)
		visitados[i] = false; //definidos como false = no visitado
	
	// Crear una cola para el recorrido BFS
	LinkedList<int> cola = new LinkedList<int>();
	
	//Marcar el parámetro; es decir, el vertice inicial como visitado y añadir a la cola
	visitados[s] = true;
	cola.AddLast(s);		

	while(cola.Any()) //mientras haya un elemento en la cola
	{
		
		// Retirar de la cola el vertice inicial e imprimirlo
		s = cola.First();
		Console.Write(s + " " );
		cola.RemoveFirst(); //removerlo ya que ha sido visitado
		
		// Conseguir todos los vertices adyacentes
		// del vertice retirado. Si un vertice adyacente
		// no ha sido visitado, marcarlo como visitado y 
		// ponerlo en la cola 
		LinkedList<int> list = _adj[s];

		foreach (var valor in list)			
		{
			if (!visitados[valor])  //if visited[val] == false
			{
				visitados[valor] = true; // marcar el vertice como visitado
				cola.AddLast(valor); //añadir ese vertice visitado en la cola
			}
		}
	}
}

static void Main(string[] args)
{
	Graph g = new Graph(4);
	
	g.AddEdge(0, 1); //en la lista de 0 agregas un 1 [1]
	g.AddEdge(0, 2); //en la lista de 0 agregas un 2 [1,2]
	g.AddEdge(1, 2);
	g.AddEdge(2, 0);
	g.AddEdge(2, 3);
	g.AddEdge(3, 3);
	Console.Write("Recorriendo con el algoritmo Breadth First " +
				"Search(empezando desde el vertice 2)\n");
	g.BFS(2);
}
}

// This code is contributed by anv89
