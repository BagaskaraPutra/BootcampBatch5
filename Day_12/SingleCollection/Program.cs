// Source: 
// https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlist-1?view=net-7.0

using System;
using System.Text;
using System.Collections.Generic;

public class Program
{
	public static void Main()
	{
		
		string[] words =
			{ "the", "fox", "jumps", "over", "the", "dog" };
		
		// Create the link list.
		LinkedList<string> sentenceLL = new LinkedList<string>(words);
		Display(sentenceLL, "The linked list values:");
		Console.WriteLine("sentence.Contains(\"jumps\") = {0}",
			sentenceLL.Contains("jumps"));

		// Add the word 'today' to the beginning of the linked list.
		sentenceLL.AddFirst("today");
		Display(sentenceLL, "Test 1: Add 'today' to beginning of the list:");

		// Move the first node to be the last node.
		LinkedListNode<string> mark1 = sentenceLL.First;
		sentenceLL.RemoveFirst();
		sentenceLL.AddLast(mark1);
		Display(sentenceLL, "Test 2: Move first node to be last node:");

		// Change the last node to 'yesterday'.
		sentenceLL.RemoveLast();
		sentenceLL.AddLast("yesterday");
		Display(sentenceLL, "Test 3: Change the last node to 'yesterday':");

		// Move the last node to be the first node.
		mark1 = sentenceLL.Last;
		sentenceLL.RemoveLast();
		// If you don't run sentence.RemoveLast(), it will throw an exception:
		// Unhandled exception. System.InvalidOperationException: The LinkedList node already belongs to a LinkedList.
		sentenceLL.AddFirst(mark1);
		Display(sentenceLL, "Test 4: Move last node to be first node:");
		IndicateNode(mark1, "Test 4.1: Indicate mark1 LinkedListNode");

		// Indicate the last occurence of 'the'.
		sentenceLL.RemoveFirst();
		LinkedListNode<string> current = sentenceLL.FindLast("the");
		IndicateNode(current, "Test 5: Indicate last occurence of 'the':");

		// Add 'lazy' and 'old' after 'the' (the LinkedListNode named current).
		sentenceLL.AddAfter(current, "old");
		sentenceLL.AddAfter(current, "lazy");
		IndicateNode(current, "Test 6: Add 'lazy' and 'old' after 'the':");

		// Indicate 'fox' node.
		current = sentenceLL.Find("fox");
		IndicateNode(current, "Test 7: Indicate the 'fox' node:");

		// Add 'quick' and 'brown' before 'fox':
		sentenceLL.AddBefore(current, "quick");
		sentenceLL.AddBefore(current, "brown");
		IndicateNode(current, "Test 8: Add 'quick' and 'brown' before 'fox':");

		// Keep a reference to the current node, 'fox',
		// and to the previous node in the list. Indicate the 'dog' node.
		mark1 = current;
		LinkedListNode<string> mark2 = current.Previous;
		current = sentenceLL.Find("dog");
		IndicateNode(current, "Test 9: Indicate the 'dog' node:");

		// The AddBefore method throws an InvalidOperationException
		// if you try to add a node that already belongs to a list.
		Console.WriteLine("Test 10: Throw exception by adding node (fox) already in the list:");
		try
		{
			sentenceLL.AddBefore(current, mark1);
		}
		catch (InvalidOperationException ex)
		{
			Console.WriteLine("Exception message: {0}", ex.Message);
		}
		Console.WriteLine();

		// Remove the node referred to by mark1, and then add it
		// before the node referred to by current.
		// Indicate the node referred to by current.
		sentenceLL.Remove(mark1);
		sentenceLL.AddBefore(current, mark1);
		IndicateNode(current, "Test 11: Move a referenced node (fox) before the current node (dog):");

		// Remove the node referred to by current.
		sentenceLL.Remove(current);
		IndicateNode(current, "Test 12: Remove current node (dog) and attempt to indicate it:");

		// Add the node after the node referred to by mark2.
		sentenceLL.AddAfter(mark2, current);
		IndicateNode(current, "Test 13: Add node removed in test 11 after a referenced node (brown):");

		// The Remove method finds and removes the
		// first node that that has the specified value.
		sentenceLL.Remove("old");
		Display(sentenceLL, "Test 14: Remove node that has the value 'old':");

		// When the linked list is cast to ICollection(Of String),
		// the Add method adds a node to the end of the list.
		sentenceLL.RemoveLast();
		ICollection<string> icoll = sentenceLL;
		icoll.Add("rhinoceros");
		Display(sentenceLL, "Test 15: Remove last node, cast to ICollection, and add 'rhinoceros':");

		Console.WriteLine("Test 16: Copy the list to an array:");
		// Create an array with the same number of
		// elements as the linked list.
		string[] sArray = new string[sentenceLL.Count];
		sentenceLL.CopyTo(sArray, 0);

		foreach (string s in sArray)
		{
			Console.WriteLine(s);
		}

		// Release all the nodes.
		sentenceLL.Clear();

		Console.WriteLine();
		Console.WriteLine("Test 17: Clear linked list. Contains 'jumps' = {0}",
			sentenceLL.Contains("jumps"));

		Console.ReadLine();
	}

	private static void Display(LinkedList<string> words, string test)
	{
		Console.WriteLine(test);
		foreach (string word in words)
		{
			Console.Write(word + " ");
		}
		Console.WriteLine();
		Console.WriteLine();
	}

	private static void IndicateNode(LinkedListNode<string> node, string test)
	{
		Console.WriteLine(test);
		if (node.List == null)
		{
			Console.WriteLine("Node '{0}' is not in the list.\n",
				node.Value);
			return;
		}

		StringBuilder result = new StringBuilder("(" + node.Value + ")");
		LinkedListNode<string> nodeP = node.Previous;

		while (nodeP != null)
		{
			result.Insert(0, nodeP.Value + " ");
			nodeP = nodeP.Previous;
		}

		node = node.Next;
		while (node != null)
		{
			result.Append(" " + node.Value);
			node = node.Next;
		}

		Console.WriteLine(result);
		Console.WriteLine();
	}
}

//This code example produces the following output:
//
//The linked list values:
//the fox jumps over the dog

//Test 1: Add 'today' to beginning of the list:
//today the fox jumps over the dog

//Test 2: Move first node to be last node:
//the fox jumps over the dog today

//Test 3: Change the last node to 'yesterday':
//the fox jumps over the dog yesterday

//Test 4: Move last node to be first node:
//yesterday the fox jumps over the dog

//Test 5: Indicate last occurence of 'the':
//the fox jumps over (the) dog

//Test 6: Add 'lazy' and 'old' after 'the':
//the fox jumps over (the) lazy old dog

//Test 7: Indicate the 'fox' node:
//the (fox) jumps over the lazy old dog

//Test 8: Add 'quick' and 'brown' before 'fox':
//the quick brown (fox) jumps over the lazy old dog

//Test 9: Indicate the 'dog' node:
//the quick brown fox jumps over the lazy old (dog)

//Test 10: Throw exception by adding node (fox) already in the list:
//Exception message: The LinkedList node belongs a LinkedList.

//Test 11: Move a referenced node (fox) before the current node (dog):
//the quick brown jumps over the lazy old fox (dog)

//Test 12: Remove current node (dog) and attempt to indicate it:
//Node 'dog' is not in the list.

//Test 13: Add node removed in test 11 after a referenced node (brown):
//the quick brown (dog) jumps over the lazy old fox

//Test 14: Remove node that has the value 'old':
//the quick brown dog jumps over the lazy fox

//Test 15: Remove last node, cast to ICollection, and add 'rhinoceros':
//the quick brown dog jumps over the lazy rhinoceros

//Test 16: Copy the list to an array:
//the
//quick
//brown
//dog
//jumps
//over
//the
//lazy
//rhinoceros

//Test 17: Clear linked list. Contains 'jumps' = False
//