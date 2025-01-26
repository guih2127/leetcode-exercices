using BenchmarkDotNet.Running;
using Problems;

var removeElement = new RemoveDuplicatesFromSortedArray();
removeElement.ExecuteGoodSolution();
// BenchmarkRunner.Run<RemoveElement>();