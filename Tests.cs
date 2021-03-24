using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using NUnit.Framework;

namespace Lab2
{
    public class SortsTests
    {
        private static readonly Random Random = new Random();
        private static readonly XmlDocument xDoc = new XmlDocument();
        private List<string> orderedWordsCollection;
        private List<string> shuffledWordsCollection;

        [Test]
        public void BubbleSortTest()
        {
            xDoc.Load("C:\\Labs\\Lab2\\Lab2\\Path.xml");
            var xmlRoot = xDoc.DocumentElement.SelectSingleNode("./BubbleSort");
            var reader = new StreamReader(xmlRoot.InnerText);
            orderedWordsCollection = new List<string>();
            while (!reader.EndOfStream)
                orderedWordsCollection.Add(reader.ReadLine());
            reader.Close();

            shuffledWordsCollection = ShuffleCollection(orderedWordsCollection);
            BubbleSort.MakeBubbleSort(shuffledWordsCollection);

            for (var i = 0; i < orderedWordsCollection.Count; ++i)
                Assert.AreEqual(orderedWordsCollection[i], shuffledWordsCollection[i]);
        }

        [Test]
        public void QuickSortTest()
        {
            xDoc.Load("C:\\Labs\\Lab2\\Lab2\\Path.xml");
            var xmlRoot = xDoc.DocumentElement.SelectSingleNode("./QuickSort");
            var reader = new StreamReader(xmlRoot.InnerText);
            orderedWordsCollection = new List<string>();
            while (!reader.EndOfStream)
                orderedWordsCollection.Add(reader.ReadLine());
            reader.Close();

            shuffledWordsCollection = ShuffleCollection(orderedWordsCollection);
            QuickSort.MakeQuickSort(shuffledWordsCollection);

            for (var i = 0; i < orderedWordsCollection.Count; ++i)
                Assert.AreEqual(orderedWordsCollection[i], shuffledWordsCollection[i]);
        }

        [Test]
        public void TreeSortTest()
        {
            xDoc.Load("C:\\Labs\\Lab2\\Lab2\\Path.xml");
            var xmlRoot = xDoc.DocumentElement.SelectSingleNode("./TreeSort");
            var reader = new StreamReader(xmlRoot.InnerText);
            orderedWordsCollection = new List<string>();
            while (!reader.EndOfStream)
                orderedWordsCollection.Add(reader.ReadLine());
            reader.Close();

            shuffledWordsCollection = ShuffleCollection(orderedWordsCollection);
            shuffledWordsCollection = TreeSort.MakeTreeSort(shuffledWordsCollection);

            for (var i = 0; i < orderedWordsCollection.Count; ++i)
                Assert.AreEqual(orderedWordsCollection[i], shuffledWordsCollection[i]);
        }

        [Test]
        public void InsertSortTest()
        {
            xDoc.Load("C:\\Labs\\Lab2\\Lab2\\Path.xml");
            var xmlRoot = xDoc.DocumentElement.SelectSingleNode("./InsertSort");
            var reader = new StreamReader(xmlRoot.InnerText);
            orderedWordsCollection = new List<string>();
            while (!reader.EndOfStream)
                orderedWordsCollection.Add(reader.ReadLine());
            reader.Close();

            shuffledWordsCollection = ShuffleCollection(orderedWordsCollection);
            InsertSort.MakeInsertSort(shuffledWordsCollection);

            for (var i = 0; i < orderedWordsCollection.Count; ++i)
                Assert.AreEqual(orderedWordsCollection[i], shuffledWordsCollection[i]);
        }

        [Test]
        public void MergeSortTest()
        {
            xDoc.Load("C:\\Labs\\Lab2\\Lab2\\Path.xml");
            var xmlRoot = xDoc.DocumentElement.SelectSingleNode("./MergeSort");
            var reader = new StreamReader(xmlRoot.InnerText);
            orderedWordsCollection = new List<string>();
            while (!reader.EndOfStream)
                orderedWordsCollection.Add(reader.ReadLine());
            reader.Close();

            shuffledWordsCollection = ShuffleCollection(orderedWordsCollection);
            MergeSort.MakeMergeSort(shuffledWordsCollection);

            for (var i = 0; i < orderedWordsCollection.Count; ++i)
                Assert.AreEqual(orderedWordsCollection[i], shuffledWordsCollection[i]);
        }

        [Test]
        public void HeapSortTest()
        {
            xDoc.Load("C:\\Labs\\Lab2\\Lab2\\Path.xml");
            var xmlRoot = xDoc.DocumentElement.SelectSingleNode("./HeapSort");
            var reader = new StreamReader(xmlRoot.InnerText);
            orderedWordsCollection = new List<string>();
            while (!reader.EndOfStream)
                orderedWordsCollection.Add(reader.ReadLine());
            reader.Close();

            shuffledWordsCollection = ShuffleCollection(orderedWordsCollection);
            HeapSort.MakeHeapSort(shuffledWordsCollection);

            for (var i = 0; i < orderedWordsCollection.Count; ++i)
                Assert.AreEqual(orderedWordsCollection[i], shuffledWordsCollection[i]);
        }

        [Test]
        public void RadixSortTest()
        {
            xDoc.Load("C:\\Labs\\Lab2\\Lab2\\Path.xml");
            var xmlRoot = xDoc.DocumentElement.SelectSingleNode("./RadixSort");
            var reader = new StreamReader(xmlRoot.InnerText);
            orderedWordsCollection = new List<string>();
            while (!reader.EndOfStream)
                orderedWordsCollection.Add(reader.ReadLine());
            reader.Close();

            shuffledWordsCollection = ShuffleCollection(orderedWordsCollection);
            RadixSort.MakeRadixSort(shuffledWordsCollection);

            for (var i = 0; i < orderedWordsCollection.Count; ++i)
                Assert.AreEqual(orderedWordsCollection[i], shuffledWordsCollection[i]);
        }

        [Test]
        public void RedBlackTreeSortTest()
        {
            xDoc.Load("C:\\Labs\\Lab2\\Lab2\\Path.xml");
            var xmlRoot = xDoc.DocumentElement.SelectSingleNode("./RedBlackTreeSort");
            var reader = new StreamReader(xmlRoot.InnerText);
            orderedWordsCollection = new List<string>();
            while (!reader.EndOfStream)
                orderedWordsCollection.Add(reader.ReadLine());
            reader.Close();

            shuffledWordsCollection = ShuffleCollection(orderedWordsCollection);
            shuffledWordsCollection = RBSort.MakeRBSort(shuffledWordsCollection);

            for (var i = 0; i < orderedWordsCollection.Count; ++i)
                Assert.AreEqual(orderedWordsCollection[i], shuffledWordsCollection[i]);
        }

        private List<string> ShuffleCollection(List<string> collection)
        {
            var result = collection.ToList();

            for (var i = 0; i < result.Count; ++i)
            {
                var next = Random.Next(0, result.Count);
                var temp = result[i];
                result[i] = result[next];
                result[next] = temp;
            }

            return result;
        }
    }
}