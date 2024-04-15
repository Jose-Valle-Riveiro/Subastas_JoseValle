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

static PriorityQueue<Costumer, long> generateMaxHeap(Property property)
{
    //Una priorityQueue funciona igual a un maxHeap
    var Heap = new PriorityQueue<Costumer, long>();

    //Se agrega a la cola cada costumer de la propiedad ingresada
    foreach (var item in property.customers)
    {
        long newDPI = Convert.ToInt64(item.dpi);

        Heap.Enqueue(item, newDPI);

    }
    return Heap;
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

    foreach (var property in properties)
    {
        PriorityQueue<Costumer, long> maxHeap = generateMaxHeap(property);  

    }

    Console.WriteLine("a");
    Console.ReadKey();

