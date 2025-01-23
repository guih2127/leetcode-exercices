using BenchmarkDotNet.Running;
using Problems;

var mergeSortedArray = new MergeSortedArray();
mergeSortedArray.ExecuteGoodSolution();
BenchmarkRunner.Run<MergeSortedArray>();