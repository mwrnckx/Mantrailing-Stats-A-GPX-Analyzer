Imports System.Xml

Public Class GpxReaderII
    Private xmlDoc As XmlDocument
    Private namespaceManager As XmlNamespaceManager

    ' Veřejné vlastnosti pro přístup k uzlům
    Public Property Node As XmlNode
    Public Property Nodes As XmlNodeList

    ' Konstruktor pro načtení XML dokumentu a inicializaci namespace manageru
    Public Sub New(filePath As String)
        xmlDoc = New XmlDocument()
        xmlDoc.Load(filePath)

        ' Zjištění namespace, pokud je definován
        Dim rootNode As XmlNode = xmlDoc.DocumentElement
        Dim namespaceUri As String = rootNode.NamespaceURI

        ' Inicializace XmlNamespaceManager s dynamicky zjištěným namespace
        namespaceManager = New XmlNamespaceManager(xmlDoc.NameTable)
        If Not String.IsNullOrEmpty(namespaceUri) Then
            namespaceManager.AddNamespace("gpx", namespaceUri) ' Použijeme lokální prefix "gpx"
        End If
    End Sub

    ' Metoda pro načítání všech uzlů
    Public Sub LoadNodes(Optional xpath As String = "//*")
        If String.IsNullOrEmpty(namespaceManager.LookupNamespace("gpx")) Then
            Nodes = xmlDoc.SelectNodes(xpath)
        Else
            Nodes = xmlDoc.SelectNodes(xpath, namespaceManager)
        End If
    End Sub

    ' Metoda pro načítání konkrétního uzlu podle XPath
    Public Sub LoadNode(nodePath As String)
        If String.IsNullOrEmpty(namespaceManager.LookupNamespace("gpx")) Then
            Node = xmlDoc.SelectSingleNode(nodePath)
        Else
            Node = xmlDoc.SelectSingleNode(nodePath, namespaceManager)
        End If
    End Sub

    ' Metoda pro načtení dětí specifického uzlu
    Public Function LoadChildNodes(parentNodePath As String, childNodeName As String) As XmlNodeList
        ' Načteme rodičovský uzel
        Dim parentNode As XmlNode
        If String.IsNullOrEmpty(namespaceManager.LookupNamespace("gpx")) Then
            parentNode = xmlDoc.SelectSingleNode(parentNodePath)
        Else
            parentNode = xmlDoc.SelectSingleNode(parentNodePath, namespaceManager)
        End If

        ' Zajistíme, aby rodičovský uzel existoval
        If parentNode Is Nothing Then
            Return Nothing
        End If

        ' Načteme děti podle jména nebo cesty
        Dim childNodes As XmlNodeList
        If String.IsNullOrEmpty(namespaceManager.LookupNamespace("gpx")) Then
            childNodes = parentNode.SelectNodes(childNodeName)
        Else
            childNodes = parentNode.SelectNodes("gpx:" & childNodeName, namespaceManager)
        End If

        Return childNodes
    End Function
End Class

