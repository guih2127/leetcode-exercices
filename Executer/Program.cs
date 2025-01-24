using BenchmarkDotNet.Running;
using Problems;

var removeElement = new RemoveElement();
removeElement.ExecuteBadSolution();
// BenchmarkRunner.Run<RemoveElement>();