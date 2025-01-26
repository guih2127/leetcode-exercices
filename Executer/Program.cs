using BenchmarkDotNet.Running;
using Problems;

var removeElement = new RemoveElement();
removeElement.ExecuteGoodSolution();
// BenchmarkRunner.Run<RemoveElement>();