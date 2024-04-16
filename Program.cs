using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Subastas_JoseValle;
using System.IO;
using System.Collections.Generic;
using System.Numerics;

static List<Property> readJson()
{
    //El proposito de esta funcion es retornar el json ya deserializado.
    //1) OBTENER ARCHIVO
    string fileName =
    @"C:\Users\jose_\OneDrive\Documentos\---TAREAS--- UNI\TERCER SEMESTRE\ESTRUCTURA DE DATOS I\lab3 (1)\lab3\input_auctions_example_lab_3(1).jsonl";

    //2) CREAR LA LISTA
    List<Property> properties = new List<Property>(); //Agregar cada var a esta lista. Necesito un ciclo.
    var auctionedProperty = new Property();

    //*prevencion de errores
    if (File.Exists(fileName))
    {
        //3) LEER EL JSON
        using (StreamReader json = File.OpenText(fileName)) //json leera fileName 
        {
            string line;
            while ((line = json.ReadLine()) != null) //este ciclo leera cada linea del json
            {
                //Se leera una sola linea y se guardará como un propiedad en la lista "properties"
                auctionedProperty = JsonConvert.DeserializeObject<Property>(line);
                properties.Add(auctionedProperty);
            }
        }
                       
        return properties;
    }
    return null;
}

static void generateMaxHeap(Property property)
{
    Costumer[] costumers = null;
    maxHeap Heap = new maxHeap();
    int n;
        
     n = property.customers.Length;
     costumers = Heap.heapifyRoot(property.customers, n, 0);

     for (int i = 1; i < n; i++)
     {
        costumers = Heap.heapify(property.customers, n, i);
     }
    
    property.customers = costumers;
    
}

static void pop(Property property)
{
    maxHeap heap = new maxHeap();
    List<Costumer> ereasedCostumers = new List<Costumer>();
    int n = property.customers.Length;

    Costumer rejected = heap.deleteRoot(property.customers, n);
    ereasedCostumers.Add(rejected);
    n--;

    for (int i = 0; i < property.rejection-1; i++)
    {
       
        rejected = heap.deleteRoot(property.customers, n);
        ereasedCostumers.Add(rejected);
        n--;
    }
}



/*
 *  -OBJETIVOS- 
 * 1) leer el json2 (auction) -listo-
 * 2) Crear un maxHeap -listo-
 * 3) Agregar los clientes del json2 al maxHeap -listo-
 * 4) Popear en base a rejection
 * 5) Indicar el ganador
 * 6) Leer json1 (costumers)
 * 7) Buscar el dpi del ganador en json1 
 * 8) Generar el hash key
 * 9) Imprimir
 * 
 */

    //Reading the Json 2
    var properties = readJson();

    //Creation of the maxHeaps
    foreach (var property in properties)
    {
        generateMaxHeap(property);
    }

    //Extraction proccess.
    foreach (var property in properties) //TENEMOS UN PROBLEMA AQUI
    {
        pop(property);
    }
  


    Console.WriteLine("a");
    Console.ReadKey(); 




