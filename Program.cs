using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Subastas_JoseValle;
using System.IO;
using System.Collections.Generic;

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

Costumer[] generateMaxHeap(Property property)
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
        
    return costumers;
}



/*
 *  -OBJETIVOS- 
 * 1) leer el json2 (auction) -listo-
 * 2) Crear un maxHeap
 * 3) Agregar los clientes del json2 al maxHeap
 * 4) Popear en base a rejection
 * 5) Indicar el ganador
 * 6) Leer json1 (costumers)
 * 7) Buscar el dpi del ganador en json1 
 * 8) Generar el hash key
 * 9) Imprimir
 * 
 */
    var properties = readJson();
    List<Costumer[]> heaps = new List<Costumer[]>();

    foreach (var property in properties)
    {
        Costumer[] heap = null;
        heap = generateMaxHeap(property);
        heaps.Add(heap);
    }

    Console.WriteLine("a");
    Console.ReadKey(); 

