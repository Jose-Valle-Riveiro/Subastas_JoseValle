using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Subastas_JoseValle;
using System.IO;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;

static List<Property> readJson()
{
    //El proposito de esta funcion es retornar el json ya deserializado.
    //1) OBTENER ARCHIVO
    string fileName =
    @"C:\Users\jose_\OneDrive\Documentos\---TAREAS--- UNI\TERCER SEMESTRE\ESTRUCTURA DE DATOS I\lab3 (1)\lab3\input_auctions_challenge_lab_3.jsonl";

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

static List<completeCustomer> readJson2()
{
    //El proposito de esta funcion es retornar el json ya deserializado.
    //1) OBTENER ARCHIVO
    string fileName =
    @"C:\Users\jose_\OneDrive\Documentos\---TAREAS--- UNI\TERCER SEMESTRE\ESTRUCTURA DE DATOS I\lab3 (1)\lab3\input_customer_challenge_lab_3.jsonl";

    //2) CREAR LA LISTA
    List<completeCustomer> allCustomers = new List<completeCustomer>(); //Agregar cada var a esta lista. Necesito un ciclo.
    var customer = new completeCustomer();

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
                customer = JsonConvert.DeserializeObject<completeCustomer>(line);
                allCustomers.Add(customer);
            }
        }

        return allCustomers;
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

static Costumer declareWinner(Property property)
{
    return property.customers[0];
}

static completeCustomer finalWinner(List <completeCustomer> customers, Costumer winner)
{
    //Recorrer la lista de clientes en busqueda de un dpi que coincida con winner
    foreach (var customer in customers)
    {
    
        if (winner.dpi == customer.dpi)
        {
            return customer;
        }
    }

    return null;

}


static string hashingKeys(completeCustomer winner)
{
    string hashKey = Hashing.generateSHA256(winner.dpi);
    return hashKey;
}

    //Reading the Json 2
    var properties = readJson();

    //Creation of the maxHeaps
    foreach (var property in properties)
    {
        generateMaxHeap(property);
    }

    //Extraction proccess.
    foreach (var property in properties) //TENEMOS UN PROBLEMA AQUI --- YA NO :D
    {
        pop(property);
    }
  
    //Winners
    List<Costumer> winners = new List<Costumer>();
    foreach (var property in properties)
    {
        Costumer winner = declareWinner(property);
        winners.Add(winner);
    }

    //Read Json1
    var allCustomers = readJson2();
    List<completeCustomer> completeWinners = new List<completeCustomer>();

    //Lookout for winners in allCustomers
    foreach(var customer in winners)
    {
        completeCustomer winner = finalWinner(allCustomers, customer);
        completeWinners.Add(winner);
    }

    //Generate the hashKeys for the winners
    List<string> allHashKeys = new List<string>();
    foreach (var winner in completeWinners)
    {
        string hashKey = hashingKeys(winner);
        allHashKeys.Add(hashKey);
    }

    //Fucking finally print this shit
    int size = completeWinners.Count();
    for (int i = 0; i < size; i++)
    {
        Console.WriteLine("{"+$"\"dpi\":{winners[i].dpi}"+"," + $"\"budget\":{ winners[i].budget}" + ","
        + $"\"firstname\":\"{completeWinners[i].firstname}\"" + "," + $"\"lastname\":\"{completeWinners[i].lastname}\"" + ","
        + $"\"birthDate\":\"{completeWinners[i].birthDate}\"" + "," + $"\"job\":\"{completeWinners[i].job}\"" + ","
        + $"\"placejob\":\"{completeWinners[i].placejob}\"" + "," + $"\"salary\":{completeWinners[i].salary}" + ","
        + $"\"property\":\"{properties[i].property}\"" + "," + $"\"signature\":\"{allHashKeys[i]}\""+"}"



            );
    }

    
    Console.ReadKey(); 




