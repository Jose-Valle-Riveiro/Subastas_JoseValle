using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subastas_JoseValle
{
    public class maxHeap
    {
        // Function to heapify ith node in a Heap of size n following a Bottom-up approach
        public Costumer[] heapify(Costumer[] arr, int n, int i)
        {
            // Find parent
            int parent = (i - 1) / 2;
            Costumer costumer = arr[parent];
            Costumer costumerI = arr[i];
            
            if (costumer.budget > 0)
            {
                // For Max-Heap
                // If current node is greater than its parent
                // Swap both of them and call heapify again
                // for the parent
                if (costumerI.budget > costumer.budget)
                {

                    // swap arr[i] and arr[parent]
                    arr[i] = costumer;
                    arr[parent] = costumerI;

                    // Recursively heapify the parent node
                    heapify(arr, n, parent);
                }
                return arr;
            }

            return null;
        }

        public Costumer[] heapifyRoot(Costumer[] arr, int n, int i)
        {
            int largest = i; // Initialize largest as root
            int l = (2 * i) + 1; // left = 2*i + 1
            int r = (2 * i) + 2; // right = 2*i + 2

            Costumer costumer = arr[largest];
            Costumer costumerL = new Costumer();
            Costumer costumerR = new Costumer();

            // Bug prevention
            if (l < n)
                costumerL = arr[l];

            if (r < n)
                costumerR = arr[l];




            // If left child is larger than root
            if (l < n && costumerL.budget > costumer.budget)
                largest = l;

            // If right child is larger than largest so far
            if (r < n && costumerR.budget > costumer.budget)
                largest = r;

            //Update
             costumer = arr[largest];

            // If largest is not root
            if (largest != i)
            {
                Costumer swap = arr[i];
                arr[i] = costumer;
                arr[largest] = swap;

                // Recursively heapify the affected sub-tree
                heapifyRoot(arr, n, largest);
            }
            return arr;
        }

        public int deleteRoot(Costumer[] arr, int n)
        {
            // Get the last element
            Costumer lastElement = arr.Last<Costumer>();

            // Replace root with first element
            arr[0] = lastElement;

            // Decrease size of heap by 1
            n = n - 1;

            // heapify the root node
            heapifyRoot(arr, n, 0);

            // return new size of Heap
            return n;
        }

        /* A utility function to print array of size n */
        public void printArray(Costumer[] arr, int n)
        {
         
            Costumer costumer = new Costumer();
            for (int i = 0; i < n; ++i)
            {
                costumer = arr[i];
                Console.WriteLine(costumer.budget + " ");
                Console.WriteLine("");
            }       
        }

       
    }
}
