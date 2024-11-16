Imports System.Resources

Module SharedResources
    Public ReadOnly ResourceManager As ResourceManager = New ResourceManager("GPXTrailAnalyzer.Resource1", GetType(SharedResources).Assembly)
End Module

